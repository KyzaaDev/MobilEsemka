namespace MobilEsemka
{
    partial class Laporan
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
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKembali = new System.Windows.Forms.Button();
            this.btnSewa = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTgl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCari = new System.Windows.Forms.Button();
            this.dgvLaporan = new System.Windows.Forms.DataGridView();
            this.dtpTanggal = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).BeginInit();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.flowLayoutPanel1.Controls.Add(this.panel1);
            this.flowLayoutPanel1.Controls.Add(this.btnLaporan);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(206, 450);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKembali);
            this.panel1.Controls.Add(this.btnSewa);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 89);
            this.panel1.TabIndex = 4;
            // 
            // btnKembali
            // 
            this.btnKembali.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnKembali.Location = new System.Drawing.Point(0, 47);
            this.btnKembali.Name = "btnKembali";
            this.btnKembali.Size = new System.Drawing.Size(200, 41);
            this.btnKembali.TabIndex = 1;
            this.btnKembali.Text = "Pengembalian";
            this.btnKembali.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKembali.UseVisualStyleBackColor = true;
            this.btnKembali.Click += new System.EventHandler(this.btnKembali_Click);
            // 
            // btnSewa
            // 
            this.btnSewa.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSewa.Location = new System.Drawing.Point(0, 0);
            this.btnSewa.Name = "btnSewa";
            this.btnSewa.Size = new System.Drawing.Size(200, 41);
            this.btnSewa.TabIndex = 0;
            this.btnSewa.Text = "Sewa";
            this.btnSewa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSewa.UseVisualStyleBackColor = true;
            this.btnSewa.Click += new System.EventHandler(this.btnSewa_Click);
            // 
            // btnLaporan
            // 
            this.btnLaporan.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporan.Location = new System.Drawing.Point(3, 98);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(200, 41);
            this.btnLaporan.TabIndex = 2;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaporan.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 45);
            this.label1.TabIndex = 8;
            this.label1.Text = "Rental Motor ESEMKA";
            // 
            // lblTgl
            // 
            this.lblTgl.AutoSize = true;
            this.lblTgl.Location = new System.Drawing.Point(522, -30);
            this.lblTgl.Name = "lblTgl";
            this.lblTgl.Size = new System.Drawing.Size(0, 13);
            this.lblTgl.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(216, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 21);
            this.label2.TabIndex = 13;
            this.label2.Text = "Laporan Harian Operator";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(216, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 21);
            this.label3.TabIndex = 17;
            this.label3.Text = "Sales Report";
            // 
            // btnCari
            // 
            this.btnCari.BackColor = System.Drawing.Color.Turquoise;
            this.btnCari.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCari.Location = new System.Drawing.Point(709, 160);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 21);
            this.btnCari.TabIndex = 16;
            this.btnCari.Text = "Lihat";
            this.btnCari.UseVisualStyleBackColor = false;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // dgvLaporan
            // 
            this.dgvLaporan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaporan.Location = new System.Drawing.Point(220, 197);
            this.dgvLaporan.Name = "dgvLaporan";
            this.dgvLaporan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvLaporan.Size = new System.Drawing.Size(568, 178);
            this.dgvLaporan.TabIndex = 14;
            // 
            // dtpTanggal
            // 
            this.dtpTanggal.Location = new System.Drawing.Point(491, 160);
            this.dtpTanggal.Name = "dtpTanggal";
            this.dtpTanggal.Size = new System.Drawing.Size(200, 20);
            this.dtpTanggal.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(539, 378);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 21);
            this.label4.TabIndex = 19;
            this.label4.Text = "Total Sales:";
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(640, 378);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(95, 21);
            this.lblTotal.TabIndex = 20;
            this.lblTotal.Text = "Total Sales:";
            // 
            // Laporan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dtpTanggal);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.dgvLaporan);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblTgl);
            this.Name = "Laporan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Laporan";
            this.Load += new System.EventHandler(this.Laporan_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaporan)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnKembali;
        private System.Windows.Forms.Button btnSewa;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTgl;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.DataGridView dgvLaporan;
        private System.Windows.Forms.DateTimePicker dtpTanggal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblTotal;
    }
}