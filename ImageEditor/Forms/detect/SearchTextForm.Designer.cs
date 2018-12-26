namespace ImageEditor
{
    partial class SearchTextForm
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
            this.searchText = new System.Windows.Forms.Button();
            this.iterations = new System.Windows.Forms.TrackBar();
            this.iterationsSize = new System.Windows.Forms.Label();
            this.thresholdLabel = new System.Windows.Forms.Label();
            this.thresholdValue = new System.Windows.Forms.TrackBar();
            this.findedText = new System.Windows.Forms.RichTextBox();
            this.languages = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.iterations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdValue)).BeginInit();
            this.SuspendLayout();
            // 
            // searchText
            // 
            this.searchText.Location = new System.Drawing.Point(12, 142);
            this.searchText.Name = "searchText";
            this.searchText.Size = new System.Drawing.Size(75, 23);
            this.searchText.TabIndex = 0;
            this.searchText.Text = "Search text";
            this.searchText.UseVisualStyleBackColor = true;
            this.searchText.Click += new System.EventHandler(this.SearchText);
            // 
            // iterations
            // 
            this.iterations.Location = new System.Drawing.Point(12, 91);
            this.iterations.Maximum = 5;
            this.iterations.Minimum = 1;
            this.iterations.Name = "iterations";
            this.iterations.Size = new System.Drawing.Size(260, 45);
            this.iterations.TabIndex = 1;
            this.iterations.Value = 1;
            this.iterations.Scroll += new System.EventHandler(this.IterationChange);
            // 
            // iterationsSize
            // 
            this.iterationsSize.AutoSize = true;
            this.iterationsSize.Location = new System.Drawing.Point(21, 74);
            this.iterationsSize.Name = "iterationsSize";
            this.iterationsSize.Size = new System.Drawing.Size(48, 13);
            this.iterationsSize.TabIndex = 2;
            this.iterationsSize.Text = "Iteration:";
            // 
            // thresholdLabel
            // 
            this.thresholdLabel.AutoSize = true;
            this.thresholdLabel.Location = new System.Drawing.Point(91, 10);
            this.thresholdLabel.Name = "thresholdLabel";
            this.thresholdLabel.Size = new System.Drawing.Size(85, 13);
            this.thresholdLabel.TabIndex = 6;
            this.thresholdLabel.Text = "threshold value: ";
            // 
            // thresholdValue
            // 
            this.thresholdValue.Location = new System.Drawing.Point(12, 26);
            this.thresholdValue.Maximum = 400;
            this.thresholdValue.Minimum = 1;
            this.thresholdValue.Name = "thresholdValue";
            this.thresholdValue.Size = new System.Drawing.Size(260, 45);
            this.thresholdValue.SmallChange = 100;
            this.thresholdValue.TabIndex = 5;
            this.thresholdValue.TickFrequency = 50;
            this.thresholdValue.Value = 248;
            this.thresholdValue.Scroll += new System.EventHandler(this.OnChangeThreshold);
            // 
            // findedText
            // 
            this.findedText.Location = new System.Drawing.Point(12, 181);
            this.findedText.Name = "findedText";
            this.findedText.Size = new System.Drawing.Size(260, 96);
            this.findedText.TabIndex = 7;
            this.findedText.Text = "";
            // 
            // languages
            // 
            this.languages.FormattingEnabled = true;
            this.languages.Location = new System.Drawing.Point(278, 10);
            this.languages.Name = "languages";
            this.languages.Size = new System.Drawing.Size(67, 264);
            this.languages.TabIndex = 8;
            this.languages.SelectedIndexChanged += new System.EventHandler(this.OnSelectLang);
            // 
            // SearchTextForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 289);
            this.Controls.Add(this.languages);
            this.Controls.Add(this.findedText);
            this.Controls.Add(this.thresholdLabel);
            this.Controls.Add(this.thresholdValue);
            this.Controls.Add(this.iterationsSize);
            this.Controls.Add(this.iterations);
            this.Controls.Add(this.searchText);
            this.Name = "SearchTextForm";
            this.Text = "SearchTextForm";
            ((System.ComponentModel.ISupportInitialize)(this.iterations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.thresholdValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchText;
        private System.Windows.Forms.TrackBar iterations;
        private System.Windows.Forms.Label iterationsSize;
        private System.Windows.Forms.Label thresholdLabel;
        private System.Windows.Forms.TrackBar thresholdValue;
        private System.Windows.Forms.RichTextBox findedText;
        private System.Windows.Forms.ListBox languages;
    }
}