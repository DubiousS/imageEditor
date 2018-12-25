using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class SearchGeometryForm : Form
    {

        private Editor Editor = new Editor();

        public SearchGeometryForm(Editor Editor)
        {
            this.Editor = Editor;
            InitializeComponent();
        }

        private void SetPrimitivesCount(int count)
        {
            primitivesCount.Text = "Primitives: " + count;
        }

        private void SearchContours(object sender, EventArgs e)
        {
            Editor
                .ResetImage()
                .DrawContours(new Bgr(Color.GreenYellow), thresholdValue.Value);

            SetPrimitivesCount(Editor.GetPrimitivesCount());
        }

        private void DrawTriangle(object sender, EventArgs e)
        {
            Editor
                .ResetImage()
                .DrawTriangles(new Bgr(Color.GreenYellow), triangleArea.Value, thresholdValue.Value);

            SetPrimitivesCount(Editor.GetPrimitivesCount());
        }

        private void DrawRectangle(object sender, EventArgs e)
        {
            Editor
                .ResetImage()
                .DrawRectangles(new Bgr(Color.GreenYellow), rectangleArea.Value, thresholdValue.Value);

            SetPrimitivesCount(Editor.GetPrimitivesCount());
        }

        private void DrawCircles(object sender, EventArgs e)
        {
            Editor
                .ResetImage()
                .DrawCircles(new Bgr(Color.GreenYellow), distance.Value, thresholdValue.Value, radius.Value);

            SetPrimitivesCount(Editor.GetPrimitivesCount());
        }

        private void SelectColor(object sender, EventArgs e)
        {
            Editor
                .ResetImage()
                .SelectColor(color.Value, range.Value);
        }

        private void OnChangeArea(object sender, EventArgs e)
        {
            triangleAreaSize.Text = "area: " + triangleArea.Value;
        }

        private void OnChangeRectArea(object sender, EventArgs e)
        {

            rectangleAreaSize.Text = "area: " + rectangleArea.Value;
        }

        private void OnChangeThreshold(object sender, EventArgs e)
        {
            thresholdLabel.Text = "threshold value: " + thresholdValue.Value;
        }

        private void OnChangeDistance(object sender, EventArgs e)
        {
            distanceSize.Text = "distance: " + distance.Value;
        }

        private void OnChangeRadius(object sender, EventArgs e)
        {
            radiusSize.Text = "min radius: " + radius.Value;
        }

        private void OnChangeColor(object sender, EventArgs e)
        {
            colorSize.Text = "color: " + color.Value;
        }

        private void OnChangeRange(object sender, EventArgs e)
        {
            rangeSize.Text = "range: " + range.Value;
        }
    }
}
