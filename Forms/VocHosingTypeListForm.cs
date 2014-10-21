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
    public partial class VocHosingTypeListForm : Form
    {
        public VocHosingTypeListForm()
        {
            InitializeComponent();
            VocHousingTypeListGrid.AutoGenerateColumns = false;
            SearchComboBox.SelectedItem = "Активные";
        }

        private void LoadData()
        {
            VocHousingTypeDAO vhtDAO = new VocHousingTypeDAO();
            VocHousingTypeListGrid.DataSource = vhtDAO.getVocHousingTypes(SearchComboBox.SelectedItem.ToString());
        }

        private void AddButon_Click(object sender, EventArgs e)
        {
            AddEditViewVocHousingTypeForm f = new AddEditViewVocHousingTypeForm(null);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void SearchComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void VocHousingTypeListGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddEditViewVocHousingTypeForm f = new AddEditViewVocHousingTypeForm(Convert.ToInt32(VocHousingTypeListGrid.Rows[e.RowIndex].Cells["id"].Value));
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
