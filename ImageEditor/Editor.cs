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
        private Image<Bgr, byte> sourceImage = new Image<Bgr, byte>(640, 480);
        private Image<Bgr, byte> defaulImage = new Image<Bgr, byte>(640, 480);
        public delegate void forEachDelegateWithChannel<T1, T2, T3, T4>(T1 channel, T2 width, T3 height, T4 color);
        public delegate void forEachDelegate<T1, T2, T3>(T1 width, T2 height, T3 color);
        public delegate byte mapDelegateWithChannel<T1, T2, T3, T4>(T1 channel, T2 width, T3 height, T4 color);
        public delegate byte mapDelegate<T1, T2, T3>(T1 width, T2 height, T3 color);

        public static String FILE_DESCRIPTION = "Файлы изображений (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        public static byte BLUE_CHANNEL = 0;
        public static byte GREEN_CHANNEL = 1;
        public static byte RED_CHANNEL = 2;

        public Editor() {}

        public Editor readImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FILE_DESCRIPTION;

            DialogResult result = openFileDialog.ShowDialog();

            try {
                if (result == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    sourceImage = new Image<Bgr, byte>(fileName);
                    defaulImage = sourceImage.Clone();

                }
            } catch(Exception error) {}

            return this;
        }

        public Editor clone() {
            Editor clonable = new Editor();
            clonable.sourceImage = this.sourceImage.Clone();
            clonable.defaulImage = this.defaulImage.Clone();
            return clonable;
        }


        public Editor imageResize(int width, int height)
        {
            Editor immutable = this.clone();
            immutable.sourceImage = this.sourceImage
                .Clone()
                .Resize(width, height, Inter.Linear);
            return immutable;
        }


        public Image<Bgr, byte> getImage()
        {
            return this.sourceImage.Clone();
        }

        static byte toFourColor(byte color)
        {
            if (color <= 50) {
                return 0;
            } else if (color <= 100) {
                return 25;
            } else if (color <= 150) {
                return 180;
            } else if (color <= 200) {
                return 210;
            }

           return 255;
        }


        public Editor removeNoises()
        {
            Editor immutable = this.clone();
            immutable.sourceImage = sourceImage
                .Clone()
                .PyrDown()
                .PyrUp();
            return immutable;
        }

        public Editor resetImage()
        {
            Editor immutable = this.clone();
            immutable.sourceImage = this.defaulImage.Clone();
            return immutable;
        }

        public Editor cannyEffect(double cannyThreshold, double cannyThresholdLinking)
        {
            Editor immutable = this.clone();

            immutable.sourceImage = sourceImage
                .Clone()
                .Canny(cannyThreshold, cannyThresholdLinking)
                .Convert<Bgr, byte>();

            return immutable;
        }

        public void forEach(forEachDelegate<int, int, byte> callback, int channel = 0)
        {
            for (int width = 0; width < sourceImage.Width; width++) {
                for (int height = 0; height < sourceImage.Height; height++)
                {
                    callback(height, width, sourceImage.Data[height, width, channel]);
                }
            }
        }

        public void forEach(forEachDelegateWithChannel<int, int, int, byte> callback)
        {
            for (int channel = 0; channel < sourceImage.NumberOfChannels; channel++)
            {
                this.forEach((height, width, color) => {
                    callback(channel, height, width, color);
                }, channel);
            }
        }

        public Editor map(mapDelegate<int, int, byte> callback, int channel = 0)
        {
            Editor immutable = this.clone();

            this.forEach((height, width, color) => {
                immutable.sourceImage.Data[height, width, channel] = callback(height, width, color);
            });

            return immutable;
        }

        public Editor map(mapDelegateWithChannel<int, int, int, byte> callback)
        {
            Editor immutable = this.clone();

            this.forEach((channel, height, width, color) => {
                immutable.sourceImage.Data[height, width, channel] = callback(channel, height, width, color);
            });

            return immutable;
        }

        public Editor cellShading()
        {
            return this.map((channel, height, width, color) => Editor.toFourColor(color));
        }

        public Editor getOneChannel(byte channelIndex)
        {
            Editor immutable = this.clone();

            immutable.sourceImage = sourceImage
                .Clone()
                .Split()[channelIndex]
                .Convert<Bgr, byte>();
            return immutable;
        }

        public Editor toGray()
        {
            Editor immutable = this.clone();
            var grayImage = new Image<Gray, byte>(sourceImage.Size);

            this.forEach((height, width, color) => {
                grayImage.Data[height, width, 0] = Convert.ToByte(
                    0.299 * sourceImage.Data[height, width, Editor.RED_CHANNEL] +
                    0.587 * sourceImage.Data[height, width, Editor.GREEN_CHANNEL] +
                    0.114 * sourceImage.Data[height, width, Editor.BLUE_CHANNEL]
                );
            });
            immutable.sourceImage = grayImage.Convert<Bgr, byte>();
            return immutable;
        }

        public Editor changeBrightness(byte brightness)
        {
            return this.map((channel, height, width, color) => (byte)(color + brightness));
        }

        public Editor changeContrast(byte contrast)
        {
            return this.map((channel, height, width, color) => (byte)(color * contrast));
        }

        public Editor additionColors(byte addingColor)
        {
            return this.map((channel, height, width, color) => {
                byte newColor = (byte)(color + addingColor);

                if (newColor > 255) {
                    newColor = 255;
                } else if(newColor < 0) {
                    newColor = 0;
                }

                return (byte)newColor;
            });
        }
    }
}
