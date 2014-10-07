using DatabaseLib;
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
    public partial class AddEditKladrForm : Form
    {
        private SQLiteConnection dbConnection;
        private string SelectedAddressGuid;

        public AddEditKladrForm(SQLiteConnection dbConnection, string SelectedAddressGuid)
        {
            this.dbConnection = dbConnection;
            this.SelectedAddressGuid = SelectedAddressGuid;

            InitializeComponent();

            NameErrorProvider.SetIconAlignment(NameTextBox, ErrorIconAlignment.MiddleRight);
            TypeErrorProvider.SetIconAlignment(TypeComboBox, ErrorIconAlignment.MiddleRight);
            TypeBriefErrorProvider.SetIconAlignment(TypeBriefComboBox, ErrorIconAlignment.MiddleRight);
            CodeErrorProvider.SetIconAlignment(CodeTextBox, ErrorIconAlignment.MiddleRight);

            string getTypes =
                "select ID, NAME "
                + "from VOC_LEVEL "
                + "where ID > (select AOLEVEL from VOC_ADDRESS_OBJECT where CURRSTATUS = 0 and AOGUID = '" + SelectedAddressGuid + "') "
                + "order by ID ASC";
            SQLiteDataAdapter da = new SQLiteDataAdapter(getTypes, dbConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            TypeComboBox.DataSource = ds.Tables[0].DefaultView;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren(ValidationConstraints.None))
            {
                DialogResult = DialogResult.None;
                return;
            }
            else
            {
                int codeLength = CodeTextBox.Text.Length;
                DbFacadeSQLite db = new DbFacadeSQLite(dbConnection);
                ParametersCollection parameters = new ParametersCollection();
                parameters.Add("aoguid", 0, System.Data.DbType.String);
                parameters.Add("formalname", NameTextBox.Text, System.Data.DbType.String);
                parameters.Add("regioncode", "21", System.Data.DbType.String);
                parameters.Add("autocode","" , System.Data.DbType.String);
                parameters.Add("areacode", CodeTextBox.Text.Substring(2, 3), System.Data.DbType.String);
                parameters.Add("citycode", CodeTextBox.Text.Substring(5, 3), System.Data.DbType.String);
                parameters.Add("ctarcode", "000", System.Data.DbType.String);
                parameters.Add("placecode", CodeTextBox.Text.Substring(8, 3), System.Data.DbType.String);
                if (codeLength == 17) {
                    parameters.Add("streetcode", CodeTextBox.Text.Substring(11, 4), System.Data.DbType.String);
                } else {
                    parameters.Add("streetcode", "0000", System.Data.DbType.String);
                }
                parameters.Add("extrcode", "0000", System.Data.DbType.String);
                parameters.Add("sextcode", "000", System.Data.DbType.String);
                parameters.Add("offname", NameTextBox.Text, System.Data.DbType.String);
                parameters.Add("updatedate", DateTime.Now, System.Data.DbType.Date);
                parameters.Add("shortname", TypeBriefComboBox.SelectedValue, System.Data.DbType.String);
                parameters.Add("aolevel", TypeComboBox.SelectedValue, System.Data.DbType.Int32);
                parameters.Add("parentguid", SelectedAddressGuid, System.Data.DbType.String);
                parameters.Add("aoid", Convert.ToInt32(db.Execute("select max(id) from VOC_ADDRESS_OBJECT").Rows[0][0]) + 1, System.Data.DbType.String);
                parameters.Add("code", CodeTextBox.Text, System.Data.DbType.String);
                parameters.Add("plaincode", CodeTextBox.Text.Substring(0, codeLength - 2), System.Data.DbType.String);
                parameters.Add("actstatus", 1, System.Data.DbType.Int32);
                parameters.Add("centstatus", 0, System.Data.DbType.Int32);
                parameters.Add("operstatus", 10, System.Data.DbType.Int32);
                parameters.Add("currstatus", CodeTextBox.Text.Substring(codeLength - 2, 2), System.Data.DbType.Int32);
                parameters.Add("startdate", DateTime.Now, System.Data.DbType.Date);
                parameters.Add("enddate", DateTime.Parse("2079-06-06"), System.Data.DbType.Date);
                parameters.Add("livestatus", 1, System.Data.DbType.Int32);
                db.Insert("VOC_ADDRESS_OBJECT", parameters);
                Close();
            }
        }

        private void NameTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                NameErrorProvider.SetError(NameTextBox, "Заполените поле!");
                e.Cancel = true;
            }
            else
            {
                NameErrorProvider.SetError(NameTextBox, null);
                e.Cancel = false;
            }
        }

        private void TypeComboBox_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
            {
                TypeErrorProvider.SetError(TypeComboBox, "Выберите значение из списка!");
                e.Cancel = true;
            }
            else
            {
                TypeErrorProvider.SetError(TypeComboBox, null);
                e.Cancel = false;
            }
        }

        private void TypeBriefComboBox_Validating(object sender, CancelEventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex == -1)
            {
                TypeBriefErrorProvider.SetError(TypeBriefComboBox, "Выберите значение из списка!");
                e.Cancel = true;
            }
            else
            {
                TypeBriefErrorProvider.SetError(TypeBriefComboBox, null);
                e.Cancel = false;
            }
        }

        private void CodeTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                CodeErrorProvider.SetError(CodeTextBox, "Заполените поле!");
                e.Cancel = true;
            }
            else
            {
                CodeErrorProvider.SetError(CodeTextBox, null);
                e.Cancel = false;
            }
        }

        private void TypeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string getTypeBriefs =
                "select SOCRNAME "
                + "from VOC_ADDRESS_TYPE "
                + "where LEVEL = " + (sender as ComboBox).SelectedValue + " "
                + "order by ID ASC";
            SQLiteDataAdapter da = new SQLiteDataAdapter(getTypeBriefs, dbConnection);
            DataSet ds = new DataSet();
            da.Fill(ds);
            TypeBriefComboBox.DataSource = ds.Tables[0].DefaultView;
        }
    }
}
