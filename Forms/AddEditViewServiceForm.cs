using OSZN.DAO;
using OSZN.Model;
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
    public partial class AddEditViewServiceForm : Form
    {
        VocService service;
        bool refreshTable = false;
        
        public AddEditViewServiceForm(int? id)
        {
            InitializeComponent();
            
            CodeErrorProvider.SetIconAlignment(CodeTextBox, ErrorIconAlignment.MiddleRight);
            VocServiceDAO vsDAO = new VocServiceDAO();
            if (id != null)
            {
                service = vsDAO.getVocServiceById(id.Value);
                panel1.Hide();
                panel2.Show();
                setViewData();
            }
            else
            {
                service = new VocService();
                int code = vsDAO.getNextCode();
                CodeTextBox.Text = code.ToString();
                panel1.Show();
                panel2.Hide();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (validateCodeTextBox())
            {
                setDataForSave();
                VocServiceDAO vsDAO = new VocServiceDAO();
                if (service.id == null)
                    service.id = vsDAO.insertVocService(service);
                else
                {
                    vsDAO.updateVocService(service);
                }
                setViewData();
                panel1.Hide();
                panel2.Show();
                refreshTable = true;
            }
        }

        private void setViewData()
        {

            CodeValue.Text = service.code.ToString();
            NameValue.Text = service.name;
            UnitValue.Text = service.unit;
        }

        private void setEditData()
        {
            CodeTextBox.Text = service.code.ToString();
            NameTextBox.Text = service.name;
            UnitTextBox.Text = service.unit;
        }
        private void AddEditViewServiceForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (refreshTable)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private bool validateCodeTextBox()
        {
            if (String.IsNullOrEmpty(CodeTextBox.Text))
            {
                CodeErrorProvider.SetError(CodeTextBox, "Заполните поле!");
                return false;
            }
            else if (service.code.ToString() != CodeTextBox.Text)
            {
                VocServiceDAO vsDAO = new VocServiceDAO();
                VocService vs = vsDAO.getVocServiceByCode(Convert.ToInt32(CodeTextBox.Text));
                if (vs.id != null)
                {
                    CodeErrorProvider.SetError(CodeTextBox, "Код не уникален, внесите изменения!");
                    return false;
                }
                else
                {
                    CodeErrorProvider.SetError(CodeTextBox, null);
                    return true;
                }
            }
            else
            {
                CodeErrorProvider.SetError(CodeTextBox, null);
                return true;
            }
        }

        private void CodeTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(CodeErrorProvider.GetError(NameTextBox)))
            {
                validateCodeTextBox();
            }
        }

        private void setDataForSave()
        {
            if (!String.IsNullOrEmpty(CodeTextBox.Text))
                service.code = Convert.ToInt32(CodeTextBox.Text);
            if (!String.IsNullOrEmpty(NameTextBox.Text))
                service.name = NameTextBox.Text;
            else
                service.name = null;
            if (!String.IsNullOrEmpty(UnitTextBox.Text))
                service.unit = UnitTextBox.Text;
            else
                service.unit = null;
        }

        private void CodeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            setEditData();
            panel1.Show();
            panel2.Hide();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту запись?",
                "Удаление записи",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                VocServiceDAO vsDAO = new VocServiceDAO();
                service.Active = false;
                vsDAO.updateVocService(service);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
