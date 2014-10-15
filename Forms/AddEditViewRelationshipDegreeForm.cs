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
    public partial class AddEditViewRelationshipDegreeForm : Form
    {
        RelationshipDegree relationshipDegree;
        bool refreshTable = false;

        public AddEditViewRelationshipDegreeForm(int? relationshipDegreeId)
        {
            InitializeComponent();

            NameErrorProvider.SetIconAlignment(NameTextBox, ErrorIconAlignment.MiddleRight);

            if (relationshipDegreeId != null) {
                RelationshipDegreeDAO rdDAO = new RelationshipDegreeDAO();
                relationshipDegree = rdDAO.getRelationshipDegreeById(relationshipDegreeId.Value);
                panel1.Hide();
                panel2.Show();
                setViewData();
            } else {
                relationshipDegree = new RelationshipDegree();
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
                relationshipDegree.name = NameTextBox.Text;
                RelationshipDegreeDAO rdDAO = new RelationshipDegreeDAO();
                if (relationshipDegree.id == null)
                    relationshipDegree.id = rdDAO.insertRelationshipDegree(relationshipDegree);
                else
                {
                    rdDAO.updateRelationshipDegree(relationshipDegree);
                }
                setViewData();
                panel1.Hide();
                panel2.Show();
                refreshTable = true;
            }
        }

        private void setViewData()
        {
            NameValue.Text = relationshipDegree.name;
        }

        private void setEditData()
        {
            NameTextBox.Text = relationshipDegree.name;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            setEditData();
            panel1.Show();
            panel2.Hide();
        }

        private void AddEditViewRelationshipDegreeForm_FormClosed(object sender, FormClosedEventArgs e)
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
                RelationshipDegreeDAO rdDAO = new RelationshipDegreeDAO();
                relationshipDegree.Active = false;
                rdDAO.updateRelationshipDegree(relationshipDegree);
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
