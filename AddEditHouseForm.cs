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

namespace OSZN
{
    public partial class AddEditHouseForm : Form
    {
        public AddEditHouseForm()
        {
            InitializeComponent();
            setCityAndAreaComboBoxValue();
        }

        private void setCityAndAreaComboBoxValue()
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            CityAndAreaComboBox.DataSource = aoDAO.getCityAndArea();
        }
        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void CityAndAreaComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)(sender as ComboBox).DataSource;
            string aoguid = dt.Rows[CityAndAreaComboBox.SelectedIndex]["aoguid"].ToString();
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            PlaceComboBox.Text = "";
            PlaceComboBox.DataSource = aoDAO.getPlaceByParentGUID(aoguid);
            PlaceComboBox.SelectedIndex = -1;
            
        }

        private void PlaceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            StreetComboBox.Text = "";
            if (PlaceComboBox.SelectedIndex != -1)
            {
                DataTable dt = (DataTable)PlaceComboBox.DataSource;
                string aoguid = dt.Rows[PlaceComboBox.SelectedIndex]["aoguid"].ToString();
                StreetComboBox.DataSource = aoDAO.getStreetByParentGUID(aoguid);
            }
            else
            {
                DataTable dt = (DataTable)CityAndAreaComboBox.DataSource;
                string aoguid = dt.Rows[CityAndAreaComboBox.SelectedIndex]["aoguid"].ToString();
                StreetComboBox.DataSource = aoDAO.getStreetByParentGUID(aoguid); ;
            }
            StreetComboBox.SelectedIndex = -1;
        }

        private void PlaceComboBox_TextChanged(object sender, EventArgs e)
        {
            PlaceComboBox.DroppedDown = false;
            if (PlaceComboBox.Text == "")
            {
                PlaceComboBox_SelectedIndexChanged(sender, e);
            }
        }

        private void CityAndAreaComboBox_TextChanged(object sender, EventArgs e)
        {
            (sender as ComboBox).DroppedDown = false;
        }
    }
}
