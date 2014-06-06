using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameItems;

namespace PacMan
{
    /// <summary>
    /// Класс, создающий и заполняющий игровую карту
    /// </summary>
    public class MapMaker
    {
        /// <summary>
        /// Создание первого уровня с использованием следующих символов
        /// W-wall
        /// T-treasure
        /// P-player
        /// E-enemy
        /// F-finish (выход с уровня)
        /// любой другой символ-пустая клетка.
        /// </summary>
        /// <returns>заполненный уровень в виде списка ячеек</returns>
        public List<Cell> MakeLevel1()
        {
            List<Cell> result = new List<Cell>();
            string firstLevel = string.Empty;
            firstLevel = firstLevel + "WWWWWWWWWW";
            firstLevel = firstLevel + "W........W";
            firstLevel = firstLevel + "W...T....W";
            firstLevel = firstLevel + "W........W";
            firstLevel = firstLevel + "W...P....W";
            firstLevel = firstLevel + "W........W";
            firstLevel = firstLevel + "W.....E..W";
            firstLevel = firstLevel + "W........W";
            firstLevel = firstLevel + "W..E...F.W";
            firstLevel = firstLevel + "WWWWWWWWWW";
            if (firstLevel.Length == 100)
            {
                result = this.MakeMap(firstLevel);
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        /// <summary>
        /// Создание списка из 100 ячеек, означающих карту 10 на 10
        /// </summary>
        /// <param name="mapPreset">маска, по которой расставляются объекты</param>
        /// <returns>карта в виде списка ячеек</returns>
        private List<Cell> MakeMap(string mapPreset)
        {
            List<Cell> result = new List<Cell>();
            if (mapPreset.Length == 100)
            {
                foreach (var item in mapPreset)
                {
                    for (int y = 0; y < 10; y++)
                    {
                        for (int x = 0; x < 10; x++)
                        {
                            result.Add(this.MakeCell(x, y, item));
                        }
                    }
                }
            }
            else
            {
                throw new ArgumentOutOfRangeException();
            }

            return result;
        }

        /// <summary>
        /// Метод создающий новую ячейку с заполненными координатами и типом объекта
        /// </summary>
        /// <param name="x">координата по горизонтали</param>
        /// <param name="y">координата по вертикали</param>
        /// <param name="symbol">символ, определяющий тип объекта</param>
        /// <returns>новая заполненная ячейка</returns>
        private Cell MakeCell(int x, int y, char symbol)
        {
            Cell result = new Cell(x, y);
            switch (symbol)
            {
                case 'P':
                    result.AddGameItem(new Player());
                    break;
                case 'E':
                    result.AddGameItem(new Enemy());
                    break;
                case 'F':
                    result.AddGameItem(new Exit());
                    break;
                case 'T':
                    result.AddGameItem(new Treasure());
                    break;
                case 'W':
                    result.AddGameItem(new Wall());
                    break;
                default:
                    result.AddGameItem(new Empty());
                    break;
            }

            ////if (symbol == 'P')
            ////{
            ////    result.AddGameItem(new Player());
            ////}
            ////if (symbol == 'E')
            ////{
            ////    result.AddGameItem(new Enemy());
            ////}
            ////if (symbol == 'F')
            ////{
            ////    result.AddGameItem(new Exit());
            ////}
            ////if (symbol == 'T')
            ////{
            ////    result.AddGameItem(new Treasure());
            ////}
            ////if (symbol == 'W')
            ////{
            ////    result.AddGameItem(new Wall());
            ////}
            ////else
            ////{
            ////    result.AddGameItem(new Empty());
            ////}
            return result;
        }
    }
}