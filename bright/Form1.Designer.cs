namespace bright
{
    partial class Form1
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
            this.trackBarBrightness = new bright.Form1.TrackBarWithoutFocus();
            this.txtBrightnessValue = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtContrastValue = new System.Windows.Forms.TextBox();
            this.trackBarContrast = new bright.Form1.TrackBarWithoutFocus();
            this.btnRevert = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).BeginInit();
            this.SuspendLayout();
            // 
            // trackBarBrightness
            // 
            this.trackBarBrightness.LargeChange = 1;
            this.trackBarBrightness.Location = new System.Drawing.Point(32, 42);
            this.trackBarBrightness.Maximum = 100;
            this.trackBarBrightness.Minimum = -100;
            this.trackBarBrightness.Name = "trackBarBrightness";
            this.trackBarBrightness.Size = new System.Drawing.Size(315, 69);
            this.trackBarBrightness.TabIndex = 0;
            this.trackBarBrightness.TickFrequency = 0;
            this.trackBarBrightness.Scroll += new System.EventHandler(this.trackBarBrightness_Scroll);
            this.trackBarBrightness.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarBrightness_MouseUp);
            // 
            // txtBrightnessValue
            // 
            this.txtBrightnessValue.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtBrightnessValue.ForeColor = System.Drawing.SystemColors.Window;
            this.txtBrightnessValue.Location = new System.Drawing.Point(281, 14);
            this.txtBrightnessValue.Name = "txtBrightnessValue";
            this.txtBrightnessValue.Size = new System.Drawing.Size(52, 26);
            this.txtBrightnessValue.TabIndex = 1;
            this.txtBrightnessValue.Text = "0";
            this.txtBrightnessValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBrightnessValue.Leave += new System.EventHandler(this.txtBrightnessValue_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Brightness:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(408, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Contrast";
            // 
            // txtContrastValue
            // 
            this.txtContrastValue.BackColor = System.Drawing.SystemColors.InfoText;
            this.txtContrastValue.ForeColor = System.Drawing.SystemColors.Window;
            this.txtContrastValue.Location = new System.Drawing.Point(650, 14);
            this.txtContrastValue.Name = "txtContrastValue";
            this.txtContrastValue.Size = new System.Drawing.Size(52, 26);
            this.txtContrastValue.TabIndex = 4;
            this.txtContrastValue.Text = "0";
            this.txtContrastValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtContrastValue.Leave += new System.EventHandler(this.txtContrastValue_Leave);
            // 
            // trackBarContrast
            // 
            this.trackBarContrast.LargeChange = 1;
            this.trackBarContrast.Location = new System.Drawing.Point(401, 42);
            this.trackBarContrast.Maximum = 100;
            this.trackBarContrast.Minimum = -100;
            this.trackBarContrast.Name = "trackBarContrast";
            this.trackBarContrast.Size = new System.Drawing.Size(315, 69);
            this.trackBarContrast.TabIndex = 3;
            this.trackBarContrast.TickFrequency = 0;
            this.trackBarContrast.Scroll += new System.EventHandler(this.trackBarContrast_Scroll);
            this.trackBarContrast.MouseUp += new System.Windows.Forms.MouseEventHandler(this.trackBarContrast_MouseUp);
            // 
            // btnRevert
            // 
            this.btnRevert.Location = new System.Drawing.Point(508, 98);
            this.btnRevert.Name = "btnRevert";
            this.btnRevert.Size = new System.Drawing.Size(110, 34);
            this.btnRevert.TabIndex = 6;
            this.btnRevert.Text = "Revert";
            this.btnRevert.UseVisualStyleBackColor = true;
            this.btnRevert.Click += new System.EventHandler(this.btnRevert_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(638, 98);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(110, 34);
            this.btnExit.TabIndex = 7;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 146);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRevert);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtContrastValue);
            this.Controls.Add(this.trackBarContrast);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBrightnessValue);
            this.Controls.Add(this.trackBarBrightness);
            this.Name = "Form1";
            this.Text = "Brightness & Contrast";
            ((System.ComponentModel.ISupportInitialize)(this.trackBarBrightness)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarContrast)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBrightnessValue;
        private TrackBarWithoutFocus trackBarBrightness;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtContrastValue;
        private TrackBarWithoutFocus trackBarContrast;
        private System.Windows.Forms.Button btnRevert;
        private System.Windows.Forms.Button btnExit;
    }
}

