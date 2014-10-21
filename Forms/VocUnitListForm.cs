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
    public partial class VocUnitListForm : Form
    {
        public VocUnitListForm()
        {
            InitializeComponent();
            VocUnitListGrid.AutoGenerateColumns = false;
            SearchComboBox.SelectedItem = "Активные";
        }

        private void LoadData()
        {
            VocUnitDAO vuDAO = new VocUnitDAO();
            VocUnitListGrid.DataSource = vuDAO.getVocUnits(SearchComboBox.SelectedItem.ToString());
        }

        private void AddButon_Click(object sender, EventArgs e)
        {
            AddEditViewVocUnitForm f = new AddEditViewVocUnitForm(null);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void VocUnitListGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddEditViewVocUnitForm f = new AddEditViewVocUnitForm(Convert.ToInt32(VocUnitListGrid.Rows[e.RowIndex].Cells["id"].Value));
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
