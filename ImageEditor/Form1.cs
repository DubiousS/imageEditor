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
        public delegate void Function<T1>(T1 frame);

        private Editor editor = new Editor();
        private VideoStream stream;

        public Form1()
        {
            InitializeComponent();
            this.stream = new VideoStream((frame) => {
                videoContainer.Image = frame;
            });
        }

        private void loadImage(object sender, EventArgs e)
        {
            
            imageDefault.Image = editor
                .readImage()
                .imageResize(imageDefault.Width, imageDefault.Height)
                .getImage();
        }

        private void toCanny(object sender, EventArgs e)
        {
            imageDefault.Image = editor
                .cannyEffect(cannyThreshold.Value, cannyThresholdLinking.Value)
                .getImage();
        }

        private void cellShading(object sender, EventArgs e)
        {
            imageDefault.Image = editor
                .cannyEffect(cannyThreshold.Value, cannyThresholdLinking.Value)
                .cellShading()
                .imageResize(imageDefault.Width, imageDefault.Height)
                .getImage();
        }

        private void resetImage(object sender, EventArgs e)
        {
            imageDefault.Image = editor
                .resetImage()
                .imageResize(imageDefault.Width, imageDefault.Height)
                .getImage();
        }

        private void stopVideo(object sender, EventArgs e)
        {
            stream.stopStream();
        }

        private void startVideo(object sender, EventArgs e)
        {
            stream.startStream();
        }

        private void downloadImageForChannelEdtor(object sender, EventArgs e)
        {
            defaultImageChannel.Image = editor
                .readImage()
                .imageResize(editedImage.Width, editedImage.Height)
                .getImage();
        }

        private void selectChannel(object sender, EventArgs e)
        {
            int index = channelList.SelectedIndex;
            if (index != 0)
            {
                editedImage.Image = editor
                    .resetImage()
                    .imageResize(editedImage.Width, editedImage.Height)
                    .getOneChannel((byte)(index - 1))
                    .getImage();
            } else
            {
                editedImage.Image = editor
                   .resetImage()
                   .imageResize(editedImage.Width, editedImage.Height)
                   .getImage();
            }
        }
    }
}
