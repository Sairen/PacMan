using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameItems;

namespace PacMan
{
    /// <summary>
    /// Класс отвечающий за логику движения противника
    /// </summary>
    public class EnemyMover
    {
        /// <summary>
        /// Экземпляр менеджера ячеек
        /// </summary>
        private CellsManager managerOfCells;

        /// <summary>
        /// Экземпляр класса, позволяющего перемещать объект из ячейки в ячейку
        /// </summary>
        private ItemMover moverOfItems;

        /// <summary>
        /// Конструктор
        /// </summary>
        public EnemyMover()
        {
            this.managerOfCells = new CellsManager();
            this.moverOfItems = new ItemMover();
        }

        /// <summary>
        /// Метод перемещения врага в соседнюю клетку
        /// </summary>
        /// <param name="theEnemy">конкретный противник, которого следует переместить</param>
        /// <param name="gameMap">игровое поле, по которому будет перемещаться противник</param>
        public void MoveTheEnemy(Enemy theEnemy, List<Cell> gameMap)
        {
            //// обычно противник двигается в том же направлении, что и двигался на предыдущем ходу,
            ////поэтому в новое направление присваивается прошлое
            MoveDirection newDirection = theEnemy.LastDirection;
            //// однако, с шансом в "a" процентов противник может сменить направление.
            //// в данном случае это 20%. из которых 5% придутся на то же направление
            Random rannd = new Random();
            int a = 20;
            if (a > rannd.Next(1, 100))
            {
                newDirection = StaticResources.RandomDirectionButIndicated(theEnemy.LastDirection);
            }

            bool wasMoved = this.moverOfItems.MoveItem(theEnemy, newDirection, gameMap);

            //// если в результате движения противник уперся в стену или остался на месте по какой-либо другой причине, его направление меняется
            if (wasMoved == false)
            {
                theEnemy.LastDirection = StaticResources.RandomDirectionButIndicated(theEnemy.LastDirection);
            }
        }
    }
}