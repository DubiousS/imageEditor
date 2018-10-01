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
        private Image<Bgr, byte> sourceImage;
        private Image<Bgr, byte> defaulImage;
        public delegate void Function<T1, T2, T3, T4>(T1 channel, T2 width, T3 height, T4 color);

        static String FILE_DESCRIPTION = "Файлы изображений (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

        public Editor() {}

        public Editor readImage()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FILE_DESCRIPTION;
            var result = openFileDialog.ShowDialog();
            try {
                if (result == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    sourceImage = new Image<Bgr, byte>(fileName);
                    defaulImage = sourceImage.Clone();

                }
            } catch(Exception error) {
                sourceImage = new Image<Bgr, byte>(640, 480);
            }

            return this.clone();
        }

        public Editor clone() {
            Editor clonable = new Editor();
            clonable.sourceImage = this.sourceImage.Clone();
            clonable.defaulImage = this.defaulImage.Clone();
            return clonable;
        }


        public Editor imageResize(int width, int height)
        {
            this.sourceImage = this.sourceImage.Resize(width, height, Inter.Linear);
            return this.clone();
        }


        public Image<Bgr, byte> getImage()
        {
            return this.sourceImage.Clone();
        }

        static byte toFourColor(byte color)
        {
            if (color <= 50)
                return 0;
            else if (color <= 100)
                return 25;
            else if (color <= 150)
                return 180;
            else if (color <= 200)
                return 210;

           return 255;
        }


        public Editor removeNoises()
        {
            this.sourceImage.PyrDown().PyrUp();
            return this.clone();
        }

        public Editor resetImage()
        {
            this.sourceImage = this.defaulImage.Clone();
            return this.clone();
        }

        public Editor cannyEffect(double cannyThreshold, double cannyThresholdLinking)
        {
            this.sourceImage = this.sourceImage
                .Canny(cannyThreshold, cannyThresholdLinking)
                .Convert<Bgr, byte>();
            return this.clone();
        }

        public void forEach(Function<int, int, int, byte> callback)
        {
            for (int channel = 0; channel < sourceImage.NumberOfChannels; channel++)
            {
                for (int x = 0; x < sourceImage.Width; x++)
                {
                    for (int y = 0; y < sourceImage.Height; y++)
                    {
                        callback(channel, y, x, sourceImage.Data[y, x, channel]);
                    }
                }
            }
        }

        public Editor cellShading()
        {
            Image<Bgr, byte> sourceImage = this.defaulImage.Sub(this.sourceImage);

            this.forEach((channel, width, height, color) => {
                sourceImage.Data[width, height, channel] = Editor.toFourColor(color);
            });
            return this.clone();
        }        
    }
}
