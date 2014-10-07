namespace OSZN
{
    partial class AddEditKladrForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.TypeLabel = new System.Windows.Forms.Label();
            this.TypeBriefLabel = new System.Windows.Forms.Label();
            this.CodeLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.TypeComboBox = new System.Windows.Forms.ComboBox();
            this.TypeBriefComboBox = new System.Windows.Forms.ComboBox();
            this.CodeTextBox = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.ApplyButton = new System.Windows.Forms.Button();
            this.NameErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TypeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.TypeBriefErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.CodeErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeBriefErrorProvider)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeErrorProvider)).BeginInit();
            this.SuspendLayout();
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(387, 268);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.NameLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.TypeLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.TypeBriefLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.CodeLabel, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.NameTextBox, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.TypeComboBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.TypeBriefComboBox, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.CodeTextBox, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(381, 227);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameLabel.Location = new System.Drawing.Point(3, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(144, 56);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Наименование:";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TypeLabel
            // 
            this.TypeLabel.AutoSize = true;
            this.TypeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeLabel.Location = new System.Drawing.Point(3, 56);
            this.TypeLabel.Name = "TypeLabel";
            this.TypeLabel.Size = new System.Drawing.Size(144, 56);
            this.TypeLabel.TabIndex = 2;
            this.TypeLabel.Text = "Тип:";
            this.TypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TypeBriefLabel
            // 
            this.TypeBriefLabel.AutoSize = true;
            this.TypeBriefLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TypeBriefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TypeBriefLabel.Location = new System.Drawing.Point(3, 112);
            this.TypeBriefLabel.Name = "TypeBriefLabel";
            this.TypeBriefLabel.Size = new System.Drawing.Size(144, 56);
            this.TypeBriefLabel.TabIndex = 4;
            this.TypeBriefLabel.Text = "Сокращение:";
            this.TypeBriefLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CodeLabel
            // 
            this.CodeLabel.AutoSize = true;
            this.CodeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CodeLabel.Location = new System.Drawing.Point(3, 168);
            this.CodeLabel.Name = "CodeLabel";
            this.CodeLabel.Size = new System.Drawing.Size(144, 59);
            this.CodeLabel.TabIndex = 6;
            this.CodeLabel.Text = "Код:";
            this.CodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextBox.Location = new System.Drawing.Point(153, 18);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(205, 20);
            this.NameTextBox.TabIndex = 7;
            this.NameTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.NameTextBox_Validating);
            // 
            // TypeComboBox
            // 
            this.TypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeComboBox.DisplayMember = "name";
            this.TypeComboBox.FormattingEnabled = true;
            this.TypeComboBox.Location = new System.Drawing.Point(153, 73);
            this.TypeComboBox.Name = "TypeComboBox";
            this.TypeComboBox.Size = new System.Drawing.Size(205, 21);
            this.TypeComboBox.TabIndex = 8;
            this.TypeComboBox.ValueMember = "id";
            this.TypeComboBox.SelectedIndexChanged += new System.EventHandler(this.TypeComboBox_SelectedIndexChanged);
            this.TypeComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.TypeComboBox_Validating);
            // 
            // TypeBriefComboBox
            // 
            this.TypeBriefComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TypeBriefComboBox.DisplayMember = "SOCRNAME";
            this.TypeBriefComboBox.FormattingEnabled = true;
            this.TypeBriefComboBox.Location = new System.Drawing.Point(153, 129);
            this.TypeBriefComboBox.Name = "TypeBriefComboBox";
            this.TypeBriefComboBox.Size = new System.Drawing.Size(205, 21);
            this.TypeBriefComboBox.TabIndex = 9;
            this.TypeBriefComboBox.ValueMember = "SOCRNAME";
            this.TypeBriefComboBox.Validating += new System.ComponentModel.CancelEventHandler(this.TypeBriefComboBox_Validating);
            // 
            // CodeTextBox
            // 
            this.CodeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeTextBox.Location = new System.Drawing.Point(153, 187);
            this.CodeTextBox.MaxLength = 17;
            this.CodeTextBox.Name = "CodeTextBox";
            this.CodeTextBox.Size = new System.Drawing.Size(205, 20);
            this.CodeTextBox.TabIndex = 10;
            this.CodeTextBox.Validating += new System.ComponentModel.CancelEventHandler(this.CodeTextBox_Validating);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoSize = true;
            this.flowLayoutPanel1.Controls.Add(this.CloseButton);
            this.flowLayoutPanel1.Controls.Add(this.ApplyButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 236);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(381, 29);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(303, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Закрыть";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ApplyButton
            // 
            this.ApplyButton.Location = new System.Drawing.Point(217, 3);
            this.ApplyButton.Name = "ApplyButton";
            this.ApplyButton.Size = new System.Drawing.Size(80, 23);
            this.ApplyButton.TabIndex = 0;
            this.ApplyButton.Text = "Применить";
            this.ApplyButton.UseVisualStyleBackColor = true;
            this.ApplyButton.Click += new System.EventHandler(this.ApplyButton_Click);
            // 
            // NameErrorProvider
            // 
            this.NameErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.NameErrorProvider.ContainerControl = this;
            // 
            // TypeErrorProvider
            // 
            this.TypeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.TypeErrorProvider.ContainerControl = this;
            // 
            // TypeBriefErrorProvider
            // 
            this.TypeBriefErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.TypeBriefErrorProvider.ContainerControl = this;
            // 
            // CodeErrorProvider
            // 
            this.CodeErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.CodeErrorProvider.ContainerControl = this;
            // 
            // AddEditKladrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 268);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "AddEditKladrForm";
            this.Text = "Добавление нового элемента классификатора";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NameErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeBriefErrorProvider)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CodeErrorProvider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label TypeLabel;
        private System.Windows.Forms.Label TypeBriefLabel;
        private System.Windows.Forms.Label CodeLabel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ApplyButton;
        private System.Windows.Forms.ErrorProvider NameErrorProvider;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.ComboBox TypeComboBox;
        private System.Windows.Forms.ComboBox TypeBriefComboBox;
        private System.Windows.Forms.TextBox CodeTextBox;
        private System.Windows.Forms.ErrorProvider TypeErrorProvider;
        private System.Windows.Forms.ErrorProvider TypeBriefErrorProvider;
        private System.Windows.Forms.ErrorProvider CodeErrorProvider;
    }
}