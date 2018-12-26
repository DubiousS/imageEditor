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
using Emgu.CV.OCR;

namespace ImageEditor
{
    public class Editor
    {
        public Image<Bgr, byte> DefaultImage = new Image<Bgr, byte>(640, 480);
        private Image<Bgr, byte> ResultImage = new Image<Bgr, byte>(640, 480);
        private Image<Bgr, byte> _sourceImage = new Image<Bgr, byte>(640, 480);
        private int prCount = 0;
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
                OnChangeImage(GetImage());
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
        public static string LANGUAGES_PATH = "C:\\tessdata";

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
            return color + (newColor - color) * strength;
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

        private Image<Bgr, byte> BilinearInterp(Image<Bgr, byte> img, double scalingWidth, double scalingHeight)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(img.Size);


            ForEach((channel, height, width, color) =>
            {
                if (color == 0)
                {
                    byte floorX = (byte)(width / scalingWidth);
                    double ratioX = width / scalingWidth - floorX;
                    double inverseXratio = 1 - ratioX;

                    byte floorY = (byte)(height / scalingHeight);
                    double ratioY = height / scalingHeight - floorY;
                    double inverseYratio = 1 - ratioY;

                    if (floorX < SourceImage.Width - 1 && floorX >= 0 &&
                       floorY < SourceImage.Height - 1 && floorY >= 0)
                    {
                        resultImage.Data[
                            height,
                            width,
                            channel
                        ] = (byte)(
                            (GetColor(floorY, floorY, channel) * inverseXratio +
                            GetColor(floorY, floorX + 1, channel) * ratioX) * inverseYratio +
                            (GetColor(floorY + 1, floorX, channel) * inverseXratio +
                            GetColor(floorY + 1, floorX + 1, channel) * ratioX) * ratioY
                        );
                    }
                }
                else
                {
                    resultImage.Data[
                        height,
                        width,
                        channel
                    ] = color;
                }

            }, img);

            return resultImage;
        }

        public static Image<Bgr, byte> FaceDetector(Mat frame)
        {
            Image<Bgr, byte> result = frame.ToImage<Bgr, byte>();
            using (CascadeClassifier cascadeClassifier = new CascadeClassifier("C:\\faceDetector\\haarcascade_frontalface_default.xml"))
            {
                Image<Gray, byte> grayImage = result.Convert<Gray, byte>();

                Rectangle[] facesDetected = cascadeClassifier.DetectMultiScale(
                    grayImage,
                    1.1,
                    10,
                    new Size(20, 20)
                );

                foreach (Rectangle face in facesDetected)
                {
                    result.Draw(face, new Bgr(Color.Yellow), 2);
                }
            }

            return result;
        }

        private Image<Bgr, byte> CannyEffect(double cannyThreshold = 80.0, double cannyThresholdLinking = 40.0)
        {
            return SourceImage
                .Clone()
                .Canny(cannyThreshold, cannyThresholdLinking)
                .Convert<Bgr, byte>();
        }

        private Image<Gray, byte> GaussianBlur(Image<Bgr, byte> image, int radius = 5)
        {
            return SourceImage
                .Convert<Gray, byte>()
                .SmoothGaussian(radius);
        }

        private Image<Gray, byte> SearchArea(Gray color, int radius = 5, int thresholdValue = 80)
        {
            return GaussianBlur(SourceImage, radius)
                .ThresholdBinary(new Gray(thresholdValue), color);
        }

        private VectorOfVectorOfPoint ApproxContours(VectorOfVectorOfPoint contours)
        {
            VectorOfVectorOfPoint approxContours = new VectorOfVectorOfPoint(contours.Size);

            for (int i = 0; i < contours.Size; i++)
            {
                CvInvoke.ApproxPolyDP(
                    contours[i],
                    approxContours[i],
                    CvInvoke.ArcLength(contours[i], true) * 0.05,
                    true
                );
            }
            return approxContours;
        }

        private VectorOfVectorOfPoint GetContours(Image<Gray, byte> img)
        {
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();

            CvInvoke.FindContours(
                 img,
                 contours,
                 null,
                 RetrType.List,
                 ChainApproxMethod.ChainApproxSimple
             );

            return contours;
        }

        private bool IsRectangle(VectorOfPoint contour)
        {
            if (contour.Size != 4)
            {
                return false;
            }

            Point[] points = contour.ToArray();

            int delta = 10;
            LineSegment2D[] edges = PointCollection.PolyLine(points, true);

            for (int i = 0; i < edges.Length; i++)
            {
                double angle = Math.Abs(edges[(i + 1) %
                edges.Length].GetExteriorAngleDegree(edges[i]));
                if (angle < 90 - delta || angle > 90 + delta)
                {
                    return false;
                }
            }

            return true;
        }

