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
    public partial class ReflectForm : Form
    {
        private Editor Editor = new Editor();

        public ReflectForm(Editor Editor)
        {
            this.Editor = Editor;
            InitializeComponent();

            qX.SelectedIndex = 0;
            qY.SelectedIndex = 0;
        }

        private void OnSelect(object sender, EventArgs e)
        {
            if (qX.SelectedIndex != -1 && qY.SelectedIndex != -1)
            {
                Editor
                    .ResetImage()
                    .Reflect(
                        int.Parse(qX.Items[qX.SelectedIndex].ToString()),
                        int.Parse(qY.Items[qY.SelectedIndex].ToString())
                    );
            }
        }
    }
}
