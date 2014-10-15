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
    public partial class AddEditViewFamilyMember : Form
    {
        private FamilyMember member;
        private Exempt exempt;
        private bool refreshTable = false;

        public AddEditViewFamilyMember(int? memberId, Exempt exempt)
        {
            InitializeComponent();
            setRelationshipDegreeComboBoxValue();
            this.exempt = exempt;
            if (memberId != null)
            {
                FamilyMembersDAO fmDAO = new FamilyMembersDAO();
                member = fmDAO.getFamilyMemberById(memberId.Value);
                setViewData();
                panel1.Hide();
                panel2.Show();
            }
            else
            {
                member = new FamilyMember();
                panel1.Show();
                panel2.Hide();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setRelationshipDegreeComboBoxValue()
        {
            RelationshipDegreeDAO rdDAO = new RelationshipDegreeDAO();
            RelationshipDegreeComboBox.DataSource = rdDAO.getRelationshipDegrees("Активные");
            RelationshipDegreeComboBox.SelectedIndex = -1;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            setDataForSave();
            FamilyMembersDAO fmDAO = new FamilyMembersDAO();
            if (member.id == null)
                member.id = fmDAO.insertFamilyMember(member);
            else
            {
                fmDAO.updateFamilyMember(member);
            }
            setViewData();
            panel1.Hide();
            panel2.Show();
            refreshTable = true;
        }

        private void AddEditViewFamilyMember_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (refreshTable)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void setDataForSave()
        {
            if (RelationshipDegreeComboBox.SelectedIndex != -1) {
                member.relationshipDegreeId = Convert.ToInt32(RelationshipDegreeComboBox.SelectedValue);
                RelationshipDegree rd = new RelationshipDegree();
                rd.id = member.relationshipDegreeId;
                rd.name = RelationshipDegreeComboBox.Text;
                member.relationshipDegree = rd;
            }
            else {
                member.relationshipDegreeId = null;
                member.relationshipDegree = null;
            }
            if (!String.IsNullOrEmpty(LastNameTextBox.Text))
                member.lastName = LastNameTextBox.Text;
            else
                member.lastName = null;
            if (!String.IsNullOrEmpty(NameTextBox.Text))
                member.name = NameTextBox.Text;
            else
                member.name = null;
            if (!String.IsNullOrEmpty(MiddleNameTextBox.Text))
                member.middleName = MiddleNameTextBox.Text;
            else
                member.middleName = null;
            if (BirthDateDateTimePicker.Value != DateTime.MinValue)
                member.birthDate = BirthDateDateTimePicker.Value;
            else
                member.birthDate = DateTime.MinValue;
            if (MaleRadioButton.Checked)
                member.sex = "мужской";
            else if (FemaleRadioButton.Checked)
            {
                member.sex = "женский";
            }
            else
            {
                member.sex = null;
            }
            member.isOwner = isOwnerCheckBox.Checked;
            member.exemptId = exempt.id.Value;
        }

        private void setEditData()
        {
            if (member.relationshipDegreeId != null)
                RelationshipDegreeComboBox.SelectedValue = member.relationshipDegreeId;
            LastNameTextBox.Text = member.lastName;
            NameTextBox.Text = member.name;
            MiddleNameTextBox.Text = member.middleName;
            if (member.birthDate != DateTime.MinValue)
                BirthDateDateTimePicker.Value = member.birthDate;
            if (!String.IsNullOrEmpty(member.sex))
            {
                if (member.sex.Equals("мужской"))
                {
                    MaleRadioButton.Select();
                }
                else
                {
                    FemaleRadioButton.Select();
                }
            }
            isOwnerCheckBox.Checked = member.isOwner;
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
                FamilyMembersDAO fmDAO = new FamilyMembersDAO();
                fmDAO.deleteFamilyMember(member.id.Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            setEditData();
            panel1.Show();
            panel2.Hide();
        }

        private void setViewData()
        {
            if (member.relationshipDegree != null)
                RelationshipDegreeValue.Text = member.relationshipDegree.name;
            else
                RelationshipDegreeValue.Text = "";
            LastNameValue.Text = member.lastName;
            NameValue.Text = member.name;
            MiddleNameValue.Text = member.middleName;
            if (member.birthDate != DateTime.MinValue)
                BirthDateValue.Text = member.birthDate.ToString("dd.MM.yyyy");
            else
                BirthDateValue.Text = "";
            SexValue.Text = member.sex;
            IsOwnerCheckBoxValue.Checked = member.isOwner;
        }

        private void RelationshipDegreeComboBox_TextChanged(object sender, EventArgs e)
        {
            RelationshipDegreeComboBox.DroppedDown = false;
        }
    }
}
