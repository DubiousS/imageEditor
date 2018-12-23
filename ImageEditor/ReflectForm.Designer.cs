namespace ImageEditor
{
    partial class ReflectForm
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
            this.qX = new System.Windows.Forms.ListBox();
            this.qY = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // qX
            // 
            this.qX.FormattingEnabled = true;
            this.qX.Items.AddRange(new object[] {
            "1",
            "-1"});
            this.qX.Location = new System.Drawing.Point(12, 12);
            this.qX.Name = "qX";
            this.qX.Size = new System.Drawing.Size(23, 30);
            this.qX.TabIndex = 2;
            this.qX.SelectedIndexChanged += new System.EventHandler(this.OnSelect);
            // 
            // qY
            // 
            this.qY.FormattingEnabled = true;
            this.qY.Items.AddRange(new object[] {
            "1",
            "-1"});
            this.qY.Location = new System.Drawing.Point(85, 12);
            this.qY.Name = "qY";
            this.qY.Size = new System.Drawing.Size(23, 30);
            this.qY.TabIndex = 3;
            this.qY.SelectedIndexChanged += new System.EventHandler(this.OnSelect);
            // 
            // ReflectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 55);
            this.Controls.Add(this.qY);
            this.Controls.Add(this.qX);
            this.Name = "ReflectForm";
            this.Text = "ReflectForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox qX;
        private System.Windows.Forms.ListBox qY;
    }
}