using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameItems
{
    /// <summary>
    /// Объект - выход с уровня
    /// </summary>
    public class Exit : GameItem
    {
        /// <summary>
        /// Установка символа объекта в конструкторе
        /// </summary>
        public Exit()
        {
            this.Texture = '@';
        }
    }
}