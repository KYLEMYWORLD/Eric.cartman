using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XMLHelper
{
    public class LineMoveSize
    {
        public int ID;
        public float Value;
        public static List<LineMoveSize> _lineMoveSize = new List<LineMoveSize>();
        public LineMoveSize()
        {

        }
         public LineMoveSize(int id, float value)
        {
            ID = id;
            Value = value;
        }

        public static float GetLineMoveSize(int id)
        {
            LineMoveSize size = _lineMoveSize.Find(c => { return c.ID == id; });
            return size != null ? size.Value : 1;
        }

    }
}
