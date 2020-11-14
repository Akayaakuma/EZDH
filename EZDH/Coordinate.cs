using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EZDH
{
    class Coordinate
    {
        private int x;
        private int y;

        public Coordinate(int ix, int iy)
        {
            x = ix;
            y = iy;
        }

        public int GetX()
        {
            return x;
        }

        public void SetX(int ix)
        {
            x = ix;
        }

        public int GetY()
        {
            return y;
        }

        public void SetY(int iy)
        {
            y = iy;
        }
    }
}
