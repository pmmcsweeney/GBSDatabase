using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using MongoDB.Bson;
using MongoDB.Driver;

namespace WindowsFormsApplication1
{
    public partial class Import_MtoC_map : Form
    {
        bool cultivarIsX = true, jobNumberRowPresent = true;
        int dataStartRow;
        public Import_MtoC_map()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void radioButton3_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "No File Selected" || (textBox1.Text.Substring(textBox1.Text.Length - 4) != ".xls" && textBox1.Text.Substring(textBox1.Text.Length - 5) != ".xlsx"))
            {
                MessageBox.Show("A spreadsheet file was not selected. Please select a spreadsheet file (.xls, .xlsx, or .csv) by pressing the button near the top of the window and try again.");
                return;
            }
            cultivarIsX = radioButton1.Checked;
            jobNumberRowPresent = checkBox1.Checked;
            dataStartRow = Convert.ToInt32(numericUpDown1.Value);
            MapMarkersToCultivars();
        }
        private void MapMarkersToCultivars()
        {
            int numMarkers = 658;
            int successes = 0, located = 0;
            int currentCol = 2;
            string cultivarName;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook targetWB = excel.Workbooks.Open(openFileDialog1.FileName);
            Excel.Worksheet targetSheet = targetWB.ActiveSheet;
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("GBSDatabase");
            MongoCollection<BsonDocument> markerCollection = db.GetCollection<BsonDocument>("MSMarkers");
            MongoCollection<BsonDocument> cultivarCollection = db.GetCollection<BsonDocument>("Cultivars");
            // MAIN WHILE LOOP HERE, loop through acceptable cells looking for #s
            while (targetSheet.Cells[1, currentCol].Value2 != null)
            {
                cultivarName = targetSheet.Cells[1, currentCol].Value2;
                var query = new QueryDocument("CultivarName", cultivarName);
                BsonDocument cultivar = cultivarCollection.FindOne(query);
                if (cultivar == null)
                {
                    currentCol++;
                    continue;
                }
                BsonArray markerArray = new BsonArray();
                for (int i = 3; i < numMarkers; i++)
                {
                    if (targetSheet.Cells[i, currentCol].Value2 != null)
                    {
                        var markerQuery = new QueryDocument("PrimerName", targetSheet.Cells[i, 1].Value2.ToLower());
                        BsonDocument marker = markerCollection.FindOne(markerQuery);
                        if (marker == null)
                            continue;
                        markerArray.Add(new BsonDocument { { "MarkerName", targetSheet.Cells[i, 1].Value2 }, { "MarkerID", marker.GetElement("_id").Value } });
                        successes++;
                    }
                }
                cultivar.Add("markers", markerArray);
                currentCol++;
                cultivarCollection.Save(cultivar);
            }
            MessageBox.Show("Successfully mapped " + successes + " marker(s).\n" + located + " cultivar(s) updated.");
            this.Close();
        }
    }
}
