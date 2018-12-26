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
    public partial class ShearingForm : Form
    {
        private Editor Editor = new Editor();

        public ShearingForm(Editor Editor)
        {
            this.Editor = Editor;
            InitializeComponent();
        }

        private void SharingAlignTop(object sender, EventArgs e)
        {
            sharingAlignBottom.Value = 0;
            sharingAlignRight.Value = 0;
            sharingAlignLeft.Value = 0;
            
            Editor
                .ResetImage()
                .ShearingAlignTop((double)sharingAlignTop.Value / 100.0);
        }

        private void SharingAlignBottom(object sender, EventArgs e)
        {
            sharingAlignTop.Value = 0;
            sharingAlignRight.Value = 0;
            sharingAlignLeft.Value = 0;

            Editor
                .ResetImage()
                .ShearingAlignBottom((double)sharingAlignBottom.Value / 100.0);
        }

        private void SharingAlignRight(object sender, EventArgs e)
        {
            sharingAlignTop.Value = 0;
            sharingAlignBottom.Value = 0;
            sharingAlignLeft.Value = 0;

            Editor
                .ResetImage()
                .ShearingAlignRight((double)sharingAlignRight.Value / 100.0);
        }

        private void SharingAlignLeft(object sender, EventArgs e)
        {
            sharingAlignTop.Value = 0;
            sharingAlignBottom.Value = 0;
            sharingAlignRight.Value = 0;

            Editor
                .ResetImage()
                .ShearingAlignLeft((double)sharingAlignLeft.Value / 100.0);
        }
    }
}
