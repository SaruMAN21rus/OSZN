namespace OSZN
{
    partial class ViewKladrForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameValue = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TypeValue = new System.Windows.Forms.Label();
            this.TypeBriefLabel = new System.Windows.Forms.Label();
            this.TypeBriefValue = new System.Windows.Forms.Label();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.CodeValue = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NameValue, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TypeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TypeValue, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TypeBriefLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.TypeBriefValue, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.CodeLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CodeValue, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(371, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(144, 45);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Наименование:";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameValue
            // 
            this.NameValue.AutoSize = true;
            this.NameValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameValue.Location = new System.Drawing.Point(153, 0);
            this.NameValue.Name = "NameValue";
            this.NameValue.Size = new System.Drawing.Size(215, 45);
            this.NameValue.TabIndex = 1;
            this.NameValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeLabel.Location = new System.Drawing.Point(3, 45);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(144, 45);
            this.TypeLabel.TabIndex = 2;
            this.TypeLabel.Text = "Тип:";
            this.TypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TypeValue
            // 
            this.TypeValue.AutoSize = true;
            this.TypeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeValue.Location = new System.Drawing.Point(153, 45);
            this.TypeValue.Name = "TypeValue";
            this.TypeValue.Size = new System.Drawing.Size(215, 45);
            this.TypeValue.TabIndex = 3;
            this.TypeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TypeBriefLabel
            // 
            this.TypeBriefLabel.AutoSize = true;
            this.TypeBriefLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeBriefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeBriefLabel.Location = new System.Drawing.Point(3, 90);
            this.TypeBriefLabel.Name = "TypeBriefLabel";
            this.TypeBriefLabel.Size = new System.Drawing.Size(144, 45);
            this.TypeBriefLabel.TabIndex = 4;
            this.TypeBriefLabel.Text = "Сокращение:";
            this.TypeBriefLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TypeBriefValue
            // 
            this.TypeBriefValue.AutoSize = true;
            this.TypeBriefValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeBriefValue.Location = new System.Drawing.Point(153, 90);
            this.TypeBriefValue.Name = "TypeBriefValue";
            this.TypeBriefValue.Size = new System.Drawing.Size(215, 45);
            this.TypeBriefValue.TabIndex = 5;
            this.TypeBriefValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeLabel.Location = new System.Drawing.Point(3, 135);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(144, 45);
            this.CodeLabel.TabIndex = 6;
            this.CodeLabel.Text = "Код:";
            this.CodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CodeValue
            // 
            this.CodeValue.AutoSize = true;
            this.CodeValue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeValue.Location = new System.Drawing.Point(153, 135);
            this.CodeValue.Name = "CodeValue";
            this.CodeValue.Size = new System.Drawing.Size(215, 45);
            this.CodeValue.TabIndex = 7;
            this.CodeValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.DeleteButton);
            this.flowLayoutPanel1.Controls.Add(this.EditButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 189);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(371, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(293, 3);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(75, 23);
            this.DeleteButton.TabIndex = 1;
            this.DeleteButton.Text = "Удалить";
            this.DeleteButton.UseVisualStyleBackColor = true;
            // 
            // EditButton
            // 
            this.EditButton.Location = new System.Drawing.Point(183, 3);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(104, 23);
            this.EditButton.TabIndex = 0;
            this.EditButton.Text = "Редактировать";
            this.EditButton.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.flowLayoutPanel1, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(377, 221);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // ViewKladr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(377, 221);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "ViewKladr";
            this.Text = "Просмотр элемента классификатора";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label NameValue;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label TypeValue;
        private System.Windows.Forms.Label TypeBriefLabel;
        private System.Windows.Forms.Label TypeBriefValue;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.Label CodeValue;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button DeleteButton;
        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}