namespace Snake
{
    partial class BSnake
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BSnake));
            this.TabelaDeJoc = new System.Windows.Forms.PictureBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.imglist1 = new System.Windows.Forms.ImageList(this.components);
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.TabelaDeJoc)).BeginInit();
            this.SuspendLayout();
            // 
            // TabelaDeJoc
            // 
            this.TabelaDeJoc.Location = new System.Drawing.Point(22, 12);
            this.TabelaDeJoc.Name = "TabelaDeJoc";
            this.TabelaDeJoc.Size = new System.Drawing.Size(630, 630);
            this.TabelaDeJoc.TabIndex = 0;
            this.TabelaDeJoc.TabStop = false;
            this.TabelaDeJoc.Click += new System.EventHandler(this.BSnake_Load);
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // imglist1
            // 
            this.imglist1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist1.ImageStream")));
            this.imglist1.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist1.Images.SetKeyName(0, "1.PNG");
            this.imglist1.Images.SetKeyName(1, "bonus2.png");
            this.imglist1.Images.SetKeyName(2, "bonus3.png");
            this.imglist1.Images.SetKeyName(3, "bonus4.png");
            this.imglist1.Images.SetKeyName(4, "cap.png");
            this.imglist1.Images.SetKeyName(5, "corp.png");
            this.imglist1.Images.SetKeyName(6, "death.png");
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist.Images.SetKeyName(0, "zid.png");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(658, 277);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 39);
            this.label1.TabIndex = 1;
            this.label1.Text = "Foloseste sagetile pentru a ajuta sarpele sa adune merele.\r\nP.S.: - apasa una din" +
    " sageti pentru a incepe\r\n         - succes!!! ";
            // 
            // BSnake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.ClientSize = new System.Drawing.Size(917, 661);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TabelaDeJoc);
            this.Name = "BSnake";
            this.Load += new System.EventHandler(this.BSnake_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BSnake_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.TabelaDeJoc)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox TabelaDeJoc;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ImageList imglist1;
        private System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.Label label1;
    }
}

