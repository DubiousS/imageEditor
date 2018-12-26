using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class ChannelsForm : Form
    {
        public delegate void setImage<T1>(T1 frame);

        private Editor Editor = new Editor();
        private setImage<Image<Bgr, byte>> SetImage;

        public ChannelsForm(Editor Editor, setImage<Image<Bgr, byte>> SetImage)
        {
            this.Editor = Editor;
            this.SetImage = SetImage;

            InitializeComponent();
        }

        public void SetAllChannels(object sender, EventArgs e)
        {
            SetImage(Editor.GetImage());
        }

        public void SetRedChannel(object sender, EventArgs e)
        {
            SetImage(Editor.GetOneChannel(Editor.RED_CHANNEL));
        }

        public void SetGreenChannel(object sender, EventArgs e)
        {
            SetImage(Editor.GetOneChannel(Editor.GREEN_CHANNEL));
        }

        protected void SetBlueChannel(object sender, EventArgs e)
        {
            SetImage(Editor.GetOneChannel(Editor.BLUE_CHANNEL));
        }
    }
}
