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
    public partial class MSMarkerImport_Manual : Form
    {
        public MSMarkerImport_Manual()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            IMongoClient client = new MongoClient();
            IMongoDatabase db = client.GetDatabase("GBSDatabase");
            var document = new BsonDocument
            {
                {
                    "PrimerName", PrimerNameBox.Text.ToString()
                },
                {
                    "Origin", OriginBox.Text.ToString()
                },
                {
                    "Sequence", SeqBox.Text.ToString()
                },
                {
                    "Chromosome", ChromosomeBox.Text.ToString()
                },
                {
                    "Gene", GeneBox.Text.ToString()
                },
                {
                    "TraitDescription", DescriptionBox.Text.ToString()
                }
            };
            db.GetCollection<BsonDocument>("MSMarkers").InsertOneAsync(document);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
