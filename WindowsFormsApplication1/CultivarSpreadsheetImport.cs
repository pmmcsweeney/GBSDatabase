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
    public partial class CultivarSpreadsheetImport : Form
    {
        int CultivarName, Hardness, Color, Season, RowAfterHeader;

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        public CultivarSpreadsheetImport()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "No File Selected" || (textBox1.Text.Substring(textBox1.Text.Length - 4) != ".xls" && textBox1.Text.Substring(textBox1.Text.Length - 5) != ".xlsx"))
            {
                MessageBox.Show("A spreadsheet file was not selected. Please select a spreadsheet file (.xls, .xlsx, or .csv) by pressing the button near the top of the window and try again.");
                return;
            }

            //at this point we have the file path of a target spreadsheet, and the columns that refer to each attribute   
            CultivarName = Convert.ToInt32(numericUpDown1.Value);
            Hardness = Convert.ToInt32(numericUpDown2.Value);
            Color = Convert.ToInt32(numericUpDown3.Value);
            Season = Convert.ToInt32(numericUpDown4.Value);
            RowAfterHeader = Convert.ToInt32(numericUpDown5.Value);
            if (CultivarName == 0)
            {
                MessageBox.Show("CultivarName is a required field, please set it to a non-zero value.");
                return;
            }
            ImportCultivars();
            this.Close();
        }

        private void ImportCultivars()
        {
            int successes = 0, located = 0;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook targetWB = excel.Workbooks.Open(openFileDialog1.FileName);
            Excel.Worksheet targetSheet = targetWB.ActiveSheet;
            MongoClient client = new MongoClient();
            MongoServer server = client.GetServer();
            MongoDatabase db = server.GetDatabase("GBSDatabase");
            MongoCollection<BsonDocument> collection = db.GetCollection<BsonDocument>("MSMarkers");

            while (targetSheet.Cells[RowAfterHeader, CultivarName].Value2 != null)
            {
                bool valid = true;
                var query = new QueryDocument("CultivarName", targetSheet.Cells[RowAfterHeader, CultivarName].Value2);
                foreach (BsonDocument mkr in collection.Find(query))
                {
                    //to add update functionality, add code here
                    valid = false;
                    located++;
                }
                if (valid)
                {
                    BsonDocument cultivar = new BsonDocument();
                    if (targetSheet.Cells[RowAfterHeader, CultivarName].Value2 != null)
                        cultivar.Add(new BsonElement("CultivarName", targetSheet.Cells[RowAfterHeader, CultivarName].Value.ToString()));
                    else
                        continue;
                    if (Hardness != 0 && targetSheet.Cells[RowAfterHeader, Hardness].Value2 != null)
                        cultivar.Add(new BsonElement("Hardness", targetSheet.Cells[RowAfterHeader, Hardness].Value.ToString()));
                    if (Color != 0 && targetSheet.Cells[RowAfterHeader, Color].Value2 != null)
                        cultivar.Add(new BsonElement("Color", targetSheet.Cells[RowAfterHeader, Color].Value.ToString()));
                    if (Season != 0 && targetSheet.Cells[RowAfterHeader, Season].Value2 != null)
                        cultivar.Add(new BsonElement("Season", targetSheet.Cells[RowAfterHeader, Season].Value.ToString()));
                    db.GetCollection<BsonDocument>("Cultivars").Insert(cultivar);
                    successes++;
                }
                RowAfterHeader++;
            }
            MessageBox.Show("Successfully imported " + successes + " cultivar(s). \n" + (located) + " cultivar(s) updated.");
        }
    }
}
