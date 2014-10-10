using OSZN.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSZN
{
    public partial class KladrForm : Form
    {

        private string SelectedAddressGuid;

        public KladrForm()
        {
            InitializeComponent();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            DataTable dt = aoDAO.getTreeRootNode();
            foreach (DataRow row in dt.Rows)
            {
                TreeNode rootNode = new TreeNode();
                rootNode.Text = row[1] + " " + row[2];
                rootNode.Tag = row[0];
                TreeNode dummyNode = new TreeNode("Загрузка. Пожалуйста подождите...");
                dummyNode.Tag = "dummy";
                rootNode.Nodes.Add(dummyNode);
                kladrTree.Nodes.Add(rootNode);
            }
        }

        private IEnumerable<TreeNodeData> GetChildData(string parentGuid)
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            DataTable dt = aoDAO.getTreeChildNode(parentGuid);
            List<TreeNodeData> data = new List<TreeNodeData>();
            foreach (DataRow row in dt.Rows)
            {
                TreeNodeData d = new TreeNodeData();
                d.Guid = row[0].ToString();
                d.Name = row[1].ToString();
                d.Type = row[2].ToString();
                d.ChildCount = Convert.ToInt32(row[3]);
                data.Add(d);
            }
            return data;
        }

        private void PopulateChildren(TreeNode parent, IEnumerable<TreeNodeData> childItems)
        {
            TreeNode child;
            TreeNode dummy;
            TreeNode originalDummyItem = parent.Nodes[0];
            foreach (var item in childItems)
            {
                child = new TreeNode();
                child.Text = item.Name + " " + item.Type;
                child.Tag = item.Guid;
                if (item.ChildCount > 0)
                {
                    dummy = new TreeNode("Загрузка. Пожалуйста подождите...");
                    dummy.Tag = "dummy";
                    child.Nodes.Add(dummy);
                }
                parent.Nodes.Add(child);
            }
            originalDummyItem.Remove();
        }

        private void kladrTree_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Nodes.Count == 1 && e.Node.Nodes[0].Tag == "dummy")
            {
                ThreadPool.QueueUserWorkItem(state =>
                {
                    IEnumerable<TreeNodeData> childItems = GetChildData(e.Node.Tag.ToString());
                    kladrTree.BeginInvoke((Action)delegate
                    {
                        PopulateChildren(e.Node, childItems);
                    });
                });
            }
        }

        private void kladrTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
            SelectedAddressGuid = e.Node.Tag.ToString();
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            DataTable dt = aoDAO.getTableData(SelectedAddressGuid, null);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            DataTable dt = aoDAO.getTableData(SelectedAddressGuid, textBox1.Text);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                ViewKladrForm viewKladr = new ViewKladrForm(dataGridView1.Rows[e.RowIndex].Cells["Guid"].Value.ToString());
                if (viewKladr.ShowDialog(this) == DialogResult.OK)
                {
                    VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                    DataTable dt = aoDAO.getTableData(SelectedAddressGuid, textBox1.Text);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditKladrForm addKladr = new AddEditKladrForm(SelectedAddressGuid, false);
            if (addKladr.ShowDialog(this) == DialogResult.OK)
            {
                VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                DataTable dt = aoDAO.getTableData(SelectedAddressGuid, textBox1.Text);
                dataGridView1.DataSource = dt;
            }
            
            //Оптимизировать
           /* string sql = "WITH RECURSIVE "
                    + "under_alice(guid, name, type, code, level) AS ( "
                    + "select ao.AOGUID, ao.FORMALNAME, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END as TYPE, ao.CODE, 0 "
                    + "from VOC_ADDRESS_OBJECT ao "
                    + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                    + "where ao.CURRSTATUS = 0 and ao.PARENTGUID = '" + SelectedAddressGuid + "'"
                    + "UNION ALL "
                    + "SELECT ao.AOGUID, ao.FORMALNAME, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END as TYPE, ao.CODE, under_alice.level+1 "
                    + "from VOC_ADDRESS_OBJECT ao "
                    + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                    + "inner join under_alice ON ao.PARENTGUID=under_alice.guid and ao.CURRSTATUS = 0 "
                    + "ORDER BY ao.CODE ASC "
                    + ") "
                    + "SELECT substr('            ',1,level*3) || name as FORMALNAME, guid as AOGUID, type, code FROM under_alice;";
            SQLiteDataAdapter da = new SQLiteDataAdapter(sql, dbConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = UpdateAddressObject.update();
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show(e.Result.ToString());
            }
        }
    }

    public class TreeNodeData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Guid { get; set; }
        public int ChildCount { get; set; }
    }
}
