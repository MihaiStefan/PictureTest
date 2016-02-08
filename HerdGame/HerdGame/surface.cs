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
        List<Individ> IndividList;

        public Surface(int width, int height)
            : base(width, height)
        {
            IndividList = new List<Individ>();
        }

        public Surface()
            : this(0, 0)
        { }

        private void Interact()
        {
            foreach (Individ elem in IndividList)
            { 
                if ()
            }
        }
    }
}
