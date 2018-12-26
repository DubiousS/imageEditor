namespace ImageEditor
{
    partial class VideoDetectorForm
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
            this.components = new System.ComponentModel.Container();
            this.videoCapture = new Emgu.CV.UI.ImageBox();
            this.faceDetect = new System.Windows.Forms.Button();
            this.textDetect = new System.Windows.Forms.Button();
            this.textFromVideo = new System.Windows.Forms.RichTextBox();
            this.moveDetect = new System.Windows.Forms.Button();
            this.loadVideo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.videoCapture)).BeginInit();
            this.SuspendLayout();
            // 
            // videoCapture
            // 
            this.videoCapture.Location = new System.Drawing.Point(13, 13);
            this.videoCapture.Name = "videoCapture";
            this.videoCapture.Size = new System.Drawing.Size(346, 328);
            this.videoCapture.TabIndex = 2;
            this.videoCapture.TabStop = false;
            // 
            // faceDetect
            // 
            this.faceDetect.Location = new System.Drawing.Point(366, 13);
            this.faceDetect.Name = "faceDetect";
            this.faceDetect.Size = new System.Drawing.Size(164, 23);
            this.faceDetect.TabIndex = 3;
            this.faceDetect.Text = "face detect";
            this.faceDetect.UseVisualStyleBackColor = true;
            this.faceDetect.Click += new System.EventHandler(this.StartFaceDetect);
            // 
            // textDetect
            // 
            this.textDetect.Location = new System.Drawing.Point(366, 42);
            this.textDetect.Name = "textDetect";
            this.textDetect.Size = new System.Drawing.Size(164, 23);
            this.textDetect.TabIndex = 3;
            this.textDetect.Text = "text detect";
            this.textDetect.UseVisualStyleBackColor = true;
            this.textDetect.Click += new System.EventHandler(this.StartTextDetect);
            // 
            // textFromVideo
            // 
            this.textFromVideo.Location = new System.Drawing.Point(12, 347);
            this.textFromVideo.Name = "textFromVideo";
            this.textFromVideo.Size = new System.Drawing.Size(347, 96);
            this.textFromVideo.TabIndex = 4;
            this.textFromVideo.Text = "";
            // 
            // moveDetect
            // 
            this.moveDetect.Location = new System.Drawing.Point(365, 71);
            this.moveDetect.Name = "moveDetect";
            this.moveDetect.Size = new System.Drawing.Size(164, 23);
            this.moveDetect.TabIndex = 3;
            this.moveDetect.Text = "move detect";
            this.moveDetect.UseVisualStyleBackColor = true;
            this.moveDetect.Click += new System.EventHandler(this.StartMoveDetect);
            // 
            // loadVideo
            // 
            this.loadVideo.Location = new System.Drawing.Point(366, 100);
            this.loadVideo.Name = "loadVideo";
            this.loadVideo.Size = new System.Drawing.Size(164, 23);
            this.loadVideo.TabIndex = 3;
            this.loadVideo.Text = "Load file for move";
            this.loadVideo.UseVisualStyleBackColor = true;
            this.loadVideo.Click += new System.EventHandler(this.LoadVideo);
            // 
            // VideoDetectorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 450);
            this.Controls.Add(this.textFromVideo);
            this.Controls.Add(this.loadVideo);
            this.Controls.Add(this.moveDetect);
            this.Controls.Add(this.textDetect);
            this.Controls.Add(this.faceDetect);
            this.Controls.Add(this.videoCapture);
            this.Name = "VideoDetectorForm";
            this.Text = "VideoDetectorForm";
            ((System.ComponentModel.ISupportInitialize)(this.videoCapture)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Emgu.CV.UI.ImageBox videoCapture;
        private System.Windows.Forms.Button faceDetect;
        private System.Windows.Forms.Button textDetect;
        private System.Windows.Forms.RichTextBox textFromVideo;
        private System.Windows.Forms.Button moveDetect;
        private System.Windows.Forms.Button loadVideo;
    }
}