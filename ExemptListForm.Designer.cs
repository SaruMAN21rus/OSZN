﻿namespace OSZN
{
    partial class ExemptListForm
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
            this.AddButon = new System.Windows.Forms.Button();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.ExemptListGrid = new System.Windows.Forms.DataGridView();
            this.ObjectName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GUID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BirthDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SNILS = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExemptListGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.ExemptListGrid, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 345);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.AddButon, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.SearchLabel, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.SearchTextBox, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(978, 34);
            this.tableLayoutPanel2.TabIndex = 4;
            // 
            // AddButon
            // 
            this.AddButon.Dock = System.Windows.Forms.DockStyle.Left;
            this.AddButon.Location = new System.Drawing.Point(3, 3);
            this.AddButon.Name = "AddButon";
            this.AddButon.Size = new System.Drawing.Size(74, 28);
            this.AddButon.TabIndex = 0;
            this.AddButon.Text = "Добавить";
            this.AddButon.UseVisualStyleBackColor = true;
            this.AddButon.Click += new System.EventHandler(this.AddButon_Click);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchLabel.Location = new System.Drawing.Point(83, 0);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(47, 34);
            this.SearchLabel.TabIndex = 6;
            this.SearchLabel.Text = "Искать:";
            this.SearchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SearchTextBox.Location = new System.Drawing.Point(136, 5);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(3, 5, 3, 3);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(839, 20);
            this.SearchTextBox.TabIndex = 7;
            // 
            // ExemptListGrid
            // 
            this.ExemptListGrid.AllowUserToAddRows = false;
            this.ExemptListGrid.AllowUserToDeleteRows = false;
            this.ExemptListGrid.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ExemptListGrid.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.ExemptListGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.ExemptListGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ExemptListGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ObjectName,
            this.Type,
            this.Code,
            this.GUID,
            this.BirthDate,
            this.SNILS,
            this.Address});
            this.ExemptListGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExemptListGrid.Location = new System.Drawing.Point(3, 43);
            this.ExemptListGrid.Name = "ExemptListGrid";
            this.ExemptListGrid.ReadOnly = true;
            this.ExemptListGrid.RowHeadersVisible = false;
            this.ExemptListGrid.Size = new System.Drawing.Size(978, 299);
            this.ExemptListGrid.TabIndex = 5;
            // 
            // ObjectName
            // 
            this.ObjectName.DataPropertyName = "FORMALNAME";
            this.ObjectName.HeaderText = "ФИО";
            this.ObjectName.MinimumWidth = 50;
            this.ObjectName.Name = "ObjectName";
            this.ObjectName.ReadOnly = true;
            this.ObjectName.Width = 200;
            // 
            // Type
            // 
            this.Type.DataPropertyName = "TYPE";
            this.Type.HeaderText = "ИД";
            this.Type.MinimumWidth = 50;
            this.Type.Name = "Type";
            this.Type.ReadOnly = true;
            // 
            // Code
            // 
            this.Code.DataPropertyName = "CODE";
            this.Code.HeaderText = "Паспортные данные";
            this.Code.MinimumWidth = 100;
            this.Code.Name = "Code";
            this.Code.ReadOnly = true;
            this.Code.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Code.Width = 200;
            // 
            // GUID
            // 
            this.GUID.DataPropertyName = "AOGUID";
            this.GUID.HeaderText = "Пол";
            this.GUID.Name = "GUID";
            this.GUID.ReadOnly = true;
            this.GUID.Visible = false;
            // 
            // BirthDate
            // 
            this.BirthDate.HeaderText = "Дата рождения";
            this.BirthDate.Name = "BirthDate";
            this.BirthDate.ReadOnly = true;
            this.BirthDate.Width = 125;
            // 
            // SNILS
            // 
            this.SNILS.HeaderText = "СНИЛС";
            this.SNILS.Name = "SNILS";
            this.SNILS.ReadOnly = true;
            // 
            // Address
            // 
            this.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Address.HeaderText = "Адрес места проживания";
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // ExemptListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 345);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExemptListForm";
            this.Text = "Льготники";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ExemptListGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button AddButon;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.DataGridView ExemptListGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn ObjectName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Code;
        private System.Windows.Forms.DataGridViewTextBoxColumn GUID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BirthDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn SNILS;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
    }
}