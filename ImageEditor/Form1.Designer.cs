namespace ImageEditor
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.download = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.imageDefault = new Emgu.CV.UI.ImageBox();
            this.cannyThresholdLinking = new System.Windows.Forms.TrackBar();
            this.cannyThreshold = new System.Windows.Forms.TrackBar();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.stop = new System.Windows.Forms.Button();
            this.start = new System.Windows.Forms.Button();
            this.videoContainer = new Emgu.CV.UI.ImageBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.defaultImageChannel = new Emgu.CV.UI.ImageBox();
            this.editedImage = new Emgu.CV.UI.ImageBox();
            this.channelList = new System.Windows.Forms.ListBox();
            this.downloadChannelImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.imageDefault)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThresholdLinking)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThreshold)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.videoContainer)).BeginInit();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultImageChannel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editedImage)).BeginInit();
            this.SuspendLayout();
            // 
            // download
            // 
            this.download.Location = new System.Drawing.Point(10, 440);
            this.download.Name = "download";
            this.download.Size = new System.Drawing.Size(89, 60);
            this.download.TabIndex = 3;
            this.download.Text = "Download";
            this.download.UseVisualStyleBackColor = true;
            this.download.Click += new System.EventHandler(this.loadImage);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(105, 469);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(89, 31);
            this.button2.TabIndex = 4;
            this.button2.Text = "Canny effect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.toCanny);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(105, 440);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(89, 31);
            this.button3.TabIndex = 5;
            this.button3.Text = "Cell Shading";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.cellShading);
            // 
            // imageDefault
            // 
            this.imageDefault.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageDefault.Location = new System.Drawing.Point(10, 6);
            this.imageDefault.Name = "imageDefault";
            this.imageDefault.Size = new System.Drawing.Size(615, 428);
            this.imageDefault.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.imageDefault.TabIndex = 2;
            this.imageDefault.TabStop = false;
            // 
            // cannyThresholdLinking
            // 
            this.cannyThresholdLinking.Location = new System.Drawing.Point(342, 440);
            this.cannyThresholdLinking.Maximum = 100;
            this.cannyThresholdLinking.Name = "cannyThresholdLinking";
            this.cannyThresholdLinking.Size = new System.Drawing.Size(138, 45);
            this.cannyThresholdLinking.TabIndex = 6;
            // 
            // cannyThreshold
            // 
            this.cannyThreshold.Location = new System.Drawing.Point(200, 440);
            this.cannyThreshold.Maximum = 100;
            this.cannyThreshold.Name = "cannyThreshold";
            this.cannyThreshold.Size = new System.Drawing.Size(136, 45);
            this.cannyThreshold.TabIndex = 7;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(-2, -4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(639, 538);
            this.tabControl1.TabIndex = 8;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.imageDefault);
            this.tabPage1.Controls.Add(this.cannyThresholdLinking);
            this.tabPage1.Controls.Add(this.cannyThreshold);
            this.tabPage1.Controls.Add(this.download);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(631, 512);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Canny and Cell";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(582, 440);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.resetImage);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.stop);
            this.tabPage2.Controls.Add(this.start);
            this.tabPage2.Controls.Add(this.videoContainer);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(631, 512);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TWITCH";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // stop
            // 
            this.stop.Location = new System.Drawing.Point(333, 465);
            this.stop.Name = "stop";
            this.stop.Size = new System.Drawing.Size(75, 23);
            this.stop.TabIndex = 4;
            this.stop.Text = "STOP";
            this.stop.UseVisualStyleBackColor = true;
            this.stop.Click += new System.EventHandler(this.stopVideo);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(227, 465);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 3;
            this.start.Text = "START";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.startVideo);
            // 
            // videoContainer
            // 
            this.videoContainer.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.videoContainer.Location = new System.Drawing.Point(0, 0);
            this.videoContainer.Name = "videoContainer";
            this.videoContainer.Size = new System.Drawing.Size(628, 439);
            this.videoContainer.TabIndex = 2;
            this.videoContainer.TabStop = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.downloadChannelImage);
            this.tabPage3.Controls.Add(this.channelList);
            this.tabPage3.Controls.Add(this.editedImage);
            this.tabPage3.Controls.Add(this.defaultImageChannel);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(631, 512);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "CHANNEL";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // defaultImageChannel
            // 
            this.defaultImageChannel.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.defaultImageChannel.Location = new System.Drawing.Point(4, 4);
            this.defaultImageChannel.Name = "defaultImageChannel";
            this.defaultImageChannel.Size = new System.Drawing.Size(300, 250);
            this.defaultImageChannel.TabIndex = 2;
            this.defaultImageChannel.TabStop = false;
            // 
            // editedImage
            // 
            this.editedImage.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.editedImage.Location = new System.Drawing.Point(325, 4);
            this.editedImage.Name = "editedImage";
            this.editedImage.Size = new System.Drawing.Size(300, 249);
            this.editedImage.TabIndex = 2;
            this.editedImage.TabStop = false;
            // 
            // channelList
            // 
            this.channelList.FormattingEnabled = true;
            this.channelList.Items.AddRange(new object[] {
            "ALL",
            "RED",
            "GREEN",
            "BLUE"});
            this.channelList.Location = new System.Drawing.Point(94, 260);
            this.channelList.Name = "channelList";
            this.channelList.Size = new System.Drawing.Size(48, 56);
            this.channelList.TabIndex = 4;
            this.channelList.SelectedIndexChanged += new System.EventHandler(this.selectChannel);
            // 
            // downloadChannelImage
            // 
            this.downloadChannelImage.Location = new System.Drawing.Point(4, 260);
            this.downloadChannelImage.Name = "downloadChannelImage";
            this.downloadChannelImage.Size = new System.Drawing.Size(84, 56);
            this.downloadChannelImage.TabIndex = 5;
            this.downloadChannelImage.Text = "Download";
            this.downloadChannelImage.UseVisualStyleBackColor = true;
            this.downloadChannelImage.Click += new System.EventHandler(this.downloadImageForChannelEdtor);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 530);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageDefault)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThresholdLinking)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cannyThreshold)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.videoContainer)).EndInit();
            this.tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.defaultImageChannel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editedImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button download;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private Emgu.CV.UI.ImageBox imageDefault;
        private System.Windows.Forms.TrackBar cannyThresholdLinking;
        private System.Windows.Forms.TrackBar cannyThreshold;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private Emgu.CV.UI.ImageBox videoContainer;
        private System.Windows.Forms.Button stop;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TabPage tabPage3;
        private Emgu.CV.UI.ImageBox editedImage;
        private Emgu.CV.UI.ImageBox defaultImageChannel;
        private System.Windows.Forms.ListBox channelList;
        private System.Windows.Forms.Button downloadChannelImage;
    }
}

