namespace ImageEditor
{
    partial class ChannelsForm
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
            this.allChannel = new System.Windows.Forms.Button();
            this.redChannel = new System.Windows.Forms.Button();
            this.greenChannel = new System.Windows.Forms.Button();
            this.blueChannel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // allChannel
            // 
            this.allChannel.Location = new System.Drawing.Point(10, 10);
            this.allChannel.Name = "allChannel";
            this.allChannel.Size = new System.Drawing.Size(40, 40);
            this.allChannel.TabIndex = 0;
            this.allChannel.UseVisualStyleBackColor = true;
            this.allChannel.Click += new System.EventHandler(this.SetAllChannels);
            // 
            // redChannel
            // 
            this.redChannel.BackColor = System.Drawing.Color.Red;
            this.redChannel.Location = new System.Drawing.Point(60, 10);
            this.redChannel.Name = "redChannel";
            this.redChannel.Size = new System.Drawing.Size(40, 40);
            this.redChannel.TabIndex = 1;
            this.redChannel.UseVisualStyleBackColor = false;
            this.redChannel.Click += new System.EventHandler(this.SetRedChannel);
            // 
            // greenChannel
            // 
            this.greenChannel.BackColor = System.Drawing.Color.Green;
            this.greenChannel.Location = new System.Drawing.Point(110, 10);
            this.greenChannel.Name = "greenChannel";
            this.greenChannel.Size = new System.Drawing.Size(40, 40);
            this.greenChannel.TabIndex = 2;
            this.greenChannel.UseVisualStyleBackColor = false;
            this.greenChannel.Click += new System.EventHandler(this.SetGreenChannel);
            // 
            // blueChannel
            // 
            this.blueChannel.BackColor = System.Drawing.Color.Blue;
            this.blueChannel.Location = new System.Drawing.Point(160, 10);
            this.blueChannel.Name = "blueChannel";
            this.blueChannel.Size = new System.Drawing.Size(40, 40);
            this.blueChannel.TabIndex = 3;
            this.blueChannel.UseVisualStyleBackColor = false;
            this.blueChannel.Click += new System.EventHandler(this.SetBlueChannel);
            // 
            // ChannelsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 61);
            this.Controls.Add(this.blueChannel);
            this.Controls.Add(this.greenChannel);
            this.Controls.Add(this.redChannel);
            this.Controls.Add(this.allChannel);
            this.Name = "ChannelsForm";
            this.Text = "ChannelsForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button allChannel;
        private System.Windows.Forms.Button redChannel;
        private System.Windows.Forms.Button greenChannel;
        private System.Windows.Forms.Button blueChannel;
    }
}