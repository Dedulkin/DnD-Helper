namespace DND_Helper
{
    partial class Auth1
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
            this.psrd_lb = new System.Windows.Forms.Label();
            this.insert_btn = new System.Windows.Forms.Button();
            this.pswrd_tBox = new System.Windows.Forms.TextBox();
            this.log_tBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // psrd_lb
            // 
            this.psrd_lb.AutoSize = true;
            this.psrd_lb.Location = new System.Drawing.Point(242, 207);
            this.psrd_lb.Name = "psrd_lb";
            this.psrd_lb.Size = new System.Drawing.Size(13, 13);
            this.psrd_lb.TabIndex = 25;
            this.psrd_lb.Text = "1";
            this.psrd_lb.Visible = false;
            // 
            // insert_btn
            // 
            this.insert_btn.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.insert_btn.Location = new System.Drawing.Point(108, 174);
            this.insert_btn.Name = "insert_btn";
            this.insert_btn.Size = new System.Drawing.Size(89, 29);
            this.insert_btn.TabIndex = 23;
            this.insert_btn.Text = "Войти";
            this.insert_btn.UseVisualStyleBackColor = true;
            this.insert_btn.Click += new System.EventHandler(this.insert_btn_Click);
            // 
            // pswrd_tBox
            // 
            this.pswrd_tBox.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pswrd_tBox.Location = new System.Drawing.Point(47, 146);
            this.pswrd_tBox.Name = "pswrd_tBox";
            this.pswrd_tBox.Size = new System.Drawing.Size(216, 22);
            this.pswrd_tBox.TabIndex = 22;
            // 
            // log_tBox
            // 
            this.log_tBox.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.log_tBox.Location = new System.Drawing.Point(47, 76);
            this.log_tBox.Name = "log_tBox";
            this.log_tBox.Size = new System.Drawing.Size(216, 22);
            this.log_tBox.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label2.Location = new System.Drawing.Point(117, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 25);
            this.label2.TabIndex = 20;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(121, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 25);
            this.label1.TabIndex = 19;
            this.label1.Text = "Логин";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DND_Helper.Properties.Resources.close_eye;
            this.pictureBox1.Location = new System.Drawing.Point(269, 140);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(29, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Auth1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 263);
            this.Controls.Add(this.psrd_lb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.insert_btn);
            this.Controls.Add(this.pswrd_tBox);
            this.Controls.Add(this.log_tBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Auth1";
            this.Text = "Auth1";
            this.Load += new System.EventHandler(this.Auth1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label psrd_lb;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button insert_btn;
        private System.Windows.Forms.TextBox pswrd_tBox;
        private System.Windows.Forms.TextBox log_tBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}