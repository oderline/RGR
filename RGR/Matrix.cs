using System;
using System.Drawing;
using System.Windows.Forms;

namespace RGR
{
    public partial class Matrix : Form
    {
        const int m = 5;
        int[,] A = new int[m, m];
        int[,] B = new int[m, m];

        public Matrix()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    A[i, j] = random.Next(-9, 9);
                }
            }

            this.pictureBox1.Refresh();

            B = A;
            for (int i = 0; i < m; i++)
            {
                B[0, i] = B[i, i] * B[i, m - 1];
            }

            this.pictureBox2.Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете вийти?", "Підтвердження виходу", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    float x = j * 30;
                    float y = i * 30;
                    float width = 45.0F;
                    float height = 20.0F;
                    e.Graphics.DrawString(A[i, j].ToString(), new Font("Calibri", 16), new SolidBrush(Color.Black), new RectangleF(x, y, width, height), drawFormat);
                }
            }
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            StringFormat drawFormat = new StringFormat();
            drawFormat.Alignment = StringAlignment.Center;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    float x = j * 30;
                    float y = i * 30;
                    float width = 45.0F;
                    float height = 20.0F;
                    e.Graphics.DrawString(B[i, j].ToString(), new Font("Calibri", 16), new SolidBrush(Color.Black), new RectangleF(x, y, width, height), drawFormat);
                }
            }
        }
    }
}
