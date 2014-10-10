using OSZN.DAO;
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

        private string recordGuid;
        private int recordId;

        public ViewKladrForm(string recordGuid)
        {
            this.recordGuid = recordGuid;
            InitializeComponent();
            SetFormValues();
        }

        private void SetFormValues()
        {
            VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
            Dictionary<string, object> ao = aoDAO.getAddressByAOGUID(this.recordGuid);
            NameValue.Text = ao["FORMALNAME"].ToString();
            TypeValue.Text = ao["NAME"].ToString();
            TypeBriefValue.Text = ao["SHORTNAME"].ToString();
            CodeValue.Text = ao["CODE"].ToString();
            recordId = Convert.ToInt32(ao["ID"]);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить этот адрес?",
                "Удаление записи",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                VocAddressObjectDAO aoDAO = new VocAddressObjectDAO();
                aoDAO.deleteAddressObject(recordId);
                this.DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            AddEditKladrForm addKladr = new AddEditKladrForm(this.recordGuid, true);
            if (addKladr.ShowDialog(this) == DialogResult.OK)
            {
            }
        }
    }
}
