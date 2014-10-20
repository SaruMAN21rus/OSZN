using CsvHelper;
using OSZN.DAO;
using OSZN.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
            for (int i = 0; i < fi.Length; ++i)
            {
                if (Path.GetExtension(fi[i].Name).ToLower() == ".csv")
                {
                    StreamReader sr = new StreamReader(fi[i].FullName, Encoding.GetEncoding("windows-1251"));
                    try
                    {
                        var csv = new CsvReader(sr);
                        csv.Configuration.Delimiter = ";";
                        csv.Configuration.Encoding = Encoding.GetEncoding("windows-1251");
                        csv.Configuration.HasHeaderRecord = false;
                        while (csv.Read())
                        {
                            var id = csv.GetField<string>(0);
                            MessageBox.Show(id);
                        }
                    }
                    catch (Exception e)
                    {
                        //ViewBag.Error = e.ToString();
                    }
                    finally
                    {
                        sr.Close();
                    }
                }
            }
            return "Данные успешно загружены.";
        }
    }
}
