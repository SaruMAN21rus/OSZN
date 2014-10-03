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
                + "from ADDRESS_OBJECT ao "
                + "left join ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
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
                "select ao.AOGUID, ao.FORMALNAME, CASE WHEN at.SCNAME is null THEN ao.SHORTNAME ELSE at.SCNAME END, (select count(*) from ADDRESS_OBJECT ao2 where ao2.CURRSTATUS = 0 AND ao2.PARENTGUID = ao.AOGUID) as CHILDCOUNT "
                + "from ADDRESS_OBJECT ao "
                + "left join ADDRESS_TYPE at on ao.AOLEVEL = at.LEVEL and ao.SHORTNAME = at.SOCRNAME "
                + "where ao.CURRSTATUS = 0 and ao.PARENTGUID = '" + parentGuid + "'"
                + "order by PLAINCODE ASC";
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
    }

    public class TreeNodeData
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Guid { get; set; }
        public int ChildCount { get; set; }
    }
}
