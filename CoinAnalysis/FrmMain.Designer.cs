namespace CoinAnalysis
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.buttonOpenProfile = new System.Windows.Forms.Button();
            this.buttonOpenDriver = new System.Windows.Forms.Button();
            this.buttonScanAnalysis = new System.Windows.Forms.Button();
            this.buttonAnalysis = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.numPageCMC = new System.Windows.Forms.NumericUpDown();
            this.numStartIndex = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.numYellowPixel = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPageCMC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYellowPixel)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(15, 15);
            this.buttonOpenFolder.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(115, 36);
            this.buttonOpenFolder.TabIndex = 0;
            this.buttonOpenFolder.Text = "Open folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // buttonOpenProfile
            // 
            this.buttonOpenProfile.Location = new System.Drawing.Point(138, 15);
            this.buttonOpenProfile.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenProfile.Name = "buttonOpenProfile";
            this.buttonOpenProfile.Size = new System.Drawing.Size(115, 36);
            this.buttonOpenProfile.TabIndex = 2;
            this.buttonOpenProfile.Text = "Open profile";
            this.buttonOpenProfile.UseVisualStyleBackColor = true;
            this.buttonOpenProfile.Click += new System.EventHandler(this.buttonOpenProfile_Click);
            // 
            // buttonOpenDriver
            // 
            this.buttonOpenDriver.Location = new System.Drawing.Point(261, 15);
            this.buttonOpenDriver.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenDriver.Name = "buttonOpenDriver";
            this.buttonOpenDriver.Size = new System.Drawing.Size(115, 36);
            this.buttonOpenDriver.TabIndex = 3;
            this.buttonOpenDriver.Text = "Open driver";
            this.buttonOpenDriver.UseVisualStyleBackColor = true;
            this.buttonOpenDriver.Click += new System.EventHandler(this.buttonOpenDriver_Click);
            // 
            // buttonScanAnalysis
            // 
            this.buttonScanAnalysis.Location = new System.Drawing.Point(15, 110);
            this.buttonScanAnalysis.Name = "buttonScanAnalysis";
            this.buttonScanAnalysis.Size = new System.Drawing.Size(150, 40);
            this.buttonScanAnalysis.TabIndex = 5;
            this.buttonScanAnalysis.Text = "Scan + Analysis";
            this.buttonScanAnalysis.UseVisualStyleBackColor = true;
            this.buttonScanAnalysis.Click += new System.EventHandler(this.buttonScanAnalysis_Click);
            // 
            // buttonAnalysis
            // 
            this.buttonAnalysis.Location = new System.Drawing.Point(15, 198);
            this.buttonAnalysis.Name = "buttonAnalysis";
            this.buttonAnalysis.Size = new System.Drawing.Size(150, 40);
            this.buttonAnalysis.TabIndex = 6;
            this.buttonAnalysis.Text = "Analysis";
            this.buttonAnalysis.UseVisualStyleBackColor = true;
            this.buttonAnalysis.Click += new System.EventHandler(this.buttonAnalysis_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(201, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Số page CMC";
            // 
            // numPageCMC
            // 
            this.numPageCMC.Location = new System.Drawing.Point(321, 110);
            this.numPageCMC.Maximum = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this.numPageCMC.Name = "numPageCMC";
            this.numPageCMC.Size = new System.Drawing.Size(50, 23);
            this.numPageCMC.TabIndex = 8;
            this.numPageCMC.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            // 
            // numStartIndex
            // 
            this.numStartIndex.Location = new System.Drawing.Point(321, 141);
            this.numStartIndex.Name = "numStartIndex";
            this.numStartIndex.Size = new System.Drawing.Size(50, 23);
            this.numStartIndex.TabIndex = 10;
            this.numStartIndex.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 17);
            this.label2.TabIndex = 9;
            this.label2.Text = "Index bắt đầu";
            // 
            // numYellowPixel
            // 
            this.numYellowPixel.Location = new System.Drawing.Point(321, 208);
            this.numYellowPixel.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numYellowPixel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numYellowPixel.Name = "numYellowPixel";
            this.numYellowPixel.Size = new System.Drawing.Size(50, 23);
            this.numYellowPixel.TabIndex = 12;
            this.numYellowPixel.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Số pixel Vàng";
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 260);
            this.Controls.Add(this.numYellowPixel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numStartIndex);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numPageCMC);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonAnalysis);
            this.Controls.Add(this.buttonScanAnalysis);
            this.Controls.Add(this.buttonOpenDriver);
            this.Controls.Add(this.buttonOpenProfile);
            this.Controls.Add(this.buttonOpenFolder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmMain";
            this.Text = "Coin Analysis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.numPageCMC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStartIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numYellowPixel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button buttonOpenProfile;
        private System.Windows.Forms.Button buttonOpenDriver;
        private System.Windows.Forms.Button buttonScanAnalysis;
        private System.Windows.Forms.Button buttonAnalysis;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numPageCMC;
        private System.Windows.Forms.NumericUpDown numStartIndex;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numYellowPixel;
        private System.Windows.Forms.Label label3;
    }
}

