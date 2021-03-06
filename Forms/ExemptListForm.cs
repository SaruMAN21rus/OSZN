﻿using OSZN.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OSZN
{
    public partial class ExemptListForm : Form
    {
        public ExemptListForm()
        {
            InitializeComponent();
            this.ExemptListGrid.AutoGenerateColumns = false;
            LoadData(null);
        }

        private void LoadData(string searchText) {
            ExemptDAO eDAO = new ExemptDAO();
            ExemptListGrid.DataSource = eDAO.getExempts(searchText);
        }

        private void AddButon_Click(object sender, EventArgs e)
        {
            AddEditViewExemptForm f = new AddEditViewExemptForm(null);
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(SearchTextBox.Text);
            }
        }

        private void ExemptListGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AddEditViewExemptForm f = new AddEditViewExemptForm(Convert.ToInt32(ExemptListGrid.Rows[e.RowIndex].Cells["id"].Value));
            if (f.ShowDialog(this) == DialogResult.OK)
            {
                LoadData(SearchTextBox.Text);
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            ExemptDAO eDAO = new ExemptDAO();
            ExemptListGrid.DataSource = eDAO.getExempts(SearchTextBox.Text);
        }
    }
}