        public Editor() { }

        public Editor(int width, int height)
        {
            SourceImage = new Image<Bgr, byte>(width, height);
            DefaultImage = new Image<Bgr, byte>(width, height);
        }

        public int GetPrimitivesCount()
        {
            return prCount;
        }

        private void ForEach(forEachDelegate<int, int, byte> callback, int channel = 0)
        {
            for (int width = 0; width < SourceImage.Width; width++)
            {
                for (int height = 0; height < SourceImage.Height; height++)
                {
                    callback(height, width, GetColor(height, width, channel));
                }
            }
        }

        private void ForEach(forEachDelegateWithChannel<int, int, int, byte> callback)
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

        static void ForEach(forEachDelegateWithChannel<int, int, int, byte> callback, Image<Bgr, byte> img)
        {
            for (int channel = 0; channel < img.NumberOfChannels; channel++)
            {
                for (int width = 0; width < img.Width; width++)
                {
                    for (int height = 0; height < img.Height; height++)
                    {
                        callback(channel, height, width, img.Data[height, width, channel]);
                    }
                }
            }
        }

        public Editor Map(mapDelegate<int, int, byte> callback, int channel = 0)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(GetImageWidth(), GetImageHeight());

            ForEach((height, width, color) =>
            {
                resultImage.Data[height, width, channel] = callback(height, width, color);
            });
            SourceImage = resultImage;

