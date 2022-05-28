using System;
using System.Drawing;
using System.Windows.Forms;

namespace WinAppDriverSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Red;
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Green;
        }
    }
}
