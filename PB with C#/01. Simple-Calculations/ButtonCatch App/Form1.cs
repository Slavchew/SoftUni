using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ButtonCatch_App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void CatchButton_MouseEnter(object sender, EventArgs e)
        {
            Random rand = new Random();
            var maxWidth = this.ClientSize.Width - CatchButton.ClientSize.Width;
            var maxHeight = this.ClientSize.Height - CatchButton.ClientSize.Height;
            this.CatchButton.Location = new Point(rand.Next(maxWidth), rand.Next(maxHeight));
        }

        private void CatchButton_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void CatchButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You Win!", "Congratulations");
        }
    }
}
