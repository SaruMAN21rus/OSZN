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
        private SQLiteConnection dbConnection;

        private string SelectedAddressGuid;

        public KladrForm(SQLiteConnection dbConnection)
        {
            this.dbConnection = dbConnection;
            InitializeComponent();
            InitializeTreeView();
        }

        private void InitializeTreeView()
        {
            string getParentNode =
                "select ao.AOGUID, ao.FORMALNAME, at.SCNAME "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.CURRSTATUS = 0 and ao.PARENTGUID is null";

            SQLiteCommand command = new SQLiteCommand(getParentNode, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                TreeNode rootNode = new TreeNode();
                rootNode.Text = reader.GetString(1) + " " + reader.GetString(2);
                rootNode.Tag = reader.GetString(0);
                TreeNode dummyNode = new TreeNode("Загрузка. Пожалуйста подождите...");
                dummyNode.Tag = "dummy";
                rootNode.Nodes.Add(dummyNode);
                kladrTree.Nodes.Add(rootNode);
            }
        }

        private IEnumerable<TreeNodeData> GetChildData(string parentGuid)
        {
            string getChildNode =
                "select ao.AOGUID, ao.FORMALNAME, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END, (select count(*) from VOC_ADDRESS_OBJECT ao2 where ao2.CURRSTATUS = 0 AND ao2.PARENTGUID = ao.AOGUID) as CHILDCOUNT "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.CURRSTATUS = 0 and ao.PARENTGUID = '" + parentGuid + "'"
                + "order by CODE ASC";
            SQLiteCommand command = new SQLiteCommand(getChildNode, dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            List<TreeNodeData> data = new List<TreeNodeData>();
            while (reader.Read())
            {
                TreeNodeData d = new TreeNodeData();
                d.Guid = reader.GetString(0);
                d.Name = reader.GetString(1);
                d.Type = reader.GetString(2);
                d.ChildCount = reader.GetInt32(3);
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
            string getChildNode =
                "select ao.AOGUID, ao.FORMALNAME, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END as TYPE, ao.CODE "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.CURRSTATUS = 0 and ao.PARENTGUID = '" + SelectedAddressGuid + "'"
                + "order by PLAINCODE ASC";
            SQLiteDataAdapter da = new SQLiteDataAdapter(getChildNode, dbConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string searchText = textBox1.Text;
            string getChildNode =
                "select ao.AOGUID, ao.FORMALNAME, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END as TYPE, ao.CODE "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.CURRSTATUS = 0 and ao.PARENTGUID = '" + SelectedAddressGuid + "' "
                + "and (lower(ao.FORMALNAME) LIKE ('%" + searchText.ToLower() + "%') or lower(at.SCNAME) LIKE ('%" + searchText.ToLower() + "%') or ao.CODE LIKE ('%" + searchText + "%'))"
                + "order by PLAINCODE ASC";
            SQLiteDataAdapter da = new SQLiteDataAdapter(getChildNode, dbConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                this.SelectedAddressGuid = dataGridView1.Rows[e.RowIndex].Cells["Guid"].Value.ToString();
                ViewKladrForm viewKladr = new ViewKladrForm(this.dbConnection, SelectedAddressGuid);
                viewKladr.Show();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //Оптимизировать
            string sql = "WITH RECURSIVE "
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
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
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
