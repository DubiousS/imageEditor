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

        public VideoStream()
        {
            capture.ImageGrabbed += this.processFrame;   
        }

        private void processFrame(object sender, EventArgs e)
        {
            var frame = new Mat();
            this.capture.Retrieve(frame);
        }

        private void startStream()
        {
            capture.Start(null);
        }

        private void stopStream(object sender, EventArgs e)
        {
            capture.Stop();
        }


    }
}
