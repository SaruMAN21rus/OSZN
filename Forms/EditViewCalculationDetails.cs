using OSZN.DAO;
using OSZN.Model;
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
    public partial class EditViewCalculationDetails : Form
    {
        ExemptService exemptService;
        Exempt exempt;

        bool refreshTable = false;
        
        public EditViewCalculationDetails(int? exemptServiceId, Exempt exempt)
        {
            InitializeComponent();

            this.Grid.AutoGenerateColumns = false;

            this.exempt = exempt;
            if (exemptServiceId != null)
            {
                ExemptServiceDAO esDAO = new ExemptServiceDAO();
                exemptService = esDAO.getExemptServiceById(exemptServiceId.Value);
                setEditData();
                LoadServiceDetailes();
            }
            else
            {
                exemptService = new ExemptService();
                panel1.Show();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            setDataForSave();
            ExemptServiceDAO esDAO = new ExemptServiceDAO();
            esDAO.updateExemptServices(exemptService);
            refreshTable = true;
            Close();
        }

        private void EditViewCalculationDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (refreshTable)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void setEditData()
        {
            ExemptTextBox.Text = getExemptText();
            PeriodTextBox.Text = exemptService.period.ToString("MMMM yyyy");
            PaymentAmountTextBox.Text = exemptService.paymentAmount.ToString();
            PenaltiesAmountTextBox.Text = exemptService.penaltiesAmount.ToString();
            DebtAmountTextBox.Text = exemptService.debtAmount.ToString();
            DebtMonthCount.Text = exemptService.debtMonthCount.ToString();
            PaymentDebtAmountTextBox.Text = exemptService.paymentDebtAmount.ToString();
        }

        private string getExemptText()
        {
            string exemptStr = "";
            if (!String.IsNullOrEmpty(exempt.lastName))
                exemptStr += exempt.lastName;
            if (!String.IsNullOrEmpty(exempt.name))
                exemptStr += " " + exempt.name;
            if (!String.IsNullOrEmpty(exempt.middleName))
                exemptStr += " " + exempt.middleName;
            if (!String.IsNullOrEmpty(exempt.personalAccount))
                exemptStr += (String.IsNullOrEmpty(exemptStr) ? "л/с № " : ", л/с № ") + exempt.personalAccount;
            if (exempt.house != null)
                exemptStr += (String.IsNullOrEmpty(exemptStr) ? "" : ", ") + exempt.house.fullAddress;
            return exemptStr.Trim();
        }

        private void DebtMonthCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void PaymentAmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !e.KeyChar.Equals(','))
                e.Handled = true;
            if (e.KeyChar.Equals(',') && (sender as TextBox).Text.IndexOf(',') > -1)
                e.Handled = true;
            if ((sender as TextBox).SelectionStart > (sender as TextBox).Text.Length - 2 && (sender as TextBox).Text.IndexOf(",") >= 0
                && (sender as TextBox).Text.IndexOf(",") + 3 == (sender as TextBox).Text.Length && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void setDataForSave()
        {
            if (!String.IsNullOrEmpty(PaymentAmountTextBox.Text))
                exemptService.paymentAmount = Convert.ToDecimal(PaymentAmountTextBox.Text);
            else
                exemptService.paymentAmount = null;
            if (!String.IsNullOrEmpty(PenaltiesAmountTextBox.Text))
                exemptService.penaltiesAmount = Convert.ToDecimal(PenaltiesAmountTextBox.Text);
            else
                exemptService.penaltiesAmount = null;
            if (!String.IsNullOrEmpty(DebtAmountTextBox.Text))
                exemptService.debtAmount = Convert.ToDecimal(DebtAmountTextBox.Text);
            else
                exemptService.debtAmount = null;
            if (!String.IsNullOrEmpty(DebtMonthCount.Text))
                exemptService.debtMonthCount = Convert.ToInt32(DebtMonthCount.Text);
            else
                exemptService.debtMonthCount = null;
            if (!String.IsNullOrEmpty(PaymentDebtAmountTextBox.Text))
                exemptService.paymentDebtAmount = Convert.ToDecimal(PaymentDebtAmountTextBox.Text);
            else
                exemptService.paymentDebtAmount = null;
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            AddEditViewCalculationService f = new AddEditViewCalculationService(null, exemptService);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadServiceDetailes();
            }
        }

        private void LoadServiceDetailes()
        {
            ExemptServiceDetailDAO esdDAO = new ExemptServiceDetailDAO();
            Grid.DataSource = esdDAO.getExemptServiceDetailsByExemptServiceId(exemptService.id.Value);
        }

        private void Grid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddEditViewCalculationService f = new AddEditViewCalculationService(Convert.ToInt32(Grid.Rows[e.RowIndex].Cells["id"].Value), exemptService);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadServiceDetailes();
            }
        }

        private void CopyLastCalculateButton_Click(object sender, EventArgs e)
        {
            DateTime prevPeriod = exemptService.period.AddMonths(-1);
            ExemptServiceDAO esDAO = new ExemptServiceDAO();
            ExemptService prevService = esDAO.getExemptServiceByPeriodAndExemptId(prevPeriod, exempt.id.Value);
            exemptService.paymentAmount = prevService.paymentAmount;
            exemptService.paymentDebtAmount = prevService.paymentDebtAmount;
            exemptService.penaltiesAmount = prevService.penaltiesAmount;
            exemptService.debtAmount = prevService.debtAmount;
            exemptService.debtMonthCount = prevService.debtMonthCount;
            setEditData();
            ExemptServiceDetailDAO esdDAO = new ExemptServiceDetailDAO();
            DataTable exemptServiceDetails = esdDAO.getExemptServiceDetailsByExemptServiceId(prevService.id.Value);
            esdDAO.beginTransaction();
            foreach (DataRow row in exemptServiceDetails.Rows)
            {
                ExemptServiceDetail d = new ExemptServiceDetail();
                if (row["accrued_amount"] != null && !DBNull.Value.Equals(row["accrued_amount"]))
                    d.accruedAmount = Convert.ToDecimal(row["accrued_amount"]);
                d.exemptServiceId = exemptService.id;
                if (row["norm"] != null && !DBNull.Value.Equals(row["norm"]))
                    d.norm = Convert.ToDecimal(row["norm"]);
                if (row["paid_amount"] != null && !DBNull.Value.Equals(row["paid_amount"]))
                    d.paidAmount = Convert.ToDecimal(row["paid_amount"]);
                if (row["accrued_amount"] != null && !DBNull.Value.Equals(row["parameter"]))
                    d.parameter = row["parameter"].ToString();
                if (row["penalties_amount"] != null && !DBNull.Value.Equals(row["penalties_amount"]))
                    d.penaltiesAmount = Convert.ToDecimal(row["penalties_amount"]);
                if (row["accrued_amount"] != null && !DBNull.Value.Equals(row["rate"]))
                    d.rate = Convert.ToDecimal(row["rate"]);
                if (row["recalculated_amount"] != null && !DBNull.Value.Equals(row["recalculated_amount"]))
                    d.recalculatedAmount = Convert.ToDecimal(row["recalculated_amount"]);
                if (row["recalculate_end_date"] != null && !DBNull.Value.Equals(row["recalculate_end_date"]))
                    d.recalculateEndDate = Convert.ToDateTime(row["recalculate_end_date"]);
                if (row["recalculate_start_date"] != null && !DBNull.Value.Equals(row["recalculate_start_date"]))
                    d.recalculateStartDate = Convert.ToDateTime(row["recalculate_start_date"]);
                if (row["voc_service_id"] != null && !DBNull.Value.Equals(row["voc_service_id"]))
                    d.vocServiceId = Convert.ToInt32(row["voc_service_id"]);
                if (row["service_volume"] != null && !DBNull.Value.Equals(row["service_volume"]))
                    d.volume = Convert.ToDecimal(row["service_volume"]);
                esdDAO.insertExemptServiceDetail(d);
            }
            esdDAO.commitTransaction();
            LoadServiceDetailes();
        }
    }
}
