using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manu_Uus
{
    class Score
    {
        private int value;
        private int x;
        private int y;

        public Score(int x, int y)
        {
            this.x = x;
            this.y = y;
            value = 0;
            Draw();
        }

        public void Add(int points)
        {
            value += points;
            Draw();
        }

        public void Draw()
        {
            Console.SetCursorPosition(x, y);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Score: {value}".PadRight(Console.WindowWidth));
        }

        public int GetValue()
        {
            return value;
        }
    }
}
