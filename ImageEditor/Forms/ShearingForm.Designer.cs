namespace ImageEditor
{
    partial class ShearingForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.sharingAlignTop = new System.Windows.Forms.TrackBar();
            this.sharingAlignRight = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.sharingAlignBottom = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.sharingAlignLeft = new System.Windows.Forms.TrackBar();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.sharingAlignTop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharingAlignRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharingAlignBottom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharingAlignLeft)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "sharing align top";
            // 
            // sharingAlignTop
            // 
            this.sharingAlignTop.LargeChange = 10;
            this.sharingAlignTop.Location = new System.Drawing.Point(12, 27);
            this.sharingAlignTop.Maximum = 90;
            this.sharingAlignTop.Name = "sharingAlignTop";
            this.sharingAlignTop.Size = new System.Drawing.Size(259, 45);
            this.sharingAlignTop.TabIndex = 3;
            this.sharingAlignTop.Scroll += new System.EventHandler(this.SharingAlignTop);
            // 
            // sharingAlignRight
            // 
            this.sharingAlignRight.LargeChange = 10;
            this.sharingAlignRight.Location = new System.Drawing.Point(12, 91);
            this.sharingAlignRight.Maximum = 90;
            this.sharingAlignRight.Name = "sharingAlignRight";
            this.sharingAlignRight.Size = new System.Drawing.Size(259, 45);
            this.sharingAlignRight.TabIndex = 3;
            this.sharingAlignRight.Scroll += new System.EventHandler(this.SharingAlignRight);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "sharing align right";
            // 
            // sharingAlignBottom
            // 
            this.sharingAlignBottom.LargeChange = 10;
            this.sharingAlignBottom.Location = new System.Drawing.Point(12, 142);
            this.sharingAlignBottom.Maximum = 90;
            this.sharingAlignBottom.Name = "sharingAlignBottom";
            this.sharingAlignBottom.Size = new System.Drawing.Size(259, 45);
            this.sharingAlignBottom.TabIndex = 3;
            this.sharingAlignBottom.Scroll += new System.EventHandler(this.SharingAlignBottom);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "sharing align bottom";
            // 
            // sharingAlignLeft
            // 
            this.sharingAlignLeft.LargeChange = 10;
            this.sharingAlignLeft.Location = new System.Drawing.Point(15, 193);
            this.sharingAlignLeft.Maximum = 90;
            this.sharingAlignLeft.Name = "sharingAlignLeft";
            this.sharingAlignLeft.Size = new System.Drawing.Size(259, 45);
            this.sharingAlignLeft.TabIndex = 3;
            this.sharingAlignLeft.Scroll += new System.EventHandler(this.SharingAlignLeft);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 177);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "sharing align left";
            // 
            // ShearingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(280, 261);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.sharingAlignLeft);
            this.Controls.Add(this.sharingAlignBottom);
            this.Controls.Add(this.sharingAlignRight);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sharingAlignTop);
            this.Name = "ShearingForm";
            this.Text = "ShearingForm";
            ((System.ComponentModel.ISupportInitialize)(this.sharingAlignTop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharingAlignRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharingAlignBottom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sharingAlignLeft)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar sharingAlignTop;
        private System.Windows.Forms.TrackBar sharingAlignRight;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar sharingAlignBottom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar sharingAlignLeft;
        private System.Windows.Forms.Label label4;
    }
}