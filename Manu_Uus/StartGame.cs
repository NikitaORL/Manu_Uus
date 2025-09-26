using Manu_Uus;
using System;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading;
using static System.Formats.Asn1.AsnWriter;

using System;
using System.Threading;

namespace Manu_Uus
{
    static class StartGame
    {
        public static void Start()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8; 
            int scoreRows = 5; // количество строк сверху для панели Score

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            // создаём объект Score
            Score score = new Score(0, 0); // рисует Score в верхней строке

            // создаём стены с учётом смещения вниз
            Walls walls = new Walls(80, 25 - scoreRows);
            walls.Draw(scoreRows);

            // создаём змейку
            Point p = new Point(4, 5 + scoreRows, '●');
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            // создаём еду
            FoodCreator foodCreator = new FoodCreator(80, 25 - scoreRows, '⚠');
            Point food = foodCreator.CreateFood();
            food.y += scoreRows;
            food.Draw();

            Console.ForegroundColor = ConsoleColor.White;

            while (true)
            {
                if (walls.IsHit(snake) || snake.IsHitTail())
                    break;

                if (snake.Eat(food))
                {
                    score.Add(10); // увеличиваем очки

                    food = foodCreator.CreateFood();
                    food.y += scoreRows;
                    food.Draw();
                }
                else
                {
                    snake.Move();
                }

                Thread.Sleep(100);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true); // true чтобы не отображать символ
                    snake.HandleKey(key.Key);
                }
            }

            WriteGameOver(scoreRows);
            Console.ReadLine();
        }

        static void WriteGameOver(int yOffset)
        {
            int xOffset = 25;
            int y = 8 + yOffset;
            Console.ForegroundColor = ConsoleColor.Red;

            Console.SetCursorPosition(xOffset, y++);
            WriteText("============================", xOffset, y++);
            WriteText("M Ä N G  L Õ P E T A N U D!", xOffset + 1, y++);
            WriteText("============================", xOffset, y++);
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}