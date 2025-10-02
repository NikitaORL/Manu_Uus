using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Threading;


namespace Manu_Uus
{
    public static class Keerukus
    {
        public static int MääraKeerukus(string keerukus, string userName, char snakeChar)
        {
            try
            {
                if (keerukus == "K")
                {
                    return StartSnake(userName, 150, ConsoleColor.Green, snakeChar);
                }
                else if (keerukus == "M")
                {
                    int finalScore = StartGame.Start(userName, snakeChar);
                    WriteGameOver(1, userName, finalScore);
                    return finalScore;
                }
                else if (keerukus == "R")
                {
                    return StartSnake(userName, 50, ConsoleColor.DarkYellow, snakeChar);
                }
                else if (keerukus == "D")
                {
                    return StartSnake(userName, 15, ConsoleColor.Red, snakeChar);
                }
                else
                {
                    Console.WriteLine("Vale valik. Proovi uuesti.");
                    Thread.Sleep(2000);
                    return 0;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Tekkis viga: " + ex.Message);
                Thread.Sleep(2000);
                return 0;
            }
        }

        private static int StartSnake(string userName, int speed, ConsoleColor wallsColor, char snakeChar)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            int scoreRows = 1;
            Console.SetWindowSize(80, 25);
            Console.SetBufferSize(80, 25);

            Score score = new Score(0, 0);

            Walls walls = new Walls(80, 25 - scoreRows);
            Console.ForegroundColor = wallsColor;
            walls.Draw(scoreRows);

            // змейка с выбранным скином
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

                Thread.Sleep(speed);

                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    snake.HandleKey(key.Key);
                }
            }

            WriteGameOver(scoreRows, userName, score.GetValue());
            return score.GetValue();
        }

        private static void WriteGameOver(int yOffset, string userName, int score)
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

        private static void WriteText(string text, int xOffset, int yOffset)
        {
            Console.SetCursorPosition(xOffset, yOffset);
            Console.WriteLine(text);
        }
    }
}