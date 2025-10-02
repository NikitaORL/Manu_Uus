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
        public static int Start(string userName, char snakeChar)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            int scoreRows = 1;

            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            Score score = new Score(0, 0);

            Walls walls = new Walls(80, 25 - scoreRows);
            walls.Draw(scoreRows);

            // создаём змейку с выбранным символом
            Point p = new Point(4, 5 + scoreRows, snakeChar);
            Snake snake = new Snake(p, 4, Direction.RIGHT);
            snake.Draw();

            FoodCreator foodCreator = new FoodCreator(80, 25 - scoreRows, '$');
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
                    score.Add(10);
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
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            WriteGameOver(scoreRows, userName, score.GetValue());
            return score.GetValue();
        }

        static void WriteGameOver(int yOffset, string userName, int score)
        {
            int xOffset = 25;
            int y = 8 + yOffset;
            Console.ForegroundColor = ConsoleColor.Red;

            WriteText("============================", xOffset, y++);
            WriteText(" M Ä N G  L Õ P E T A N U D ", xOffset + 1, y++);
            WriteText("============================", xOffset, y++);
            Console.ForegroundColor = ConsoleColor.Yellow;
            WriteText($"Mängija: {userName}", xOffset + 2, y++);
            WriteText($"Tulemus: {score} punkti", xOffset + 2, y++);
            Console.ForegroundColor = ConsoleColor.White;
        }

        static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}