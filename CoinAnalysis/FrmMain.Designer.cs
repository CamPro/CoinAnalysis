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
            this.buttonOpenFolder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.buttonOpenProfile = new System.Windows.Forms.Button();
            this.buttonOpenDriver = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOpenFolder
            // 
            this.buttonOpenFolder.Location = new System.Drawing.Point(33, 16);
            this.buttonOpenFolder.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOpenFolder.Name = "buttonOpenFolder";
            this.buttonOpenFolder.Size = new System.Drawing.Size(115, 36);
            this.buttonOpenFolder.TabIndex = 0;
            this.buttonOpenFolder.Text = "Open folder";
            this.buttonOpenFolder.UseVisualStyleBackColor = true;
            this.buttonOpenFolder.Click += new System.EventHandler(this.buttonOpenFolder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(33, 102);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // buttonOpenProfile
            // 
            this.buttonOpenProfile.Location = new System.Drawing.Point(156, 16);
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
            this.buttonOpenDriver.Location = new System.Drawing.Point(279, 16);
            this.buttonOpenDriver.Margin = new System.Windows.Forms.Padding(4);
            this.buttonOpenDriver.Name = "buttonOpenDriver";
            this.buttonOpenDriver.Size = new System.Drawing.Size(115, 36);
            this.buttonOpenDriver.TabIndex = 3;
            this.buttonOpenDriver.Text = "Open driver";
            this.buttonOpenDriver.UseVisualStyleBackColor = true;
            this.buttonOpenDriver.Click += new System.EventHandler(this.buttonOpenDriver_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 341);
            this.Controls.Add(this.buttonOpenDriver);
            this.Controls.Add(this.buttonOpenProfile);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonOpenFolder);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmMain";
            this.Text = "Coin Analysis";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Shown += new System.EventHandler(this.FrmMain_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFolder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button buttonOpenProfile;
        private System.Windows.Forms.Button buttonOpenDriver;
    }
}

