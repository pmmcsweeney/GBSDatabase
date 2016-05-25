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
    public partial class MarkerSpreadsheetImport : Form
    {
        int PrimerName, Origin, ForwardPrimerSeq, Chromosome, Gene, TraitDescription, RowAfterHeader;
        public MarkerSpreadsheetImport()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "No File Selected" || (textBox1.Text.Substring(textBox1.Text.Length - 4) != ".xls" && textBox1.Text.Substring(textBox1.Text.Length - 5) != ".xlsx"))
            {
                MessageBox.Show("A spreadsheet file was not selected. Please select a spreadsheet file (.xls, .xlsx, or .csv) by pressing the button near the top of the window and try again.");
                return;
            }

            //at this point we have the file path of a target spreadsheet, and the columns that refer to each attribute   
            PrimerName = Convert.ToInt32(numericUpDown1.Value);
            Origin = Convert.ToInt32(numericUpDown2.Value);
            ForwardPrimerSeq = Convert.ToInt32(numericUpDown3.Value);
            Chromosome = Convert.ToInt32(numericUpDown4.Value);
            Gene = Convert.ToInt32(numericUpDown5.Value);
            TraitDescription = Convert.ToInt32(numericUpDown6.Value);
            RowAfterHeader = Convert.ToInt32(numericUpDown7.Value);
            if (PrimerName == 0)
            {
                MessageBox.Show("PrimerName is a required field, please set it to a non-zero value.");
                return;
            }
            ImportMarkers();
            this.Close();
        }
        private void ImportMarkers()
        {
            int successes = 0, located = 0;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook targetWB = excel.Workbooks.Open(openFileDialog1.FileName);
            Excel.Worksheet targetSheet = targetWB.ActiveSheet;
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("GBSDatabase");
            MongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("MSMarkers");

            while (targetSheet.Cells[RowAfterHeader, PrimerName].Value2 != null)
            {
                bool valid = true;
                var query = new QueryDocument("PrimerName", targetSheet.Cells[RowAfterHeader, PrimerName].Value2);
                foreach (BsonDocument mkr in collection.Find(query))
                {
                    //to add update functionality, add code here
                    valid = false;
                    located++;
                }
                if (valid)
                {
                    BsonDocument marker = new BsonDocument();
                    if (targetSheet.Cells[RowAfterHeader, PrimerName].Value2 != null)
                        marker.Add(new BsonElement("PrimerName", targetSheet.Cells[RowAfterHeader, PrimerName].Value.ToString()));
                    else
                        continue;
                    if (Origin != 0 && targetSheet.Cells[RowAfterHeader, Origin].Value2 != null)
                        marker.Add(new BsonElement("Origin", targetSheet.Cells[RowAfterHeader, Origin].Value.ToString()));
                    if (ForwardPrimerSeq != 0 && targetSheet.Cells[RowAfterHeader, ForwardPrimerSeq].Value2 != null)
                        marker.Add(new BsonElement("Sequence", targetSheet.Cells[RowAfterHeader, ForwardPrimerSeq].Value.ToString()));
                    if (Chromosome != 0 && targetSheet.Cells[RowAfterHeader, Chromosome].Value2 != null)
                        marker.Add(new BsonElement("Chromosome", targetSheet.Cells[RowAfterHeader, Chromosome].Value.ToString()));
                    if (Gene != 0 && targetSheet.Cells[RowAfterHeader, Gene].Value2 != null)
                        marker.Add(new BsonElement("Gene", targetSheet.Cells[RowAfterHeader, Gene].Value.ToString()));
                    if (TraitDescription != 0 && targetSheet.Cells[RowAfterHeader, TraitDescription].Value2 != null)
                        marker.Add(new BsonElement("TraitDescription", targetSheet.Cells[RowAfterHeader, TraitDescription].Value.ToString()));
                    db.GetCollection<BsonDocument>("MSMarkers").Insert(marker);
                    successes++;
                }
                RowAfterHeader++;
            }
            MessageBox.Show("Successfully imported " + successes + " marker(s). \n"+(located)+" marker(s) updated.");
        }
    }
}
