using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan.GameItems
{
    /// <summary>
    /// Объект - противник
    /// </summary>
    public class Enemy : GameItem
    {
        /// <summary>
        /// Установка символа объекта в конструкторе и начального направления
        /// </summary>
        public Enemy()
        {
            this.Texture = 'X';
            this.LastDirection = MoveDirection.Right;
        }

        /// <summary>
        /// Направление, в котором противник двигался на предыдущем ходу
        /// </summary>
        public MoveDirection LastDirection { get; set; }
    }
}