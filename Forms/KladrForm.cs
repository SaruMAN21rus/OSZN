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
            this.dataGridView1.AutoGenerateColumns = false;
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
            Dictionary<string, object> selectedAddress = aoDAO.getAddressByAOGUID(SelectedAddressGuid);
            if (Convert.ToInt32(selectedAddress["levelId"]) == 7)
            {
                AddButon.Hide();
            }
            else
            {
                AddButon.Show();
            }
            DataTable dt = aoDAO.getTableData(SelectedAddressGuid, textBox1.Text, checkBox2.Checked);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            DataTable dt = aoDAO.getTableData(SelectedAddressGuid, textBox1.Text, checkBox2.Checked);
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                AddEditViewKladrForm viewKladr = new AddEditViewKladrForm(dataGridView1.Rows[e.RowIndex].Cells["Guid"].Value.ToString(), "View");
                if (viewKladr.ShowDialog(this) == DialogResult.OK)
                {
                    VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                    DataTable dt = aoDAO.getTableData(SelectedAddressGuid, textBox1.Text, checkBox2.Checked);
                    dataGridView1.DataSource = dt;

                    UpdateTree();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddEditViewKladrForm addKladr = new AddEditViewKladrForm(SelectedAddressGuid, "Add");
            if (addKladr.ShowDialog(this) == DialogResult.OK)
            {
                VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                DataTable dt = aoDAO.getTableData(SelectedAddressGuid, textBox1.Text, checkBox2.Checked);
                dataGridView1.DataSource = dt;

                UpdateTree();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy != true)
            {
                this.Enabled = false;
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
            this.Enabled = true;
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
            }
            else
            {
                MessageBox.Show(e.Result.ToString());
            }
        }

        public TreeNode FindNodeByTag(string itemId, TreeNode rootNode)
        {
            if (rootNode.Tag.Equals(itemId)) return rootNode;
            else
            {
                foreach (TreeNode node in rootNode.Nodes)
                {
                    if (node.Tag.Equals(itemId)) return node;
                    TreeNode next = FindNodeByTag(itemId, node);
                    if (next != null) return next;
                }
                return null;
            }
        }

        public void UpdateTree()
        {
            TreeNode parentNode = null;
            foreach (TreeNode node in kladrTree.Nodes)
            {
                parentNode = FindNodeByTag(SelectedAddressGuid, node);
                if (parentNode != null) break;
            }
            parentNode.Nodes.Clear();
            TreeNode dummyNode = new TreeNode("Загрузка. Пожалуйста подождите...");
            dummyNode.Tag = "dummy";
            parentNode.Nodes.Add(dummyNode);
            IEnumerable<TreeNodeData> childItems = GetChildData(SelectedAddressGuid);
            kladrTree.BeginInvoke((Action)delegate
            {
                PopulateChildren(parentNode, childItems);
            });
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            DataTable dt = aoDAO.getTableData(SelectedAddressGuid, textBox1.Text, checkBox2.Checked);
            dataGridView1.DataSource = dt;
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
