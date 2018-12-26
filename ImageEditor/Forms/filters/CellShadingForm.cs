using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class CellShadingForm : Form
    {
        private Editor Editor = new Editor();

        public CellShadingForm(Editor Editor)
        {
            this.Editor = Editor;
            InitializeComponent();
        }

        private void ToCellShading(object sender, EventArgs e)
        {
            Editor
                .ResetImage()
                .CellShading(cannyThreshold.Value, cannyThresholdLinking.Value);
        }
    }
}
