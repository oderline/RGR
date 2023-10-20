using System;
using System.Windows.Forms;

namespace RGR
{
    public partial class Notepad : Form
    {
        string filename = string.Empty;
        string data = string.Empty;
        bool changed = false;
        public Notepad()
        {
            InitializeComponent();
        }
        private void Notepad_Load(object sender, EventArgs e)
        {

        }
        private void new_file(object sender, EventArgs e)
        {
            this.textBox1.Clear();
            this.filename = string.Empty;
            this.data = string.Empty;
            this.Text = "Без імені";
        }
        private void open_file(object sender, EventArgs e)
        {
            if (this.data != this.textBox1.Text)
            {
                if (MessageBox.Show("Зберегти зміни у файлі?", filename, MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    this.save_file(this, EventArgs.Empty);
                }
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.Cancel || openFileDialog.FileName == String.Empty)
            {
                return;
            }
            this.filename = openFileDialog.FileName;
            this.data = System.IO.File.ReadAllText(filename);
            this.textBox1.Text = data;
            this.Text = filename;
            this.changed = false;
        }
        private void save_file(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.filename))
            {
                this.save_as_file(this, EventArgs.Empty);
            }
            this.data = textBox1.Text;
            this.changed = false;
            System.IO.File.WriteAllText(this.filename, this.data);
        }
        private void save_as_file(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text files (*.txt)|*.txt|Comma-separated values (*.csv)|*.csv";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            this.filename = saveFileDialog.FileName;
            this.data = textBox1.Text;
            this.Text = filename;
            this.changed = false;
            System.IO.File.WriteAllText(filename, data);
        }
        private void exit(object sender, EventArgs e)
        {
            if (this.data != this.textBox1.Text || this.changed)
            {
                if (MessageBox.Show("Зберегти зміни у файлі?", filename, MessageBoxButtons.YesNoCancel) == DialogResult.Cancel)
                {
                    return;
                }
                if (MessageBox.Show("Зберегти зміни у файлі?", filename, MessageBoxButtons.YesNoCancel) == DialogResult.Yes)
                {
                    this.save_file(this, EventArgs.Empty);
                }
            }
            this.Close();
        }
        private void set_font(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                this.textBox1.Font = fontDialog.Font;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!changed) {
                this.Text = $"*{this.Text}";
                this.changed = true;
            }
            if (textBox1.Text == String.Empty)
            {
                this.Text = this.Text.Remove(0, 1);
                this.changed = false;
            }
        }

        private void новеВікноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad notepad = new Notepad();
            notepad.Show();
        }
    }
}
