using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manu_Uus
{
    class Figure
    {
        protected List<Point> pList = new List<Point>();

        public void Draw()
        {
            foreach (Point p in pList)
                p.Draw();
        }

        public void Draw(int yOffset)
        {
            foreach (Point p in pList)
                p.Draw(yOffset);
        }

        internal bool IsHit(Figure figure)
        {
            foreach (var p in pList)
                if (figure.IsHit(p))
                    return true;
            return false;
        }

        private bool IsHit(Point point)
        {
            foreach (var p in pList)
                if (p.IsHit(point))
                    return true;
            return false;
        }
    }
}