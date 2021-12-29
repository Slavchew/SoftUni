using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BNG2EUR
{
    public partial class Converter : Form
    {
        public Converter()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Convert();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDownAmount_ValueChanged(object sender, EventArgs e)
        {
            Convert();
        }


        void Convert()
        {
            var amount = this.numericUpDownAmount.Value;
            var amountInEuro = amount / 1.95583m;
            this.labelResult.Text = amount + " BGN = " + Math.Round(amountInEuro,2) + " EUR";
        }

        private void numericUpDownAmount_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
