﻿using OSZN.DAO;
using OSZN.Forms;
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
    public partial class AddEditViewExemptForm : Form
    {
        Exempt exempt;
        ExemptHouseroom exemptHouseroom;
        int? exemptId;
        int? houseId;
        bool refreshTable = false;

        private Button AddressTextBoxClearButton;
        private Button AddressTextBoxSelectButton;

        public AddEditViewExemptForm(int? exemptId)
        {
            this.exemptId = exemptId;
            InitializeComponent();

            IDErrorProvider.SetIconAlignment(IDTextBox, ErrorIconAlignment.MiddleRight);
            this.FamilyMemberListGrid.AutoGenerateColumns = false;
            this.ServiceDataGridView.AutoGenerateColumns = false;

            VocHousingTypeDAO vhtDAO = new VocHousingTypeDAO();
            HousingTypeComboBox.DataSource = vhtDAO.getVocHousingTypes("Активные");
            HousingTypeComboBox.SelectedIndex = -1;

            if (exemptId != null)
            {
                ExemptDAO eDAO = new ExemptDAO();
                exempt = eDAO.getExemptById(exemptId.Value);
                ExemptHouseroomDAO ehDAO = new ExemptHouseroomDAO();
                exemptHouseroom = ehDAO.getExemptHouseroomByExemptId(exempt.id.Value);
                setViewData();
                panel1.Hide();
                panel2.Show();
                if (exempt.houseId != null)
                {
                    this.houseId = exempt.houseId;
                }
                if (!exempt.HasFamilyComposition)
                {
                    tabControl1.TabPages.Remove(FamilyPage);
                }
            }
            else
            {
                exempt = new Exempt();
                exemptHouseroom = new ExemptHouseroom();
                CreateDateTextBox.Text = DateTime.Now.ToString("dd.MM.yyyy");
                panel1.Show();
                panel2.Hide();
            }
        }

        private void setViewData()
        {
            IDValue.Text = exempt.id.ToString();
            CreateDateValue.Text = exempt.createDate.ToString("dd.MM.yyyy");
            PersonalAccountValue.Text = exempt.personalAccount;
            LastNameValue.Text = exempt.lastName;
            NameValue.Text = exempt.name;
            MidleNameValue.Text = exempt.middleName;
            if (exempt.birthDate != null)
                BirthDateValue.Text = exempt.birthDate.Value.ToString("dd.MM.yyyy");
            else
                BirthDateValue.Text = "";
            SexValue.Text = exempt.sex;
            SNILSValue.Text = exempt.SNILS;
            DocumentNameValue.Text = exempt.documentName;
            DocumentSeriesValue.Text = exempt.documentSeries;
            DocumentNumberValue.Text = exempt.documentNumber;
            if (exempt.documentDate != null)
                DocumentDateValue.Text = exempt.documentDate.Value.ToString("dd.MM.yyyy");
            else
                DocumentDateValue.Text = "";
            DocumentIssuerValue.Text = exempt.documentIssuer;
            if (exempt.house != null)
            {
                AddressValue.Text = exempt.house.fullAddress;
                CodeValue.Text = exempt.house.code;
            }
            if (exemptHouseroom.VocHousingType != null)
                HousingTypeValue.Text = exemptHouseroom.VocHousingType.name;
            else
                HousingTypeValue.Text = "";
            IsOwnerValue.Checked = exemptHouseroom.isOwner;
            TotalAreaValue.Text = exemptHouseroom.totalArea.ToString();
            LivingAreaValue.Text = exemptHouseroom.livingArea.ToString();
            ResidentsCountValue.Text = exemptHouseroom.residentsCount.ToString();
            RoomsCountValue.Text = exemptHouseroom.roomsCount.ToString();
            FamilyMembersCountValue.Text = exemptHouseroom.familyMembersCount.ToString();
            LandSizeValue.Text = exemptHouseroom.landSize.ToString();
        }

        private void setDataForSave()
        {
            if (!String.IsNullOrEmpty(IDTextBox.Text))
                exempt.id = Convert.ToInt32(IDTextBox.Text);
            if (!String.IsNullOrEmpty(CreateDateTextBox.Text))
                exempt.createDate = Convert.ToDateTime(CreateDateTextBox.Text);
            if (!String.IsNullOrEmpty(PersonalCodeTextBox.Text))
                exempt.personalAccount = PersonalCodeTextBox.Text;
            else
                exempt.personalAccount = null;
            if (!String.IsNullOrEmpty(LastNameTextBox.Text))
                exempt.lastName = LastNameTextBox.Text;
            else
                exempt.lastName = null;
            if (!String.IsNullOrEmpty(NameTextBox.Text))
                exempt.name = NameTextBox.Text;
            else
                exempt.name = null;
            if (!String.IsNullOrEmpty(MiddleNameTextBox.Text))
                exempt.middleName = MiddleNameTextBox.Text;
            else
                exempt.middleName = null;
            if (BirthDateDateTimePicker.Value != DateTime.MinValue)
                exempt.birthDate = BirthDateDateTimePicker.Value;
            else
                exempt.birthDate = null;
            if (MaleRadioButton.Checked)
                exempt.sex = "мужской";
            else if (FemaleRadioButton.Checked)
            {
                exempt.sex = "женский";
            }
            else
            {
                exempt.sex = null;
            }
            if (!String.IsNullOrEmpty(SNILSTextBox.Text))
                exempt.SNILS = SNILSTextBox.Text;
            else
                exempt.SNILS = null;
            if (!String.IsNullOrEmpty(DocumentNameTextBox.Text))
                exempt.documentName = DocumentNameTextBox.Text;
            else
                exempt.documentName = null;
            if (!String.IsNullOrEmpty(DocumetnSeriesTextBox.Text))
                exempt.documentSeries = DocumetnSeriesTextBox.Text;
            else 
                exempt.documentSeries = null;
            if (!String.IsNullOrEmpty(DocumentNumberTextBox.Text))
                exempt.documentNumber = DocumentNumberTextBox.Text;
            else 
                 exempt.documentNumber = null;
            if (DocumentDateDateTimePicker.Value != DateTime.MinValue)
                exempt.documentDate = DocumentDateDateTimePicker.Value;
            else 
                exempt.documentDate = null;
            if (!String.IsNullOrEmpty(DocumentIssuerTextBox.Text))
                exempt.documentIssuer = DocumentIssuerTextBox.Text;
            else
                exempt.documentIssuer = null;
            if (String.IsNullOrEmpty(AddressTextBox.Text))
            {
                exempt.house = null;
                exempt.houseId = null;
            }
            if (HousingTypeComboBox.SelectedIndex != -1)
                exemptHouseroom.vocHousingTypeId = Convert.ToInt32(HousingTypeComboBox.SelectedValue);
            else
            {
                exemptHouseroom.vocHousingTypeId = null;
                exemptHouseroom.VocHousingType = null;
            }
            exemptHouseroom.isOwner = IsOwnerCheckBox.Checked;
            if (!String.IsNullOrEmpty(TotalAreaTextBox.Text))
                exemptHouseroom.totalArea = Convert.ToDecimal(TotalAreaTextBox.Text);
            else
                exemptHouseroom.totalArea = null;
            if (!String.IsNullOrEmpty(LivingAreaTextBox.Text))
                exemptHouseroom.livingArea = Convert.ToDecimal(LivingAreaTextBox.Text);
            else
                exemptHouseroom.livingArea = null;
            if (!String.IsNullOrEmpty(ResidentsCountTextBox.Text))
                exemptHouseroom.residentsCount = Convert.ToInt32(ResidentsCountTextBox.Text);
            else
                exemptHouseroom.residentsCount = null;
            if (!String.IsNullOrEmpty(RoomsCountTextBox.Text))
                exemptHouseroom.roomsCount = Convert.ToInt32(RoomsCountTextBox.Text);
            else
                exemptHouseroom.roomsCount = null;
            if (!String.IsNullOrEmpty(FamilyMembersCount.Text))
                exemptHouseroom.familyMembersCount = Convert.ToInt32(FamilyMembersCount.Text);
            else
                exemptHouseroom.familyMembersCount = null;
            if (!String.IsNullOrEmpty(LandSizeTextBox.Text))
                exemptHouseroom.landSize = Convert.ToDecimal(LandSizeTextBox.Text);
            else
                exemptHouseroom.landSize = null;
        }

        private void setEditData()
        {
            IDTextBox.Text = exempt.id.ToString();
            CreateDateTextBox.Text = exempt.createDate.ToString("dd.MM.yyyy");
            PersonalCodeTextBox.Text = exempt.personalAccount;
            LastNameTextBox.Text = exempt.lastName;
            NameTextBox.Text = exempt.name;
            MiddleNameTextBox.Text = exempt.middleName;
            if (exempt.birthDate != null)
                BirthDateDateTimePicker.Value = exempt.birthDate.Value;
            if (!String.IsNullOrEmpty(exempt.sex))
            {
                if (exempt.sex.Equals("мужской"))
                {
                    MaleRadioButton.Select();
                }
                else
                {
                    FemaleRadioButton.Select();
                }
            }
            SNILSTextBox.Text = exempt.SNILS;
            DocumentNameTextBox.Text = exempt.documentName;
            DocumetnSeriesTextBox.Text = exempt.documentSeries;
            DocumentNumberTextBox.Text = exempt.documentNumber;
            if (exempt.documentDate != null)
                DocumentDateDateTimePicker.Value = exempt.documentDate.Value;
            DocumentIssuerTextBox.Text = exempt.documentIssuer;
            if (exempt.house != null)
            {
                AddressTextBox.Text = exempt.house.fullAddress;
                CodeTextBox.Text = exempt.house.code;
            }
            
            if (exempt.loaded)
            {
                IDTextBox.ReadOnly = true;
                LastNameTextBox.ReadOnly = true;
                NameTextBox.ReadOnly = true;
                MiddleNameTextBox.ReadOnly = true;
                MaleRadioButton.AutoCheck = false;
                FemaleRadioButton.AutoCheck = false;
                SNILSTextBox.ReadOnly = true;
                DocumentNameTextBox.ReadOnly = true;
                DocumetnSeriesTextBox.ReadOnly = true;
                DocumentNumberTextBox.ReadOnly = true;
                DocumentIssuerTextBox.ReadOnly = true;
                AddressTextBoxSelectButton.Visible = false;
                AddressTextBoxClearButton.Visible = false;

                TextBox birthDateTextBox = new TextBox();
                birthDateTextBox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                birthDateTextBox.Location = new Point(143, 4);
                birthDateTextBox.ReadOnly = true;
                birthDateTextBox.Size = new System.Drawing.Size(130, 20);
                birthDateTextBox.Text = exempt.birthDate.Value.ToString("dd.MM.yyyy");
                tableLayoutPanel3.Controls.Remove(tableLayoutPanel3.GetControlFromPosition(1, 0));
                tableLayoutPanel3.Controls.Add(birthDateTextBox);

                TextBox documentDateTextBox = new TextBox();
                documentDateTextBox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                documentDateTextBox.Location = new Point(143, 4);
                documentDateTextBox.ReadOnly = true;
                documentDateTextBox.Size = new System.Drawing.Size(130, 20);
                documentDateTextBox.Text = exempt.documentDate.Value.ToString("dd.MM.yyyy");
                tableLayoutPanel14.Controls.Remove(tableLayoutPanel14.GetControlFromPosition(1, 0));
                tableLayoutPanel14.Controls.Add(documentDateTextBox);
            }

            if (exemptHouseroom.vocHousingTypeId != null)
                HousingTypeComboBox.SelectedValue = exemptHouseroom.vocHousingTypeId;
            IsOwnerCheckBox.Checked = exemptHouseroom.isOwner;
            TotalAreaTextBox.Text = exemptHouseroom.totalArea.ToString();
            LivingAreaTextBox.Text = exemptHouseroom.livingArea.ToString();
            ResidentsCountTextBox.Text = exemptHouseroom.residentsCount.ToString();
            RoomsCountTextBox.Text = exemptHouseroom.roomsCount.ToString();
            FamilyMembersCount.Text = exemptHouseroom.familyMembersCount.ToString();
            LandSizeTextBox.Text = exemptHouseroom.landSize.ToString();
        }

        protected override void OnLoad(EventArgs e)
        {
            var panel = new FlowLayoutPanel();
            panel.Size = new Size(42, AddressTextBox.ClientSize.Height + 2);
            panel.Location = new Point(AddressTextBox.ClientSize.Width - panel.Width, -1);
            panel.Anchor = AnchorStyles.Right;
            panel.FlowDirection = FlowDirection.RightToLeft;

            AddressTextBoxClearButton = new Button();
            AddressTextBoxClearButton.Size = new Size(AddressTextBox.ClientSize.Height + 2, AddressTextBox.ClientSize.Height + 2);
            AddressTextBoxClearButton.BackColor = Color.Transparent;
            AddressTextBoxClearButton.BackgroundImage = Properties.Resources.e10a_Cancel_48;
            AddressTextBoxClearButton.BackgroundImageLayout = ImageLayout.Stretch;
            AddressTextBoxClearButton.Cursor = Cursors.Default;
            AddressTextBoxClearButton.FlatAppearance.BorderSize = 0;
            AddressTextBoxClearButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            AddressTextBoxClearButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            AddressTextBoxClearButton.FlatStyle = FlatStyle.Flat;
            AddressTextBoxClearButton.Margin = new Padding(0);
            AddressTextBoxClearButton.UseVisualStyleBackColor = false;
            AddressTextBoxClearButton.Click += AddressTextBoxClearButton_Click;
            AddressTextBoxClearButton.Hide();
            ToolTip clearButtontoolTip = new ToolTip();
            clearButtontoolTip.AutomaticDelay = 100;
            clearButtontoolTip.AutoPopDelay = 5000;
            clearButtontoolTip.SetToolTip(AddressTextBoxClearButton, "Очистить");

            AddressTextBoxSelectButton = new Button();
            AddressTextBoxSelectButton.Size = new Size(24, AddressTextBox.ClientSize.Height + 2);
            AddressTextBoxSelectButton.Cursor = Cursors.Default;
            AddressTextBoxSelectButton.Margin = new Padding(0);
            AddressTextBoxSelectButton.Text = "∙∙∙";
            AddressTextBoxSelectButton.Click += new System.EventHandler(this.AddressTextBoxButton_Click);

            panel.Controls.Add(AddressTextBoxSelectButton);
            panel.Controls.Add(AddressTextBoxClearButton);
            AddressTextBox.Controls.Add(panel);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(AddressTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(panel.Width << 16));

            BirthDateDateTimePicker.AddClearButton();
            DocumentDateDateTimePicker.AddClearButton();
            base.OnLoad(e);
        }

        void BirthDatePickerClearButton_Click(object sender, EventArgs e)
        {
            BirthDateDateTimePicker.Value = DateTime.MinValue;
        }

        void AddressTextBoxClearButton_Click(object sender, EventArgs e)
        {
            AddressTextBox.Clear();
            CodeTextBox.Clear();
            exempt.house = null;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (validateIDTextBox())
            {
                if (this.exempt.house != null)
                {
                    HouseDAO hDAO = new HouseDAO();
                    exempt.houseId = hDAO.saveHouse(this.exempt.house);
                }
                setDataForSave();
                ExemptDAO eDAO = new ExemptDAO();
                if (exemptId == null)
                {
                    exemptId = eDAO.insertExempt(exempt);
                    exempt.id = exemptId;
                }
                else
                {
                    eDAO.updateExempt(exempt);
                }
                ExemptHouseroomDAO ehDAO = new ExemptHouseroomDAO();
                exemptHouseroom.exemtId = exemptId;
                if (exemptHouseroom.id == null)
                    ehDAO.insertExemptHouseRoom(exemptHouseroom);
                else
                {
                    ehDAO.updateExemptHouseroom(exemptHouseroom);
                }
                setViewData();
                panel1.Hide();
                panel2.Show();
                refreshTable = true;
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddressTextBoxButton_Click(object sender, EventArgs e)
        {
            AddEditHouseForm f;
            if (exempt.house != null)
                f = new AddEditHouseForm(exempt.house);
            else
                f = new AddEditHouseForm(null);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                this.exempt.house = f.ReturnData();
                AddressTextBox.Text = exempt.house.fullAddress;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            setEditData();
            panel1.Show();
            panel2.Hide();
        }

        private void AddressTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(AddressTextBox.Text))
            {
                AddressTextBoxClearButton.Hide();
            }
            else
            {
                AddressTextBoxClearButton.Show();
            }
        }

        private void IDTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void SNILSTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !e.KeyChar.Equals('-'))
            {
                e.Handled = true;
            }
        }

        private void TotalAreaTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !e.KeyChar.Equals(','))
                e.Handled = true;
            if (e.KeyChar.Equals(',') && (sender as TextBox).Text.IndexOf(',') > -1)
                e.Handled = true;
        }

        private bool validateIDTextBox()
        {
            if (exemptId.ToString() != IDTextBox.Text)
            {
                ExemptDAO eDAO = new ExemptDAO();
                Exempt e = eDAO.getExemptById(Convert.ToInt32(IDTextBox.Text));
                if (e.id != null)
                {
                    IDTextBox.Size = new Size(IDTextBox.Width - 20, 20);
                    IDTextBox.Anchor = ((AnchorStyles)((AnchorStyles.Left)));
                    IDErrorProvider.SetError(IDTextBox, "Запись с таким идентификатором уже существует!");
                    return false;
                }
                else
                {
                    IDTextBox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                    IDErrorProvider.SetError(IDTextBox, null);
                    return true;
                }
            }
            else
            {
                IDTextBox.Anchor = ((AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right)));
                IDErrorProvider.SetError(IDTextBox, null);
                return true;
            }
        }

        private void IDTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(IDErrorProvider.GetError(IDTextBox)))
            {
                validateIDTextBox();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPageIndex == 1)
            {
                setFamilyPageViewData();
            }
            else if (e.TabPageIndex == 2)
            {
                setServicePageViewData();
            }
        }

        private void setFamilyPageViewData()
        {
            IDValue2.Text = exempt.id.ToString();
            if (exempt.createDate != DateTime.MinValue)
                CreateDateValue2.Text = exempt.createDate.ToString("dd.MM.yyyy");
            PersonalAccountValue2.Text = exempt.personalAccount;
            LastNameValue2.Text = exempt.lastName;
            NameValue2.Text = exempt.name;
            MiddleNameValue2.Text = exempt.middleName;
            if (exempt.house != null)
            {
                AddressValue2.Text = exempt.house.fullAddress;
                CodeValue2.Text = exempt.house.code;
            }
            LoadFamilyMembers();
        }

        private void setServicePageViewData()
        {
            IDValue3.Text = exempt.id.ToString();
            if (exempt.createDate != DateTime.MinValue)
                CreateDateValue3.Text = exempt.createDate.ToString("dd.MM.yyyy");
            PersonalAccountValue3.Text = exempt.personalAccount;
            LastNameValue3.Text = exempt.lastName;
            NameValue3.Text = exempt.name;
            MiddleNameValue3.Text = exempt.middleName;
            if (exempt.house != null)
            {
                AddressValue3.Text = exempt.house.fullAddress;
                CodeValue3.Text = exempt.house.code;
            }
        }

        private void AddMember_Click(object sender, EventArgs e)
        {
            AddEditViewFamilyMember f = new AddEditViewFamilyMember(null, exempt);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadFamilyMembers();
            }
        }

        private void AddEditViewExemptForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (refreshTable)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void LoadFamilyMembers()
        {
            if (exempt.id != null)
            {
                FamilyMembersDAO fmDAO = new FamilyMembersDAO();
                FamilyMemberListGrid.DataSource = fmDAO.getExemptFamilyMembers(exempt.id.Value);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (exempt.id == null && tabControl1.SelectedTab != generalPage)
            {
                tabControl1.SelectedTab = generalPage;
                DialogResult result = MessageBox.Show("Необходимо сохранить данные на вкладке \"Общее\"!",
                "Ошибка",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }
            else if (tabControl1.SelectedTab == ServicePage && SearchYearComboBox.Items.Count <= 0)
            {
                setYearComboBoxItems();
            }
        }

        private void FamilyMemberListGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddEditViewFamilyMember f = new AddEditViewFamilyMember(Convert.ToInt32(FamilyMemberListGrid.Rows[e.RowIndex].Cells["id"].Value), exempt);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadFamilyMembers();
            }
        }

        private void setYearComboBoxItems()
        {
            for (int i = 2000; i <= DateTime.Now.Year + 1; i++)
            {
                SearchYearComboBox.Items.Add(i);
                SearchYearComboBox.SelectedItem = DateTime.Now.Year;
            }

        }

        private void SearchYearComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedYear = Convert.ToInt32(SearchYearComboBox.SelectedItem);
            ExemptServiceDAO esDAO = new ExemptServiceDAO();
            DataTable dt = esDAO.getExemptServicesByExemptIdAndYear(exempt.id.Value, selectedYear);
            if (dt == null || dt.Rows.Count <= 0)
            {
                esDAO.insertExemptServicesByYear(exempt.id.Value, selectedYear);
                dt = esDAO.getExemptServicesByExemptIdAndYear(exempt.id.Value, selectedYear);
            }
            ServiceDataGridView.DataSource = dt;
        }

        private void ServiceDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            EditViewCalculationDetails f = new EditViewCalculationDetails(Convert.ToInt32(ServiceDataGridView.Rows[e.RowIndex].Cells["id1"].Value), exempt);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                SearchYearComboBox_SelectedIndexChanged(sender, null);
            }
        }

        private void HousingTypeComboBox_TextChanged(object sender, EventArgs e)
        {
            (sender as ComboBox).DroppedDown = false;
        }
    }
}
