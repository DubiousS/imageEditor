using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class AppForm : Form
    {
        public delegate void Function<T1>(T1 frame);

        private Editor Editor = new Editor();
        private VideoStream stream;

        public AppForm()
        {
            InitializeComponent();
            Editor.SubscribeToChange(SetImage);
        }

        public void SetImage(Image<Bgr, byte> image)
        {
            sourceImage.Image = image;
        }

        private void StopVideo(object sender, EventArgs e)
        {
            stream.stopStream();
        }

        private void StartVideo(object sender, EventArgs e)
        {
            stream.startStream();
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
    }
}
