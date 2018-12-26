namespace ImageEditor
{
    partial class CellShadingForm
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
            this.cannyThresholdLinking = new System.Windows.Forms.TrackBar();
            this.cannyThreshold = new System.Windows.Forms.TrackBar();
            this.cannyThresholdLabel = new System.Windows.Forms.Label();
            this.cannyThresholdLinkingLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThresholdLinking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // cannyThresholdLinking
            // 
            this.cannyThresholdLinking.AccessibleDescription = "";
            this.cannyThresholdLinking.AccessibleName = "";
            this.cannyThresholdLinking.Location = new System.Drawing.Point(12, 78);
            this.cannyThresholdLinking.Maximum = 100;
            this.cannyThresholdLinking.Name = "cannyThresholdLinking";
            this.cannyThresholdLinking.Size = new System.Drawing.Size(260, 45);
            this.cannyThresholdLinking.TabIndex = 18;
            this.cannyThresholdLinking.TickFrequency = 5;
            this.cannyThresholdLinking.Value = 40;
            this.cannyThresholdLinking.Scroll += new System.EventHandler(this.ToCellShading);
            // 
            // cannyThreshold
            // 
            this.cannyThreshold.Location = new System.Drawing.Point(12, 27);
            this.cannyThreshold.Maximum = 100;
            this.cannyThreshold.Name = "cannyThreshold";
            this.cannyThreshold.Size = new System.Drawing.Size(264, 45);
            this.cannyThreshold.TabIndex = 19;
            this.cannyThreshold.Tag = "";
            this.cannyThreshold.TickFrequency = 5;
            this.cannyThreshold.Value = 80;
            this.cannyThreshold.Scroll += new System.EventHandler(this.ToCellShading);
            // 
            // cannyThresholdLabel
            // 
            this.cannyThresholdLabel.AutoSize = true;
            this.cannyThresholdLabel.Location = new System.Drawing.Point(21, 11);
            this.cannyThresholdLabel.Name = "cannyThresholdLabel";
            this.cannyThresholdLabel.Size = new System.Drawing.Size(83, 13);
            this.cannyThresholdLabel.TabIndex = 20;
            this.cannyThresholdLabel.Text = "Canny threshold";
            // 
            // cannyThresholdLinkingLabel
            // 
            this.cannyThresholdLinkingLabel.AutoSize = true;
            this.cannyThresholdLinkingLabel.Location = new System.Drawing.Point(21, 62);
            this.cannyThresholdLinkingLabel.Name = "cannyThresholdLinkingLabel";
            this.cannyThresholdLinkingLabel.Size = new System.Drawing.Size(116, 13);
            this.cannyThresholdLinkingLabel.TabIndex = 21;
            this.cannyThresholdLinkingLabel.Text = "Canny threshold linking";
            // 
            // CannyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 127);
            this.Controls.Add(this.cannyThresholdLinkingLabel);
            this.Controls.Add(this.cannyThresholdLabel);
            this.Controls.Add(this.cannyThresholdLinking);
            this.Controls.Add(this.cannyThreshold);
            this.Name = "CannyForm";
            this.Text = "CannyForm";
            ((System.ComponentModel.ISupportInitialize)(this.cannyThresholdLinking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThreshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar cannyThresholdLinking;
        private System.Windows.Forms.TrackBar cannyThreshold;
        private System.Windows.Forms.Label cannyThresholdLabel;
        private System.Windows.Forms.Label cannyThresholdLinkingLabel;
    }
}