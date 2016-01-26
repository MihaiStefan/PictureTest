using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictDev
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Rectangle Image_Rectangle = new Rectangle(0, 0, MyImage.Width, MyImage.Height);
            //BitmapData Image_Data = MyImage.LockBits(Image_Rectangle, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            // ... x and y nested for-loops to work with each pixel
            //Byte* PixelRow = (Byte*)Image_Data.Scan0 + (y * Image_Data.Stride);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                pictureBox1.Load(openFileDialog1.FileName);
            }
        }
    }
}
