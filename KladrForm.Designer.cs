namespace OSZN
{
    partial class KladrForm
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
            this.headPanel = new System.Windows.Forms.TableLayoutPanel();
            this.kladrTree = new System.Windows.Forms.TreeView();
            this.headPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // headPanel
            // 
            this.headPanel.ColumnCount = 2;
            this.headPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.42413F));
            this.headPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.57587F));
            this.headPanel.Controls.Add(this.kladrTree, 0, 0);
            this.headPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.headPanel.Location = new System.Drawing.Point(0, 0);
            this.headPanel.Name = "headPanel";
            this.headPanel.RowCount = 1;
            this.headPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.headPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.headPanel.Size = new System.Drawing.Size(661, 422);
            this.headPanel.TabIndex = 0;
            // 
            // kladrTree
            // 
            this.kladrTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kladrTree.Location = new System.Drawing.Point(3, 3);
            this.kladrTree.Name = "kladrTree";
            this.kladrTree.Size = new System.Drawing.Size(241, 416);
            this.kladrTree.TabIndex = 1;
            this.kladrTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.kladrTree_AfterExpand);
            // 
            // KladrForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 422);
            this.Controls.Add(this.headPanel);
            this.Name = "KladrForm";
            this.Text = "Адресный классификатор";
            this.headPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel headPanel;
        private System.Windows.Forms.TreeView kladrTree;
    }
}