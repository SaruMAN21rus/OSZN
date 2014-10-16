using OSZN.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSZN
{
    public partial class HeadForm : Form
    {           
        public HeadForm()
        {
            InitializeComponent();
        }

        private void выгрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void адресныйКлассификаторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KladrForm kForm = new KladrForm();
            kForm.ShowDialog();
        }

        private void льготникиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExemptListForm f = new ExemptListForm();
            f.ShowDialog();
        }

        private void организацияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditViewOrganizationForm f = new EditViewOrganizationForm();
            f.ShowDialog();
        }

        private void степеньРодстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RelationshipDegreeListForm f = new RelationshipDegreeListForm();
            f.ShowDialog();
        }

        private void организацияToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            EditViewOrganizationForm f = new EditViewOrganizationForm();
            f.ShowDialog();
        }

        private void услугиЖКХToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ServiceListForm f = new ServiceListForm();
            f.ShowDialog(this);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }
    }
}
