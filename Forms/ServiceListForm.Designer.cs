namespace OSZN.Forms
{
    partial class ServiceListForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.ServiceListGrid = new System.Windows.Forms.DataGridView();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.AddButon = new System.Windows.Forms.Button();
            this.SearchComboBox = new System.Windows.Forms.ComboBox();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Сode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Direction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NormBaseUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ServiceListGrid)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.ServiceListGrid, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.flowLayoutPanel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(715, 362);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // ServiceListGrid
            // 
            this.ServiceListGrid.AllowUserToAddRows = false;
            this.ServiceListGrid.AllowUserToDeleteRows = false;
            this.ServiceListGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ServiceListGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ServiceListGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.ServiceListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ServiceListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.Сode,
            this.name,
            this.Direction,
            this.Unit,
            this.NormBaseUnit});
            this.ServiceListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServiceListGrid.Location = new System.Drawing.Point(5, 45);
            this.ServiceListGrid.Margin = new System.Windows.Forms.Padding(5);
            this.ServiceListGrid.MultiSelect = false;
            this.ServiceListGrid.Name = "ServiceListGrid";
            this.ServiceListGrid.ReadOnly = true;
            this.ServiceListGrid.RowHeadersVisible = false;
            this.ServiceListGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.ServiceListGrid.Size = new System.Drawing.Size(705, 312);
            this.ServiceListGrid.TabIndex = 6;
            this.ServiceListGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ServiceListGrid_CellDoubleClick);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.AddButon);
            this.flowLayoutPanel1.Controls.Add(this.SearchComboBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(715, 40);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // AddButon
            // 
            this.AddButon.Location = new System.Drawing.Point(5, 10);
            this.AddButon.Margin = new System.Windows.Forms.Padding(5, 10, 5, 5);
            this.AddButon.Name = "AddButon";
            this.AddButon.Size = new System.Drawing.Size(97, 24);
            this.AddButon.TabIndex = 1;
            this.AddButon.Text = "Добавить";
            this.AddButon.UseVisualStyleBackColor = true;
            this.AddButon.Click += new System.EventHandler(this.AddButon_Click);
            // 
            // SearchComboBox
            // 
            this.SearchComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.SearchComboBox.FormattingEnabled = true;
            this.SearchComboBox.IntegralHeight = false;
            this.SearchComboBox.ItemHeight = 13;
            this.SearchComboBox.Items.AddRange(new object[] {
            "Все",
            "Активные",
            "Удаленные"});
            this.SearchComboBox.Location = new System.Drawing.Point(113, 11);
            this.SearchComboBox.Margin = new System.Windows.Forms.Padding(6, 11, 6, 6);
            this.SearchComboBox.Name = "SearchComboBox";
            this.SearchComboBox.Size = new System.Drawing.Size(121, 21);
            this.SearchComboBox.TabIndex = 3;
            this.SearchComboBox.SelectedIndexChanged += new System.EventHandler(this.SearchComboBox_SelectedIndexChanged_1);
            // 
            // id
            // 
            this.id.DataPropertyName = "id";
            this.id.HeaderText = "id";
            this.id.MinimumWidth = 50;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            this.id.Width = 80;
            // 
            // Сode
            // 
            this.Сode.DataPropertyName = "code";
            this.Сode.HeaderText = "Код";
            this.Сode.Name = "Сode";
            this.Сode.ReadOnly = true;
            this.Сode.Width = 80;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "name";
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // Direction
            // 
            this.Direction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Direction.DataPropertyName = "direction";
            this.Direction.HeaderText = "Направление услуги";
            this.Direction.Name = "Direction";
            this.Direction.ReadOnly = true;
            // 
            // Unit
            // 
            this.Unit.DataPropertyName = "unit_name";
            this.Unit.HeaderText = "ЕИ";
            this.Unit.Name = "Unit";
            this.Unit.ReadOnly = true;
            // 
            // NormBaseUnit
            // 
            this.NormBaseUnit.DataPropertyName = "norm_base_unit_name";
            this.NormBaseUnit.HeaderText = "ЕИ базы для номатива";
            this.NormBaseUnit.Name = "NormBaseUnit";
            this.NormBaseUnit.ReadOnly = true;
            // 
            // ServiceListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 362);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(470, 200);
            this.Name = "ServiceListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Услуги ЖКХ";
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ServiceListGrid)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView ServiceListGrid;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button AddButon;
        private System.Windows.Forms.ComboBox SearchComboBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Сode;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn Direction;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unit;
        private System.Windows.Forms.DataGridViewTextBoxColumn NormBaseUnit;

    }
}