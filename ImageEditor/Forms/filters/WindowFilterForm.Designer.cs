namespace ImageEditor
{
    partial class WindowFilterForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.windowFilter = new System.Windows.Forms.DataGridView();
            this.selectSharpenMatrix = new System.Windows.Forms.Button();
            this.selectEmbosMatrix = new System.Windows.Forms.Button();
            this.selectEdgesMatrix = new System.Windows.Forms.Button();
            this.applyMatrix = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.windowFilter)).BeginInit();
            this.SuspendLayout();
            // 
            // windowFilter
            // 
            this.windowFilter.AllowUserToAddRows = false;
            this.windowFilter.AllowUserToDeleteRows = false;
            this.windowFilter.AllowUserToResizeColumns = false;
            this.windowFilter.AllowUserToResizeRows = false;
            this.windowFilter.BackgroundColor = System.Drawing.SystemColors.Control;
            this.windowFilter.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.windowFilter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.windowFilter.ColumnHeadersVisible = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "N0";
            dataGridViewCellStyle1.NullValue = "0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.windowFilter.DefaultCellStyle = dataGridViewCellStyle1;
            this.windowFilter.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.windowFilter.Location = new System.Drawing.Point(12, 12);
            this.windowFilter.MultiSelect = false;
            this.windowFilter.Name = "windowFilter";
            this.windowFilter.RowHeadersVisible = false;
            this.windowFilter.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.windowFilter.RowTemplate.Height = 30;
            this.windowFilter.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.windowFilter.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.windowFilter.ShowCellToolTips = false;
            this.windowFilter.ShowEditingIcon = false;
            this.windowFilter.ShowRowErrors = false;
            this.windowFilter.Size = new System.Drawing.Size(120, 120);
            this.windowFilter.TabIndex = 0;
            this.windowFilter.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.CellValidating);
            // 
            // selectSharpenMatrix
            // 
            this.selectSharpenMatrix.Location = new System.Drawing.Point(152, 12);
            this.selectSharpenMatrix.Name = "selectSharpenMatrix";
            this.selectSharpenMatrix.Size = new System.Drawing.Size(75, 23);
            this.selectSharpenMatrix.TabIndex = 1;
            this.selectSharpenMatrix.Text = "sharpen";
            this.selectSharpenMatrix.UseVisualStyleBackColor = true;
            this.selectSharpenMatrix.Click += new System.EventHandler(this.SelectSharpen);
            // 
            // selectEmbosMatrix
            // 
            this.selectEmbosMatrix.Location = new System.Drawing.Point(152, 41);
            this.selectEmbosMatrix.Name = "selectEmbosMatrix";
            this.selectEmbosMatrix.Size = new System.Drawing.Size(75, 23);
            this.selectEmbosMatrix.TabIndex = 2;
            this.selectEmbosMatrix.Text = "embos";
            this.selectEmbosMatrix.UseVisualStyleBackColor = true;
            this.selectEmbosMatrix.Click += new System.EventHandler(this.SelectEmbos);
            // 
            // selectEdgesMatrix
            // 
            this.selectEdgesMatrix.Location = new System.Drawing.Point(152, 70);
            this.selectEdgesMatrix.Name = "selectEdgesMatrix";
            this.selectEdgesMatrix.Size = new System.Drawing.Size(75, 23);
            this.selectEdgesMatrix.TabIndex = 2;
            this.selectEdgesMatrix.Text = "edges";
            this.selectEdgesMatrix.UseVisualStyleBackColor = true;
            this.selectEdgesMatrix.Click += new System.EventHandler(this.SelectEdges);
            // 
            // applyMatrix
            // 
            this.applyMatrix.Location = new System.Drawing.Point(152, 99);
            this.applyMatrix.Name = "applyMatrix";
            this.applyMatrix.Size = new System.Drawing.Size(75, 33);
            this.applyMatrix.TabIndex = 3;
            this.applyMatrix.Text = "apply";
            this.applyMatrix.UseVisualStyleBackColor = true;
            this.applyMatrix.Click += new System.EventHandler(this.ApplyMatrix);
            // 
            // WindowFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(239, 143);
            this.Controls.Add(this.applyMatrix);
            this.Controls.Add(this.selectEdgesMatrix);
            this.Controls.Add(this.selectEmbosMatrix);
            this.Controls.Add(this.selectSharpenMatrix);
            this.Controls.Add(this.windowFilter);
            this.Name = "WindowFilterForm";
            this.Text = "WindowFilterForm";
            ((System.ComponentModel.ISupportInitialize)(this.windowFilter)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button selectSharpenMatrix;
        private System.Windows.Forms.Button selectEmbosMatrix;
        private System.Windows.Forms.Button selectEdgesMatrix;
        private System.Windows.Forms.Button applyMatrix;
        private System.Windows.Forms.DataGridView windowFilter;
    }
}