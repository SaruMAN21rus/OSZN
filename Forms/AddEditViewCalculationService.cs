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
    public partial class AddEditViewCalculationService : Form
    {
        private ExemptServiceDetail exemptServiceDetail;
        private bool refreshTable = false;

        public AddEditViewCalculationService(int? exemptServiceDetailId, ExemptService exemptService)
        {
            InitializeComponent();
            setServiceComboBoxValue();
            if (exemptServiceDetailId != null)
            {
                ExemptServiceDetailDAO esdDAO = new ExemptServiceDetailDAO();
                exemptServiceDetail = esdDAO.getExemptServiceById(exemptServiceDetailId.Value);
                setViewData();
                panel1.Hide();
                panel2.Show();
            }
            else
            {
                exemptServiceDetail = new ExemptServiceDetail();
                exemptServiceDetail.exemptService = exemptService;
                exemptServiceDetail.exemptServiceId = exemptService.id;
                panel1.Show();
                panel2.Hide();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            RecalculateStartDateTimePicker.AddClearButton();
            RecalculateEndDateTimePicker.AddClearButton();
            base.OnLoad(e);
        }

        private void setServiceComboBoxValue()
        {
            VocServiceDAO vsDAO = new VocServiceDAO();
            ServiceComboBox.DataSource = vsDAO.getVocServices("Активные");
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            setDataForSave();
            ExemptServiceDetailDAO esdDAO = new ExemptServiceDetailDAO();
            if (exemptServiceDetail.id == null)
                exemptServiceDetail.id = esdDAO.insertExemptServiceDetail(exemptServiceDetail);
            else
            {
                esdDAO.updateExemptServiceDetail(exemptServiceDetail);
            }
            setViewData();
            panel1.Hide();
            panel2.Show();
            refreshTable = true;
        }

        private void setDataForSave()
        {
            if (ServiceComboBox.SelectedIndex != -1)
            {
                exemptServiceDetail.vocServiceId = Convert.ToInt32(ServiceComboBox.SelectedValue);
                VocService vs = new VocService();
                vs.id = exemptServiceDetail.vocServiceId;
                vs.CodeName = ServiceComboBox.Text;
                exemptServiceDetail.vocService = vs;
            }
            else
            {
                exemptServiceDetail.vocServiceId = null;
                exemptServiceDetail.vocService = null;
            }
            if (!String.IsNullOrEmpty(RateTextBox.Text))
                exemptServiceDetail.rate = Convert.ToDecimal(RateTextBox.Text);
            else
                exemptServiceDetail.rate = null;
            if (!String.IsNullOrEmpty(NormTextBox.Text))
                exemptServiceDetail.norm = Convert.ToDecimal(NormTextBox.Text);
            else
                exemptServiceDetail.norm = null;
            if (!String.IsNullOrEmpty(VolumeTextBox.Text))
                exemptServiceDetail.volume = Convert.ToDecimal(VolumeTextBox.Text);
            else
                exemptServiceDetail.volume = null;
            if (ParameterComboBox.SelectedIndex != -1)
                exemptServiceDetail.parameter = ParameterComboBox.SelectedItem.ToString();
            else
                exemptServiceDetail.parameter = null;
            if (!String.IsNullOrEmpty(AccruedAmountTextBox.Text))
                exemptServiceDetail.accruedAmount = Convert.ToDecimal(AccruedAmountTextBox.Text);
            else
                exemptServiceDetail.accruedAmount = null;
            if (!String.IsNullOrEmpty(PenaltiesAmountTextBox.Text))
                exemptServiceDetail.penaltiesAmount = Convert.ToDecimal(PenaltiesAmountTextBox.Text);
            else
                exemptServiceDetail.penaltiesAmount = null;
            if (!String.IsNullOrEmpty(PaidAmountTextBox.Text))
                exemptServiceDetail.paidAmount = Convert.ToDecimal(PaidAmountTextBox.Text);
            else
                exemptServiceDetail.paidAmount = null;
            if (!String.IsNullOrEmpty(RecalculatedAmountTextBox.Text))
                exemptServiceDetail.recalculatedAmount = Convert.ToDecimal(RecalculatedAmountTextBox.Text);
            else
                exemptServiceDetail.recalculatedAmount = null;
            if (RecalculateStartDateTimePicker.Value != DateTime.MinValue)
                exemptServiceDetail.recalculateStartDate = RecalculateStartDateTimePicker.Value;
            else
                exemptServiceDetail.recalculateStartDate = null;
            if (RecalculateEndDateTimePicker.Value != DateTime.MinValue)
                exemptServiceDetail.recalculateEndDate = RecalculateEndDateTimePicker.Value;
            else
                exemptServiceDetail.recalculateEndDate = null;
        }

        private void RateTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !e.KeyChar.Equals(','))
                e.Handled = true;
            if (e.KeyChar.Equals(',') && (sender as TextBox).Text.IndexOf(',') > -1)
                e.Handled = true;
            if ((sender as TextBox).SelectionStart > (sender as TextBox).Text.Length - 2 && (sender as TextBox).Text.IndexOf(",") >= 0
                && (sender as TextBox).Text.IndexOf(",") + 3 == (sender as TextBox).Text.Length && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void VolumeTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !e.KeyChar.Equals(','))
                e.Handled = true;
            if (e.KeyChar.Equals(',') && (sender as TextBox).Text.IndexOf(',') > -1)
                e.Handled = true;
            if ((sender as TextBox).SelectionStart > (sender as TextBox).Text.Length - 4 && (sender as TextBox).Text.IndexOf(",") >= 0
                && (sender as TextBox).Text.IndexOf(",") + 5 == (sender as TextBox).Text.Length && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void PaidAmountTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar) && !e.KeyChar.Equals(',') && !e.KeyChar.Equals('-'))
                e.Handled = true;
            if (e.KeyChar.Equals(',') && (sender as TextBox).Text.IndexOf(',') > -1)
                e.Handled = true;
            if (e.KeyChar.Equals('-') && (sender as TextBox).Text.Length > 0)
                e.Handled = true;
            if ((sender as TextBox).SelectionStart > (sender as TextBox).Text.Length - 2 && (sender as TextBox).Text.IndexOf(",") >= 0
                && (sender as TextBox).Text.IndexOf(",") + 3 == (sender as TextBox).Text.Length && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void AddEditViewCalculationService_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (refreshTable)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            setEditData();
            panel1.Show();
            panel2.Hide();
        }

        private void ComboBox_TextChanged(object sender, EventArgs e)
        {
            (sender as ComboBox).DroppedDown = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите удалить эту запись?",
                "Удаление записи",
                MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
            if (result == DialogResult.Yes)
            {
                ExemptServiceDetailDAO esdDAO = new ExemptServiceDetailDAO();
                esdDAO.deleteExemptServiceDetail(exemptServiceDetail.id.Value);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void setViewData()
        {
            if (exemptServiceDetail.vocService != null)
                ServiceValue.Text = exemptServiceDetail.vocService.CodeName;
            else
                ServiceValue.Text = "";
            RateValue.Text = exemptServiceDetail.rate.ToString();
            NormValue.Text = exemptServiceDetail.norm.ToString();
            VolumeLabel.Text = exemptServiceDetail.volume.ToString();
            ParameterLabel.Text = exemptServiceDetail.parameter;
            AccruedAmountValue.Text = exemptServiceDetail.accruedAmount.ToString();
            PenaltiesAmountValue.Text = exemptServiceDetail.penaltiesAmount.ToString();
            PaidAmountValue.Text = exemptServiceDetail.paidAmount.ToString();
            RecalculatedAmountValue.Text = exemptServiceDetail.recalculatedAmount.ToString();
            if (exemptServiceDetail.recalculateStartDate != null)
                RecalculateStartDateValue.Text = exemptServiceDetail.recalculateStartDate.Value.ToString("dd.MM.yyyy");
            else
                RecalculateStartDateValue.Text = "";
            if (exemptServiceDetail.recalculateEndDate != null)
                RecalculateEndDateValue.Text = exemptServiceDetail.recalculateEndDate.Value.ToString("dd.MM.yyyy");
            else
                RecalculateEndDateValue.Text = "";
        }

        private void setEditData()
        {
            if (exemptServiceDetail.vocServiceId != null)
                ServiceComboBox.SelectedValue = exemptServiceDetail.vocServiceId;
            RateTextBox.Text = exemptServiceDetail.rate.ToString();
            NormTextBox.Text = exemptServiceDetail.norm.ToString();
            VolumeTextBox.Text = exemptServiceDetail.volume.ToString();
            ParameterComboBox.SelectedItem = exemptServiceDetail.parameter;
            AccruedAmountTextBox.Text = exemptServiceDetail.accruedAmount.ToString();
            PenaltiesAmountTextBox.Text = exemptServiceDetail.penaltiesAmount.ToString();
            PaidAmountTextBox.Text = exemptServiceDetail.paidAmount.ToString();
            RecalculatedAmountTextBox.Text = exemptServiceDetail.recalculatedAmount.ToString();
            if (exemptServiceDetail.recalculateStartDate != null)
                RecalculateStartDateTimePicker.Value = exemptServiceDetail.recalculateStartDate.Value;
            if (exemptServiceDetail.recalculateEndDate != null)
                RecalculateStartDateTimePicker.Value = exemptServiceDetail.recalculateEndDate.Value;
        }
    }
}
