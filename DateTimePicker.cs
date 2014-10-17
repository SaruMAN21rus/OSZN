using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSZN
{
    class DateTimePicker : System.Windows.Forms.DateTimePicker
    {
        private DateTimePickerFormat oldFormat = DateTimePickerFormat.Short;
        private string oldCustomFormat = null;
        private bool bIsNull = false;
        private Button ClearButton;

        public DateTimePicker()
            : base()
        {
        }

        public void AddClearButton()
        {
            ClearButton = new Button();
            ClearButton.Size = new Size(18, 18);
            if (this.ClientSize.Height == 16)
                ClearButton.Location = new Point(this.ClientSize.Width - 52, -1);
            else
                ClearButton.Location = new Point(this.ClientSize.Width - 52, 1);
            ClearButton.BackColor = Color.Transparent;
            ClearButton.BackgroundImage = Properties.Resources.e10a_Cancel_48;
            ClearButton.BackgroundImageLayout = ImageLayout.Stretch;
            ClearButton.Cursor = Cursors.Default;
            ClearButton.FlatAppearance.BorderSize = 0;
            ClearButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            ClearButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            ClearButton.FlatStyle = FlatStyle.Flat;
            ClearButton.Margin = new Padding(0);
            ClearButton.UseVisualStyleBackColor = false;
            ClearButton.Anchor = AnchorStyles.Right;
            ClearButton.Click += ClearButton_Click;
            ToolTip BirthDatePickerClearButtonToolTip = new ToolTip();
            BirthDatePickerClearButtonToolTip.AutomaticDelay = 100;
            BirthDatePickerClearButtonToolTip.AutoPopDelay = 5000;
            BirthDatePickerClearButtonToolTip.SetToolTip(ClearButton, "Очистить");
            this.Controls.Add(ClearButton);
            this.Value = DateTime.MinValue;
            SendMessage(this.Handle, 0xd3, (IntPtr)2, (IntPtr)(ClearButton.Width << 16));
        }

        void ClearButton_Click(object sender, EventArgs e)
        {
            this.Value = DateTime.MinValue;
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        public new DateTime Value
        {
            get
            {
                if (bIsNull)
                    return DateTime.MinValue;
                else
                    return base.Value;
            }
            set
            {
                if (value == DateTime.MinValue)
                {
                    if (bIsNull == false)
                    {
                        oldFormat = this.Format;
                        oldCustomFormat = this.CustomFormat;
                        bIsNull = true;
                    }

                    this.Format = DateTimePickerFormat.Custom;
                    this.CustomFormat = " ";
                    if (ClearButton != null)
                        ClearButton.Hide();
                }
                else
                {
                    if (bIsNull)
                    {
                        this.Format = oldFormat;
                        this.CustomFormat = oldCustomFormat;
                        bIsNull = false;
                    }
                    base.Value = value;
                    if (ClearButton != null)
                        ClearButton.Show();
                }
            }
        }

        protected override void OnCloseUp(EventArgs eventargs)
        {
            if (Control.MouseButtons == MouseButtons.None)
            {
                if (bIsNull)
                {
                    this.Format = oldFormat;
                    this.CustomFormat = oldCustomFormat;
                    bIsNull = false;
                    if (ClearButton != null)
                        ClearButton.Show();
                }
            }
            base.OnCloseUp(eventargs);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            if (e.KeyCode == Keys.Delete)
                this.Value = DateTime.MinValue;
        }
    }
}
