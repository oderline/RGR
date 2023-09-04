﻿using System;
using System.Windows.Forms;

namespace RGR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void btnExit(object sender, EventArgs e)
        {
            if (MessageBox.Show("Ви дійсно хочете вийти?", "Підтвердження виходу", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
        private void notepad(object sender, EventArgs e)
        {
            Notepad notepad = new Notepad();
            notepad.Show();
        }
        private void help(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }
    }
}
