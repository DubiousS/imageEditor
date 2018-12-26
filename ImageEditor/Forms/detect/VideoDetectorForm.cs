using Emgu.CV;
using Emgu.CV.Structure;
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
    public partial class VideoDetectorForm : Form
    {

        private Editor Editor;
        private VideoStream Stream;

        public VideoDetectorForm()
        {
            this.Editor = new Editor();
            InitializeComponent();
            Stream = new VideoStream((Mat frame) => {
                videoCapture.Image = frame;
            });
            Stream.StartStream();
        }

        private void StartFaceDetect(object sender, EventArgs e)
        {
            Stream.ChangeHandler((Mat frame) => {
                videoCapture.Image = Editor.FaceDetector(frame);
            });
        }

        private void StartTextDetect(object sender, EventArgs e)
        {
            Stream.ChangeHandler((Mat frame) => {
                // Ноутбук не справляется
                // textFromVideo.Text = Editor.SearchText(frame.ToImage<Bgr, byte>());
                videoCapture.Image = frame;
            });
        }

        private void StartMoveDetect(object sender, EventArgs e)
        {
            Stream.ChangeHandler((Mat frame) => {
                videoCapture.Image = Stream.GetChangeMask(frame);
            });
        }

        private void LoadVideo(object sender, EventArgs e)
        {
            Stream.StopStream();
            Stream = new VideoStream();
            Stream.ChangeHandler((Mat frame) =>
            {
                videoCapture.Image = Stream.GetChangeMask(frame);
            });
            Stream.StartStream();
        }
    }
}
