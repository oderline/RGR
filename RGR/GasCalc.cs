using System;
using System.Windows.Forms;

namespace RGR
{
    public partial class GasCalc : Form
    {
        private int current, previous, difference;

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете вийти?", "Підтвердження виходу", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        public GasCalc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            current = Int32.Parse(this.textBox1.Text);
            previous = Int32.Parse(this.textBox2.Text);
            difference = current - previous;
            this.textBox3.Text = difference.ToString();
            this.textBox4.Text = (difference * 7.99f).ToString();
        }
    }
}
