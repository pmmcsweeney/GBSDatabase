namespace WindowsFormsApplication1
{
    partial class MSMarkerImport_Manual
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PrimerNameBox = new System.Windows.Forms.TextBox();
            this.OriginBox = new System.Windows.Forms.TextBox();
            this.SeqBox = new System.Windows.Forms.TextBox();
            this.ChromosomeBox = new System.Windows.Forms.TextBox();
            this.GeneBox = new System.Windows.Forms.TextBox();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.GeneBox);
            this.groupBox1.Controls.Add(this.ChromosomeBox);
            this.groupBox1.Controls.Add(this.SeqBox);
            this.groupBox1.Controls.Add(this.OriginBox);
            this.groupBox1.Controls.Add(this.PrimerNameBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Microsatellite Marker Information";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(261, 270);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Submit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Primer Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Origin";
            // 
            // PrimerNameBox
            // 
            this.PrimerNameBox.Location = new System.Drawing.Point(216, 29);
            this.PrimerNameBox.Name = "PrimerNameBox";
            this.PrimerNameBox.Size = new System.Drawing.Size(130, 20);
            this.PrimerNameBox.TabIndex = 2;
            // 
            // OriginBox
            // 
            this.OriginBox.Location = new System.Drawing.Point(216, 55);
            this.OriginBox.Name = "OriginBox";
            this.OriginBox.Size = new System.Drawing.Size(130, 20);
            this.OriginBox.TabIndex = 3;
            // 
            // SeqBox
            // 
            this.SeqBox.Location = new System.Drawing.Point(216, 81);
            this.SeqBox.Name = "SeqBox";
            this.SeqBox.Size = new System.Drawing.Size(130, 20);
            this.SeqBox.TabIndex = 4;
            // 
            // ChromosomeBox
            // 
            this.ChromosomeBox.Location = new System.Drawing.Point(216, 108);
            this.ChromosomeBox.Name = "ChromosomeBox";
            this.ChromosomeBox.Size = new System.Drawing.Size(130, 20);
            this.ChromosomeBox.TabIndex = 5;
            // 
            // GeneBox
            // 
            this.GeneBox.Location = new System.Drawing.Point(216, 135);
            this.GeneBox.Name = "GeneBox";
            this.GeneBox.Size = new System.Drawing.Size(130, 20);
            this.GeneBox.TabIndex = 6;
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.Location = new System.Drawing.Point(6, 19);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.Size = new System.Drawing.Size(311, 62);
            this.DescriptionBox.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(19, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Forward Primer Sequence";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Chromosome";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 138);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Gene";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DescriptionBox);
            this.groupBox2.Location = new System.Drawing.Point(22, 161);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 87);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trait Description";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 269);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MSMarkerImport_Manual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 297);
            this.ControlBox = false;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Name = "MSMarkerImport_Manual";
            this.Text = "MSMarkerImport_Manual";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox GeneBox;
        private System.Windows.Forms.TextBox ChromosomeBox;
        private System.Windows.Forms.TextBox SeqBox;
        private System.Windows.Forms.TextBox OriginBox;
        private System.Windows.Forms.TextBox PrimerNameBox;
        private System.Windows.Forms.Button button2;
    }
}