using DatabaseLib;
using OSZN.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSZN
{
    public partial class AddEditViewKladrForm : Form
    {

        private string AddressObjectGuid;
        private string action;
        private string editCode;
        private int id;
        private Dictionary<string, object> ao;

        public AddEditViewKladrForm(string AddressObjectGuid, string action)
        {
            this.AddressObjectGuid = AddressObjectGuid;
            this.action = action;
            InitializeComponent();

            NameErrorProvider.SetIconAlignment(NameTextBox, ErrorIconAlignment.MiddleRight);
            TypeErrorProvider.SetIconAlignment(TypeComboBox, ErrorIconAlignment.MiddleRight);
            TypeBriefErrorProvider.SetIconAlignment(TypeBriefComboBox, ErrorIconAlignment.MiddleRight);
            CodeErrorProvider.SetIconAlignment(CodeTextBox, ErrorIconAlignment.MiddleRight);

            if (action == "Add")
            {
                panel1.Show();
                panel2.Hide();
                CatalogDAO catalogDAO = new CatalogDAO();
                TypeComboBox.DataSource = catalogDAO.getLowLevels(AddressObjectGuid);
            }
            else if (action == "View")
            {
                panel1.Hide();
                panel2.Show();
                VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                this.ao = aoDAO.getAddressByAOGUID(AddressObjectGuid);
                NameValue.Text = ao["FORMALNAME"].ToString();
                TypeValue.Text = ao["NAME"].ToString();
                TypeBriefValue.Text = ao["SHORTNAME"].ToString();
                CodeValue.Text = ao["CODE"].ToString();
                this.id = Convert.ToInt32(ao["ID"]);
            }
        }

        private void SetEditValues()
        {
            CatalogDAO catalogDAO = new CatalogDAO();
            TypeComboBox.DataSource = catalogDAO.getCurrAndLowLevels(AddressObjectGuid);
            this.Text = "Изменение классификатора";
            this.editCode = this.ao["CODE"].ToString();
            NameTextBox.Text = this.ao["FORMALNAME"].ToString();
            TypeComboBox.SelectedValue = this.ao["levelId"];
            TypeBriefComboBox.SelectedValue = this.ao["SHORTNAME"].ToString();
            CodeTextBox.Text = this.editCode;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (!validateForm())
            {
                DialogResult = DialogResult.None;
                return;
            }
            else
            {
                VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                if (action == "Edit") 
                {
                    aoDAO.updateAddress(NameTextBox.Text,
                        Convert.ToInt32(TypeComboBox.SelectedValue),
                        TypeBriefComboBox.SelectedValue.ToString(),
                        CodeTextBox.Text,
                        this.id);
                }
                else
                {
                    aoDAO.insertAddress(NameTextBox.Text,
                        Convert.ToInt32(TypeComboBox.SelectedValue),
                        TypeBriefComboBox.SelectedValue.ToString(),
                        CodeTextBox.Text,
                        AddressObjectGuid);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private bool validateNameTextBox()
        {
            if (string.IsNullOrEmpty(NameTextBox.Text))
            {
                NameErrorProvider.SetError(NameTextBox, "Заполените поле!");
                return false;
            }
            else
            {
                NameErrorProvider.SetError(NameTextBox, null);
                return true;
            }
        }

        private bool validateTypeComboBox()
        {
            if (TypeComboBox.SelectedIndex == -1)
            {
                TypeErrorProvider.SetError(TypeComboBox, "Выберите значение из списка!");
                return false;
            }
            else
            {
                TypeErrorProvider.SetError(TypeComboBox, null);
                return true;
            }
        }

        private bool validateTypeBriefComboBox()
        {
            if (TypeBriefComboBox.SelectedIndex == -1)
            {
                TypeErrorProvider.SetError(TypeBriefComboBox, "Выберите значение из списка!");
                return false;
            }
            else
            {
                TypeErrorProvider.SetError(TypeBriefComboBox, null);
                return true;
            }
        }

        private bool validateCodeTextBox()
        {
            int type = Convert.ToInt32(TypeComboBox.SelectedValue);
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();

            if (string.IsNullOrEmpty(CodeTextBox.Text))
            {
                CodeErrorProvider.SetError(CodeTextBox, "Заполените поле!");
                return false;
            }
            else if (!CodeTextBox.Text.StartsWith("21"))
            {
                CodeErrorProvider.SetError(CodeTextBox, "Код должен начинаться с 21!");
                return false;
            }
            else if (type >= 7 && CodeTextBox.TextLength != 17)
            {
                CodeErrorProvider.SetError(CodeTextBox, "Длина кода должна быть равна 17!");
                return false;
            }
            else if (type < 7 && CodeTextBox.TextLength != 13)
            {
                CodeErrorProvider.SetError(CodeTextBox, "Длина кода должна быть равна 13!");
                return false;
            }
            else if ((this.action != "Edit" || this.action == "Edit" && !this.editCode.Equals(CodeTextBox.Text)) && !aoDAO.checkCode(CodeTextBox.Text))
            {
                CodeErrorProvider.SetError(CodeTextBox, "Адрес с таким кодом уже существует!");
                return false;
            }
            else
            {
                CodeErrorProvider.SetError(CodeTextBox, null);
                return true;
            }
        }

        private bool validateForm()
        {
            return validateNameTextBox() & validateTypeComboBox()
                & validateTypeBriefComboBox() & validateCodeTextBox();
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int levelId = Convert.ToInt32((sender as ComboBox).SelectedValue);
            CatalogDAO catalogDAO = new CatalogDAO();
            TypeBriefComboBox.DataSource = catalogDAO.getTypeBriefs(levelId);
            if (levelId >= 7)
            {
                CodeTextBox.MaxLength = 17;
            }
            else
            {
                CodeTextBox.MaxLength = 13;
            }
        }

        private void CodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(NameErrorProvider.GetError(NameTextBox)))
            {
                validateNameTextBox();
            }
        }

        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CodeErrorProvider.GetError(CodeTextBox)))
            {
                validateCodeTextBox();
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить этот адрес?",
                "Удаление записи",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                aoDAO.deleteAddressObject(this.id);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            this.SetEditValues();
            panel1.Show();
            panel2.Hide();
            this.action = "Edit";
        }
    }
}
