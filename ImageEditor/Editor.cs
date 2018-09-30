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
    class Editor
    {
        public Image<Bgr, byte> sourceImage;
        private Image<Bgr, byte> defaulImage;

        public Editor() {}

        public void readImage()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Файлы изображений (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
            var result = openFileDialog.ShowDialog();
            try {
                if (result == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    sourceImage = new Image<Bgr, byte>(fileName);
                    defaulImage = sourceImage.Clone();

                }
            } catch(Exception error) {}
        }


        public Image<Bgr, byte> imageResize(int width, int height)
        {
            sourceImage = this.sourceImage.Resize(width, height, Inter.Linear);
            return sourceImage;
        }


        public Image<Bgr, byte> removeNoises()
        {
            return this.sourceImage.PyrDown().PyrUp();
        }

        public Image<Bgr, byte> resetImage()
        {
            sourceImage = defaulImage;
            return sourceImage;
        }

        public Image<Bgr, byte> cannyEffect(double cannyThreshold, double cannyThresholdLinking)
        {
            this.sourceImage = this.sourceImage
                .Canny(cannyThreshold, cannyThresholdLinking)
                .Convert<Bgr, byte>();
            return this.sourceImage;
        }

        public Image<Bgr, byte> cellShading()
        {
            var resultImage = sourceImage.Sub(this.cannyEffect(80, 40));

            for (int channel = 0; channel < resultImage.NumberOfChannels; channel++)
            {
                for (int x = 0; x < resultImage.Width; x++)
                {
                    for (int y = 0; y < resultImage.Height; y++)
                    {
                        byte color = resultImage.Data[y, x, channel];
                        if (color <= 50)
                            color = 0;
                        else if (color <= 100)
                            color = 25;
                        else if (color <= 150)
                            color = 180;
                        else if (color <= 200)
                            color = 210;
                        else
                            color = 255;
                        resultImage.Data[y, x, channel] = color;
                    }
                }
            }

            sourceImage = resultImage;
            return sourceImage;
        }        
    }
}
