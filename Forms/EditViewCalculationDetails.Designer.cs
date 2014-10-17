namespace OSZN.Forms
{
    partial class EditViewCalculationDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Grid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Norm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServiceVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Parameter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AccruedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PenaltiesAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PaidAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RecalculatedAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.DocumentIssuerLabel = new System.Windows.Forms.Label();
            this.ExemptTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.PeriodDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel23 = new System.Windows.Forms.TableLayoutPanel();
            this.TotalAreaLabel = new System.Windows.Forms.Label();
            this.PenaltiesAmountTextBox = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel22 = new System.Windows.Forms.TableLayoutPanel();
            this.LivingAreaLabel = new System.Windows.Forms.Label();
            this.DebtMonthCount = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.PaymentAmountTextBox = new System.Windows.Forms.TextBox();
            this.PropertyTypeLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel21 = new System.Windows.Forms.TableLayoutPanel();
            this.DebtAmountTextBox = new System.Windows.Forms.TextBox();
            this.IsOwnerLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel20 = new System.Windows.Forms.TableLayoutPanel();
            this.PaymentDebtAmountTextBox = new System.Windows.Forms.TextBox();
            this.ResidentsCountLabel = new System.Windows.Forms.Label();
            this.CopyLastCalculateButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ResidentsCountTextBox = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).BeginInit();
            this.tableLayoutPanel15.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel23.SuspendLayout();
            this.tableLayoutPanel22.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            this.tableLayoutPanel21.SuspendLayout();
            this.tableLayoutPanel20.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(804, 362);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Grid, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel15, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel16, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel17, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CopyLastCalculateButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.AddButton, 0, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 362);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Grid
            // 
            this.Grid.AllowUserToAddRows = false;
            this.Grid.AllowUserToDeleteRows = false;
            this.Grid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.Grid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.Grid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.Grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.ServiceName,
            this.Rate,
            this.Norm,
            this.ServiceVolume,
            this.Parameter,
            this.AccruedAmount,
            this.PenaltiesAmount,
            this.PaidAmount,
            this.RecalculatedAmount});
            this.Grid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Grid.Location = new System.Drawing.Point(3, 177);
            this.Grid.Name = "Grid";
            this.Grid.ReadOnly = true;
            this.Grid.RowHeadersVisible = false;
            this.Grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.Grid.Size = new System.Drawing.Size(798, 153);
            this.Grid.TabIndex = 16;
            this.Grid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.Grid_CellDoubleClick);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // ServiceName
            // 
            this.ServiceName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ServiceName.DataPropertyName = "serviceName";
            this.ServiceName.FillWeight = 4F;
            this.ServiceName.HeaderText = "Услуга ЖКХ";
            this.ServiceName.MinimumWidth = 50;
            this.ServiceName.Name = "ServiceName";
            this.ServiceName.ReadOnly = true;
            // 
            // Rate
            // 
            this.Rate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Rate.DataPropertyName = "rate";
            this.Rate.FillWeight = 4F;
            this.Rate.HeaderText = "Тариф на ЖКУ";
            this.Rate.MinimumWidth = 50;
            this.Rate.Name = "Rate";
            this.Rate.ReadOnly = true;
            // 
            // Norm
            // 
            this.Norm.DataPropertyName = "norm";
            this.Norm.FillWeight = 4F;
            this.Norm.HeaderText = "Норматив";
            this.Norm.MinimumWidth = 80;
            this.Norm.Name = "Norm";
            this.Norm.ReadOnly = true;
            this.Norm.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Norm.Width = 80;
            // 
            // ServiceVolume
            // 
            this.ServiceVolume.DataPropertyName = "service_volume";
            this.ServiceVolume.FillWeight = 2F;
            this.ServiceVolume.HeaderText = "Объем услуги(факт)";
            this.ServiceVolume.Name = "ServiceVolume";
            this.ServiceVolume.ReadOnly = true;
            this.ServiceVolume.Width = 155;
            // 
            // Parameter
            // 
            this.Parameter.DataPropertyName = "parameter";
            this.Parameter.FillWeight = 2F;
            this.Parameter.HeaderText = "Параметр";
            this.Parameter.Name = "Parameter";
            this.Parameter.ReadOnly = true;
            this.Parameter.Width = 80;
            // 
            // AccruedAmount
            // 
            this.AccruedAmount.DataPropertyName = "accrued_amount";
            this.AccruedAmount.FillWeight = 3F;
            this.AccruedAmount.HeaderText = "Начислено";
            this.AccruedAmount.Name = "AccruedAmount";
            this.AccruedAmount.ReadOnly = true;
            this.AccruedAmount.Width = 80;
            // 
            // PenaltiesAmount
            // 
            this.PenaltiesAmount.DataPropertyName = "penalties_amount";
            this.PenaltiesAmount.HeaderText = "Начислено(пени)";
            this.PenaltiesAmount.Name = "PenaltiesAmount";
            this.PenaltiesAmount.ReadOnly = true;
            this.PenaltiesAmount.Width = 110;
            // 
            // PaidAmount
            // 
            this.PaidAmount.DataPropertyName = "paid_amount";
            this.PaidAmount.HeaderText = "Оплачено";
            this.PaidAmount.Name = "PaidAmount";
            this.PaidAmount.ReadOnly = true;
            this.PaidAmount.Width = 80;
            // 
            // RecalculatedAmount
            // 
            this.RecalculatedAmount.DataPropertyName = "recalculated_amount";
            this.RecalculatedAmount.HeaderText = "Перерасчет";
            this.RecalculatedAmount.Name = "RecalculatedAmount";
            this.RecalculatedAmount.ReadOnly = true;
            this.RecalculatedAmount.Width = 90;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 2;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Controls.Add(this.DocumentIssuerLabel, 0, 0);
            this.tableLayoutPanel15.Controls.Add(this.ExemptTextBox, 1, 0);
            this.tableLayoutPanel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel15.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel15.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 1;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(804, 29);
            this.tableLayoutPanel15.TabIndex = 10;
            // 
            // DocumentIssuerLabel
            // 
            this.DocumentIssuerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DocumentIssuerLabel.AutoSize = true;
            this.DocumentIssuerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DocumentIssuerLabel.Location = new System.Drawing.Point(3, 8);
            this.DocumentIssuerLabel.Name = "DocumentIssuerLabel";
            this.DocumentIssuerLabel.Size = new System.Drawing.Size(134, 13);
            this.DocumentIssuerLabel.TabIndex = 0;
            this.DocumentIssuerLabel.Text = "Начисление по:";
            // 
            // ExemptTextBox
            // 
            this.ExemptTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ExemptTextBox.Location = new System.Drawing.Point(143, 4);
            this.ExemptTextBox.Name = "ExemptTextBox";
            this.ExemptTextBox.ReadOnly = true;
            this.ExemptTextBox.Size = new System.Drawing.Size(658, 20);
            this.ExemptTextBox.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.CloseButton);
            this.flowLayoutPanel1.Controls.Add(this.SaveButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 333);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(804, 29);
            this.flowLayoutPanel1.TabIndex = 2;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(726, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(640, 3);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(80, 23);
            this.SaveButton.TabIndex = 0;
            this.SaveButton.Text = "Применить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 2;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(this.AddressLabel, 0, 0);
            this.tableLayoutPanel16.Controls.Add(this.PeriodDateTimePicker, 1, 0);
            this.tableLayoutPanel16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel16.Location = new System.Drawing.Point(0, 58);
            this.tableLayoutPanel16.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 1;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(804, 29);
            this.tableLayoutPanel16.TabIndex = 11;
            // 
            // AddressLabel
            // 
            this.AddressLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.AddressLabel.AutoSize = true;
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddressLabel.Location = new System.Drawing.Point(3, 8);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(134, 13);
            this.AddressLabel.TabIndex = 1;
            this.AddressLabel.Text = "Период начисления:";
            // 
            // PeriodDateTimePicker
            // 
            this.PeriodDateTimePicker.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.PeriodDateTimePicker.CustomFormat = "MMMM yyyy";
            this.PeriodDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.PeriodDateTimePicker.Location = new System.Drawing.Point(143, 4);
            this.PeriodDateTimePicker.Name = "PeriodDateTimePicker";
            this.PeriodDateTimePicker.ShowUpDown = true;
            this.PeriodDateTimePicker.Size = new System.Drawing.Size(106, 20);
            this.PeriodDateTimePicker.TabIndex = 2;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 3;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.19352F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.80649F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 324F));
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel23, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel22, 0, 1);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel19, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel21, 1, 0);
            this.tableLayoutPanel17.Controls.Add(this.tableLayoutPanel20, 2, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(0, 87);
            this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(804, 58);
            this.tableLayoutPanel17.TabIndex = 12;
            // 
            // tableLayoutPanel23
            // 
            this.tableLayoutPanel23.ColumnCount = 2;
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel23.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.Controls.Add(this.TotalAreaLabel, 0, 0);
            this.tableLayoutPanel23.Controls.Add(this.PenaltiesAmountTextBox, 1, 0);
            this.tableLayoutPanel23.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel23.Location = new System.Drawing.Point(0, 29);
            this.tableLayoutPanel23.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel23.Name = "tableLayoutPanel23";
            this.tableLayoutPanel23.RowCount = 1;
            this.tableLayoutPanel23.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel23.Size = new System.Drawing.Size(207, 29);
            this.tableLayoutPanel23.TabIndex = 14;
            // 
            // TotalAreaLabel
            // 
            this.TotalAreaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TotalAreaLabel.AutoSize = true;
            this.TotalAreaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TotalAreaLabel.Location = new System.Drawing.Point(3, 8);
            this.TotalAreaLabel.Name = "TotalAreaLabel";
            this.TotalAreaLabel.Size = new System.Drawing.Size(134, 13);
            this.TotalAreaLabel.TabIndex = 0;
            this.TotalAreaLabel.Text = "Сумма пени:";
            // 
            // PenaltiesAmountTextBox
            // 
            this.PenaltiesAmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PenaltiesAmountTextBox.Location = new System.Drawing.Point(143, 4);
            this.PenaltiesAmountTextBox.Name = "PenaltiesAmountTextBox";
            this.PenaltiesAmountTextBox.Size = new System.Drawing.Size(61, 20);
            this.PenaltiesAmountTextBox.TabIndex = 4;
            this.PenaltiesAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaymentAmountTextBox_KeyPress);
            // 
            // tableLayoutPanel22
            // 
            this.tableLayoutPanel22.ColumnCount = 2;
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this.tableLayoutPanel22.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.Controls.Add(this.LivingAreaLabel, 0, 0);
            this.tableLayoutPanel22.Controls.Add(this.DebtMonthCount, 1, 0);
            this.tableLayoutPanel22.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel22.Location = new System.Drawing.Point(207, 29);
            this.tableLayoutPanel22.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel22.Name = "tableLayoutPanel22";
            this.tableLayoutPanel22.RowCount = 1;
            this.tableLayoutPanel22.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel22.Size = new System.Drawing.Size(272, 29);
            this.tableLayoutPanel22.TabIndex = 13;
            // 
            // LivingAreaLabel
            // 
            this.LivingAreaLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LivingAreaLabel.AutoSize = true;
            this.LivingAreaLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LivingAreaLabel.Location = new System.Drawing.Point(20, 8);
            this.LivingAreaLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.LivingAreaLabel.Name = "LivingAreaLabel";
            this.LivingAreaLabel.Size = new System.Drawing.Size(207, 13);
            this.LivingAreaLabel.TabIndex = 0;
            this.LivingAreaLabel.Text = "Кол-во месяцев задолженности:";
            // 
            // DebtMonthCount
            // 
            this.DebtMonthCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DebtMonthCount.Location = new System.Drawing.Point(233, 4);
            this.DebtMonthCount.Name = "DebtMonthCount";
            this.DebtMonthCount.Size = new System.Drawing.Size(36, 20);
            this.DebtMonthCount.TabIndex = 4;
            this.DebtMonthCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DebtMonthCount_KeyPress);
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 2;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 140F));
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Controls.Add(this.PaymentAmountTextBox, 0, 0);
            this.tableLayoutPanel19.Controls.Add(this.PropertyTypeLabel, 0, 0);
            this.tableLayoutPanel19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel19.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel19.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 1;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(207, 29);
            this.tableLayoutPanel19.TabIndex = 10;
            // 
            // PaymentAmountTextBox
            // 
            this.PaymentAmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PaymentAmountTextBox.Location = new System.Drawing.Point(143, 4);
            this.PaymentAmountTextBox.Name = "PaymentAmountTextBox";
            this.PaymentAmountTextBox.Size = new System.Drawing.Size(61, 20);
            this.PaymentAmountTextBox.TabIndex = 5;
            this.PaymentAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaymentAmountTextBox_KeyPress);
            // 
            // PropertyTypeLabel
            // 
            this.PropertyTypeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PropertyTypeLabel.AutoSize = true;
            this.PropertyTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PropertyTypeLabel.Location = new System.Drawing.Point(3, 8);
            this.PropertyTypeLabel.Name = "PropertyTypeLabel";
            this.PropertyTypeLabel.Size = new System.Drawing.Size(134, 13);
            this.PropertyTypeLabel.TabIndex = 0;
            this.PropertyTypeLabel.Text = "Сумма оплаты:";
            // 
            // tableLayoutPanel21
            // 
            this.tableLayoutPanel21.ColumnCount = 2;
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 170F));
            this.tableLayoutPanel21.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.Controls.Add(this.DebtAmountTextBox, 0, 0);
            this.tableLayoutPanel21.Controls.Add(this.IsOwnerLabel, 0, 0);
            this.tableLayoutPanel21.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel21.Location = new System.Drawing.Point(207, 0);
            this.tableLayoutPanel21.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel21.Name = "tableLayoutPanel21";
            this.tableLayoutPanel21.RowCount = 1;
            this.tableLayoutPanel21.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel21.Size = new System.Drawing.Size(272, 29);
            this.tableLayoutPanel21.TabIndex = 12;
            // 
            // DebtAmountTextBox
            // 
            this.DebtAmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DebtAmountTextBox.Location = new System.Drawing.Point(173, 4);
            this.DebtAmountTextBox.Name = "DebtAmountTextBox";
            this.DebtAmountTextBox.Size = new System.Drawing.Size(96, 20);
            this.DebtAmountTextBox.TabIndex = 5;
            this.DebtAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaymentAmountTextBox_KeyPress);
            // 
            // IsOwnerLabel
            // 
            this.IsOwnerLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.IsOwnerLabel.AutoSize = true;
            this.IsOwnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IsOwnerLabel.Location = new System.Drawing.Point(20, 8);
            this.IsOwnerLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.IsOwnerLabel.Name = "IsOwnerLabel";
            this.IsOwnerLabel.Size = new System.Drawing.Size(147, 13);
            this.IsOwnerLabel.TabIndex = 0;
            this.IsOwnerLabel.Text = "Сумма задолженности:";
            // 
            // tableLayoutPanel20
            // 
            this.tableLayoutPanel20.ColumnCount = 2;
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel20.Controls.Add(this.PaymentDebtAmountTextBox, 0, 0);
            this.tableLayoutPanel20.Controls.Add(this.ResidentsCountLabel, 0, 0);
            this.tableLayoutPanel20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel20.Location = new System.Drawing.Point(479, 0);
            this.tableLayoutPanel20.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel20.Name = "tableLayoutPanel20";
            this.tableLayoutPanel20.RowCount = 1;
            this.tableLayoutPanel20.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel20.Size = new System.Drawing.Size(325, 29);
            this.tableLayoutPanel20.TabIndex = 11;
            // 
            // PaymentDebtAmountTextBox
            // 
            this.PaymentDebtAmountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.PaymentDebtAmountTextBox.Location = new System.Drawing.Point(248, 4);
            this.PaymentDebtAmountTextBox.Name = "PaymentDebtAmountTextBox";
            this.PaymentDebtAmountTextBox.Size = new System.Drawing.Size(74, 20);
            this.PaymentDebtAmountTextBox.TabIndex = 5;
            this.PaymentDebtAmountTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.PaymentAmountTextBox_KeyPress);
            // 
            // ResidentsCountLabel
            // 
            this.ResidentsCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ResidentsCountLabel.AutoSize = true;
            this.ResidentsCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ResidentsCountLabel.Location = new System.Drawing.Point(20, 8);
            this.ResidentsCountLabel.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.ResidentsCountLabel.Name = "ResidentsCountLabel";
            this.ResidentsCountLabel.Size = new System.Drawing.Size(222, 13);
            this.ResidentsCountLabel.TabIndex = 0;
            this.ResidentsCountLabel.Text = "Внесенная оплата задолженности:";
            this.ResidentsCountLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CopyLastCalculateButton
            // 
            this.CopyLastCalculateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CopyLastCalculateButton.Location = new System.Drawing.Point(3, 3);
            this.CopyLastCalculateButton.Name = "CopyLastCalculateButton";
            this.CopyLastCalculateButton.Size = new System.Drawing.Size(250, 23);
            this.CopyLastCalculateButton.TabIndex = 14;
            this.CopyLastCalculateButton.Text = "Копировать с предыдущего начисления";
            this.CopyLastCalculateButton.UseVisualStyleBackColor = true;
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(3, 148);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(75, 23);
            this.AddButton.TabIndex = 15;
            this.AddButton.Text = "Добавить";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // ResidentsCountTextBox
            // 
            this.ResidentsCountTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ResidentsCountTextBox.Location = new System.Drawing.Point(245, 3);
            this.ResidentsCountTextBox.Name = "ResidentsCountTextBox";
            this.ResidentsCountTextBox.Size = new System.Drawing.Size(74, 20);
            this.ResidentsCountTextBox.TabIndex = 5;
            // 
            // EditViewCalculationDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 362);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(820, 300);
            this.Name = "EditViewCalculationDetails";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ввод данных о расчетах за коммунальные услуги за период";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EditViewCalculationDetails_FormClosed);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Grid)).EndInit();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel23.ResumeLayout(false);
            this.tableLayoutPanel23.PerformLayout();
            this.tableLayoutPanel22.ResumeLayout(false);
            this.tableLayoutPanel22.PerformLayout();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
            this.tableLayoutPanel21.ResumeLayout(false);
            this.tableLayoutPanel21.PerformLayout();
            this.tableLayoutPanel20.ResumeLayout(false);
            this.tableLayoutPanel20.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel15;
        private System.Windows.Forms.Label DocumentIssuerLabel;
        private System.Windows.Forms.TextBox ExemptTextBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel16;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel23;
        private System.Windows.Forms.Label TotalAreaLabel;
        private System.Windows.Forms.TextBox PenaltiesAmountTextBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel22;
        private System.Windows.Forms.Label LivingAreaLabel;
        private System.Windows.Forms.TextBox DebtMonthCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel20;
        private System.Windows.Forms.TextBox ResidentsCountTextBox;
        private System.Windows.Forms.Label ResidentsCountLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel19;
        private System.Windows.Forms.Label PropertyTypeLabel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel21;
        private System.Windows.Forms.Label IsOwnerLabel;
        private System.Windows.Forms.DateTimePicker PeriodDateTimePicker;
        private System.Windows.Forms.Button CopyLastCalculateButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.DataGridView Grid;
        private System.Windows.Forms.TextBox PaymentAmountTextBox;
        private System.Windows.Forms.TextBox DebtAmountTextBox;
        private System.Windows.Forms.TextBox PaymentDebtAmountTextBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Norm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServiceVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Parameter;
        private System.Windows.Forms.DataGridViewTextBoxColumn AccruedAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PenaltiesAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn PaidAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn RecalculatedAmount;
    }
}