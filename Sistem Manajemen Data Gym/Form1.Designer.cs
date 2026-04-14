namespace Sistem_Manajemen_Data_Gym
{
    partial class Form1
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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btntampilkann = new System.Windows.Forms.Button();
            this.Inputcari = new System.Windows.Forms.Label();
            this.txtcari = new System.Windows.Forms.TextBox();
            this.txtupdate = new System.Windows.Forms.Button();
            this.txthapus = new System.Windows.Forms.Button();
            this.txtsimpan = new System.Windows.Forms.Button();
            this.Inputstatus = new System.Windows.Forms.Label();
            this.cbstatus = new System.Windows.Forms.ComboBox();
            this.txthp = new System.Windows.Forms.TextBox();
            this.Inputnohp = new System.Windows.Forms.Label();
            this.Inputnama = new System.Windows.Forms.Label();
            this.txtnama = new System.Windows.Forms.TextBox();
            this.lblJudul = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.lblTotalRecord = new System.Windows.Forms.Label();
            this.lblStatusKoneksi = new System.Windows.Forms.Label();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.pnlHeader.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlHeader.Controls.Add(this.dataGridView2);
            this.pnlHeader.Controls.Add(this.dataGridView1);
            this.pnlHeader.Controls.Add(this.btntampilkann);
            this.pnlHeader.Controls.Add(this.Inputcari);
            this.pnlHeader.Controls.Add(this.txtcari);
            this.pnlHeader.Controls.Add(this.txtupdate);
            this.pnlHeader.Controls.Add(this.txthapus);
            this.pnlHeader.Controls.Add(this.txtsimpan);
            this.pnlHeader.Controls.Add(this.Inputstatus);
            this.pnlHeader.Controls.Add(this.cbstatus);
            this.pnlHeader.Controls.Add(this.txthp);
            this.pnlHeader.Controls.Add(this.Inputnohp);
            this.pnlHeader.Controls.Add(this.Inputnama);
            this.pnlHeader.Controls.Add(this.txtnama);
            this.pnlHeader.Controls.Add(this.lblTotalRecord);
            this.pnlHeader.Controls.Add(this.lblStatusKoneksi);
            this.pnlHeader.Controls.Add(this.lblJudul);
            this.pnlHeader.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pnlHeader.Location = new System.Drawing.Point(-6, -29);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(815, 487);
            this.pnlHeader.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(18, 317);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(384, 150);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btntampilkann
            // 
            this.btntampilkann.Font = new System.Drawing.Font("Segoe Fluent Icons", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btntampilkann.Location = new System.Drawing.Point(494, 65);
            this.btntampilkann.Name = "btntampilkann";
            this.btntampilkann.Size = new System.Drawing.Size(70, 23);
            this.btntampilkann.TabIndex = 14;
            this.btntampilkann.Text = "Tampilkan";
            this.btntampilkann.UseVisualStyleBackColor = true;
            this.btntampilkann.Click += new System.EventHandler(this.button1_Click);
            // 
            // Inputcari
            // 
            this.Inputcari.AutoSize = true;
            this.Inputcari.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inputcari.Location = new System.Drawing.Point(224, 68);
            this.Inputcari.Name = "Inputcari";
            this.Inputcari.Size = new System.Drawing.Size(27, 13);
            this.Inputcari.TabIndex = 13;
            this.Inputcari.Text = "Cari";
            // 
            // txtcari
            // 
            this.txtcari.Location = new System.Drawing.Point(262, 68);
            this.txtcari.Name = "txtcari";
            this.txtcari.Size = new System.Drawing.Size(226, 23);
            this.txtcari.TabIndex = 12;
            this.txtcari.TextChanged += new System.EventHandler(this.txtcari_TextChanged);
            // 
            // txtupdate
            // 
            this.txtupdate.Location = new System.Drawing.Point(457, 215);
            this.txtupdate.Name = "txtupdate";
            this.txtupdate.Size = new System.Drawing.Size(75, 23);
            this.txtupdate.TabIndex = 11;
            this.txtupdate.Text = "Update";
            this.txtupdate.UseVisualStyleBackColor = true;
            this.txtupdate.Click += new System.EventHandler(this.txtupdate_Click);
            // 
            // txthapus
            // 
            this.txthapus.Location = new System.Drawing.Point(343, 215);
            this.txthapus.Name = "txthapus";
            this.txthapus.Size = new System.Drawing.Size(75, 23);
            this.txthapus.TabIndex = 10;
            this.txthapus.Text = "Hapus";
            this.txthapus.UseVisualStyleBackColor = true;
            this.txthapus.Click += new System.EventHandler(this.txthapus_Click);
            // 
            // txtsimpan
            // 
            this.txtsimpan.Location = new System.Drawing.Point(227, 215);
            this.txtsimpan.Name = "txtsimpan";
            this.txtsimpan.Size = new System.Drawing.Size(75, 23);
            this.txtsimpan.TabIndex = 9;
            this.txtsimpan.Text = "Simpan";
            this.txtsimpan.UseVisualStyleBackColor = true;
            this.txtsimpan.Click += new System.EventHandler(this.txtsimpan_Click);
            // 
            // Inputstatus
            // 
            this.Inputstatus.AutoSize = true;
            this.Inputstatus.Font = new System.Drawing.Font("Segoe Fluent Icons", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inputstatus.Location = new System.Drawing.Point(222, 149);
            this.Inputstatus.Name = "Inputstatus";
            this.Inputstatus.Size = new System.Drawing.Size(38, 12);
            this.Inputstatus.TabIndex = 8;
            this.Inputstatus.Text = "Status";
            this.Inputstatus.Click += new System.EventHandler(this.Inputstatus_Click);
            // 
            // cbstatus
            // 
            this.cbstatus.FormattingEnabled = true;
            this.cbstatus.Items.AddRange(new object[] {
            "Aktif",
            "Tidak Aktif"});
            this.cbstatus.Location = new System.Drawing.Point(262, 146);
            this.cbstatus.Name = "cbstatus";
            this.cbstatus.Size = new System.Drawing.Size(87, 23);
            this.cbstatus.TabIndex = 7;
            this.cbstatus.SelectedIndexChanged += new System.EventHandler(this.cbstatus_SelectedIndexChanged);
            // 
            // txthp
            // 
            this.txthp.Location = new System.Drawing.Point(262, 120);
            this.txthp.Name = "txthp";
            this.txthp.Size = new System.Drawing.Size(226, 23);
            this.txthp.TabIndex = 6;
            this.txthp.TextChanged += new System.EventHandler(this.txthp_TextChanged);
            // 
            // Inputnohp
            // 
            this.Inputnohp.AutoSize = true;
            this.Inputnohp.Font = new System.Drawing.Font("Segoe Fluent Icons", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inputnohp.Location = new System.Drawing.Point(221, 123);
            this.Inputnohp.Name = "Inputnohp";
            this.Inputnohp.Size = new System.Drawing.Size(39, 12);
            this.Inputnohp.TabIndex = 5;
            this.Inputnohp.Text = "No HP";
            // 
            // Inputnama
            // 
            this.Inputnama.AutoSize = true;
            this.Inputnama.Font = new System.Drawing.Font("Segoe Fluent Icons", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Inputnama.Location = new System.Drawing.Point(222, 96);
            this.Inputnama.Name = "Inputnama";
            this.Inputnama.Size = new System.Drawing.Size(34, 12);
            this.Inputnama.TabIndex = 4;
            this.Inputnama.Text = "Nama";
            // 
            // txtnama
            // 
            this.txtnama.Location = new System.Drawing.Point(262, 94);
            this.txtnama.Name = "txtnama";
            this.txtnama.Size = new System.Drawing.Size(226, 23);
            this.txtnama.TabIndex = 3;
            this.txtnama.TextChanged += new System.EventHandler(this.txtnama_TextChanged);
            // 
            // lblJudul
            // 
            this.lblJudul.AutoSize = true;
            this.lblJudul.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.lblJudul.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblJudul.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblJudul.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJudul.ForeColor = System.Drawing.Color.Black;
            this.lblJudul.Location = new System.Drawing.Point(194, 38);
            this.lblJudul.Name = "lblJudul";
            this.lblJudul.Size = new System.Drawing.Size(401, 20);
            this.lblJudul.TabIndex = 0;
            this.lblJudul.Text = "GYM DATA MASTER - SISTEM MANAJEMEN DATA GYM";
            this.lblJudul.Click += new System.EventHandler(this.lblJudul_Click);
            // 
            // lblTotalRecord
            // 
            this.lblTotalRecord.AutoSize = true;
            this.lblTotalRecord.Location = new System.Drawing.Point(125, 289);
            this.lblTotalRecord.Name = "lblTotalRecord";
            this.lblTotalRecord.Size = new System.Drawing.Size(85, 15);
            this.lblTotalRecord.TabIndex = 2;
            this.lblTotalRecord.Text = "Total Member";
            this.lblTotalRecord.Click += new System.EventHandler(this.lblTotalRecord_Click);
            // 
            // lblStatusKoneksi
            // 
            this.lblStatusKoneksi.AutoSize = true;
            this.lblStatusKoneksi.Location = new System.Drawing.Point(569, 289);
            this.lblStatusKoneksi.Name = "lblStatusKoneksi";
            this.lblStatusKoneksi.Size = new System.Drawing.Size(89, 15);
            this.lblStatusKoneksi.TabIndex = 1;
            this.lblStatusKoneksi.Text = "Status Koneksi";
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(435, 317);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(359, 150);
            this.dataGridView2.TabIndex = 16;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlHeader);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblJudul;
        private System.Windows.Forms.TextBox txtnama;
        private System.Windows.Forms.Label Inputstatus;
        private System.Windows.Forms.ComboBox cbstatus;
        private System.Windows.Forms.TextBox txthp;
        private System.Windows.Forms.Label Inputnohp;
        private System.Windows.Forms.Label Inputnama;
        private System.Windows.Forms.Button txtupdate;
        private System.Windows.Forms.Button txthapus;
        private System.Windows.Forms.Button txtsimpan;
        private System.Windows.Forms.TextBox txtcari;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button btntampilkann;
        private System.Windows.Forms.Label Inputcari;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label lblTotalRecord;
        private System.Windows.Forms.Label lblStatusKoneksi;
    }
}

