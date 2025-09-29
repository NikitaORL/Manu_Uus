using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manu_Uus
{
    public static class Leaderboard
    {
        private static string filePath = "leaderboard.txt";

        public static void SaveScore(string username, int score)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine($"{username}:{score}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga tulemuse salvestamisel: " + ex.Message);
            }
        }

        public static void ShowLeaderboard()
        {
            if (!File.Exists(filePath))
            {
                Console.WriteLine("Edetabel on tühi!");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            var scores = new List<(string Name, int Score)>();

            foreach (var line in lines)
            {
                var parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int score))
                {
                    scores.Add((parts[0], score));
                }
            }

            var topScores = scores
                .OrderByDescending(s => s.Score)
                .Take(10)
                .ToList();

            Console.WriteLine("Parimad tulemused:");
            for (int i = 0; i < topScores.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {topScores[i].Name} - {topScores[i].Score} punkti");
            }
        }
    }
}