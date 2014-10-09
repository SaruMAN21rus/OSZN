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

        public AddEditKladrForm(string AddressObjectGuid)
        {
            this.AddressObjectGuid = AddressObjectGuid;

            InitializeComponent();

            NameErrorProvider.SetIconAlignment(NameTextBox, ErrorIconAlignment.MiddleRight);
            TypeErrorProvider.SetIconAlignment(TypeComboBox, ErrorIconAlignment.MiddleRight);
            TypeBriefErrorProvider.SetIconAlignment(TypeBriefComboBox, ErrorIconAlignment.MiddleRight);
            CodeErrorProvider.SetIconAlignment(CodeTextBox, ErrorIconAlignment.MiddleRight);

            CatalogDAO catalogDAO = new CatalogDAO();
            TypeComboBox.DataSource = catalogDAO.getLowLevels(AddressObjectGuid);
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.None))
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

        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                NameErrorProvider.SetError(NameTextBox, "Заполените поле!");
                e.Cancel = true;
            }
            else
            {
                NameErrorProvider.SetError(NameTextBox, null);
                e.Cancel = false;
            }
        }

        private void TypeComboBox_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
            {
                TypeErrorProvider.SetError(TypeComboBox, "Выберите значение из списка!");
                e.Cancel = true;
            }
            else
            {
                TypeErrorProvider.SetError(TypeComboBox, null);
                e.Cancel = false;
            }
        }

        private void TypeBriefComboBox_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
            {
                TypeBriefErrorProvider.SetError(TypeBriefComboBox, "Выберите значение из списка!");
                e.Cancel = true;
            }
            else
            {
                TypeBriefErrorProvider.SetError(TypeBriefComboBox, null);
                e.Cancel = false;
            }
        }

        private void CodeTextBox_Validating(object sender, CancelEventArgs e)
        {
            int type = Convert.ToInt32(TypeComboBox.SelectedValue);
            //string checkCode = "select id from VOC_ADDRESS_OBJECT where "
            
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                CodeErrorProvider.SetError(CodeTextBox, "Заполените поле!");
                e.Cancel = true;
            }
            else if (!CodeTextBox.Text.StartsWith("21"))
            {
                CodeErrorProvider.SetError(CodeTextBox, "Код должен начинаться с 21!");
                e.Cancel = true;
            }
            else if (type >= 7 && CodeTextBox.TextLength != 17) 
            {
                CodeErrorProvider.SetError(CodeTextBox, "Длина кода должна быть равна 17!");
                e.Cancel = true;
            } 
            else if (type < 7 && CodeTextBox.TextLength != 13)
            {
                CodeErrorProvider.SetError(CodeTextBox, "Длина кода должна быть равна 13!");
                e.Cancel = true;
            }/*
            else if ()
            {
                CodeErrorProvider.SetError(CodeTextBox, null);
                e.Cancel = false;
            }*/
            else
            {
                CodeErrorProvider.SetError(CodeTextBox, null);
                e.Cancel = false;
            }
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CatalogDAO catalogDAO = new CatalogDAO();
            TypeBriefComboBox.DataSource = catalogDAO.getTypeBriefs(Convert.ToInt32((sender as ComboBox).SelectedValue));
        }

        private void CodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
