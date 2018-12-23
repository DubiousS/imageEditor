namespace ImageEditor
{
    partial class RotateForm
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
            this.rotateAngle = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.rotateAngle)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "rotate";
            // 
            // rotateAngle
            // 
            this.rotateAngle.LargeChange = 10;
            this.rotateAngle.Location = new System.Drawing.Point(13, 30);
            this.rotateAngle.Maximum = 360;
            this.rotateAngle.Name = "rotateAngle";
            this.rotateAngle.Size = new System.Drawing.Size(259, 45);
            this.rotateAngle.TabIndex = 3;
            this.rotateAngle.Scroll += new System.EventHandler(this.Rotate);
            // 
            // RotateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 131);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.rotateAngle);
            this.Name = "RotateForm";
            this.Text = "RotateForm";
            ((System.ComponentModel.ISupportInitialize)(this.rotateAngle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar rotateAngle;
    }
}