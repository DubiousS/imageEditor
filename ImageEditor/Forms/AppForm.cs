using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class AppForm : Form
    {
        public delegate void Function<T1>(T1 frame);

        private Editor Editor = new Editor();

        PointF[] srcPoints = new PointF[4];        int pointsIndex = 0;

        public AppForm()
        {
            InitializeComponent();
            Editor.SubscribeToChange(SetImage);
        }

        private void MouseHandler(object sender, MouseEventArgs e)
        {
            int x = (int)(e.Location.X / sourceImage.ZoomScale);
            int y = (int)(e.Location.Y / sourceImage.ZoomScale);

            Editor.DrawCircly(x, y);

            srcPoints.SetValue(new PointF(x, y), pointsIndex);
            pointsIndex++;

            if (pointsIndex == 4)
            {
                pointsIndex = 0;
                sourceImage.MouseClick -= MouseHandler;
                Editor.CropToHomography(srcPoints);
            }
        }

        public void SetImage(Image<Bgr, byte> image)
        {
            sourceImage.Image = image;
        }

        private void LoadImage(object sender, EventArgs e)
        {
            Editor
                .ReadImage()
                .ImageResizeOnHeight(sourceImage.Height);

            defaultImage.Image = Editor.GetImage();
        }

        public void ApplyChanges(object sender, EventArgs e)
        {
            Editor.ApplyChanges();

            defaultImage.Image = Editor.GetImage();
        }

        private void ToCellShading(object sender, EventArgs e)
        {
            Editor.CellShading();
        }

        private void ResetImage(object sender, EventArgs e)
        {
            Editor.ResetImage();
        }

        private void BlurImage(object sender, EventArgs e)
        {
            Editor
                .ToGray()
                .Blur();
        }

        private void SepiaImage(object sender, EventArgs e)
        {
            Editor.Sepia();
        }


        private void ToGrayScale(object sender, EventArgs e)
        {
            Editor.ToGray();
        }

        private void ToCartoon(object sender, EventArgs e)
        {
            Editor
                .ToGray()
                .Blur()
                .Matrixfilter(Editor.embosMatrix);
        }

        private void OpenChannelModal(object sender, EventArgs e)
        {
            ChannelsForm channelsForm = new ChannelsForm(Editor, SetImage);

            channelsForm.ShowDialog();
        }

        private void OpenWindowFilterModal(object sender, EventArgs e)
        {
            WindowFilterForm windowFilterForm = new WindowFilterForm(Editor);

            windowFilterForm.ShowDialog();
        }

        private void OpenCellShadingFilterModal(object sender, EventArgs e)
        {
            CellShadingForm cellShadingForm = new CellShadingForm(Editor);

            cellShadingForm.ShowDialog();
        }

        private void OpenScalingModal(object sender, EventArgs e)
        {
            ScalingForm scalingForm = new ScalingForm(Editor);

            scalingForm.Show();
        }

        private void OpenSharingModal(object sender, EventArgs e)
        {
            ShearingForm sharingForm = new ShearingForm(Editor);

            sharingForm.Show();
        }

        private void OpenRotateModal(object sender, EventArgs e)
        {
            RotateForm rotateForm = new RotateForm(Editor);

            rotateForm.Show();
        }

        private void OpenReflectModal(object sender, EventArgs e)
        {
            ReflectForm reflectForm = new ReflectForm(Editor);

            reflectForm.Show();
        }

        private void StartHomography(object sender, EventArgs e)
        {
            sourceImage.MouseClick += new MouseEventHandler(MouseHandler);
        }

        private void OpenSearchGeometryModal(object sender, EventArgs e)
        {
            SearchGeometryForm searchGeometry = new SearchGeometryForm(Editor);

            searchGeometry.Show();

        }
    }
}
