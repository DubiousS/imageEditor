using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class SearchTextForm : Form
    {

        private Editor Editor;

        public SearchTextForm(Editor Editor)
        {
            this.Editor = Editor;
            InitializeComponent();
            string[] fileEntries = Directory.GetFiles(Editor.LANGUAGES_PATH);
            foreach (string fileName in fileEntries)
            {
                languages.Items.Add(Path.GetFileName(fileName).Split('.')[0]);
            }
            languages.SelectedIndex = 0;
        }

        private void SearchText(object sender, EventArgs e)
        {
            if(languages.SelectedIndex != -1)
            {

                findedText.Text = Editor
                    .ResetImage()
                    .SearchText(
                        iterations.Value,
                        thresholdValue.Value,
                        languages.Items[languages.SelectedIndex].ToString()
                    );
            } else
            {
                findedText.Text = Editor
                    .ResetImage()
                    .SearchText(
                        iterations.Value,
                        thresholdValue.Value
                    );
            }
        }

        private void IterationChange(object sender, EventArgs e)
        {
            iterationsSize.Text = "Iteration: " + iterations.Value;
        }

        private void OnChangeThreshold(object sender, EventArgs e)
        {
            thresholdLabel.Text = "threshold value: " + thresholdValue.Value;
        }

        private void OnSelectLang(object sender, EventArgs e)
        {
            
        }
    }
}
