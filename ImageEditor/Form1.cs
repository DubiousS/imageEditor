using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;

namespace ImageEditor
{
    public partial class Form1 : Form
    {

        private Editor editor = new Editor();

        public Form1()
        {
            InitializeComponent();
        }

        private void loadImage(object sender, EventArgs e)
        {
            editor.readImage();
            imageDefault.Image = editor.imageResize(640, 480);
        }

        private void toCanny(object sender, EventArgs e)
        {
            imageDefault.Image = editor.cannyEffect(cannyThreshold.Value, cannyThresholdLinking.Value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageDefault.Image = editor.cellShading();
        }

        private void imageCell_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageDefault.Image = editor.resetImage();
        }
    }
}
