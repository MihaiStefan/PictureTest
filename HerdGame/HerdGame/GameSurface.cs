using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HerdGame
{
    public partial class GameSurface : UserControl
    {
        private Surface TheSurface;
        Bitmap bm;
        
        public GameSurface()
        {
            InitializeComponent();
            bm = new Bitmap(this.Width, this.Height);
            TheSurface = new Surface(Width, Height);
            TheSurface.AddIndivid(0, 100, 100, 20, 50);
        }

        private void GameSurface_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(bm, new Point(0, 0));
        }

        public void UpdateObj()
        {
            TheSurface.UpdateSpeedPer10mSec();
            if (bm == null)
                bm = new Bitmap(this.Width, this.Width);
            using (Graphics gr = Graphics.FromImage(bm))
            {
                SolidBrush bsh = new SolidBrush(this.BackColor);
                foreach (Individ elem in TheSurface.IndividList)
                {
                    //sa se corecteze desenatul: se va face din obiect, se va modifica variabila ce tine de 
                    //modificarea pozitiei
                    gr.FillEllipse(bsh, elem._o_coord_X - elem.radius, elem._o_coord_Y - elem.radius, elem.radius, elem.radius);
                    gr.FillEllipse(Brushes.Red, elem.coord_X - elem.radius, elem.coord_Y - elem.radius, elem.radius, elem.radius);
                }
            }
            Refresh();
        }
    }
}
