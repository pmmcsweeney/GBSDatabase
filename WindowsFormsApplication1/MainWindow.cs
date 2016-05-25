using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WindowsFormsApplication1
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void cultivarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultivarImport addCultivarForm = new CultivarImport();
            addCultivarForm.Show();
        }

        private void mSMarkerFromSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MarkerSpreadsheetImport addSpreadsheetMSMarker = new MarkerSpreadsheetImport();
            addSpreadsheetMSMarker.Show();
        }

        private void cultivarFromSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CultivarSpreadsheetImport addSpreadsheetCultivar = new CultivarSpreadsheetImport();
            addSpreadsheetCultivar.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MSMarkerImport_Manual addMSMarkerForm = new MSMarkerImport_Manual();
            addMSMarkerForm.Show();
        }

        private void markerCultivarFromSpreadsheetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Import_MtoC_map addMarkerToCultivarMapForm = new Import_MtoC_map();
            addMarkerToCultivarMapForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i = 0;
            QueryDocument query = new QueryDocument();
            if (textBox7.Text != "")
                query.Add("CultivarName", textBox7.Text);
            if (comboBox4.SelectedItem != null)
                query.Add("Hardness", comboBox4.Text);
            if (comboBox5.SelectedItem != null)
                query.Add("Color", comboBox5.Text);
            if (comboBox6.SelectedItem != null)
                query.Add("Season", comboBox6.Text);
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("GBSDatabase");
            MongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("Cultivars");
            foreach (BsonDocument cultivar in collection.Find(query))
            {
                DataGridViewRow row = (DataGridViewRow)dataGridView2.Rows[0].Clone();
                if (i == 0)
                {
                    dataGridView2.Rows[0].Cells[0].Value = cultivar.GetElement("CultivarName").ToString().Substring(13);
                    dataGridView2.Rows[0].Cells[1].Value = cultivar.GetElement("Hardness").ToString().Substring(9);
                    dataGridView2.Rows[0].Cells[2].Value = cultivar.GetElement("Color").ToString().Substring(6);
                    dataGridView2.Rows[0].Cells[3].Value = cultivar.GetElement("Season").ToString().Substring(7);
                    i++;
                    continue;
                }
                row.Cells[0].Value = cultivar.GetElement("CultivarName").ToString().Substring(13);
                row.Cells[1].Value = cultivar.GetElement("Hardness").ToString().Substring(9);
                row.Cells[2].Value = cultivar.GetElement("Color").ToString().Substring(6);
                row.Cells[3].Value = cultivar.GetElement("Season").ToString().Substring(7);
                dataGridView2.Rows.Add(row);
                i++;
            }
            dataGridView2.Visible = true;
        }
    }
}
