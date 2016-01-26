using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictDev
{
    class SM_Image
    {
        private Int16 RGBtoBW_1(Int16 R, Int16 G, Int16 B)
        {
            Int32 TeRez = 0;
            
            //Red: 0.2125 Green: 0.7154 Blue: 0.0721
            TeRez = (R * 2125) + (G * 7154) + (B * 721);
            TeRez = (Int32)(TeRez / 10000);

            return (Int16)TeRez;
        }
    }
}
