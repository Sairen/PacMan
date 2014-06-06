using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameItems;

namespace PacMan
{
    /// <summary>
    /// Класс, позволяющий перемещать объект из ячейки в ячейку
    /// </summary>
    public class ItemMover
    {
        /// <summary>
        /// Экземпляр менеджера ячеек
        /// </summary>
        private CellsManager managerOfCells;

        /// <summary>
        /// Словарь соответствий, который предоставляет прирост по осям в зависимости от направления
        /// </summary>
        private Dictionary<MoveDirection, Tuple<int, int>> directionToCoords;

        /// <summary>
        /// Конструктор, заполняющий словарь соответствий направлений и координат
        /// </summary>
        public ItemMover()
        {
            this.managerOfCells = new CellsManager();
            this.directionToCoords = new Dictionary<MoveDirection, Tuple<int, int>>();
            this.directionToCoords.Add(MoveDirection.Up, new Tuple<int, int>(0, 1));
            this.directionToCoords.Add(MoveDirection.Down, new Tuple<int, int>(0, -1));
            this.directionToCoords.Add(MoveDirection.Left, new Tuple<int, int>(-1, 0));
            this.directionToCoords.Add(MoveDirection.Right, new Tuple<int, int>(1, 0));
            this.directionToCoords.Add(MoveDirection.NoMove, new Tuple<int, int>(0, 0));
        }

        /// <summary>
        /// Метод перемещения объекта в соседнюю клетку (по горизонтали или вертикали)
        /// </summary>
        /// <param name="theItem">предмет, который будет перемещен</param>
        /// <param name="direction">направление перемещения</param>
        /// <param name="map">игровая карта, по которой будет перемещаться объект</param>
        /// <returns>ответ в виде true-false, показывающий успешно ли был перемещен объект</returns>
        public bool MoveItem(GameItem theItem, MoveDirection direction, List<Cell> map)
        {
            bool wasMoved = false;
            int shiftX = this.directionToCoords[direction].Item1;
            int shiftY = this.directionToCoords[direction].Item2;
            Cell oldCell = this.managerOfCells.GetCellByItem(theItem, map);
            Cell newCell = this.managerOfCells.GetCellByCoord(oldCell.X + shiftX, oldCell.Y + shiftY, map);
            if (this.managerOfCells.GetWallCellsList(map).Contains(newCell) != true && newCell != null)
            {
                oldCell.RemoveGameItem(theItem);
                newCell.AddGameItem(theItem);
                wasMoved = true;
            }

            return wasMoved;
        }
    }
}