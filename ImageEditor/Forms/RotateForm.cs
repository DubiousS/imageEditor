using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class RotateForm : Form
    {
        private Editor Editor = new Editor();

        public RotateForm(Editor Editor)
        {
            this.Editor = Editor;
            InitializeComponent();
        }

        private void Rotate(object sender, EventArgs e)
        {
            Editor.ResetImage().Rotate(rotateAngle.Value);
        }
    }
}
