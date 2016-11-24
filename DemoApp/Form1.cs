﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NightVision;

namespace DemoApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void loadBtn_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Open Image";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
             sourcePictureBox.Image = new Bitmap(openFileDialog.FileName);   
            }
        }

        private void processBtn_Click(object sender, EventArgs e)
        {
            var source = sourcePictureBox.Image;

            var res = new Converter().Process(source);

            destinationPictureBox.Image = source;
        }
    }
}
