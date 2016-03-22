using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HerdGame
{
    public delegate bool TIsImpactFunction(int ObjID);

    public class Location
    {
        public int ID;               //Object ID (every object must have an ID)
        public int coord_X;          //X coordinate of an object
        public int coord_Y;          //Y coordinate of an object
        public float _real_X;        //real X position
        public float _real_Y;        //real Y position

        public int _o_coord_X;    //old X coordinate
        public int _o_coord_Y;    //old Y coordinate
        //protected float _o_real_X;    //the old real X position
        //protected float _o_real_Y;    //the old real Y position

        public Location()
            : this(0)
        { }

        public Location(int ObjID)
            : this(ObjID, 0, 0)
        { }

        public Location(int ObjID, int X, int Y)
        {
            ID = ObjID;
            coord_X = X;
            coord_Y = Y;
            _o_coord_X = coord_X;
            _o_coord_Y = coord_Y;
            _real_X = (float)(coord_X);
            _real_Y = (float)(coord_Y);
        }

        protected void UpdateCoodrsFromReal()
        {
            _o_coord_X = coord_X;
            _o_coord_Y = coord_Y;
            coord_X = (int)(Math.Round(_real_X));
            coord_Y = (int)(Math.Round(_real_Y));
        }
    }

    public class Individ : Location
    {

        private float _speed_X;             //speed on the X axis
        private float _speed_Y;             //speed on the Y axis
        private Boolean _IsChanged;


        //private static float _total_speed_limit = 3;
        public int radius { get; private set; }
        public Boolean IsChanged { get { return _IsChanged; } }

        //-------------CONSTRUCTORS----------------------------------------

        public Individ()
            : this(0)
        { }

        public Individ(int ObjID)
            : this(ObjID, 0, 0)
        { }

        public Individ(int ObjID, int X, int Y)
            : this(ObjID, X, Y, 0f, 0f)
        { }

        public Individ(int ObjID, int X, int Y, float speed_X, float speed_Y)
            : base(ObjID, X, Y)
        {
            _speed_X = speed_X;
            _speed_Y = speed_Y;
            UpdateCoodrsFromReal();
            _IsChanged = true;

            OnChangingCoords();
        }
        
        public void SetRadius(int NewRadius)
        {
            radius = NewRadius;
        }
        //-------------METHODS----------------------------------------

        public void UpdateSpeedPer10mSec()
        {
            _real_X = _real_X + (_speed_X / 100);
            _real_Y = _real_Y + (_speed_Y / 100);

            UpdateCoodrsFromReal();
            IsChanging();
        }

        private void IsChanging()
        { 
            if ((_o_coord_X != coord_X) || (_o_coord_Y != coord_Y))
            {
                _IsChanged = true;
                //OnChangingCoords();
            }
            else 
            {
                _IsChanged = false;
            }
        }

        public void ChangeSpeed_X_Direction()
        {
            _speed_X = -_speed_X;
        }

        public void ChangeSpeed_Y_Direction()
        {
            _speed_Y = -_speed_Y;
        }
        //-------------EVENTS----------------------------------------

        public virtual void OnChangingCoords()
        {
        }
    }
}
