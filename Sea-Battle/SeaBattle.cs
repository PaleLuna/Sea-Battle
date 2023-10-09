using System;
using System.Threading;

namespace Sea_Battle
{
    public class SeaBattle
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Добро пожаловать в игру Морской бой!");
            Console.WriteLine("Правила игры: Попади во все корабли противника, чтобы победить.");
            Console.WriteLine("Игровое поле имеет размер 10x10. Поле противника отображается вам, а ваше поле скрыто.");
            Console.WriteLine(
                "Каждый игрок поочередно указывает координаты для атаки. Введите координаты в формате 'x,y'.");

            var playerBoard = InitializeBoard();
            var enemyBoard = InitializeBoard();

            PlaceShips(playerBoard);
            Thread.Sleep(200);
            PlaceShips(enemyBoard);
            Thread.Sleep(200);

            var playerShips = 5;
            var enemyShips = 5;

            while (playerShips > 0 && enemyShips > 0)
            {
                Console.Clear();
                DisplayBoard(playerBoard, "Ваше поле:");
                DisplayBoard(enemyBoard, "Поле противника:");

                Console.Write("Введите координаты для атаки: ");
                var input = Console.ReadLine();
                if (TryParseShot(input, out var x, out var y))
                {
                    if (IsInRange(x, y))
                    {
                        if (enemyBoard[x, y] == ' ')
                        {
                            Console.WriteLine("Промах!");
                            enemyBoard[x, y] = 'O';
                        }
                        else if (enemyBoard[x, y] == 'S')
                        {
                            Console.WriteLine("Попадание!");
                            enemyBoard[x, y] = 'X';
                            enemyShips--;
                        }
                        else
                        {
                            Console.WriteLine("Вы уже стреляли в это место.");
                        }

                        Console.WriteLine($"Осталось кораблей у противника: {enemyShips}");
                        Console.WriteLine("Нажмите Enter, чтобы продолжить...");
                        Console.ReadLine();
                    }
                    else
                    {
                        Console.WriteLine("Введите корректные координаты (0-9).");
                    }
                }
                else
                {
                    Console.WriteLine("Введите координаты в формате 'x,y'.");
                }

                // Ход оппонента
                _ = TryEnemyAttack(playerBoard, new Random(), ref playerShips);
            }

            Console.Clear();
            DisplayBoard(playerBoard, "Ваше поле:");
            DisplayBoard(enemyBoard, "Поле противника:");

            if (playerShips == 0)
                Console.WriteLine("Игрок проиграл. Противник победил!");
            else
                Console.WriteLine("Поздравляем! Вы выиграли игру!");

            Console.WriteLine("Игра окончена. Нажмите Enter для выхода.");
            Console.ReadLine();
        }

        public static bool TryEnemyAttack(char[,] playerBoard, Random random, ref int playerShips)
        {
            if (playerBoard == null)
                return false;
            
            int enemyX, enemyY;
            do
            {
                enemyX = random.Next(10);
                enemyY = random.Next(10);
            } while (playerBoard[enemyX, enemyY] == 'X' || playerBoard[enemyX, enemyY] == 'O');

            if (playerBoard[enemyX, enemyY] == 'S')
            {
                Console.WriteLine("Противник попал!");
                playerBoard[enemyX, enemyY] = 'X';
                playerShips--;
            }
            else
            {
                Console.WriteLine("Противник промахнулся!");
                playerBoard[enemyX, enemyY] = 'O';
            }

            
            
            Console.WriteLine($"Ваши оставшиеся корабли: {playerShips}");
            Console.WriteLine("Нажмите Enter, чтобы продолжить...");
            Console.ReadLine();
            
            return true;
        }

        public static char[,] InitializeBoard()
        {
            var board = new char[10, 10];
            for (var i = 0; i < 10; i++)
            for (var j = 0; j < 10; j++)
                board[i, j] = ' ';
            return board;
        }

        public static void DisplayBoard(char[,] board, string title)
        {
            Console.WriteLine(title);
            Console.WriteLine("  0 1 2 3 4 5 6 7 8 9");
            for (var i = 0; i < 10; i++)
            {
                Console.Write(i + " ");
                for (var j = 0; j < 10; j++) Console.Write(board[i, j] + " ");
                Console.WriteLine();
            }

            Console.WriteLine();
        }

        public static bool TryParseShot(string input, out int x, out int y)
        {
            x = -1;
            y = -1;

            var parts = input.Split(',');
            if (parts.Length == 2 && int.TryParse(parts[0], out x) && int.TryParse(parts[1], out y)) return true;

            return false;
        }

        public static bool IsInRange(int x, int y)
        {
            return x >= 0 && x < 10 && y >= 0 && y < 10;
        }

        public static void PlaceShips(char[,] board)
        {
            var random = new Random();
            var shipsPlaced = 0;

            while (shipsPlaced < 5)
            {
                var x = random.Next(10);
                var y = random.Next(10);

                if (board[x, y] == ' ')
                {
                    board[x, y] = 'S';
                    shipsPlaced++;
                }
            }
        }
    }
}