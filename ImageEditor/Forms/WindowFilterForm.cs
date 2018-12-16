using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class WindowFilterForm : Form
    {
        private Editor Editor = new Editor();

        public WindowFilterForm(Editor Editor)
        {
            this.Editor = Editor;

            InitializeComponent();

            windowFilter.RowCount = 3;
            windowFilter.ColumnCount = 3;

            for (int rowIndex = 0; rowIndex < windowFilter.Rows.Count; rowIndex++)
            {
                DataGridViewRow row = windowFilter.Rows[rowIndex];
                row.Height = 40;
            }

            for (int columnIndex = 0; columnIndex < windowFilter.Columns.Count; columnIndex++)
            {
                DataGridViewColumn column = windowFilter.Columns[columnIndex];
                column.Width = 40;
            }
        }

        public void SetMatrix(List<int> matrix)
        {
            int index = 0;

            for (int rowIndex = 0; rowIndex < windowFilter.Rows.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < windowFilter.Columns.Count; columnIndex++)
                {
                    windowFilter[columnIndex, rowIndex].Value = matrix[index];
                    index++;
                }
            }
        } 

        public List<int> GetMatrix()
        {
            List<int> matrix = new List<int>();

            for (int rowIndex = 0; rowIndex < windowFilter.Rows.Count; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < windowFilter.Columns.Count; columnIndex++)
                {
                    matrix.Add((int)windowFilter[columnIndex, rowIndex].Value);
                }
            }

            return matrix;
        }

        private void CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            windowFilter.Rows[e.RowIndex].ErrorText = "";

            if (!int.TryParse(e.FormattedValue.ToString(), out int value))
            {
                e.Cancel = true;
                applyMatrix.Enabled = false;
                windowFilter.Rows[e.RowIndex].ErrorText = "Only number!";
            }

            applyMatrix.Enabled = true;
        }

        private void SelectSharpen(object sender, EventArgs e)
        {
            SetMatrix(Editor.sharpenMatrix);
        }

        private void SelectEmbos(object sender, EventArgs e)
        {
            SetMatrix(Editor.embosMatrix);
        }

        private void SelectEdges(object sender, EventArgs e)
        {
            SetMatrix(Editor.edgesMatrix);
        }

        private void ApplyMatrix(object sender, EventArgs e)
        {
            Editor.Matrixfilter(GetMatrix());
        }
    }
}
