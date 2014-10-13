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
        House house;

        public AddEditViewExemptForm()
        {
            InitializeComponent();
            BirthDateDateTimePicker.CustomFormat = "''";
            BirthDateDateTimePicker.Format = DateTimePickerFormat.Custom;
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

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddressTextBoxButton_Click(object sender, EventArgs e)
        {
            AddEditHouseForm f;
            if (house != null)
                f = new AddEditHouseForm(house);
            else
                f = new AddEditHouseForm(null);
            f.ShowDialog();
            if (f.DialogResult == DialogResult.OK)
            {
                this.house = f.ReturnData();
                AddressTextBox.Text = house.fullAddress;
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
    }
}
