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
    public partial class AddEditViewVocUnitForm : Form
    {
        VocUnit unit;
        bool refreshTable = false;

        public AddEditViewVocUnitForm(int? unitId)
        {
            InitializeComponent();

            NameErrorProvider.SetIconAlignment(NameTextBox, ErrorIconAlignment.MiddleRight);

            if (unitId != null)
            {
                VocUnitDAO vuDAO = new VocUnitDAO();
                unit = vuDAO.getVocUnitById(unitId.Value);
                panel1.Hide();
                panel2.Show();
                setViewData();
            } else {
                unit = new VocUnit();
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
                unit.name = NameTextBox.Text;
                unit.description = DescriptionTextBox.Text;
                VocUnitDAO vuDAO = new VocUnitDAO();
                if (unit.id == null)
                    unit.id = vuDAO.insertVocUnit(unit);
                else
                {
                    vuDAO.updateVocUnit(unit);
                }
                setViewData();
                panel1.Hide();
                panel2.Show();
                refreshTable = true;
            }
        }

        private void setViewData()
        {
            NameValue.Text = unit.name;
            DescriptionValue.Text = unit.description;
        }

        private void setEditData()
        {
            NameTextBox.Text = unit.name;
            DescriptionTextBox.Text = unit.description;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            setEditData();
            panel1.Show();
            panel2.Hide();
        }

        private void AddEditViewVocUnitForm_FormClosed(object sender, FormClosedEventArgs e)
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
                VocUnitDAO vuDAO = new VocUnitDAO();
                unit.Active = false;
                vuDAO.updateVocUnit(unit);
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
