using OSZN.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSZN.Forms
{
    public partial class RelationshipDegreeList : Form
    {
        public RelationshipDegreeList()
        {
            InitializeComponent();
            RelationshipDegreeListGrid.AutoGenerateColumns = false;
            SearchComboBox.SelectedItem = "Активные";
        }

        private void LoadData()
        {
            RelationshipDegreeDAO rdDAO = new RelationshipDegreeDAO();
            RelationshipDegreeListGrid.DataSource = rdDAO.getRelationshipDegrees(SearchComboBox.SelectedItem.ToString());
        }

        private void AddButon_Click(object sender, EventArgs e)
        {
            AddEditViewRelationshipDegreeForm f = new AddEditViewRelationshipDegreeForm(null);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void RelationshipDegreeListGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddEditViewRelationshipDegreeForm f = new AddEditViewRelationshipDegreeForm(Convert.ToInt32(RelationshipDegreeListGrid.Rows[e.RowIndex].Cells["id"].Value));
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
