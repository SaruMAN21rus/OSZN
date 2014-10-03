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
        SQLiteConnection dbConnection;
        
        
        public HeadForm()
        {
            connectToDatabase();
            InitializeComponent();
        }

        private void выгрузитьДанныеToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        void connectToDatabase()
        {
            dbConnection = new SQLiteConnection("Data Source=OSZN.sqlite;Version=3;");
            dbConnection.Open();
        }

        private void адресныйКлассификаторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KladrForm kForm = new KladrForm(dbConnection);
            kForm.Show();
        }
    }
}
