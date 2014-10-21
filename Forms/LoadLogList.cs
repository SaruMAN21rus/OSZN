using CsvHelper;
using OSZN.DAO;
using OSZN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSZN.Forms
{
    public partial class LoadLogList : Form
    {
        public LoadLogList()
        {
            InitializeComponent();
            this.LoadLogListGrid.AutoGenerateColumns = false;
            LoadData();
        }

        private void LoadData()
        {
            LoadLogDAO llDAO = new LoadLogDAO();
            LoadLogListGrid.DataSource = llDAO.getLogs();
        }

        private void LoadButon_Click(object sender, EventArgs e)
        {
            CommunicationFoldersDAO cfDAO = new CommunicationFoldersDAO();
            CommunicationFolders folders = cfDAO.getFolders();
            string loadFolder = folders.loadFolder;
            if (String.IsNullOrEmpty(loadFolder))
            {
                MessageBox.Show(
                    "Необходимо указать папку обмена для загрузки в настройках обмена.", 
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else if (!Directory.Exists(loadFolder))
            {
                MessageBox.Show(
                    "Папки обмена для загрузки, указанной в настройках обмена, не существует. Укажите корректный путь к папке обмена для загрузки.",
                    "Ошибка",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            else
            {
                WaitWindow wait = new WaitWindow(LoadFiles, loadFolder);
                this.Enabled = false;
                wait.SetMessage("Загрузка данных...");
                if (wait.ShowDialog() == DialogResult.OK)
                {
                    this.Enabled = true;
                    LoadData();
                    RunWorkerCompletedEventArgs workerResult = wait.ReturnData();
                    if (workerResult.Error != null)
                    {
                        MessageBox.Show(workerResult.Error.Message);
                    }
                    else
                    {
                        MessageBox.Show(workerResult.Result.ToString());
                    }
                }
            }
        }

        private string LoadFiles(object dir)
        {
            DirectoryInfo di = new DirectoryInfo(dir.ToString());
            DirectoryInfo[] subDir = null;
            try
            {
                subDir = di.GetDirectories();
            }
            catch
            {
                return "Папка обмена для загрузки недоступна.";
            }
            for (int i = 0; i < subDir.Length; ++i)
                this.LoadFiles(subDir[i].FullName);
            FileInfo[] fi = di.GetFiles();
            LoadLogDAO logDAO = new LoadLogDAO();
            logDAO.beginTransaction();
            string datePattern = "yyyyMMdd";
            for (int i = 0; i < fi.Length; ++i)
            {
                if (Path.GetExtension(fi[i].Name).ToLower() == ".csv")
                {
                    LoadLog ll = new LoadLog();
                    ll.loadDate = DateTime.Now;
                    ll.loadFolder = dir.ToString();
                    ll.fileName = fi[i].Name;
                    StreamReader sr = new StreamReader(fi[i].FullName, Encoding.GetEncoding("windows-1251"));
                    try
                    {
                        var csv = new CsvReader(sr);
                        csv.Configuration.Delimiter = ";";
                        csv.Configuration.Encoding = Encoding.GetEncoding("windows-1251");
                        csv.Configuration.HasHeaderRecord = false;
                        bool hasA = false;
                        int j = 0;
                        while (csv.Read())
                        {
                            j++;
                            if (csv.GetField<string>(0) == "А")
                            {
                                if (!hasA)
                                {
                                    if (!String.IsNullOrEmpty(csv.GetField<string>(3)))
                                    {
                                        DateTime requestPeriodStartDate;
                                        if (DateTime.TryParseExact(csv.GetField<string>(3), datePattern, null,
                                            DateTimeStyles.None, out requestPeriodStartDate))
                                        {
                                            ll.requestPeriodStartDate = requestPeriodStartDate;
                                        }
                                        else
                                        {
                                            throw new Exception("Неверный формат даты начала периода запроса. Cтрока " + j + ", " + "параметр 4.");
                                        }
                                    }
                                    else
                                        ll.requestPeriodStartDate = null;
                                    if (!String.IsNullOrEmpty(csv.GetField<string>(4)))
                                    {
                                        DateTime requestPeriodEndDate;
                                        if (DateTime.TryParseExact(csv.GetField<string>(4), datePattern, null,
                                            DateTimeStyles.None, out requestPeriodEndDate))
                                        {
                                            ll.requestPeriodEndDate = requestPeriodEndDate;
                                        }
                                        else
                                        {
                                            throw new Exception("Неверный формат даты окончания периода запроса. Cтрока " + j + ", " + "параметр 5.");
                                        }
                                    }
                                    else
                                        ll.requestPeriodEndDate = null;
                                    hasA = true;
                                }
                                else
                                    throw new Exception("Найдено более одной строки с типом \"А\", идентифицирующей источника сведений.");
                            }
                            if (csv.GetField<string>(0) == "О")
                            { 
                                
                            }
                        }
                        ll.status = "Загружен";
                    }
                    catch (Exception e)
                    {
                        ll.errorText = e.Message;
                        ll.errorFullTrace = e.StackTrace;
                        ll.status = "Не загружен";
                    }
                    finally
                    {
                        sr.Close();
                        logDAO.insertLog(ll);
                    }
                }
            }
            logDAO.commitTransaction();
            return "Данные успешно загружены.";
        }
    }
}
