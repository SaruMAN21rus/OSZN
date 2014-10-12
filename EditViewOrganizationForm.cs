using DatabaseLib;
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
    public partial class EditViewOrganizationForm : Form
    {
        private House house;

        private bool add = false;
        
        public EditViewOrganizationForm()
        {
            InitializeComponent();
            LoadData();

            NameErrorProvider.SetIconAlignment(NameTextBox, ErrorIconAlignment.MiddleRight);
            INNErrorProvider.SetIconAlignment(INNTextBox, ErrorIconAlignment.MiddleRight);
            KPPErrorProvider.SetIconAlignment(KPPTextBox, ErrorIconAlignment.MiddleRight);
            AddressErrorProvider.SetIconAlignment(AddressTextBox, ErrorIconAlignment.MiddleRight);
        }

        protected override void OnLoad(EventArgs e)
        {
            var btn = new Button();
            btn.Size = new Size(24, AddressTextBox.ClientSize.Height + 2);
            btn.Location = new Point(AddressTextBox.ClientSize.Width - btn.Width, -1);
            btn.Cursor = Cursors.Default;
            btn.Text = "∙∙∙";
            AddressTextBox.Controls.Add(btn);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(AddressTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
            btn.Click += new System.EventHandler(this.AddressTextBoxButton_Click);
            base.OnLoad(e);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void LoadData()
        {
            OrganizationDAO oDAO = new OrganizationDAO();
            Dictionary<string, object> organization = oDAO.getOrganization();
            if (organization.Count > 0)
            {
                NameValue.Text = organization["NAME"].ToString();
                INNKPPValue.Text = organization["INN"] + "/" + organization["KPP"];
                NameTextBox.Text = organization["NAME"].ToString();
                INNTextBox.Text = organization["INN"].ToString();
                KPPTextBox.Text = organization["KPP"].ToString();
                HouseDAO hDAO = new HouseDAO();
                house = hDAO.getAddressById(Convert.ToInt32(organization["HOUSE_ID"]));
                AddressTextBox.Text = house.fullAddress;
                AddressValue.Text = house.fullAddress;
                panel1.Hide();
                panel2.Show();
            }
            else
            {
                add = true;
                panel1.Show();
                panel2.Hide();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void INNTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void AddressTextBoxButton_Click(object sender, EventArgs e)
        {
            AddEditHouseForm f;
            if (house != null)
                f = new AddEditHouseForm(house);
            else
                f = new AddEditHouseForm(null);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                this.house = f.ReturnData();
                AddressTextBox.Text = house.fullAddress;
            }
        }

        private bool validateNameTextBox()
        {
            if (String.IsNullOrEmpty(NameTextBox.Text))
            {
                NameErrorProvider.SetError(NameTextBox, "Заполните поле!");
                return false;
            }
            else
            {
                NameErrorProvider.SetError(NameTextBox, null);
                return true;
            }
        }

        private bool validateINNTextBox()
        {
            if (String.IsNullOrEmpty(INNTextBox.Text))
            {
                INNErrorProvider.SetError(INNTextBox, "Заполните поле!");
                return false;
            }
            else if (INNTextBox.Text.Length < 10)
            {
                INNErrorProvider.SetError(INNTextBox, "ИНН должен состоять из 10 цифр!");
                return false;
            }
            else
            {
                INNErrorProvider.SetError(INNTextBox, null);
                return true;
            }
        }

        private bool validateKPPTextBox()
        {
            if (KPPTextBox.Text.Length > 0 && KPPTextBox.Text.Length < 9)
            {
                KPPErrorProvider.SetError(KPPTextBox, "КПП должен состоять из 9 цифр!");
                return false;
            }
            else
            {
                KPPErrorProvider.SetError(KPPTextBox, null);
                return true;
            }
        }

        private bool validateAddressTextBox()
        {
            if (String.IsNullOrEmpty(AddressTextBox.Text))
            {
                AddressErrorProvider.SetError(AddressTextBox, "Укажите адрес!");
                return false;
            }
            else
            {
                AddressErrorProvider.SetError(AddressTextBox, null);
                return true;
            }
        }

        private bool validateForm()
        {
            return validateNameTextBox() & validateINNTextBox()
                & validateKPPTextBox() & validateAddressTextBox();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                OrganizationDAO oDAO = new OrganizationDAO();
                ParametersCollection parameter = new ParametersCollection();
                parameter.Add("name", NameTextBox.Text, System.Data.DbType.String);
                parameter.Add("inn", INNTextBox.Text, System.Data.DbType.String);
                if (KPPTextBox.Text.Length > 0)
                {
                    parameter.Add("kpp", KPPTextBox.Text, System.Data.DbType.String);
                }
                oDAO.saveOrganization(parameter, house, add);
                LoadData();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            panel1.Show();
            panel2.Hide();
        }

        private void CloseButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
