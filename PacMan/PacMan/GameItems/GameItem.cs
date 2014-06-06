using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameItems
{
    /// <summary>
    /// Родительский класс для объектов, которые могут быть размещены на игровом поле
    /// </summary>
    public abstract class GameItem
    {
        /// <summary>
        /// Символ, которым будет отображаться определенный тип объекта
        /// </summary>
        public char Texture { get; protected set; }
    }
}