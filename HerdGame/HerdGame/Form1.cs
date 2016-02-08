using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerdGame
{
    public partial class Form1 : Form
    {
        Individ Duda;
        bool isit;
        Bitmap bm;

        public Form1()
        {
            InitializeComponent();
            Duda = new Individ();
            bm = new Bitmap(panel1.Width, panel1.Height);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int x, y, vx, vy, r;
      

            if (timer1.Enabled)
            {
                timer1.Stop();
            }
            else
            {
                r = 5;
                x = Convert.ToInt16(textBox1.Text);
                y = Convert.ToInt16(textBox2.Text);
                vx = Convert.ToInt16(textBox3.Text);
                vy = Convert.ToInt16(textBox4.Text);
                Duda = new Individ(0, x, y, vx, vy);
                Duda.SetRadius(r);
                timer1.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bm, new Point(0 , 0));
            /*
            Rectangle Margin = new Rectangle (0,0, panel1.Width-5, panel1.Height-5);

            e.Graphics.DrawRectangle(Pens.Blue, Margin);

            if (isit)
            {
                e.Graphics.FillEllipse(Brushes.Red, Duda.coord_X - Duda.radius, Duda.coord_Y - Duda.radius, Duda.radius, Duda.radius);
            }
             */

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Duda.UpdateSpeedPer10mSec();
            {
                //panel1.DrawToBitmap(bm, new Rectangle(0, 0, panel1.Width, panel1.Height));
                if (bm == null)
                    bm = new Bitmap(panel1.Width, panel1.Width);
                using (Graphics gr = Graphics.FromImage(bm))
                {
                    SolidBrush bsh = new SolidBrush(panel1.BackColor);
                    gr.FillEllipse(bsh, Duda._o_coord_X - Duda.radius, Duda._o_coord_Y - Duda.radius, Duda.radius, Duda.radius);
                    gr.FillEllipse(Brushes.Red, Duda.coord_X - Duda.radius, Duda.coord_Y - Duda.radius, Duda.radius, Duda.radius);
                }
            }
            label1.Text = Convert.ToString(Duda._real_X) + "--" + Convert.ToString(Duda._real_Y);
            //Invalidate();
            Refresh();
        }
    }
}
