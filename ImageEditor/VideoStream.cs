using System;
using System.Collections.Generic;
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
    class VideoStream
    {

        private VideoCapture capture;
        private Func<Mat, bool> onChange;

        public VideoStream(Func<Mat, bool> onChange)
        {
            this.capture = new VideoCapture();
            this.onChange = onChange;
        }

        private void processFrame(object sender, EventArgs e)
        {
            var frame = new Mat();
            this.capture.Retrieve(frame);
            this.onChange(frame);
        }

        public void startStream()
        {
            capture.ImageGrabbed += this.processFrame;
            capture.Start(null);
        }

        public void stopStream()
        {
            capture.ImageGrabbed -= this.processFrame;
            capture.Stop();
        }
    }
}
