namespace ImageEditor
{
    partial class ScalingForm
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
            this.widthScale = new System.Windows.Forms.TrackBar();
            this.heightScale = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.widthScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightScale)).BeginInit();
            this.SuspendLayout();
            // 
            // widthScale
            // 
            this.widthScale.LargeChange = 10;
            this.widthScale.Location = new System.Drawing.Point(13, 24);
            this.widthScale.Maximum = 100;
            this.widthScale.Minimum = 1;
            this.widthScale.Name = "widthScale";
            this.widthScale.Size = new System.Drawing.Size(259, 45);
            this.widthScale.TabIndex = 1;
            this.widthScale.Value = 100;
            this.widthScale.Scroll += new System.EventHandler(this.Scale);
            // 
            // heightScale
            // 
            this.heightScale.LargeChange = 10;
            this.heightScale.Location = new System.Drawing.Point(13, 108);
            this.heightScale.Maximum = 100;
            this.heightScale.Minimum = 1;
            this.heightScale.Name = "heightScale";
            this.heightScale.Size = new System.Drawing.Size(259, 45);
            this.heightScale.TabIndex = 1;
            this.heightScale.Value = 100;
            this.heightScale.Scroll += new System.EventHandler(this.Scale);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "width";
            // 
            // ScalingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 149);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.heightScale);
            this.Controls.Add(this.widthScale);
            this.Name = "ScalingForm";
            this.Text = "ScalingForm";
            ((System.ComponentModel.ISupportInitialize)(this.widthScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightScale)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar widthScale;
        private System.Windows.Forms.TrackBar heightScale;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}