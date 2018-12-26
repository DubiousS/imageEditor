using System;
using System.Collections.Generic;
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
    class VideoStream
    {

        public delegate void Function<T1>(T1 frame);

        private VideoCapture capture;
        private Function<Mat> onChange;
        BackgroundSubtractorMOG2 subtractor = new BackgroundSubtractorMOG2(1000, 32, true);

        public VideoCapture Capture { get => capture; set => capture = value; }

        public VideoStream(Function<Mat> onChange)
        {
            Capture = new VideoCapture();
            this.onChange = onChange;
        }

        public VideoStream()
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Видеофайлы (*.mp4) | *.mp4";

                DialogResult result = openFileDialog.ShowDialog();

                if (result == DialogResult.OK)
                {
                    Capture = new VideoCapture(openFileDialog.FileName);
                }
            }
            catch (Exception) {}
        }

        private Image<Gray, byte> FilterMask(Image<Gray, byte> mask)
        {
            var anchor = new Point(-1, -1);
            var borderValue = new MCvScalar(1);

            Mat kernel = CvInvoke.GetStructuringElement(
                ElementShape.Ellipse,
                new Size(3, 3), 
                anchor
            );

            return mask
                .MorphologyEx(
                    MorphOp.Close,
                    kernel,
                    anchor,
                    1,
                    BorderType.Default,
                    borderValue
                )
                .MorphologyEx(
                    MorphOp.Open,
                    kernel,
                    anchor,
                    1,
                    BorderType.Default,
                    borderValue
                )
                .Dilate(7)
                .ThresholdBinary(
                    new Gray(240), 
                    new Gray(255)
                );
        }

        public Image<Bgr, byte> GetChangeMask(Mat frame)
        {
            Image<Gray, byte> grayFrame = frame.ToImage<Gray, byte>();
            Image<Gray, byte> foregroundMask = grayFrame.CopyBlank();
            subtractor.Apply(grayFrame, foregroundMask);

            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(
                FilterMask(foregroundMask),
                contours,
                null,
                RetrType.External,
                ChainApproxMethod.ChainApproxTc89L1
            );

            Image<Bgr, byte> resultImage = frame.ToImage<Bgr, byte>();

            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i]) > 700)
                {
                    resultImage.Draw(
                        CvInvoke.BoundingRectangle(contours[i]), 
                        new Bgr(Color.GreenYellow), 
                        2
                    );
                }
            }

            return resultImage;
        }

        public void ChangeHandler(Function<Mat> onChange)
        {
            this.onChange = onChange;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            var frame = new Mat();
            Capture.Retrieve(frame);
            onChange(frame);
        }

        public void StartStream()
        {
            Capture.ImageGrabbed += this.ProcessFrame;
            Capture.Start(null);
        }

        public void StopStream()
        {
            Capture.ImageGrabbed -= this.ProcessFrame;
            Capture.Stop();
        }
    }
}
