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
            lblSlides = new Label();
            btnExport = new Button();
            pbBattle = new PictureBox();
            txtTopic = new TextBox();
            btnRandom = new Button();
            btnGenerate = new Button();
            lblTopic = new Label();
            lblTime = new Label();
            label4 = new Label();
            pictureBox1 = new PictureBox();
            nudTime = new NumericUpDown();
            pnlControl = new Panel();
            ((System.ComponentModel.ISupportInitialize)nudSlides).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBattle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTime).BeginInit();
            pnlControl.SuspendLayout();
            SuspendLayout();
            // 
            // btnPrev
            // 
            btnPrev.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnPrev.BackColor = Color.DimGray;
            btnPrev.Cursor = Cursors.Hand;
            btnPrev.FlatStyle = FlatStyle.Popup;
            btnPrev.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnPrev.ForeColor = Color.DarkRed;
            btnPrev.Location = new Point(0, 362);
            btnPrev.Name = "btnPrev";
            btnPrev.Padding = new Padding(1);
            btnPrev.Size = new Size(124, 48);
            btnPrev.TabIndex = 1;
            btnPrev.Text = "<<Prev";
            btnPrev.UseVisualStyleBackColor = false;
            btnPrev.Click += btnPrev_Click;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnNext.BackColor = Color.DimGray;
            btnNext.FlatStyle = FlatStyle.Popup;
            btnNext.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnNext.ForeColor = Color.DarkRed;
            btnNext.Location = new Point(130, 362);
            btnNext.Name = "btnNext";
            btnNext.Padding = new Padding(1);
            btnNext.Size = new Size(124, 48);
            btnNext.TabIndex = 2;
            btnNext.Text = "Next>>";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += btnNext_Click;
            // 
            // nudSlides
            // 
            nudSlides.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nudSlides.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nudSlides.Location = new Point(168, 298);
            nudSlides.Maximum = new decimal(new int[] { 90, 0, 0, 0 });
            nudSlides.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            nudSlides.Name = "nudSlides";
            nudSlides.Size = new Size(86, 26);
            nudSlides.TabIndex = 3;
            nudSlides.Value = new decimal(new int[] { 5, 0, 0, 0 });
            nudSlides.ValueChanged += nudSlides_ValueChanged;
            // 
            // lblSlides
            // 
            lblSlides.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSlides.AutoSize = true;
            lblSlides.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblSlides.ForeColor = Color.DarkRed;
            lblSlides.Location = new Point(3, 298);
            lblSlides.Name = "lblSlides";
            lblSlides.Size = new Size(148, 23);
            lblSlides.TabIndex = 4;
            lblSlides.Text = "Amount of Slides:";
            // 
            // btnExport
            // 
            btnExport.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnExport.BackColor = Color.DimGray;
            btnExport.FlatStyle = FlatStyle.Popup;
            btnExport.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnExport.ForeColor = Color.DarkRed;
            btnExport.Location = new Point(3, 512);
            btnExport.Name = "btnExport";
            btnExport.Padding = new Padding(1);
            btnExport.Size = new Size(254, 42);
            btnExport.TabIndex = 5;
            btnExport.Text = "Export";
            btnExport.UseVisualStyleBackColor = false;
            btnExport.Click += btnExport_Click;
            // 
            // pbBattle
            // 
            pbBattle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pbBattle.Location = new Point(4, 11);
            pbBattle.Name = "pbBattle";
            pbBattle.Size = new Size(634, 509);
            pbBattle.SizeMode = PictureBoxSizeMode.StretchImage;
            pbBattle.TabIndex = 6;
            pbBattle.TabStop = false;
            // 
            // txtTopic
            // 
            txtTopic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtTopic.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            txtTopic.Location = new Point(66, 523);
            txtTopic.Multiline = true;
            txtTopic.Name = "txtTopic";
            txtTopic.Size = new Size(572, 42);
            txtTopic.TabIndex = 8;
            txtTopic.TextChanged += txtTopic_TextChanged;
            // 
            // btnRandom
            // 
            btnRandom.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnRandom.BackColor = Color.DimGray;
            btnRandom.FlatStyle = FlatStyle.Popup;
            btnRandom.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnRandom.ForeColor = Color.DarkRed;
            btnRandom.Location = new Point(0, 416);
            btnRandom.Name = "btnRandom";
            btnRandom.Padding = new Padding(1);
            btnRandom.Size = new Size(254, 42);
            btnRandom.TabIndex = 9;
            btnRandom.Text = "Randomise";
            btnRandom.UseVisualStyleBackColor = false;
            btnRandom.Click += btnRandom_Click;
            // 
            // btnGenerate
            // 
            btnGenerate.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btnGenerate.BackColor = Color.DimGray;
            btnGenerate.FlatStyle = FlatStyle.Popup;
            btnGenerate.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btnGenerate.ForeColor = Color.DarkRed;
            btnGenerate.Location = new Point(3, 464);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Padding = new Padding(1);
            btnGenerate.Size = new Size(254, 42);
            btnGenerate.TabIndex = 10;
            btnGenerate.Text = "Generate";
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // lblTopic
            // 
            lblTopic.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTopic.AutoSize = true;
            lblTopic.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTopic.ForeColor = Color.DarkRed;
            lblTopic.Location = new Point(10, 532);
            lblTopic.Name = "lblTopic";
            lblTopic.Size = new Size(50, 23);
            lblTopic.TabIndex = 11;
            lblTopic.Text = "Topic";
            // 
            // lblTime
            // 
            lblTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Comic Sans MS", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lblTime.ForeColor = Color.DarkRed;
            lblTime.Location = new Point(3, 330);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(116, 23);
            lblTime.TabIndex = 13;
            lblTime.Text = "Time of Talk:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Impact", 22.2F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = Color.DarkRed;
            label4.ImageAlign = ContentAlignment.MiddleRight;
            label4.Location = new Point(55, 0);
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
            pictureBox1.Location = new Point(3, 40);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(254, 253);
            pictureBox1.TabIndex = 16;
            pictureBox1.TabStop = false;
            // 
            // nudTime
            // 
            nudTime.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nudTime.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point);
            nudTime.Increment = new decimal(new int[] { 30, 0, 0, 0 });
            nudTime.Location = new Point(168, 330);
            nudTime.Maximum = new decimal(new int[] { 600, 0, 0, 0 });
            nudTime.Minimum = new decimal(new int[] { 180, 0, 0, 0 });
            nudTime.Name = "nudTime";
            nudTime.Size = new Size(86, 26);
            nudTime.TabIndex = 17;
            nudTime.Value = new decimal(new int[] { 180, 0, 0, 0 });
            nudTime.ValueChanged += nudTime_ValueChanged;
            // 
            // pnlControl
            // 
            pnlControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            pnlControl.Controls.Add(label4);
            pnlControl.Controls.Add(nudTime);
            pnlControl.Controls.Add(btnGenerate);
            pnlControl.Controls.Add(pictureBox1);
            pnlControl.Controls.Add(btnExport);
            pnlControl.Controls.Add(btnRandom);
            pnlControl.Controls.Add(lblTime);
            pnlControl.Controls.Add(lblSlides);
            pnlControl.Controls.Add(nudSlides);
            pnlControl.Controls.Add(btnPrev);
            pnlControl.Controls.Add(btnNext);
            pnlControl.Location = new Point(644, 11);
            pnlControl.Name = "pnlControl";
            pnlControl.Size = new Size(260, 557);
            pnlControl.TabIndex = 18;
            // 
            // frmBattle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.MenuText;
            ClientSize = new Size(916, 581);
            Controls.Add(pnlControl);
            Controls.Add(lblTopic);
            Controls.Add(txtTopic);
            Controls.Add(pbBattle);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(932, 620);
            Name = "frmBattle";
            Text = "Battledex Generator";
            ((System.ComponentModel.ISupportInitialize)nudSlides).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBattle).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTime).EndInit();
            pnlControl.ResumeLayout(false);
            pnlControl.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button btnPrev;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.NumericUpDown nudSlides;
        private System.Windows.Forms.Label lblSlides;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.PictureBox pbBattle;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.Button btnRandom;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label lblTopic;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;
        private NumericUpDown nudTime;
        private Panel pnlControl;
    }
}

