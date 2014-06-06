using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameItems
{
    /// <summary>
    /// Объект - пустая клетка
    /// </summary>
    public class Empty : GameItem
    {
        /// <summary>
        /// Установка символа объекта в конструкторе
        /// </summary>
        public Empty()
        {
            this.Texture = ' ';
        }
    }
}