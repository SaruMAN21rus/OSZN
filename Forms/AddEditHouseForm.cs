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
        private House house;
        
        public AddEditHouseForm(House house)
        {
            InitializeComponent();
            setCityAndAreaComboBoxValue();

            PostalCodeErrorProvider.SetIconAlignment(PostalCodeTextBox, ErrorIconAlignment.MiddleRight);
            CityAndAreaErrorProvider.SetIconAlignment(CityAndAreaComboBox, ErrorIconAlignment.MiddleRight);
            HouseNumberErrorProvider.SetIconAlignment(HouseTextBox, ErrorIconAlignment.MiddleRight);

            if (house != null)
            {
                this.house = house;
                PostalCodeTextBox.Text = house.postalCode;
                CityAndAreaComboBox.SelectedValue = house.cityOrArea.id;
                HouseTextBox.Text = house.houseNumber;
                HousingTextBox.Text = house.housingNumber;
                if (house.place != null)
                    PlaceComboBox.SelectedValue = house.place.id;
                RoomTextBox.Text = house.roomNumber;
                if (house.street != null)
                    StreetComboBox.SelectedValue = house.street.id;
            }
            else
            {
                this.house = new House();
            }
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
            if (!String.IsNullOrEmpty(CityAndAreaErrorProvider.GetError(CityAndAreaComboBox)))
            {
                validateCityAndAreaComboBox();
            }
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

        private void NameTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public House ReturnData()
        {
            return this.house;
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                this.house.postalCode = PostalCodeTextBox.Text;
                this.house.houseNumber = HouseTextBox.Text;
                this.house.housingNumber = HousingTextBox.Text;
                this.house.roomNumber = RoomTextBox.Text;
                if (CityAndAreaComboBox.SelectedIndex != -1)
                {
                    this.house.cityOrArea = getSelectedVocAddressObject(CityAndAreaComboBox);
                }
                else
                {
                    this.house.cityOrArea = null;
                }
                if (PlaceComboBox.SelectedIndex != -1)
                {
                    this.house.place = getSelectedVocAddressObject(PlaceComboBox);
                }
                else
                {
                    this.house.place = null;
                }
                if (StreetComboBox.SelectedIndex != -1)
                {
                    this.house.street = getSelectedVocAddressObject(StreetComboBox);
                }
                else
                {
                    this.house.street = null;
                }
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                this.DialogResult = DialogResult.None;
            }
        }

        private VocAddressObject getSelectedVocAddressObject(ComboBox cb)
        {
            VocAddressObject ao = new VocAddressObject();
            ao.id = Convert.ToInt32(cb.SelectedValue);
            DataTable dt = (DataTable)cb.DataSource;
            var selectedRow = dt.Rows[cb.SelectedIndex];
            ao.name = selectedRow["formalname"].ToString();
            ao.typeBrief = selectedRow["typeBrief"].ToString();
            ao.typeBriefHasPoint = Convert.ToBoolean(selectedRow["POINT"]);
            ao.typeBriefInLeft = Convert.ToBoolean(selectedRow["LEFT"]);
            ao.code = selectedRow["CODE"].ToString();
            return ao;
        }

        private bool validatePostalCodeTextBox()
        {
            if (PostalCodeTextBox.Text.Length > 0 && PostalCodeTextBox.Text.Length < 6)
            {
                PostalCodeErrorProvider.SetError(PostalCodeTextBox, "Индекс должен состять из 6 цифр!");
                return false;
            }
            else
            {
                PostalCodeErrorProvider.SetError(PostalCodeTextBox, null);
                return true;
            }
        }

        private bool validateCityAndAreaComboBox()
        {
            if (CityAndAreaComboBox.SelectedIndex == -1)
            {
                CityAndAreaErrorProvider.SetError(CityAndAreaComboBox, "Выберите значение из списка!");
                return false;
            }
            else
            {
                CityAndAreaErrorProvider.SetError(CityAndAreaComboBox, null);
                return true;
            }
        }

        private bool validateHouseTextBox()
        {
            if (String.IsNullOrEmpty(HouseTextBox.Text))
            {
                HouseNumberErrorProvider.SetError(HouseTextBox, "Заполните поле!");
                return false;
            }
            else
            {
                HouseNumberErrorProvider.SetError(HouseTextBox, null);
                return true;
            }
        }

        private bool validateForm()
        {
            return validatePostalCodeTextBox() & validateCityAndAreaComboBox() & validateHouseTextBox();
        }

        private void PostalCodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(PostalCodeErrorProvider.GetError(PostalCodeTextBox)))
            {
                validatePostalCodeTextBox();
            }
        }

        private void HouseTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(HouseNumberErrorProvider.GetError(HouseTextBox)))
            {
                validateHouseTextBox();
            }
        }
    }
}
