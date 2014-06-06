using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameItems
{
    /// <summary>
    /// Объект - стена
    /// </summary>
    public class Wall : GameItem
    {
        /// <summary>
        /// Установка символа объекта в конструкторе
        /// </summary>
        public Wall()
        {
            this.Texture = '#';
        }
    }
}