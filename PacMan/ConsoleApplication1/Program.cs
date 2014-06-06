using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static bool isWorking = true;

        private static char[,] map = new char[10, 10];
        private static int pacmanX = 3;
        private static int pacmanY = 3;

        static void Main(string[] args)
        {
            ThreadPool.QueueUserWorkItem(CiklumRedraw);

            var key = Console.ReadKey();
            ProcessEnteredKey(key);
        }


        private static void CiklumRedraw(object state)
        {
            do
            {
                FillMap();
                DrawBorders();
                map[pacmanX, pacmanY] = '@';
                Redraw();
                Thread.Sleep(500);
            } while (isWorking);
        }

        private static void DrawBorders()
        {
            for (int x = 0; x < 10; x++)
            {
                map[x, 0] = '-';
                map[x, 9] = '-';
            }
            for (int y = 0; y < 10; y++)
            {
                map[0, y] = '|';
                map[9, y] = '|';
            }

        }

        private static void FillMap()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    map[x, y] = '.';
                }
            }
        }

        private static void Redraw()
        {
            string result = string.Empty;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    result = result + map[x, y];
                }
                result = result + Environment.NewLine;
            }

            Console.Clear();
            Console.WriteLine(result);
        }

        private static void ProcessEnteredKey(ConsoleKeyInfo key)
        {
            Thread.Sleep(500);
            switch (key.Key)
            {
                case ConsoleKey.Escape:
                    isWorking = false;
                    break;
                case ConsoleKey.LeftArrow:
                    pacmanX = pacmanX - 1;
                    ProcessEnteredKey(Console.ReadKey());
                    break;
                case ConsoleKey.RightArrow:
                    pacmanX = pacmanX + 1;
                    ProcessEnteredKey(Console.ReadKey());
                    break;

                case ConsoleKey.UpArrow:
                    pacmanY = pacmanY - 1;
                    ProcessEnteredKey(Console.ReadKey());
                    break;
                case ConsoleKey.DownArrow:
                    pacmanY = pacmanY + 1;
                    ProcessEnteredKey(Console.ReadKey());
                    break;
                default:
                    ProcessEnteredKey(Console.ReadKey());
                    break;
            }
        }
    }
}
