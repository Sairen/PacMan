using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program2
    {
        private static bool isWorking;
        private static class Pacman
        {
            public static int positionX = 3;
            public static int positionY = 3;
        }

        static void Main(string[] args)
        {
            isWorking = true;

            ThreadPool.QueueUserWorkItem(RedrawMap);

            do
            {
                ProcessKey(Console.ReadKey());

            } while (isWorking);
        }

        private static void ProcessKey(ConsoleKeyInfo arg)
        {
            switch (arg.Key)
            {
                case ConsoleKey.Escape:
                    isWorking = false;
                    break;
                case ConsoleKey.LeftArrow:
                    Pacman.positionX = Pacman.positionX - 1;
                    break;

                case ConsoleKey.RightArrow:
                    Pacman.positionX = Pacman.positionX + 1;
                    break;

                case ConsoleKey.UpArrow:
                    Pacman.positionY = Pacman.positionY - 1;
                    break;

                case ConsoleKey.DownArrow:
                    Pacman.positionY = Pacman.positionY + 1;
                    break;
                default:
                    break;
            }
        }

        private static void RedrawMap(object state)
        {
            char[,] map = new char[10, 10];
            MakeBorder(map);

            do
            {
                MakeField(map);
                map[Pacman.positionX, Pacman.positionY] = '@';
                DrawMap(map);
                Thread.Sleep(500);
            } while (isWorking);
        }

        private static void DrawMap(char[,] map)
        {
            StringBuilder sbuilder = new StringBuilder();
            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    sbuilder.Append(map[x, y]);
                }
                sbuilder.Append(Environment.NewLine);
            }

            Console.Clear();
            Console.Write(sbuilder.ToString());
        }

        private static void MakeField(char[,] map)
        {
            for (int x = 1; x < 9; x++)
            {
                for (int y = 1; y < 9; y++)
                {
                    map[x, y] = '.';
                }
            }
        }

        private static void MakeBorder(char[,] map)
        {
            for (int y = 0; y < 10; y++)
            {
                map[0, y] = '|';
                map[9, y] = '|';
            }
            for (int x = 0; x < 10; x++)
            {
                map[x, 0] = '-';
                map[x, 9] = '-';
            }
        }

    }
}
