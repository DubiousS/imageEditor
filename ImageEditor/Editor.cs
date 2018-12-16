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
    public class Editor
    {
        private Image<Bgr, byte> DefaultImage = new Image<Bgr, byte>(640, 480);
        private Image<Bgr, byte> ResultImage = new Image<Bgr, byte>(640, 480);
        private Image<Bgr, byte> _sourceImage = new Image<Bgr, byte>(640, 480);
        private onChangeImage<Image<Bgr, byte>> OnChangeImage = (SourceImage) => { };

        private Image<Bgr, byte> SourceImage
        {
            get
            {
                return _sourceImage;
            }
            set
            {
                _sourceImage = value;
                OnChangeImage(this.GetImage());
            }
        }

        public delegate void forEachDelegateWithChannel<T1, T2, T3, T4>(T1 channel, T2 width, T3 height, T4 color);
        public delegate void forEachDelegate<T1, T2, T3>(T1 width, T2 height, T3 color);
        public delegate byte mapDelegateWithChannel<T1, T2, T3, T4>(T1 channel, T2 width, T3 height, T4 color);
        public delegate byte mapDelegate<T1, T2, T3>(T1 width, T2 height, T3 color);
        public delegate byte windowFilter<T1, T2>(T1 colors, T2 color);
        public delegate void onChangeImage<T1>(T1 resultImge);

        public static List<int> sharpenMatrix = new List<int> { -1, -1, -1, -1, 9, -1, -1, -1, -1 };
        public static List<int> embosMatrix = new List<int> { -4, -2, 0, -2, 1, 2, 0, 2, 4 };
        public static List<int> edgesMatrix = new List<int> { 0, 0, 0, -4, 4, 0, 0, 0, 0 };

        private static String FILE_DESCRIPTION = "Файлы изображений (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";

        public static byte BLUE_CHANNEL = 0;
        public static byte GREEN_CHANNEL = 1;
        public static byte RED_CHANNEL = 2;

        private static byte ToFourColor(double color)
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

        private static double SmoothColor(int color, double newColor, double strength)
        {
            return (double)(color + (newColor - color) * strength);
        }

        private static byte AdditionColor(byte color, byte addingColor)
        {
            int newColor = color + addingColor;

            if (newColor > 255)
            {
                newColor = 255;
            }
            else if (newColor < 0)
            {
                newColor = 0;
            }

            return (byte)newColor;
        }

        private static byte NormalizeColor(double color, int min = 0, int max = 255)
        {
            return (byte)(Math.Min(Math.Max((int)(color), min), max));
        }

        public Editor() { }

        public Editor(int width, int height) {
            SourceImage = new Image<Bgr, byte>(width, height);
            DefaultImage = new Image<Bgr, byte>(width, height);
        }

        public void ForEach(forEachDelegate<int, int, byte> callback, int channel = 0)
        {
            for (int width = 0; width < SourceImage.Width; width++)
            {
                for (int height = 0; height < SourceImage.Height; height++)
                {
                    callback(height, width, GetColor(height, width, channel));
                }
            }
        }

        public void ForEach(forEachDelegateWithChannel<int, int, int, byte> callback)
        {
            for (int channel = 0; channel < SourceImage.NumberOfChannels; channel++)
            {
                for (int width = 0; width < SourceImage.Width; width++)
                {
                    for (int height = 0; height < SourceImage.Height; height++)
                    {
                        callback(channel, height, width, GetColor(height, width, channel));
                    }
                }
            }
        }

        public Editor Map(mapDelegate<int, int, byte> callback, int channel = 0)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(GetImageWidth(), GetImageHeight());

            this.ForEach((height, width, color) => {
                resultImage.Data[height, width, channel] = callback(height, width, color);
            });
            this.SourceImage = resultImage;

            return this;
        }

        public Editor Map(mapDelegateWithChannel<int, int, int, byte> callback)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(GetImageWidth(), GetImageHeight());

            ForEach((channel, height, width, color) => {
                resultImage.Data[height, width, channel] = callback(channel, height, width, color);
            });
            SourceImage = resultImage;

            return this;
        }

        public Editor ReadImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = FILE_DESCRIPTION;

            DialogResult result = openFileDialog.ShowDialog();

            try {
                if (result == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    SourceImage = new Image<Bgr, byte>(fileName);
                    DefaultImage = SourceImage.Clone();
                    ResultImage = SourceImage.Clone();
                }
            } catch (Exception error) { }

            return this;
        }

        public void SubscribeToChange(onChangeImage<Image<Bgr, byte>> callback)
        {
            OnChangeImage = callback;
        }

        public Editor Clone() {
            return new Editor
            {
                SourceImage = SourceImage.Clone(),
                ResultImage = ResultImage.Clone(),
                DefaultImage = ResultImage.Clone(),
            };
        }

        public byte GetColor(int height, int width, int channel)
        {
            return SourceImage.Data[height, width, channel];
        }

        public List<byte> GetColors(int x, int y, int height = 3, int width = 3, int channel = 0)
        {
            y = y < 0 ? 0 : y;
            x = x < 0 ? 0 : x;
            width = x + width < SourceImage.Width
                ? x + width 
                : SourceImage.Width - 1;
            height = y + height < SourceImage.Height
                ? y + height 
                : SourceImage.Height - 1;
            List<byte> colors = new List<byte>();

            for (int xAxis = x; xAxis < width; xAxis++)
            {
                for (int yAxis = y; yAxis < height; yAxis++)
                {
                    colors.Add(GetColor(yAxis, xAxis, channel));
                }
            }

            return colors;
        }

        public int GetImageWidth()
        {
            return SourceImage.Width;
        }

        public int GetImageHeight()
        {
            return SourceImage.Height;
        }

        public Editor Crop(int y, int x, int newWidth, int newHeight)
        {
            bool isUnCorrect = x > SourceImage.Width || y > SourceImage.Height ||
                               newWidth > SourceImage.Width || newHeight > SourceImage.Height;

            if (isUnCorrect) {
                return new Editor(newWidth, newHeight);
            }

            if (x < 0) {
                newWidth = newWidth + x;
                x = 0;
            }

            if (x + newWidth > SourceImage.Width)
            {
                newWidth = SourceImage.Width - x;
            }

            if (y < 0) {
                newHeight = newHeight + y;
                y = 0;
            }

            if (y + newHeight > SourceImage.Width)
            {
                newHeight = SourceImage.Height - y;
            }

            return new Editor(newWidth, newHeight)
                .Map((channel, height, width) => GetColor(y + height, x + width, channel));
        }

        public Editor ImageResize(int width, int height)
        {
            SourceImage = SourceImage
                .Clone()
                .Resize(width, height, Inter.Linear);
            ResultImage = SourceImage.Clone();

            return this;
        }

        public Editor ImageResize(double scale)
        {
            SourceImage = SourceImage
                .Clone()
                .Resize(scale, Inter.Linear);
            ResultImage = SourceImage.Clone();

            return this;
        }

        public Editor ImageResizeOnHeight(int newHeight)
        {
            SourceImage = ImageResize((double)newHeight / (double)GetImageHeight())
                .GetImage();

            return this;
        }

        public byte GetMiddleColor(int channel)
        {
            int colorSumm = 0;

            ForEach((height, width, color) => {
                colorSumm += color;
            }, channel);

            return (byte)(colorSumm / SourceImage.Data.Length / 3);
        }

        public Image<Bgr, byte> GetImage()
        {
            return SourceImage.Clone();
        }

        public Editor RemoveNoises()
        {
            SourceImage = SourceImage
                .PyrDown()
                .PyrUp();

            return this;
        }

        public Editor ResetImage()
        {
            SourceImage = ResultImage.Copy();

            return this;
        }

        public Editor ApplyChanges()
        {
            ResultImage = SourceImage.Clone();

            return this;
        }

        private Image<Bgr, byte> CannyEffect(double cannyThreshold = 80.0, double cannyThresholdLinking = 40.0)
        {
            return SourceImage
                .Clone()
                .Canny(cannyThreshold, cannyThresholdLinking)
                .Convert<Bgr, byte>();
        }

        public Editor CellShading(double cannyThreshold = 80.0, double cannyThresholdLinking = 40.0)
        {
            Image<Bgr, byte> edges = CannyEffect(cannyThreshold, cannyThresholdLinking);
            SourceImage = SourceImage.Sub(edges);

            return Map((channel, height, width, color) => ToFourColor(color));
        }

        public Image<Bgr, byte> GetOneChannel(byte channelIndex = 0)
        {
            return SourceImage
                .Clone()
                .Split()[channelIndex]
                .Convert<Bgr, byte>();
        }

        public Editor ToGray()
        {
            Image<Gray, byte> grayImage = new Image<Gray, byte>(GetImageWidth(), GetImageHeight());

            ForEach((height, width, color) => {
                grayImage.Data[height, width, BLUE_CHANNEL] = Convert.ToByte(
                    0.299 * GetColor(height, width, RED_CHANNEL) +
                    0.587 * GetColor(height, width, GREEN_CHANNEL) +
                    0.114 * GetColor(height, width, BLUE_CHANNEL)
                );
            });
            SourceImage = grayImage.Convert<Bgr, byte>();

            return this;
        }

        public Editor ChangeBrightness(byte brightness)
        {
            return Map((channel, height, width, color) => Convert.ToByte(color + brightness));
        }

        public Editor ChangeContrast(byte contrast)
        {
            return Map((channel, height, width, color) => Convert.ToByte(color * contrast));
        }

        public Editor SummationImage(Editor secondImage, double percentFirstImage, double percentSecondImage)
        {
            return Map((channel, height, width, color) => AdditionColor(
                Convert.ToByte(color * percentFirstImage),
                Convert.ToByte(SourceImage.Data[height, width, channel] * percentSecondImage)
            ));
        }

        public Editor Sepia()
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(GetImageWidth(), GetImageHeight());

            ForEach((channel, height, width, color) => {
                int blue = GetColor(height, width, BLUE_CHANNEL),
                    green = GetColor(height, width, GREEN_CHANNEL),
                    red = GetColor(height, width, RED_CHANNEL);

                double colorForRedChannel = red * 0.393 + green * 0.769 + blue * 0.189,
                       colorForGreenChannel = red * 0.349 + green * 0.686 + blue * 0.168,
                       colorForBlueChannel = red * 0.272 + green * 0.534 + blue * 0.131;

                resultImage.Data[height, width, RED_CHANNEL] = NormalizeColor(colorForRedChannel);
                resultImage.Data[height, width, GREEN_CHANNEL] = NormalizeColor(colorForGreenChannel);
                resultImage.Data[height, width, BLUE_CHANNEL] = NormalizeColor(colorForBlueChannel);
            });

            SourceImage = resultImage;

            return this;
        }

        private Editor WindowFilters(windowFilter<List<byte>, byte> callback)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(GetImageWidth(), GetImageHeight());

            ForEach((channel, height, width, color) => {
                List<byte> colors = GetColors(width - 1, height - 1, 3, 3, channel);
                colors.Sort();

                byte newColor = colors.Count > 0
                    ? callback(colors, color)
                    : color;

                resultImage.Data[height, width, channel] = newColor;
            });

            SourceImage = resultImage;

            return this;
        }

        public Editor Blur(double blurStrength = 1.0)
        {
            return WindowFilters((colors, color) => (byte)(colors.Sum(item => {
                double newColor = Convert.ToInt32(item);

                return SmoothColor(color, newColor, blurStrength);
            }) / colors.Count));
        }

        public Editor Matrixfilter(List<int> matrix, double strength = 1.0)
        {
            int index = 0; 
            return WindowFilters((colors, color) => {

                double newColor = colors.Sum(item => {
                    index++;
                    return item * matrix[index - 1];
                });

                index = 0;

                return NormalizeColor(SmoothColor(color, newColor, strength));
            });
        }
    }
}
