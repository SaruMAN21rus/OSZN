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
    public partial class ViewKladrForm : Form
    {
        private SQLiteConnection dbConnection;

        private string recordGuid;

        public ViewKladrForm(SQLiteConnection dbConnection, string recordGuid)
        {
            this.dbConnection = dbConnection;
            this.recordGuid = recordGuid;
            InitializeComponent();
            SetFormValues();
        }

        private void SetFormValues()
        {
            string getAddress =
                "select ao.FORMALNAME, ao.SHORTNAME, ao.CODE, l.NAME "
                + "from VOC_ADDRESS_OBJECT ao "
                + "left join VOC_LEVEL l on ao.AOLEVEL = l.ID "
                + "where CURRSTATUS = 0 and ao.AOGUID = '" + this.recordGuid + "'";
            SQLiteCommand command = new SQLiteCommand(getAddress, this.dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            reader.Read();
            NameValue.Text = reader.GetString(0);
            TypeValue.Text = reader.GetString(3);
            TypeBriefValue.Text = reader.GetString(1);
            CodeValue.Text = reader.GetString(2);
        }
    }
}
