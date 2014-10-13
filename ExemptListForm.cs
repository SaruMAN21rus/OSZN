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
    public partial class ExemptListForm : Form
    {
        public ExemptListForm()
        {
            InitializeComponent();
        }

        private void AddButon_Click(object sender, EventArgs e)
        {
            AddEditViewExemptForm f = new AddEditViewExemptForm();
            f.ShowDialog();
        }
    }
}
