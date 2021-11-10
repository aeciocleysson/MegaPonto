
namespace Sis_Vendas_Mega
{
    partial class Score
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Score));
            this.lblHoraAtual = new System.Windows.Forms.Label();
            this.timerAtual = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDateDay = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtCodeEmployee = new System.Windows.Forms.TextBox();
            this.dgvScore = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).BeginInit();
            this.SuspendLayout();
            // 
            // lblHoraAtual
            // 
            this.lblHoraAtual.AutoSize = true;
            this.lblHoraAtual.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHoraAtual.Location = new System.Drawing.Point(147, 43);
            this.lblHoraAtual.Name = "lblHoraAtual";
            this.lblHoraAtual.Size = new System.Drawing.Size(120, 24);
            this.lblHoraAtual.TabIndex = 0;
            this.lblHoraAtual.Text = "lblHoraAtual";
            // 
            // timerAtual
            // 
            this.timerAtual.Enabled = true;
            this.timerAtual.Tick += new System.EventHandler(this.timerAtual_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.lblDateDay);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.dgvScore);
            this.groupBox1.Controls.Add(this.lblHoraAtual);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(978, 455);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Firebrick;
            this.label1.Location = new System.Drawing.Point(349, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(218, 42);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mega Ponto";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(872, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 63);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // lblDateDay
            // 
            this.lblDateDay.AutoSize = true;
            this.lblDateDay.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateDay.Location = new System.Drawing.Point(15, 43);
            this.lblDateDay.Name = "lblDateDay";
            this.lblDateDay.Size = new System.Drawing.Size(87, 24);
            this.lblDateDay.TabIndex = 8;
            this.lblDateDay.Text = "DataDia";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.pictureBox2);
            this.groupBox2.Controls.Add(this.btnClose);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.txtCodeEmployee);
            this.groupBox2.Location = new System.Drawing.Point(12, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(960, 60);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Sis_Vendas_Mega.Properties.Resources.barcode;
            this.pictureBox2.Location = new System.Drawing.Point(7, 20);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(100, 26);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(875, 25);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "Sair";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(795, 25);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancelar";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtCodeEmployee
            // 
            this.txtCodeEmployee.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCodeEmployee.Location = new System.Drawing.Point(109, 22);
            this.txtCodeEmployee.Multiline = true;
            this.txtCodeEmployee.Name = "txtCodeEmployee";
            this.txtCodeEmployee.Size = new System.Drawing.Size(179, 24);
            this.txtCodeEmployee.TabIndex = 1;
            this.txtCodeEmployee.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtCodeEmployee.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodeEmployee_KeyPress);
            // 
            // dgvScore
            // 
            this.dgvScore.BackgroundColor = System.Drawing.Color.White;
            this.dgvScore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvScore.Location = new System.Drawing.Point(12, 142);
            this.dgvScore.Name = "dgvScore";
            this.dgvScore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvScore.Size = new System.Drawing.Size(960, 307);
            this.dgvScore.TabIndex = 2;
            // 
            // Score
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 479);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "Score";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ponto";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvScore)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblHoraAtual;
        private System.Windows.Forms.Timer timerAtual;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvScore;
        private System.Windows.Forms.TextBox txtCodeEmployee;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDateDay;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}