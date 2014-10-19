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
    public partial class CommunicationSettings : Form
    {
        Button LoadTextBoxClearButton;
        Button UnloadTextBoxClearButton;

        CommunicationFolders folders;

        public CommunicationSettings()
        {
            InitializeComponent();
            CommunicationFoldersDAO cfDAO = new CommunicationFoldersDAO();
            folders = cfDAO.getFolders();
            if (String.IsNullOrEmpty(folders.loadFolder) && String.IsNullOrEmpty(folders.unloadFolder))
            {
                panel1.Show();
                panel2.Hide();
            }
            else
            {
                setViewData();
                panel1.Hide();
                panel2.Show();
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            var panel = new FlowLayoutPanel();
            panel.Size = new Size(42, LoadFolderTextBox.ClientSize.Height + 2);
            panel.Location = new Point(LoadFolderTextBox.ClientSize.Width - panel.Width, -1);
            panel.Anchor = AnchorStyles.Right;
            panel.FlowDirection = FlowDirection.RightToLeft;

            LoadTextBoxClearButton = new Button();
            LoadTextBoxClearButton.Size = new Size(LoadFolderTextBox.ClientSize.Height + 2, LoadFolderTextBox.ClientSize.Height + 2);
            LoadTextBoxClearButton.BackColor = Color.Transparent;
            LoadTextBoxClearButton.BackgroundImage = Properties.Resources.e10a_Cancel_48;
            LoadTextBoxClearButton.BackgroundImageLayout = ImageLayout.Stretch;
            LoadTextBoxClearButton.Cursor = Cursors.Default;
            LoadTextBoxClearButton.FlatAppearance.BorderSize = 0;
            LoadTextBoxClearButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            LoadTextBoxClearButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            LoadTextBoxClearButton.FlatStyle = FlatStyle.Flat;
            LoadTextBoxClearButton.Margin = new Padding(0);
            LoadTextBoxClearButton.UseVisualStyleBackColor = false;
            LoadTextBoxClearButton.Click += LoadTextBoxClearButton_Click;
            LoadTextBoxClearButton.Hide();
            ToolTip clearButtontoolTip = new ToolTip();
            clearButtontoolTip.AutomaticDelay = 100;
            clearButtontoolTip.AutoPopDelay = 5000;
            clearButtontoolTip.SetToolTip(LoadTextBoxClearButton, "Очистить");

            var loadFolderSelectButton = new Button();
            loadFolderSelectButton.Size = new Size(24, LoadFolderTextBox.ClientSize.Height + 2);
            loadFolderSelectButton.Cursor = Cursors.Default;
            loadFolderSelectButton.Margin = new Padding(0);
            loadFolderSelectButton.Text = "∙∙∙";
            loadFolderSelectButton.Click += loadFolderSelectButton_Click;

            panel.Controls.Add(loadFolderSelectButton);
            panel.Controls.Add(LoadTextBoxClearButton);
            LoadFolderTextBox.Controls.Add(panel);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(LoadFolderTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(panel.Width << 16));
          

            var panel2 = new FlowLayoutPanel();
            panel2.Size = new Size(42, UnloadFolderTextBox.ClientSize.Height + 2);
            panel2.Location = new Point(UnloadFolderTextBox.ClientSize.Width - panel2.Width, -1);
            panel2.Anchor = AnchorStyles.Right;
            panel2.FlowDirection = FlowDirection.RightToLeft;

            UnloadTextBoxClearButton = new Button();
            UnloadTextBoxClearButton.Size = new Size(UnloadFolderTextBox.ClientSize.Height + 2, UnloadFolderTextBox.ClientSize.Height + 2);
            UnloadTextBoxClearButton.BackColor = Color.Transparent;
            UnloadTextBoxClearButton.BackgroundImage = Properties.Resources.e10a_Cancel_48;
            UnloadTextBoxClearButton.BackgroundImageLayout = ImageLayout.Stretch;
            UnloadTextBoxClearButton.Cursor = Cursors.Default;
            UnloadTextBoxClearButton.FlatAppearance.BorderSize = 0;
            UnloadTextBoxClearButton.FlatAppearance.MouseDownBackColor = Color.Transparent;
            UnloadTextBoxClearButton.FlatAppearance.MouseOverBackColor = Color.Transparent;
            UnloadTextBoxClearButton.FlatStyle = FlatStyle.Flat;
            UnloadTextBoxClearButton.Margin = new Padding(0);
            UnloadTextBoxClearButton.UseVisualStyleBackColor = false;
            UnloadTextBoxClearButton.Click += LoadTextBoxClearButton_Click;
            UnloadTextBoxClearButton.Hide();
            ToolTip clearButtontoolTip1 = new ToolTip();
            clearButtontoolTip1.AutomaticDelay = 100;
            clearButtontoolTip1.AutoPopDelay = 5000;
            clearButtontoolTip1.SetToolTip(UnloadTextBoxClearButton, "Очистить");

            var unloadFolderSelectButton = new Button();
            unloadFolderSelectButton.Size = new Size(24, UnloadFolderTextBox.ClientSize.Height + 2);
            unloadFolderSelectButton.Cursor = Cursors.Default;
            unloadFolderSelectButton.Margin = new Padding(0);
            unloadFolderSelectButton.Text = "∙∙∙";
            unloadFolderSelectButton.Click += unloadFolderSelectButton_Click;

            panel2.Controls.Add(unloadFolderSelectButton);
            panel2.Controls.Add(UnloadTextBoxClearButton);
            UnloadFolderTextBox.Controls.Add(panel2);
            // Send EM_SETMARGINS to prevent text from disappearing underneath the button
            SendMessage(LoadFolderTextBox.Handle, 0xd3, (IntPtr)2, (IntPtr)(panel2.Width << 16));

            base.OnLoad(e);
        }

        void unloadFolderSelectButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog2.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                UnloadFolderTextBox.Text = folderBrowserDialog2.SelectedPath;
            }
        }

        void loadFolderSelectButton_Click(object sender, EventArgs e)
        {
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                LoadFolderTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        void LoadTextBoxClearButton_Click(object sender, EventArgs e)
        {
            (((sender as Button).Parent as Panel).Parent as TextBox).Clear();
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void LoadFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(LoadFolderTextBox.Text))
            {
                LoadTextBoxClearButton.Hide();
            }
            else
            {
                LoadTextBoxClearButton.Show();
            }
        }

        private void UnloadFolderTextBox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(UnloadFolderTextBox.Text))
            {
                UnloadTextBoxClearButton.Hide();
            }
            else
            {
                UnloadTextBoxClearButton.Show();
            }
        }

        private void ApplyButton_Click(object sender, EventArgs e)
        {
            folders.loadFolder = LoadFolderTextBox.Text;
            folders.unloadFolder = UnloadFolderTextBox.Text;
            CommunicationFoldersDAO cfDAO = new CommunicationFoldersDAO();
            cfDAO.saveFolders(folders);
            setViewData();
            panel1.Hide();
            panel2.Show();
        }

        private void CloseButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            setEditData();
            panel1.Show();
            panel2.Hide();
        }

        private void setViewData()
        {
            LoadFolderValue.Text = folders.loadFolder;
            UnloadFolderValue.Text = folders.unloadFolder;
        }

        private void setEditData()
        {
            LoadFolderTextBox.Text = folders.loadFolder;
            UnloadFolderTextBox.Text = folders.unloadFolder;
            folderBrowserDialog1.SelectedPath = folders.loadFolder;
            folderBrowserDialog2.SelectedPath = folders.unloadFolder;
        }
    }
}
