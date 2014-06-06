using PacMan.GameItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    /// <summary>
    /// Класс, передвигающий игрока
    /// </summary>
    public class PlayerMover
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public PlayerMover()
        {
            moverOfItems = new ItemMover();
        }

        ItemMover moverOfItems;

        public void MoveThePlayer(Player thePlayer, List<Cell> gameMap)
        {            
        }

        //private MoveDirection ProcessKey(ConsoleKeyInfo arg)
        //{
        //    MoveDirection direction = MoveDirection.NoMove;
        //    switch (arg.Key)
        //    {
        //        case ConsoleKey.Escape:
        //            //isWorking = false;
        //            return MoveDirection.NoMove;

        //        case ConsoleKey.LeftArrow:
        //            return MoveDirection.Left;


        //        case ConsoleKey.RightArrow:
        //            return MoveDirection.Right;


        //        case ConsoleKey.UpArrow:
        //            return MoveDirection.Up;


        //        case ConsoleKey.DownArrow:
        //            return MoveDirection.Down;

        //        default:
        //            return MoveDirection.NoMove;
        //    }
        //}

    }
}
