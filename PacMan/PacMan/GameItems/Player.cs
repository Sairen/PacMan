using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameItems
{
    /// <summary>
    /// Объект - игрок
    /// </summary>
    public class Player : GameItem
    {
        /// <summary>
        /// Установка символа объекта в конструкторе
        /// </summary>
        public Player()
        {
            this.Texture = 'O';
        }
    }
}