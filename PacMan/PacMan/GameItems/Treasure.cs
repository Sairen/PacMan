using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameItems
{
    /// <summary>
    /// Объект - сокровище
    /// </summary>
    public class Treasure : GameItem
    {
        /// <summary>
        /// Установка символа объекта в конструкторе
        /// </summary>
        public Treasure()
        {
            this.Texture = '*';
        }
    }
}