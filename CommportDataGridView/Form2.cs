using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FaulhaberMotTest_V
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        // Variable für Versuch

        DataSet myData = new DataSet();

        private void btnNeuAnlegen_Click(object sender, EventArgs e)
        {
            if (txtDateiName.Text != string.Empty)
            {
                myData.WriteXml(txtDateiName.Text);
                this.Close();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // Xml-Datei in das DataSet laden
            myData.ReadXml("versuch_zeit_clear.xml");
            // Daten vom DataSet ins DataGridView übertragen
            dataGridView1.DataSource = myData.Tables[0];
        }
    }
}