            return this;
        }

        public Editor Map(mapDelegateWithChannel<int, int, int, byte> callback)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(GetImageWidth(), GetImageHeight());

            ForEach((channel, height, width, color) =>
            {
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

            try
            {
                if (result == DialogResult.OK)
                {
                    string fileName = openFileDialog.FileName;

                    MessageBox.Show(fileName);

                    SourceImage = new Image<Bgr, byte>(fileName);
                    DefaultImage = SourceImage.Clone();
                    ResultImage = SourceImage.Clone();
                }
            }
            catch (Exception error) { }

            return this;
        }

        public void SubscribeToChange(onChangeImage<Image<Bgr, byte>> callback)
        {
            OnChangeImage = callback;
        }

        public Editor Clone()
        {
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

            if (isUnCorrect)
            {
                return new Editor(newWidth, newHeight);
            }

            if (x < 0)
            {
                newWidth = newWidth + x;
                x = 0;
            }

            if (x + newWidth > SourceImage.Width)
            {
                newWidth = SourceImage.Width - x;
            }

            if (y < 0)
            {
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

            ForEach((height, width, color) =>
            {
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

            ForEach((height, width, color) =>
            {
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

        public Editor SummationImage(Image<Bgr, byte> secondImage, double percentFirstImage = 1.0, double percentSecondImage = 1.0)
        {
            return Map((channel, height, width, color) => AdditionColor(
                Convert.ToByte(color * percentFirstImage),
                Convert.ToByte(secondImage.Data[height, width, channel] * percentSecondImage)
            ));
        }

        public Editor Sepia()
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(GetImageWidth(), GetImageHeight());

            ForEach((channel, height, width, color) =>
            {
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

            ForEach((channel, height, width, color) =>
            {
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
            return WindowFilters((colors, color) => (byte)(colors.Sum(item =>
            {
                double newColor = Convert.ToInt32(item);

                return SmoothColor(color, newColor, blurStrength);
            }) / colors.Count));
        }

        public Editor Matrixfilter(List<int> matrix, double strength = 1.0)
        {
            int index = 0;
            return WindowFilters((colors, color) =>
            {

                double newColor = colors.Sum(item =>
                {
                    index++;
                    return item * matrix[index - 1];
                });

                index = 0;

                return NormalizeColor(SmoothColor(color, newColor, strength));
            });
        }

        public Editor Scaling(double scalingWidth = 1.0, double scalingHeight = 1.0)
        {

            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(
                (int)Math.Abs(GetImageWidth() * scalingWidth) + 1,
                (int)Math.Abs(GetImageHeight() * scalingHeight) + 1
            );

            ForEach((channel, height, width, color) =>
            {
                resultImage.Data[
                    (int)(height * scalingHeight),
                    (int)(width * scalingWidth),
                    channel
                ] = color;
            });

            SourceImage = BilinearInterp(resultImage, scalingWidth, scalingHeight);

            return this;
        }

        public Editor ShearingAlignBottom(double shift = 1.0)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(
                (int)(GetImageWidth() * (1.0 + shift)),
                GetImageHeight()
            );

            int heightImage = GetImageHeight();

            ForEach((channel, height, width, color) =>
            {
                resultImage.Data[
                    height,
                    (int)(width + shift * (heightImage - height)),
                    channel
                ] = color;
            });

            SourceImage = resultImage;

            return this;
        }

        public Editor ShearingAlignTop(double shift = 1.0)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(
                (int)(GetImageWidth() * (1.0 + shift)),
                GetImageHeight()
            );

            int heightImage = GetImageHeight();

            ForEach((channel, height, width, color) =>
            {
                resultImage.Data[
                    height,
                    (int)(width + shift * height),
                    channel
                ] = color;
            });

            SourceImage = resultImage;

            return this;
        }

        public Editor ShearingAlignRight(double shift = 1.0)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(
                GetImageWidth(),
                (int)(GetImageHeight() * (1.0 + shift))
            );

            int WidthImage = GetImageWidth();

            ForEach((channel, height, width, color) =>
            {
                resultImage.Data[
                    (int)(height + shift * (WidthImage - width)),
                    width,
                    channel
                ] = color;
            });

            SourceImage = resultImage;

            return this;
        }

        public Editor ShearingAlignLeft(double shift = 1.0)
        {
            Image<Bgr, byte> resultImage = new Image<Bgr, byte>(
                GetImageWidth(),
                (int)(GetImageHeight() * (1.0 + shift))
            );

            int WidthImage = GetImageWidth();

            ForEach((channel, height, width, color) =>
            {
                resultImage.Data[
                    (int)(height + shift * width),
                    width,
                    channel
                ] = color;
            });

            SourceImage = resultImage;

            return this;
        }

        public Editor Rotate(double _angle = 90, int centerX = 150, int centerY = 150)
        {
            double angle = _angle * Math.PI / 180;

            Image<Bgr, byte> resultImage = SourceImage.CopyBlank();

            ForEach((channel, height, width, color) =>
            {
                int newWidth = (int)(
                    Math.Cos(angle) * (width- centerX) - 
                    Math.Sin(angle) * (height - centerY) + centerX
                );
                int newHeight = (int)(
                    Math.Sin(angle) * (width - centerX) +
                    Math.Cos(angle) * (height - centerY) + centerY
                );

                if ((newWidth > 0 && newWidth < GetImageWidth()) && (newHeight > 0 && newHeight < GetImageHeight()))
                {
                    resultImage.Data[
                        newHeight,
                        newWidth,
                        channel
                    ] = color;
                }
            });

            SourceImage = resultImage;

            return this;
        }

        public Editor Reflect(int qX = 1, int qY = 1)
        {
            Image<Bgr, byte> resultImage = SourceImage.CopyBlank();

            ForEach((channel, height, width, color) =>
            {
                int newHeight = qY == -1 ? height * qY + GetImageHeight() - 1 : height;
                int newWidth = qX == -1 ? width * qX + GetImageWidth() - 1 : width;

                resultImage.Data[
                    newHeight,
                    newWidth,
                    channel
                ] = color;
            });

            SourceImage = resultImage;

            return this;
        }

        public Editor CropToHomography(PointF[] points)
        {
            PointF[] destPoints = new PointF[]
            {
                 new PointF(0, 0),
                 new PointF(0, GetImageHeight() - 1),
                 new PointF(GetImageWidth() - 1, GetImageHeight() - 1),
                 new PointF(GetImageWidth() - 1, 0)
            };

            var homographyMatrix = CvInvoke.GetPerspectiveTransform(points, destPoints);            Image<Bgr, byte> destImage = new Image<Bgr, byte>(SourceImage.Size);            CvInvoke.WarpPerspective(DefaultImage, destImage, homographyMatrix, destImage.Size);

            SourceImage = destImage;

            return this;
        }

        public void DrawCircly(int x, int y)
        {
            Point center = new Point(x, y);
            int radius = 2;
            int thickness = 2;
            var color = new Bgr(Color.Blue).MCvScalar;

            CvInvoke.Circle(SourceImage, center, radius, color, thickness);
            OnChangeImage(SourceImage);
        }

        public Editor GaussianBlur(int redius = 5)
        {
            SourceImage = SourceImage
                .Convert<Gray, byte>()
                .SmoothGaussian(redius)
                .Convert<Bgr, byte>();

            return this;
        }

        public Editor DrawContours(Bgr color, int thresholdValue)
        {
            VectorOfVectorOfPoint contours = GetContours(SearchArea(new Gray(255), 5, thresholdValue));

            Image<Bgr, byte> contoursImage = SourceImage.Copy();

            for (int i = 0; i < contours.Size; i++)
            {
                var points = contours[i].ToArray();
                contoursImage.Draw(points, color, 2);
            }

            SourceImage = contoursImage;

            return this;
        }

        public Editor DrawTriangles(Bgr color, int minArea, int thresholdValue)
        {
            VectorOfVectorOfPoint contours = ApproxContours(GetContours(SearchArea(new Gray(255), 5)));
            prCount = 0;

            Image<Bgr, byte> contoursImage = SourceImage.Copy();

            for (int i = 0; i < contours.Size; i++)
            {
                if (contours[i].Size == 3 && CvInvoke.ContourArea(contours[i], false) > minArea)
                {
                    Point[] points = contours[i].ToArray();

                    contoursImage.Draw(
                        new Triangle2DF(points[0], points[1], points[2]),
                        color,
                        2
                    );
                    prCount++;
                }
            }

            SourceImage = contoursImage;

            return this;
        }

        public Editor DrawRectangles(Bgr color, int minArea, int thresholdValue)
        {
            VectorOfVectorOfPoint contours = ApproxContours(GetContours(SearchArea(new Gray(255), 5)));
            prCount = 0;

            Image<Bgr, byte> contoursImage = SourceImage.Copy();

            for (int i = 0; i < contours.Size; i++)
            {
                if (IsRectangle(contours[i]) && CvInvoke.ContourArea(contours[i], false) > minArea)
                {
                    contoursImage.Draw(
                        CvInvoke.MinAreaRect(contours[i]),
                        color,
                        2
                    );
                    prCount++;
                }
            }

            SourceImage = contoursImage;

            return this;
        }

        public Editor DrawCircles(Bgr color, int minDistance = 250, int acTreshold = 36, int minRadius = 0)
        {
            Image<Gray, byte> bluredImage = GaussianBlur(SourceImage, 9);
            prCount = 0;

            List<CircleF> circles = new List<CircleF>(CvInvoke.HoughCircles(
                bluredImage,
                HoughType.Gradient,
                1.0,
                minDistance,
                100,
                acTreshold,
                minRadius
            ));


            Image<Bgr, byte> resultImage = SourceImage.Copy();

            foreach (CircleF circle in circles)
            {
                resultImage.Draw(
                    circle, 
                    new Bgr(Color.Blue), 
                    2
                );
                prCount++;
            }

            SourceImage = resultImage;

            return this;
        }

        public Editor SelectColor(int color, int rangeDelta = 10)
        {
            return this.SummationImage(SourceImage
                .Convert<Hsv, byte>()
                .Split()[0]
                .InRange(
                    new Gray(color - rangeDelta),
                    new Gray(color + rangeDelta)                )                .Convert<Bgr, byte>()
            );
        }

        public string SearchText(Image<Bgr, byte> img, int iterations = 251, int thresholdValue = 80, string language = "eng")
        {
            VectorOfVectorOfPoint contours = GetContours(
                GaussianBlur(img, 5).ThresholdBinary(new Gray(thresholdValue), new Gray(255)).Dilate(iterations)
            );

            List<Image<Bgr, byte>> roiImages = new List<Image<Bgr, byte>>();

            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > 50)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                    img.ROI = rect;

                    roiImages.Add(img.Copy());

                    img.ROI = Rectangle.Empty;
                }
            }

            Tesseract ocr = new Tesseract(LANGUAGES_PATH, language, OcrEngineMode.Default);

            string text = "";

            roiImages.ForEach((Image<Bgr, byte> roiImage) => {
                ocr.SetImage(roiImage);
                ocr.Recognize();
                text += ocr.GetUTF8Text();
            });

            return text;
        }

        public string SearchText(int iterations = 251, int thresholdValue = 80, string language = "eng")
        {
            VectorOfVectorOfPoint contours = GetContours(SearchArea(new Gray(255), 5, thresholdValue).Dilate(iterations));

            Image<Bgr, byte> copy = SourceImage.Copy();
            List<Image<Bgr, byte>> roiImages = new List<Image<Bgr, byte>>();

            for (int i = 0; i < contours.Size; i++)
            {
                if (CvInvoke.ContourArea(contours[i], false) > 50)
                {
                    Rectangle rect = CvInvoke.BoundingRectangle(contours[i]);

                    copy.Draw(rect, new Bgr(Color.Blue), 1);

                    SourceImage.ROI = rect;

                    roiImages.Add(SourceImage.Copy());

                    SourceImage.ROI = Rectangle.Empty;
                }
            }

            SourceImage = copy;

            Tesseract ocr = new Tesseract(LANGUAGES_PATH, language, OcrEngineMode.Default);

            string text = "";

            roiImages.ForEach((Image<Bgr, byte> roiImage) => {
                ocr.SetImage(roiImage);
                ocr.Recognize();
                text += ocr.GetUTF8Text();
            });

            return text;
        }
    }
}
