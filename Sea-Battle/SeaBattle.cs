using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sea_Battle
{
    public class SeaBattle
    {
        private static void Main(string[] args)
        {
            
        }

        private void Run()
        {
            Console.WriteLine("Добро пожаловать в игру Морской бой!");
            Console.WriteLine("Правила игры: Попади во все корабли противника, чтобы победить.");
            Console.WriteLine("Игровое поле имеет размер 10x10. Поле противника отображается вам, а ваше поле скрыто.");
            Console.WriteLine(
                "Каждый игрок поочередно указывает координаты для атаки. Введите координаты в формате 'x,y'.");
        }

        public static void EnemyAttack(char[,] playerBoard, Random random, ref int playerShips)
        {
            
        }

        public static char[,] InitializeBoard()
        {
            return null;
        }

        [TestMethod]
        public static void DisplayBoard(char[,] board, string title)
        {
            
        }

        public static bool TryParseShot(string input, out int x, out int y)
        {
            x = 0;
            y = 0;
            return false;
        }

        public static bool IsInRange(int x, int y)
        {
            return false;
        }

        public static void PlaceShips(char[,] board)
        {
            
        }
    }
}