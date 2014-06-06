using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PacMan
{
    /// <summary>
    /// Статический класс, содержащий методы, доступ к которым необходимо облегчить
    /// </summary>
    public static class StaticResources
    {
        /// <summary>
        /// Метод выдающий случайное направление (Up, Down, Left, Right)
        /// </summary>
        /// <returns>случайное направление</returns>
        public static MoveDirection RandomDirection()
        {
            Random rannd = new Random();
            int number = rannd.Next(1, 4);
            MoveDirection result = MoveDirection.NoMove;
            switch (number)
            {
                 case 1:
                    result = MoveDirection.Up;
                    break;
                 case 2:
                    result = MoveDirection.Down;
                    break;
                 case 3:
                    result = MoveDirection.Left;
                    break;
                default:
                    result = MoveDirection.Right;
                    break;
            }

            return result;
        }

        /// <summary>
        /// Метод выдающий случайное направление (Up, Down, Left, Right), но точно не то, что было указано во входящих параметрах
        /// </summary>
        /// <returns>случайное направление</returns>
        public static MoveDirection RandomDirectionButIndicated(MoveDirection oldDirection)
        {
            MoveDirection result = MoveDirection.NoMove;
            while (result == MoveDirection.NoMove || result == oldDirection)
            {
               result = StaticResources.RandomDirection();
            }
            return result;
        }

        /// <summary>
        /// Метод который, на основе определенного направления, выдает противоположное направление
        /// </summary>
        /// <param name="direction">известное направление</param>
        /// <returns>противоположное направление</returns>
        //public static MoveDirection GetOppositeDirection(MoveDirection direction)
        //{
        //    MoveDirection result = MoveDirection.NoMove;
        //    switch (direction)
        //    {
        //        case MoveDirection.Down:
        //            result = MoveDirection.Up;
        //            break;
        //        case MoveDirection.Up:
        //            result = MoveDirection.Down;
        //            break;
        //        case MoveDirection.Right:
        //            result = MoveDirection.Left;
        //            break;
        //        default:
        //            result = MoveDirection.Right;
        //            break;
        //    }

        //    return result;
        //}
    }
}