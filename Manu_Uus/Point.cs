using Manu_Uus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manu_Uus
{
    class Point
    {
        public int x;
        public int y;
        public char sym;

        public Point() { }

        public Point(int x, int y, char sym)
        {
            this.x = x;
            this.y = y;
            this.sym = sym;
        }

        public Point(Point p)
        {
            x = p.x;
            y = p.y;
            sym = p.sym;
        }

        public void Move(int offset, Direction direction)
        {
            switch (direction)
            {
                case Direction.RIGHT: x += offset; break;
                case Direction.LEFT: x -= offset; break;
                case Direction.UP: y -= offset; break;
                case Direction.DOWN: y += offset; break;
            }
        }

        public bool IsHit(Point p)
        {
            return p.x == this.x && p.y == this.y;
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.Write(sym);
        }

        public void Draw(int yOffset)
        {
            Console.SetCursorPosition(x, y + yOffset);
            Console.Write(sym);
        }

        public void Clear()
        {
            sym = ' ';
            Draw();
        }

        public override string ToString()
        {
            return x + ", " + y + ", " + sym;
        }
    }
}
