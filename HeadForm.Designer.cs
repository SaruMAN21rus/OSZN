namespace OSZN
{
    partial class HeadForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.льготникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.обменДаннымиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загрузитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выгрузитьДанныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.настройкиОбменаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.льготникиToolStripMenuItem,
            this.обменДаннымиToolStripMenuItem,
            this.справочникиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(693, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(693, 363);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.LeftToolStripPanelVisible = false;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(693, 387);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            // 
            // льготникиToolStripMenuItem
            // 
            this.льготникиToolStripMenuItem.Name = "льготникиToolStripMenuItem";
            this.льготникиToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.льготникиToolStripMenuItem.Text = "Льготники";
            // 
            // обменДаннымиToolStripMenuItem
            // 
            this.обменДаннымиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загрузитьДанныеToolStripMenuItem,
            this.выгрузитьДанныеToolStripMenuItem,
            this.настройкиОбменаToolStripMenuItem});
            this.обменДаннымиToolStripMenuItem.Name = "обменДаннымиToolStripMenuItem";
            this.обменДаннымиToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.обменДаннымиToolStripMenuItem.Text = "Обмен данными";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // загрузитьДанныеToolStripMenuItem
            // 
            this.загрузитьДанныеToolStripMenuItem.Name = "загрузитьДанныеToolStripMenuItem";
            this.загрузитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.загрузитьДанныеToolStripMenuItem.Text = "Загрузить данные";
            // 
            // выгрузитьДанныеToolStripMenuItem
            // 
            this.выгрузитьДанныеToolStripMenuItem.Name = "выгрузитьДанныеToolStripMenuItem";
            this.выгрузитьДанныеToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.выгрузитьДанныеToolStripMenuItem.Text = "Выгрузить данные";
            // 
            // настройкиОбменаToolStripMenuItem
            // 
            this.настройкиОбменаToolStripMenuItem.Name = "настройкиОбменаToolStripMenuItem";
            this.настройкиОбменаToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.настройкиОбменаToolStripMenuItem.Text = "Настройки обмена";
            // 
            // HeadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(693, 387);
            this.Controls.Add(this.toolStripContainer1);
            this.Name = "HeadForm";
            this.Text = "Подсистема \"ЖКХ\"";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem льготникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem обменДаннымиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загрузитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выгрузитьДанныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem настройкиОбменаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;

    }
}

