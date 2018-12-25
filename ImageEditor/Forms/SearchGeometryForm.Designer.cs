namespace ImageEditor
{
    partial class SearchGeometryForm
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
            this.searchContours = new System.Windows.Forms.Button();
            this.drawTriangle = new System.Windows.Forms.Button();
            this.triangleArea = new System.Windows.Forms.TrackBar();
            this.triangleAreaSize = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.rectangleArea = new System.Windows.Forms.TrackBar();
            this.rectangleAreaSize = new System.Windows.Forms.Label();
            this.thresholdValue = new System.Windows.Forms.TrackBar();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.distance = new System.Windows.Forms.TrackBar();
            this.distanceSize = new System.Windows.Forms.Label();
            this.radius = new System.Windows.Forms.TrackBar();
            this.radiusSize = new System.Windows.Forms.Label();
            this.primitivesCount = new System.Windows.Forms.Label();
            this.selectColor = new System.Windows.Forms.Button();
            this.color = new System.Windows.Forms.TrackBar();
            this.range = new System.Windows.Forms.TrackBar();
            this.colorSize = new System.Windows.Forms.Label();
            this.rangeSize = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.triangleArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.distance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.color)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.range)).BeginInit();
            this.SuspendLayout();
            // 
            // searchContours
            // 
            this.searchContours.Location = new System.Drawing.Point(12, 101);
            this.searchContours.Name = "searchContours";
            this.searchContours.Size = new System.Drawing.Size(100, 23);
            this.searchContours.TabIndex = 0;
            this.searchContours.Text = "Draw contours";
            this.searchContours.UseVisualStyleBackColor = true;
            this.searchContours.Click += new System.EventHandler(this.SearchContours);
            // 
            // drawTriangle
            // 
            this.drawTriangle.Location = new System.Drawing.Point(12, 130);
            this.drawTriangle.Name = "drawTriangle";
            this.drawTriangle.Size = new System.Drawing.Size(100, 23);
            this.drawTriangle.TabIndex = 0;
            this.drawTriangle.Text = "Draw triangles";
            this.drawTriangle.UseVisualStyleBackColor = true;
            this.drawTriangle.Click += new System.EventHandler(this.DrawTriangle);
            // 
            // triangleArea
            // 
            this.triangleArea.Location = new System.Drawing.Point(179, 130);
            this.triangleArea.Maximum = 10000;
            this.triangleArea.Minimum = 10;
            this.triangleArea.Name = "triangleArea";
            this.triangleArea.Size = new System.Drawing.Size(175, 45);
            this.triangleArea.SmallChange = 100;
            this.triangleArea.TabIndex = 1;
            this.triangleArea.TickFrequency = 50;
            this.triangleArea.Value = 100;
            this.triangleArea.Scroll += new System.EventHandler(this.OnChangeArea);
            // 
            // triangleAreaSize
            // 
            this.triangleAreaSize.AutoSize = true;
            this.triangleAreaSize.Location = new System.Drawing.Point(118, 135);
            this.triangleAreaSize.Name = "triangleAreaSize";
            this.triangleAreaSize.Size = new System.Drawing.Size(34, 13);
            this.triangleAreaSize.TabIndex = 2;
            this.triangleAreaSize.Text = "area: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 161);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Draw rectangles";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.DrawRectangle);
            // 
            // rectangleArea
            // 
            this.rectangleArea.Location = new System.Drawing.Point(179, 161);
            this.rectangleArea.Maximum = 10000;
            this.rectangleArea.Minimum = 10;
            this.rectangleArea.Name = "rectangleArea";
            this.rectangleArea.Size = new System.Drawing.Size(175, 45);
            this.rectangleArea.SmallChange = 100;
            this.rectangleArea.TabIndex = 1;
            this.rectangleArea.TickFrequency = 50;
            this.rectangleArea.Value = 100;
            this.rectangleArea.Scroll += new System.EventHandler(this.OnChangeRectArea);
            // 
            // rectangleAreaSize
            // 
            this.rectangleAreaSize.AutoSize = true;
            this.rectangleAreaSize.Location = new System.Drawing.Point(118, 171);
            this.rectangleAreaSize.Name = "rectangleAreaSize";
            this.rectangleAreaSize.Size = new System.Drawing.Size(34, 13);
            this.rectangleAreaSize.TabIndex = 2;
            this.rectangleAreaSize.Text = "area: ";
            // 
            // thresholdValue
            // 
            this.thresholdValue.Location = new System.Drawing.Point(12, 50);
            this.thresholdValue.Maximum = 200;
            this.thresholdValue.Minimum = 1;
            this.thresholdValue.Name = "thresholdValue";
            this.thresholdValue.Size = new System.Drawing.Size(342, 45);
            this.thresholdValue.SmallChange = 100;
            this.thresholdValue.TabIndex = 3;
            this.thresholdValue.TickFrequency = 50;
            this.thresholdValue.Value = 80;
            this.thresholdValue.Scroll += new System.EventHandler(this.OnChangeThreshold);
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(142, 34);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(85, 13);
            this.thresholdLabel.TabIndex = 4;
            this.thresholdLabel.Text = "threshold value: ";
            this.thresholdLabel.Click += new System.EventHandler(this.OnChangeThreshold);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 231);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Draw circles";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.DrawCircles);
            // 
            // distance
            // 
            this.distance.Location = new System.Drawing.Point(179, 212);
            this.distance.Maximum = 1000;
            this.distance.Minimum = 10;
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(175, 45);
            this.distance.SmallChange = 100;
            this.distance.TabIndex = 1;
            this.distance.Value = 250;
            this.distance.Scroll += new System.EventHandler(this.OnChangeDistance);
            // 
            // distanceSize
            // 
            this.distanceSize.AutoSize = true;
            this.distanceSize.Location = new System.Drawing.Point(99, 215);
            this.distanceSize.Name = "distanceSize";
            this.distanceSize.Size = new System.Drawing.Size(53, 13);
            this.distanceSize.TabIndex = 2;
            this.distanceSize.Text = "distance: ";
            // 
            // radius
            // 
            this.radius.Location = new System.Drawing.Point(179, 253);
            this.radius.Maximum = 1000;
            this.radius.Minimum = 10;
            this.radius.Name = "radius";
            this.radius.Size = new System.Drawing.Size(169, 45);
            this.radius.SmallChange = 100;
            this.radius.TabIndex = 1;
            this.radius.Value = 250;
            this.radius.Scroll += new System.EventHandler(this.OnChangeRadius);
            // 
            // radiusSize
            // 
            this.radiusSize.AutoSize = true;
            this.radiusSize.Location = new System.Drawing.Point(99, 266);
            this.radiusSize.Name = "radiusSize";
            this.radiusSize.Size = new System.Drawing.Size(60, 13);
            this.radiusSize.TabIndex = 2;
            this.radiusSize.Text = "min radius: ";
            // 
            // primitivesCount
            // 
            this.primitivesCount.AutoSize = true;
            this.primitivesCount.Location = new System.Drawing.Point(158, 9);
            this.primitivesCount.Name = "primitivesCount";
            this.primitivesCount.Size = new System.Drawing.Size(63, 13);
            this.primitivesCount.TabIndex = 5;
            this.primitivesCount.Text = "Primitives: 0";
            // 
            // selectColor
            // 
            this.selectColor.Location = new System.Drawing.Point(12, 324);
            this.selectColor.Name = "selectColor";
            this.selectColor.Size = new System.Drawing.Size(100, 23);
            this.selectColor.TabIndex = 0;
            this.selectColor.Text = "Select color";
            this.selectColor.UseVisualStyleBackColor = true;
            this.selectColor.Click += new System.EventHandler(this.SelectColor);
            // 
            // color
            // 
            this.color.Location = new System.Drawing.Point(179, 305);
            this.color.Maximum = 255;
            this.color.Name = "color";
            this.color.Size = new System.Drawing.Size(175, 45);
            this.color.SmallChange = 100;
            this.color.TabIndex = 1;
            this.color.Scroll += new System.EventHandler(this.OnChangeColor);
            // 
            // range
            // 
            this.range.Location = new System.Drawing.Point(179, 346);
            this.range.Maximum = 50;
            this.range.Name = "range";
            this.range.Size = new System.Drawing.Size(175, 45);
            this.range.SmallChange = 100;
            this.range.TabIndex = 1;
            this.range.Value = 10;
            this.range.Scroll += new System.EventHandler(this.OnChangeRange);
            // 
            // colorSize
            // 
            this.colorSize.AutoSize = true;
            this.colorSize.Location = new System.Drawing.Point(99, 308);
            this.colorSize.Name = "colorSize";
            this.colorSize.Size = new System.Drawing.Size(36, 13);
            this.colorSize.TabIndex = 2;
            this.colorSize.Text = "color: ";
            // 
            // rangeSize
            // 
            this.rangeSize.AutoSize = true;
            this.rangeSize.Location = new System.Drawing.Point(99, 359);
            this.rangeSize.Name = "rangeSize";
            this.rangeSize.Size = new System.Drawing.Size(40, 13);
            this.rangeSize.TabIndex = 2;
            this.rangeSize.Text = "range: ";
            // 
            // SearchGeometryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 396);
            this.Controls.Add(this.primitivesCount);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.thresholdValue);
            this.Controls.Add(this.rangeSize);
            this.Controls.Add(this.radiusSize);
            this.Controls.Add(this.colorSize);
            this.Controls.Add(this.distanceSize);
            this.Controls.Add(this.rectangleAreaSize);
            this.Controls.Add(this.range);
            this.Controls.Add(this.triangleAreaSize);
            this.Controls.Add(this.color);
            this.Controls.Add(this.radius);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.selectColor);
            this.Controls.Add(this.rectangleArea);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.triangleArea);
            this.Controls.Add(this.drawTriangle);
            this.Controls.Add(this.searchContours);
            this.Name = "SearchGeometryForm";
            this.Text = "SearchGeometryForm";
            ((System.ComponentModel.ISupportInitialize)(this.triangleArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rectangleArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.distance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.color)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.range)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchContours;
        private System.Windows.Forms.Button drawTriangle;
        private System.Windows.Forms.TrackBar triangleArea;
        private System.Windows.Forms.Label triangleAreaSize;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar rectangleArea;
        private System.Windows.Forms.Label rectangleAreaSize;
        private System.Windows.Forms.TrackBar thresholdValue;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TrackBar distance;
        private System.Windows.Forms.Label distanceSize;
        private System.Windows.Forms.TrackBar radius;
        private System.Windows.Forms.Label radiusSize;
        private System.Windows.Forms.Label primitivesCount;
        private System.Windows.Forms.Button selectColor;
        private System.Windows.Forms.TrackBar color;
        private System.Windows.Forms.TrackBar range;
        private System.Windows.Forms.Label colorSize;
        private System.Windows.Forms.Label rangeSize;
    }
}