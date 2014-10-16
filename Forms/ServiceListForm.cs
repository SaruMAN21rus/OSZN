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
    public partial class ServiceListForm : Form
    {
        public ServiceListForm()
        {
            InitializeComponent();
            ServiceListGrid.AutoGenerateColumns = false;
            SearchComboBox.SelectedItem = "Активные";
        }

        private void LoadData()
        {
            VocServiceDAO vsDAO = new VocServiceDAO();
            ServiceListGrid.DataSource = vsDAO.getVocServices(SearchComboBox.SelectedItem.ToString());
        }

        private void AddButon_Click(object sender, EventArgs e)
        {
            AddEditViewServiceForm f = new AddEditViewServiceForm(null);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }

        private void SearchComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ServiceListGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddEditViewServiceForm f = new AddEditViewServiceForm(Convert.ToInt32(ServiceListGrid.Rows[e.RowIndex].Cells["id"].Value));
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData();
            }
        }
    }
}
