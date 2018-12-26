using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class ScalingForm : Form
    {

        private Editor Editor = new Editor();

        public ScalingForm(Editor Editor)
        {
            this.Editor = Editor;
            InitializeComponent();
        }

        private void Scale(object sender, EventArgs e)
        {
            Editor
                .ResetImage()
                .Scaling((double)widthScale.Value / 100.0, (double)heightScale.Value / 100.0);
        }
    }
}
