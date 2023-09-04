using System;
using System.Windows.Forms;

namespace RGR
{
    public partial class Notepad : Form
    {
        string filename = string.Empty;
        string data = string.Empty;
        bool state = true;
        public Notepad()
        {
            InitializeComponent();
        }
        private void Notepad_Load(object sender, EventArgs e)
        {

        }
        private void new_file(object sender, EventArgs e)
        {
            textBox1.Clear();
            filename = string.Empty;
            data = string.Empty;
            this.Text = "Notepad";
        }
        private void open_file(object sender, EventArgs e)
        {
            if (data != textBox1.Text)
            {
                if (MessageBox.Show("Зберегти зміни у файлі?", filename, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    save_file(this, EventArgs.Empty);
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            filename = openFileDialog.FileName;
            data = System.IO.File.ReadAllText(filename);
            textBox1.Text = data;
            this.Text = filename;
        }
        private void save_file(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(filename))
            {
                save_as_file(this, EventArgs.Empty);
            }
            data = textBox1.Text;
            System.IO.File.WriteAllText(filename, data);
        }
        private void save_as_file(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|Comma-separated values (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            filename = saveFileDialog.FileName;
            data = textBox1.Text;
            System.IO.File.WriteAllText(filename, data);
            this.Text = filename;
        }
        private void exit(object sender, EventArgs e)
        {
            this.Close();
        }
        private void set_font(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog.Font;
            }
        }
    }
}
