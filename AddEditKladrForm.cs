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
    public partial class AddEditKladrForm : Form
    {

        private string AddressObjectGuid;

        public AddEditKladrForm(string AddressObjectGuid, bool edit)
        {
            this.AddressObjectGuid = AddressObjectGuid;

            InitializeComponent();

            NameErrorProvider.SetIconAlignment(NameTextBox, ErrorIconAlignment.MiddleRight);
            TypeErrorProvider.SetIconAlignment(TypeComboBox, ErrorIconAlignment.MiddleRight);
            TypeBriefErrorProvider.SetIconAlignment(TypeBriefComboBox, ErrorIconAlignment.MiddleRight);
            CodeErrorProvider.SetIconAlignment(CodeTextBox, ErrorIconAlignment.MiddleRight);

            CatalogDAO catalogDAO = new CatalogDAO();

            if (edit)
            {
                TypeComboBox.DataSource = catalogDAO.getCurrAndLowLevels(AddressObjectGuid);
                this.Text = "Изменение классификатора";
                VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                Dictionary<string, object> ao = aoDAO.getAddressByAOGUID(AddressObjectGuid);
                NameTextBox.Text = ao["FORMALNAME"].ToString();
                TypeComboBox.SelectedValue = ao["levelId"];
                TypeBriefComboBox.SelectedValue = ao["SHORTNAME"].ToString();
                CodeTextBox.Text = ao["CODE"].ToString();
            }
            else
            {
                TypeComboBox.DataSource = catalogDAO.getLowLevels(AddressObjectGuid);
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
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
                aoDAO.insertAddress(NameTextBox.Text, 
                    Convert.ToInt32(TypeComboBox.SelectedValue), 
                    TypeBriefComboBox.SelectedValue.ToString(), 
                    CodeTextBox.Text, 
                    AddressObjectGuid);
                this.DialogResult = DialogResult.OK;
                Close();
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
            else if (!aoDAO.checkCode(CodeTextBox.Text))
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
            CatalogDAO catalogDAO = new CatalogDAO();
            TypeBriefComboBox.DataSource = catalogDAO.getTypeBriefs(Convert.ToInt32((sender as ComboBox).SelectedValue));
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
    }
}
