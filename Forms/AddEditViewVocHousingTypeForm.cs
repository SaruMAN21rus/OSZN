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
    public partial class AddEditViewVocHousingTypeForm : Form
    {
        VocHousingType housingType;
        bool refreshTable = false;

        public AddEditViewVocHousingTypeForm(int? housingTypeId)
        {
            InitializeComponent();

            NameErrorProvider.SetIconAlignment(NameTextBox, ErrorIconAlignment.MiddleRight);

            if (housingTypeId != null)
            {
                VocHousingTypeDAO vhtDAO = new VocHousingTypeDAO();
                housingType = vhtDAO.getVocHousingTypeById(housingTypeId.Value);
                panel1.Hide();
                panel2.Show();
                setViewData();
            } else {
                housingType = new VocHousingType();
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
            if (validateNameTextBox())
            {
                housingType.name = NameTextBox.Text;
                VocHousingTypeDAO vhtDAO = new VocHousingTypeDAO();
                if (housingType.id == null)
                    housingType.id = vhtDAO.insertVocHousingType(housingType);
                else
                {
                    vhtDAO.updateVocHousingType(housingType);
                }
                setViewData();
                panel1.Hide();
                panel2.Show();
                refreshTable = true;
            }
        }

        private void setViewData()
        {
            NameValue.Text = housingType.name;
        }

        private void setEditData()
        {
            NameTextBox.Text = housingType.name;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            setEditData();
            panel1.Show();
            panel2.Hide();
        }

        private void AddEditViewVocHousingTypeForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (refreshTable)
            {
                this.DialogResult = DialogResult.OK;
            }
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
                VocHousingTypeDAO vhtDAO = new VocHousingTypeDAO();
                housingType.Active = false;
                vhtDAO.updateVocHousingType(housingType);
                this.DialogResult = DialogResult.OK;
                this.Close();
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

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(NameErrorProvider.GetError(NameTextBox)))
            {
                validateNameTextBox();
            }
        }
    }
}
