namespace MobilEsemka
{
    partial class USMotor
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.dgvMotor = new System.Windows.Forms.DataGridView();
            this.btnTambah = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pbMotor = new System.Windows.Forms.PictureBox();
            this.lblJenis = new System.Windows.Forms.Label();
            this.lblNoMotor = new System.Windows.Forms.Label();
            this.lblMerk = new System.Windows.Forms.Label();
            this.lblNamaMotor = new System.Windows.Forms.Label();
            this.lblHargaSewa = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rental Motor ESEMKA";
            // 
            // dgvMotor
            // 
            this.dgvMotor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMotor.Location = new System.Drawing.Point(8, 116);
            this.dgvMotor.Name = "dgvMotor";
            this.dgvMotor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMotor.Size = new System.Drawing.Size(621, 150);
            this.dgvMotor.TabIndex = 1;
            this.dgvMotor.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMotor_CellContentClick);
            this.dgvMotor.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvMotor_CellMouseDoubleClick);
            // 
            // btnTambah
            // 
            this.btnTambah.Location = new System.Drawing.Point(537, 74);
            this.btnTambah.Name = "btnTambah";
            this.btnTambah.Size = new System.Drawing.Size(92, 36);
            this.btnTambah.TabIndex = 2;
            this.btnTambah.Text = "Tambah";
            this.btnTambah.UseVisualStyleBackColor = true;
            this.btnTambah.Click += new System.EventHandler(this.btnTambah_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 281);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Detail Motor";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 313);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Jenis:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 338);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "No Motor: ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 363);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 16);
            this.label6.TabIndex = 7;
            this.label6.Text = "Merk:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 8;
            this.label7.Text = "Nama Motor: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 414);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 9;
            this.label8.Text = "Harga Sewa: ";
            // 
            // pbMotor
            // 
            this.pbMotor.Location = new System.Drawing.Point(339, 300);
            this.pbMotor.Name = "pbMotor";
            this.pbMotor.Size = new System.Drawing.Size(162, 156);
            this.pbMotor.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbMotor.TabIndex = 10;
            this.pbMotor.TabStop = false;
            // 
            // lblJenis
            // 
            this.lblJenis.AutoSize = true;
            this.lblJenis.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJenis.Location = new System.Drawing.Point(53, 313);
            this.lblJenis.Name = "lblJenis";
            this.lblJenis.Size = new System.Drawing.Size(0, 16);
            this.lblJenis.TabIndex = 11;
            // 
            // lblNoMotor
            // 
            this.lblNoMotor.AutoSize = true;
            this.lblNoMotor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNoMotor.Location = new System.Drawing.Point(75, 338);
            this.lblNoMotor.Name = "lblNoMotor";
            this.lblNoMotor.Size = new System.Drawing.Size(0, 16);
            this.lblNoMotor.TabIndex = 12;
            // 
            // lblMerk
            // 
            this.lblMerk.AutoSize = true;
            this.lblMerk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMerk.Location = new System.Drawing.Point(51, 363);
            this.lblMerk.Name = "lblMerk";
            this.lblMerk.Size = new System.Drawing.Size(0, 16);
            this.lblMerk.TabIndex = 13;
            // 
            // lblNamaMotor
            // 
            this.lblNamaMotor.AutoSize = true;
            this.lblNamaMotor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNamaMotor.Location = new System.Drawing.Point(97, 388);
            this.lblNamaMotor.Name = "lblNamaMotor";
            this.lblNamaMotor.Size = new System.Drawing.Size(0, 16);
            this.lblNamaMotor.TabIndex = 14;
            // 
            // lblHargaSewa
            // 
            this.lblHargaSewa.AutoSize = true;
            this.lblHargaSewa.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHargaSewa.Location = new System.Drawing.Point(99, 414);
            this.lblHargaSewa.Name = "lblHargaSewa";
            this.lblHargaSewa.Size = new System.Drawing.Size(0, 16);
            this.lblHargaSewa.TabIndex = 15;
            // 
            // USMotor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblHargaSewa);
            this.Controls.Add(this.lblNamaMotor);
            this.Controls.Add(this.lblMerk);
            this.Controls.Add(this.lblNoMotor);
            this.Controls.Add(this.lblJenis);
            this.Controls.Add(this.pbMotor);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnTambah);
            this.Controls.Add(this.dgvMotor);
            this.Controls.Add(this.label1);
            this.Name = "USMotor";
            this.Size = new System.Drawing.Size(641, 459);
            this.Load += new System.EventHandler(this.USMotor_Load);
            this.Enter += new System.EventHandler(this.USMotor_Enter);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMotor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbMotor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvMotor;
        private System.Windows.Forms.Button btnTambah;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.PictureBox pbMotor;
        private System.Windows.Forms.Label lblJenis;
        private System.Windows.Forms.Label lblNoMotor;
        private System.Windows.Forms.Label lblMerk;
        private System.Windows.Forms.Label lblNamaMotor;
        private System.Windows.Forms.Label lblHargaSewa;
    }
}
