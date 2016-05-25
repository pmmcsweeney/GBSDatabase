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
    public partial class CultivarImport : Form
    {
        public CultivarImport()
        {
            InitializeComponent();
        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            IMongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase("GBSDatabase");
            var document = new BsonDocument
            {
                {
                    "CultivarName", this.CultivarName.Text.ToString()
                },
                {
                    "Hardness", this.Hardness.Text.ToString()
                },
                {
                    "Color", this.Color.Text.ToString()
                },
                {
                    "Season", this.Season.Text.ToString()
                }
            };
            db.GetCollection<BsonDocument>("cultivar").InsertOneAsync(document);
            
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
