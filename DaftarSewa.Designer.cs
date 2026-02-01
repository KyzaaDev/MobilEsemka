namespace MobilEsemka
{
    partial class DaftarSewa
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
            this.btnPengembalian = new System.Windows.Forms.Button();
            this.btnSewa = new System.Windows.Forms.Button();
            this.btnLaporan = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMotor = new System.Windows.Forms.DataGridView();
            this.txtKey = new System.Windows.Forms.TextBox();
            this.btnCari = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotor)).BeginInit();
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
            this.flowLayoutPanel1.Size = new System.Drawing.Size(206, 424);
            this.flowLayoutPanel1.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPengembalian);
            this.panel1.Controls.Add(this.btnSewa);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 89);
            this.panel1.TabIndex = 4;
            // 
            // btnPengembalian
            // 
            this.btnPengembalian.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPengembalian.Location = new System.Drawing.Point(0, 47);
            this.btnPengembalian.Name = "btnPengembalian";
            this.btnPengembalian.Size = new System.Drawing.Size(200, 41);
            this.btnPengembalian.TabIndex = 1;
            this.btnPengembalian.Text = "Pengembalian";
            this.btnPengembalian.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPengembalian.UseVisualStyleBackColor = true;
            this.btnPengembalian.Click += new System.EventHandler(this.btnPengembalian_Click);
            // 
            // btnSewa
            // 
            this.btnSewa.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSewa.Location = new System.Drawing.Point(0, 0);
            this.btnSewa.Name = "btnSewa";
            this.btnSewa.Size = new System.Drawing.Size(200, 41);
            this.btnSewa.TabIndex = 0;
            this.btnSewa.Text = "Sewa";
            this.btnSewa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSewa.UseVisualStyleBackColor = true;
            // 
            // btnLaporan
            // 
            this.btnLaporan.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLaporan.Location = new System.Drawing.Point(3, 98);
            this.btnLaporan.Name = "btnLaporan";
            this.btnLaporan.Size = new System.Drawing.Size(200, 41);
            this.btnLaporan.TabIndex = 2;
            this.btnLaporan.Text = "Laporan";
            this.btnLaporan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLaporan.UseVisualStyleBackColor = true;
            this.btnLaporan.Click += new System.EventHandler(this.btnLaporan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(212, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 30);
            this.label1.TabIndex = 7;
            this.label1.Text = "Rental Motor ESEMKA";
            // 
            // dgvMotor
            // 
            this.dgvMotor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMotor.Location = new System.Drawing.Point(212, 145);
            this.dgvMotor.Name = "dgvMotor";
            this.dgvMotor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvMotor.Size = new System.Drawing.Size(641, 213);
            this.dgvMotor.TabIndex = 8;
            this.dgvMotor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMotor_CellContentClick);
            // 
            // txtKey
            // 
            this.txtKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKey.Location = new System.Drawing.Point(492, 112);
            this.txtKey.Multiline = true;
            this.txtKey.Name = "txtKey";
            this.txtKey.Size = new System.Drawing.Size(263, 27);
            this.txtKey.TabIndex = 10;
            // 
            // btnCari
            // 
            this.btnCari.Location = new System.Drawing.Point(777, 112);
            this.btnCari.Name = "btnCari";
            this.btnCari.Size = new System.Drawing.Size(75, 30);
            this.btnCari.TabIndex = 11;
            this.btnCari.Text = "Cari";
            this.btnCari.UseVisualStyleBackColor = true;
            this.btnCari.Click += new System.EventHandler(this.btnCari_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(377, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 12;
            this.label3.Text = "Daftar Motor";
            // 
            // DaftarSewa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 424);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCari);
            this.Controls.Add(this.txtKey);
            this.Controls.Add(this.dgvMotor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "DaftarSewa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Daftar Sewa";
            this.Load += new System.EventHandler(this.DaftarSewa_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPengembalian;
        private System.Windows.Forms.Button btnSewa;
        private System.Windows.Forms.Button btnLaporan;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMotor;
        private System.Windows.Forms.TextBox txtKey;
        private System.Windows.Forms.Button btnCari;
        private System.Windows.Forms.Label label3;
    }
}