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
    public partial class WaitWindow : Form
    {

        private RunWorkerCompletedEventArgs e;
        private Func<object, string> func;
        private object input;

        public WaitWindow(Func<object, string> func, object input)
        {
            this.func = func;
            if (input != null)
                this.input = input;
            else
                this.input = this;
            InitializeComponent();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            base.OnPaint(e);
            //	Paint a 3D border
            ControlPaint.DrawBorder3D(e.Graphics, this.ClientRectangle, Border3DStyle.Raised);
        }

        delegate void SetTextCallback(string message);

        public void SetMessage(string message)
        {
            if (this.MessageLabel.InvokeRequired)
            {
                var d = new SetTextCallback(SetMessage);
                Invoke(d, new object[] { message });
            }
            else
                this.MessageLabel.Text = message;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            e.Result = func(input);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.e = e;
            this.DialogResult = DialogResult.OK;
        }

        public RunWorkerCompletedEventArgs ReturnData()
        {
            return this.e;
        }
    }
}
