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
    public partial class AddEditViewExemptForm : Form
    {
        Exempt exempt;
        int? exemptId;

        public AddEditViewExemptForm(int? exemptId)
        {
            this.exemptId = exemptId;
            InitializeComponent();
            BirthDateDateTimePicker.CustomFormat = "''";
            BirthDateDateTimePicker.Format = DateTimePickerFormat.Custom;
            if (exemptId != null)
            {
                ExemptDAO eDAO = new ExemptDAO();
                exempt = eDAO.getExemptById(exemptId.Value);
                setViewData();
                panel1.Hide();
                panel2.Show();
            }
            else
            {
                exempt = new Exempt();
                CreateDateTextBox.Text = DateTime.Now.ToString("dd.MM.yyyy");
                panel1.Show();
                panel2.Hide();
            }
        }

        private void setViewData()
        {
            IDValue.Text = exempt.id.ToString();
            if (exempt.createDate != DateTime.MinValue)
                CreateDateValue.Text = exempt.createDate.ToString("dd.MM.yyyy");
            PersonalAccountValue.Text = exempt.personalAccount;
            LastNameValue.Text = exempt.lastName;
            NameValue.Text = exempt.name;
            MidleNameValue.Text = exempt.middleName;
            if (exempt.birthDate != DateTime.MinValue)
                BirthDateValue.Text = exempt.birthDate.ToString("dd.MM.yyyy");
            SexValue.Text = exempt.sex;
            SNILSValue.Text = exempt.SNILS;
            DocumentNameValue.Text = exempt.documentName;
            DocumentSeriesValue.Text = exempt.documentSeries;
            DocumentNumberValue.Text = exempt.documentNumber;
            if (exempt.documentDate != DateTime.MinValue)
                DocumentDateValue.Text = exempt.documentDate.ToString("dd.MM.yyyy");
            DocumentIssuerValue.Text = exempt.documentIssuer;
            AddressValue.Text = exempt.house.fullAddress;
            CodeValue.Text = exempt.house.code;

        }

        private void setDataForSave()
        {
            if (!String.IsNullOrEmpty(IDTextBox.Text))
                exempt.id = Convert.ToInt32(IDTextBox.Text);
            if (!String.IsNullOrEmpty(IDTextBox.Text))
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
                exempt.birthDate = DateTime.MinValue;
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
                exempt.documentDate = DateTime.MinValue;
            if (!String.IsNullOrEmpty(DocumentIssuerTextBox.Text))
                exempt.documentIssuer = DocumentIssuerTextBox.Text;
            else
                exempt.documentIssuer = null;
            if (String.IsNullOrEmpty(AddressTextBox.Text))
            {
                exempt.house = null;
                exempt.houseId = null;
            }
        }

        private void setEditData()
        {
            IDTextBox.Text = exempt.id.ToString();
            if (exempt.createDate != DateTime.MinValue)
                CreateDateTextBox.Text = exempt.createDate.ToString("dd.MM.yyyy");
            PersonalCodeTextBox.Text = exempt.personalAccount;
            LastNameTextBox.Text = exempt.lastName;
            NameTextBox.Text = exempt.name;
            MiddleNameTextBox.Text = exempt.middleName;
            if (exempt.birthDate != DateTime.MinValue)
                BirthDateDateTimePicker.Value = exempt.birthDate;
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
            if (exempt.documentDate != DateTime.MinValue)
                DocumentDateDateTimePicker.Value = exempt.documentDate;
            DocumentIssuerTextBox.Text = exempt.documentIssuer;
            AddressTextBox.Text = exempt.house.fullAddress;
            CodeTextBox.Text = exempt.house.code;

        }

        protected override void OnLoad(EventArgs e)
        {
            var btn = new Button();
            btn.Size = new Size(24, AddressTextBox.ClientSize.Height + 2);
            btn.Location = new Point(AddressTextBox.ClientSize.Width - btn.Width, -1);
            btn.Cursor = Cursors.Default;
            btn.Text = "∙∙∙";
            btn.Anchor = AnchorStyles.Right;
            AddressTextBox.Controls.Add(btn);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(AddressTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(btn.Width << 16));
            btn.Click += new System.EventHandler(this.AddressTextBoxButton_Click);
            base.OnLoad(e);
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (this.exempt.house != null)
            {
                HouseDAO hDAO = new HouseDAO();
                exempt.houseId = hDAO.saveHouse(this.exempt.house);
            }
            setDataForSave();
            ExemptDAO eDAO = new ExemptDAO();
            if (exemptId == null)
                eDAO.insertExempt(exempt);
            else
            {
                eDAO.updateExempt(exempt);
            }
            setViewData();
            panel1.Hide();
            panel2.Show();
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
                CodeTextBox.Text = exempt.house.code;
            }
        }

        private void BirthDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            BirthDateDateTimePicker.Format = DateTimePickerFormat.Short;
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
    }
}
