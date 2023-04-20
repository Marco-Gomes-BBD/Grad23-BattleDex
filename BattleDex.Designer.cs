namespace Grad23_BattleDex
{
    partial class frmBattle
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmBattle));
            btnPrev = new Button();
            btnNext = new Button();
            nudSlides = new NumericUpDown();
            label1 = new Label();
            btnExport = new Button();
            pbBattle = new PictureBox();
            txtTopic = new TextBox();
            btnRandom = new Button();
            btnGenerate = new Button();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            nudTime = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)nudSlides).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBattle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTime).BeginInit();
            SuspendLayout();
            // 
            // btnPrev
            // 
            btnPrev.BackColor = Color.DimGray;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.FlatStyle = FlatStyle.Popup;
            btnPrev.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrev.ForeColor = Color.DarkRed;
            btnPrev.Location = new Point(720, 430);
            btnPrev.Name = "btnPrev";
            btnPrev.Padding = new Padding(1);
            btnPrev.Size = new Size(122, 48);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<<Prev";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.BackColor = Color.DimGray;
            btnNext.FlatStyle = FlatStyle.Popup;
            btnNext.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNext.ForeColor = Color.DarkRed;
            btnNext.Location = new Point(849, 430);
            btnNext.Name = "btnNext";
            btnNext.Padding = new Padding(1);
            btnNext.Size = new Size(122, 48);
            btnNext.TabIndex = 2;
            btnNext.Text = "Next>>";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // nudSlides
            // 
            nudSlides.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nudSlides.Location = new Point(799, 233);
            nudSlides.Name = "nudSlides";
            nudSlides.Size = new Size(86, 26);
            nudSlides.TabIndex = 3;
            nudSlides.ValueChanged += nudSlides_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.DarkRed;
            label1.Location = new Point(754, 182);
            label1.Name = "label1";
            label1.Size = new Size(148, 23);
            label1.TabIndex = 4;
            label1.Text = "Amount of Slides:";
            // 
            // btnExport
            // 
            btnExport.BackColor = Color.DimGray;
            btnExport.FlatStyle = FlatStyle.Popup;
            btnExport.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExport.ForeColor = Color.DarkRed;
            btnExport.Location = new Point(720, 579);
            btnExport.Name = "btnExport";
            btnExport.Padding = new Padding(1);
            btnExport.Size = new Size(251, 42);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // pbBattle
            // 
            pbBattle.Location = new Point(4, 11);
            pbBattle.Name = "pbBattle";
            pbBattle.Size = new Size(700, 562);
            pbBattle.TabIndex = 6;
            pbBattle.TabStop = false;
            // 
            // txtTopic
            // 
            txtTopic.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTopic.Location = new Point(89, 579);
            txtTopic.Multiline = true;
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(615, 42);
            txtTopic.TabIndex = 8;
            txtTopic.TextChanged += txtTopic_TextChanged;
            // 
            // btnRandom
            // 
            btnRandom.BackColor = Color.DimGray;
            btnRandom.FlatStyle = FlatStyle.Popup;
            btnRandom.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandom.ForeColor = Color.DarkRed;
            btnRandom.Location = new Point(720, 484);
            btnRandom.Name = "btnRandom";
            btnRandom.Padding = new Padding(1);
            btnRandom.Size = new Size(251, 42);
            btnRandom.TabIndex = 9;
            btnRandom.Text = "Randomise";
            btnRandom.UseVisualStyleBackColor = false;
            btnRandom.Click += btnRandom_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.DimGray;
            btnGenerate.FlatStyle = FlatStyle.Popup;
            btnGenerate.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerate.ForeColor = Color.DarkRed;
            btnGenerate.Location = new Point(720, 532);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Padding = new Padding(1);
            btnGenerate.Size = new Size(251, 42);
            btnGenerate.TabIndex = 10;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = Color.DarkRed;
            label2.Location = new Point(10, 585);
            label2.Name = "label2";
            label2.Size = new Size(50, 23);
            label2.TabIndex = 11;
            label2.Text = "Topic";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = Color.DarkRed;
            label3.Location = new Point(774, 286);
            label3.Name = "label3";
            label3.Size = new Size(116, 23);
            label3.TabIndex = 13;
            label3.Text = "Time of Talk:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DarkRed;
            label4.ImageAlign = ContentAlignment.MiddleRight;
            label4.Location = new Point(757, 26);
            label4.Name = "label4";
            label4.Size = new Size(149, 37);
            label4.TabIndex = 15;
            label4.Text = "BATTLEDEX";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = (Image)resources.GetObject("pictureBox1.BackgroundImage");
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(771, 72);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(133, 106);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // nudTime
            // 
            nudTime.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nudTime.Location = new Point(799, 337);
            nudTime.Name = "nudTime";
            nudTime.Size = new Size(86, 26);
            nudTime.TabIndex = 17;
            nudTime.ValueChanged += nudTime_ValueChanged;
            // 
            // frmBattle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuText;
            ClientSize = new Size(982, 634);
            Controls.Add(nudTime);
            Controls.Add(pictureBox1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(btnGenerate);
            Controls.Add(btnRandom);
            Controls.Add(txtTopic);
            Controls.Add(pbBattle);
            Controls.Add(btnExport);
            Controls.Add(label1);
            Controls.Add(nudSlides);
            Controls.Add(btnNext);
            Controls.Add(btnPrev);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmBattle";
            Text = "Battledex Generator";
            ((System.ComponentModel.ISupportInitialize)nudSlides).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBattle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTime).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.NumericUpDown nudSlides;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.PictureBox pbBattle;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private NumericUpDown nudTime;
    }
}

