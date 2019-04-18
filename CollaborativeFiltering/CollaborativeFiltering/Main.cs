using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace CollaborativeFiltering
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }


        private void txtCsvFilePath_Click(object sender, EventArgs e)
        {
            OpenCsvFilePath.ShowDialog();
        }

        private void OpenCsvFilePath_FileOk(object sender, CancelEventArgs e)
        {
            Model.CsvFilePath = OpenCsvFilePath.FileName;
            txtCsvFilePath.Text = Model.CsvFilePath;
            Model.dtInputData = Model.readCSV(Model.CsvFilePath);
            LoadInputData();
        }

        private void LoadInputData()
        {
            dgvInputData.DataSource = Model.dtInputData;
            Model.FindTopK(0);

        }
    }
}
