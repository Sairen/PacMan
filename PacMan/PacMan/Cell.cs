using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameItems;

namespace PacMan
{
    /// <summary>
    /// Ячейка, хранящая объекты и координаты
    /// </summary>
    public class Cell
    {
        /// <summary>
        /// Конструктор, принимающий координаты
        /// </summary>
        /// <param name="x">Координата по горизонтали</param>
        /// <param name="y">Координата по вертикали</param>
        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Content = new List<GameItem>();
        }

        /// <summary>
        /// Координата по горизонтали
        /// </summary>
        public int X { get; private set; }

        /// <summary>
        /// Координата по вертикали
        /// </summary>
        public int Y { get; private set; }

        /// <summary>
        /// Содержимое ячейки в виде списка объектов
        /// </summary>
        public List<GameItem> Content { get; private set; }

        /// <summary>
        /// Метод добавляющий объект в ячейку (в список)
        /// </summary>
        /// <param name="theItem">объект, который следует добавить в ячейку</param>
        public void AddGameItem(GameItem theItem)
        {
            this.Content.Add(theItem);
        }

        /// <summary>
        /// Метод удаляющий объект из ячейки (из списка)
        /// </summary>
        /// <param name="theItem">объект, который следует убрать из ячейки</param>
        public void RemoveGameItem(GameItem theItem)
        {
            if (this.Content.Contains(theItem) == true)
            {
                this.Content.Remove(theItem);
            }

            if (this.Content.Count == 0)
            {
                this.Content.Add(new Empty());
            }
        }
    }
}