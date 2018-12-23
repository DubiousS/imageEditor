namespace ImageEditor
{
    partial class AppForm
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
            this.defaultImage = new Emgu.CV.UI.ImageBox();
            this.sourceImage = new Emgu.CV.UI.ImageBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asdaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.blackAndWhiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharpenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sepiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cartoonToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.windowFilterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.channelsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affinsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scalingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sharingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reflectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ApplyChangesButton = new System.Windows.Forms.Button();
            this.homographyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.defaultImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultImage
            // 
            this.defaultImage.Location = new System.Drawing.Point(12, 51);
            this.defaultImage.Name = "defaultImage";
            this.defaultImage.Size = new System.Drawing.Size(324, 397);
            this.defaultImage.TabIndex = 14;
            this.defaultImage.TabStop = false;
            // 
            // sourceImage
            // 
            this.sourceImage.Location = new System.Drawing.Point(381, 51);
            this.sourceImage.Name = "sourceImage";
            this.sourceImage.Size = new System.Drawing.Size(324, 397);
            this.sourceImage.TabIndex = 15;
            this.sourceImage.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.asdaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(717, 24);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "FILE";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(97, 22);
            this.loadToolStripMenuItem.Text = "load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.LoadImage);
            // 
            // asdaToolStripMenuItem
            // 
            this.asdaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.filtersToolStripMenuItem,
            this.channelsToolStripMenuItem,
            this.resetToolStripMenuItem,
            this.affinsToolStripMenuItem});
            this.asdaToolStripMenuItem.Name = "asdaToolStripMenuItem";
            this.asdaToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.asdaToolStripMenuItem.Text = "IMAGE";
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blackAndWhiteToolStripMenuItem,
            this.sharpenToolStripMenuItem,
            this.sepiaToolStripMenuItem,
            this.cellToolStripMenuItem,
            this.cartoonToolStripMenuItem,
            this.windowFilterToolStripMenuItem});
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.filtersToolStripMenuItem.Text = "filters";
            // 
            // blackAndWhiteToolStripMenuItem
            // 
            this.blackAndWhiteToolStripMenuItem.Name = "blackAndWhiteToolStripMenuItem";
            this.blackAndWhiteToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.blackAndWhiteToolStripMenuItem.Text = "grayscale";
            this.blackAndWhiteToolStripMenuItem.Click += new System.EventHandler(this.ToGrayScale);
            // 
            // sharpenToolStripMenuItem
            // 
            this.sharpenToolStripMenuItem.Name = "sharpenToolStripMenuItem";
            this.sharpenToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.sharpenToolStripMenuItem.Text = "blur";
            this.sharpenToolStripMenuItem.Click += new System.EventHandler(this.BlurImage);
            // 
            // sepiaToolStripMenuItem
            // 
            this.sepiaToolStripMenuItem.Name = "sepiaToolStripMenuItem";
            this.sepiaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.sepiaToolStripMenuItem.Text = "sepia";
            this.sepiaToolStripMenuItem.Click += new System.EventHandler(this.SepiaImage);
            // 
            // cellToolStripMenuItem
            // 
            this.cellToolStripMenuItem.Name = "cellToolStripMenuItem";
            this.cellToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cellToolStripMenuItem.Text = "cell shading";
            this.cellToolStripMenuItem.Click += new System.EventHandler(this.OpenCellShadingFilterModal);
            // 
            // cartoonToolStripMenuItem
            // 
            this.cartoonToolStripMenuItem.Name = "cartoonToolStripMenuItem";
            this.cartoonToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.cartoonToolStripMenuItem.Text = "cartoon";
            this.cartoonToolStripMenuItem.Click += new System.EventHandler(this.ToCartoon);
            // 
            // windowFilterToolStripMenuItem
            // 
            this.windowFilterToolStripMenuItem.Name = "windowFilterToolStripMenuItem";
            this.windowFilterToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.windowFilterToolStripMenuItem.Text = "window filter";
            this.windowFilterToolStripMenuItem.Click += new System.EventHandler(this.OpenWindowFilterModal);
            // 
            // channelsToolStripMenuItem
            // 
            this.channelsToolStripMenuItem.Name = "channelsToolStripMenuItem";
            this.channelsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.channelsToolStripMenuItem.Text = "channels";
            this.channelsToolStripMenuItem.Click += new System.EventHandler(this.OpenChannelModal);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.resetToolStripMenuItem.Text = "reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.ResetImage);
            // 
            // affinsToolStripMenuItem
            // 
            this.affinsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scalingToolStripMenuItem,
            this.sharingToolStripMenuItem,
            this.rotateToolStripMenuItem,
            this.reflectToolStripMenuItem,
            this.homographyToolStripMenuItem});
            this.affinsToolStripMenuItem.Name = "affinsToolStripMenuItem";
            this.affinsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.affinsToolStripMenuItem.Text = "affins";
            // 
            // scalingToolStripMenuItem
            // 
            this.scalingToolStripMenuItem.Name = "scalingToolStripMenuItem";
            this.scalingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.scalingToolStripMenuItem.Text = "scaling";
            this.scalingToolStripMenuItem.Click += new System.EventHandler(this.OpenScalingModal);
            // 
            // sharingToolStripMenuItem
            // 
            this.sharingToolStripMenuItem.Name = "sharingToolStripMenuItem";
            this.sharingToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sharingToolStripMenuItem.Text = "sharing";
            this.sharingToolStripMenuItem.Click += new System.EventHandler(this.OpenSharingModal);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.rotateToolStripMenuItem.Text = "rotate";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.OpenRotateModal);
            // 
            // reflectToolStripMenuItem
            // 
            this.reflectToolStripMenuItem.Name = "reflectToolStripMenuItem";
            this.reflectToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.reflectToolStripMenuItem.Text = "reflect";
            this.reflectToolStripMenuItem.Click += new System.EventHandler(this.OpenReflectModal);
            // 
            // ApplyChangesButton
            // 
            this.ApplyChangesButton.Location = new System.Drawing.Point(630, 454);
            this.ApplyChangesButton.Name = "ApplyChangesButton";
            this.ApplyChangesButton.Size = new System.Drawing.Size(75, 23);
            this.ApplyChangesButton.TabIndex = 20;
            this.ApplyChangesButton.Text = "Apply";
            this.ApplyChangesButton.UseVisualStyleBackColor = true;
            this.ApplyChangesButton.Click += new System.EventHandler(this.ApplyChanges);
            // 
            // homographyToolStripMenuItem
            // 
            this.homographyToolStripMenuItem.Name = "homographyToolStripMenuItem";
            this.homographyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.homographyToolStripMenuItem.Text = "homography";
            this.homographyToolStripMenuItem.Click += new System.EventHandler(this.StartHomography);
            // 
            // AppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 530);
            this.Controls.Add(this.ApplyChangesButton);
            this.Controls.Add(this.defaultImage);
            this.Controls.Add(this.sourceImage);
            this.Controls.Add(this.menuStrip1);
            this.Name = "AppForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.defaultImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sourceImage)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Emgu.CV.UI.ImageBox defaultImage;
        private Emgu.CV.UI.ImageBox sourceImage;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asdaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem blackAndWhiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharpenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sepiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cartoonToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem channelsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.Button ApplyChangesButton;
        private System.Windows.Forms.ToolStripMenuItem windowFilterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affinsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scalingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sharingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reflectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem homographyToolStripMenuItem;
    }
}

