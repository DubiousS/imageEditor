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
        private VideoStream stream;

        public Form1()
        {
            InitializeComponent();
            this.stream = new VideoStream(this.onChange);
        }

        public bool onChange(Mat frame)
        {
            videoContainer.Image = frame;
            return true;
        }

        private void loadImage(object sender, EventArgs e)
        {
            
            imageDefault.Image = editor
                .readImage()
                .imageResize(640, 480)
                .getImage();
        }

        private void toCanny(object sender, EventArgs e)
        {
            imageDefault.Image = editor
                .cannyEffect(cannyThreshold.Value, cannyThresholdLinking.Value)
                .getImage();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            imageDefault.Image = editor
                .cellShading()
                .getImage();
        }

        private void imageCell_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            imageDefault.Image = editor
                .resetImage()
                .getImage();
        }

        private void stopVideo(object sender, EventArgs e)
        {
            this.stream.stopStream();
        }

        private void startVideo(object sender, EventArgs e)
        {
            this.stream.startStream();
        }
    }
}
