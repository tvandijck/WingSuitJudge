using System.Windows.Forms;

namespace Flock
{
    partial class AboutBox : Form
    {
        public AboutBox()
        {
            InitializeComponent();
            label1.Text = Program.CopyrightNotice;
        }
    }
}
