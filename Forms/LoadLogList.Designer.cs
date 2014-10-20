namespace OSZN.Forms
{
    partial class LoadLogList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.LoadButon = new System.Windows.Forms.Button();
            this.LoadLogListGrid = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FileName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RequestPeriod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ErrorText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LoadFolder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LoadLogListGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.LoadLogListGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(916, 376);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.LoadButon, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(910, 39);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // LoadButon
            // 
            this.LoadButon.Dock = System.Windows.Forms.DockStyle.Right;
            this.LoadButon.Location = new System.Drawing.Point(3, 10);
            this.LoadButon.Margin = new System.Windows.Forms.Padding(3, 10, 3, 3);
            this.LoadButon.Name = "LoadButon";
            this.LoadButon.Size = new System.Drawing.Size(100, 28);
            this.LoadButon.TabIndex = 0;
            this.LoadButon.Text = "Загрузить";
            this.LoadButon.UseVisualStyleBackColor = true;
            this.LoadButon.Click += new System.EventHandler(this.LoadButon_Click);
            // 
            // LoadLogListGrid
            // 
            this.LoadLogListGrid.AllowUserToAddRows = false;
            this.LoadLogListGrid.AllowUserToDeleteRows = false;
            this.LoadLogListGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.LoadLogListGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.LoadLogListGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.LoadLogListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.LoadLogListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.FileName,
            this.RequestPeriod,
            this.LoadDate,
            this.Status,
            this.ErrorText,
            this.LoadFolder});
            this.LoadLogListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoadLogListGrid.Location = new System.Drawing.Point(3, 48);
            this.LoadLogListGrid.MultiSelect = false;
            this.LoadLogListGrid.Name = "LoadLogListGrid";
            this.LoadLogListGrid.ReadOnly = true;
            this.LoadLogListGrid.RowHeadersVisible = false;
            this.LoadLogListGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.LoadLogListGrid.Size = new System.Drawing.Size(910, 325);
            this.LoadLogListGrid.TabIndex = 5;
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
            // FileName
            // 
            this.FileName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FileName.DataPropertyName = "file_name";
            this.FileName.HeaderText = "Название файла";
            this.FileName.MinimumWidth = 50;
            this.FileName.Name = "FileName";
            this.FileName.ReadOnly = true;
            // 
            // RequestPeriod
            // 
            this.RequestPeriod.DataPropertyName = "request_period";
            this.RequestPeriod.HeaderText = "Период запроса";
            this.RequestPeriod.MinimumWidth = 100;
            this.RequestPeriod.Name = "RequestPeriod";
            this.RequestPeriod.ReadOnly = true;
            this.RequestPeriod.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.RequestPeriod.Width = 160;
            // 
            // LoadDate
            // 
            this.LoadDate.DataPropertyName = "load_date";
            this.LoadDate.HeaderText = "Дата загрузки";
            this.LoadDate.Name = "LoadDate";
            this.LoadDate.ReadOnly = true;
            this.LoadDate.Width = 80;
            // 
            // Status
            // 
            this.Status.DataPropertyName = "status";
            this.Status.HeaderText = "Статус";
            this.Status.Name = "Status";
            this.Status.ReadOnly = true;
            // 
            // ErrorText
            // 
            this.ErrorText.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ErrorText.DataPropertyName = "error_text";
            this.ErrorText.HeaderText = "Протокол ошибок";
            this.ErrorText.Name = "ErrorText";
            this.ErrorText.ReadOnly = true;
            // 
            // LoadFolder
            // 
            this.LoadFolder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.LoadFolder.DataPropertyName = "load_folder";
            this.LoadFolder.HeaderText = "Путь загрузки";
            this.LoadFolder.Name = "LoadFolder";
            this.LoadFolder.ReadOnly = true;
            // 
            // LoadLogList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 376);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "LoadLogList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Протокол загрузки данных";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LoadLogListGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button LoadButon;
        private System.Windows.Forms.DataGridView LoadLogListGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn FileName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RequestPeriod;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoadDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.DataGridViewTextBoxColumn ErrorText;
        private System.Windows.Forms.DataGridViewTextBoxColumn LoadFolder;
    }
}