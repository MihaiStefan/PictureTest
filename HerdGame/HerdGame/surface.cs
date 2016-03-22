using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdGame
{
    public class SimpleSurface
    {
        public int Width;
        public int Height;

        public SimpleSurface(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public SimpleSurface()
            : this(0, 0)
        { }
    }

    public class Surface : SimpleSurface
    {
        public List<Individ> IndividList;

        public Surface(int width, int height)
            : base(width, height)
        {
            IndividList = new List<Individ>();
        }

        public Surface()
            : this(0, 0)
        { }

        public void AddIndivid(int ObjID)
        {
            Individ TeInd = new Individ(ObjID);
            IndividList.Add(TeInd);
        }

        public void AddIndivid(int ObjID, int X, int Y)
        {
            Individ TeInd = new Individ(ObjID, X, Y);
            IndividList.Add(TeInd);
        }

        public void AddIndivid(int ObjID, int X, int Y, float speed_X, float speed_Y)
        {
            Individ TeInd = new Individ(ObjID, X, Y, speed_X, speed_Y);
            IndividList.Add(TeInd);
        }

        public void UpdateSpeedPer10mSec()
        {
            foreach (Individ elem in IndividList)
            {
                elem.UpdateSpeedPer10mSec();
            }
            Interact();
        }

        private void Interact()
        {
            foreach (Individ elem in IndividList)
            { 
                //de corectat si mutat tratarea in obiect
                if ((elem.coord_X > Width) || (elem.coord_X < 0))
                {
                    elem.ChangeSpeed_X_Direction();
                }
                if ((elem.coord_Y > Width) || (elem.coord_Y < 0))
                {
                    elem.ChangeSpeed_Y_Direction();
                }
            }
        }
    }
}
