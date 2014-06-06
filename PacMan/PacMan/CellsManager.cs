using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameItems;

namespace PacMan
{
    /// <summary>
    /// Класс, который позволяет находить определенные ячейки
    /// </summary>
    public class CellsManager
    {
        /// <summary>
        /// Получение ячейки по известным координатам из списка ячеек
        /// </summary>
        /// <param name="x">Координата по горизонтали</param>
        /// <param name="y">Координата по вертикали</param>
        /// <param name="map">список ячеек</param>
        /// <returns>искомая ячейка</returns>
        public Cell GetCellByCoord(int x, int y, List<Cell> map)
        {
            Cell result = null;
            foreach (var item in map)
            {
                if (item.X == x && item.Y == y)
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Получение ячейки по содержащемуся в ней объекту из списка ячеек
        /// </summary>
        /// <param name="theItem">известный объект</param>
        /// <param name="map">список ячеек</param>
        /// <returns>искомая ячейка</returns>
        public Cell GetCellByItem(GameItem theItem, List<Cell> map)
        {
            Cell result = null;
            foreach (var item in map)
            {
                if (item.Content.Contains(theItem))
                {
                    result = item;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// Получение из списка ячеек той ячейки, в которой в данный момент находится игрок
        /// </summary>
        /// <param name="map">список ячеек</param>
        /// <returns>искомая ячейка</returns>
        public Cell GetPlayerCell(List<Cell> map)
        {
            Cell result = null;

            foreach (var cell in map)
            {
                foreach (var item in cell.Content)
                {
                    if (item.GetType() == typeof(Player))
                    {
                        result = cell;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Получение из списка ячеек списка тех ячеек, в которых в данный момент находится все противники
        /// </summary>
        /// <param name="map">список ячеек</param>
        /// <returns>искомая ячейка</returns>
        public List<Cell> GetEnemyCellsList(List<Cell> map)
        {
            List<Cell> result = null;

            foreach (var cell in map)
            {
                foreach (var item in cell.Content)
                {
                    if (item.GetType() == typeof(Player))
                    {
                        result.Add(cell);
                    }
                }
            }

            return result;
        }

        public List<Cell> GetTreasureCellsList(List<Cell> map)
        {
            List<Cell> result = null;

            foreach (var cell in map)
            {
                foreach (var item in cell.Content)
                {
                    if (item.GetType() == typeof(Treasure))
                    {
                        result.Add(cell);
                    }
                }
            }

            return result;
        }

        public List<Cell> GetExitCellsList(List<Cell> map)
        {
            List<Cell> result = null;

            foreach (var cell in map)
            {
                foreach (var item in cell.Content)
                {
                    if (item.GetType() == typeof(Exit))
                    {
                        result.Add(cell);
                    }
                }
            }

            return result;
        }

        public List<Cell> GetWallCellsList(List<Cell> map)
        {
            List<Cell> result = null;

            foreach (var cell in map)
            {
                foreach (var item in cell.Content)
                {
                    if (item.GetType() == typeof(Wall))
                    {
                        result.Add(cell);
                    }
                }
            }

            return result;
        }

        public void PlayerCollision(List<Cell> map)
        {
            Cell playerCell = this.GetPlayerCell(map);
            List<Cell> enemyList = GetEnemyCellsList(map);

            if (this.GetCellByItem(playerCell.Content[0], enemyList) != null)
            {
                //game over
            }

            List<Cell> exitList = GetExitCellsList(map);
            if (this.GetCellByItem(playerCell.Content[0], exitList) != null)
            {
                //win
            }

            List<Cell> treasureList = GetTreasureCellsList(map);
            foreach (var cell in treasureList)
            {
                GameItem itemToDelete = null;
                if (cell == playerCell)
                {
                    foreach (var item in cell.Content)
                    {
                        if (item.GetType() == typeof(Treasure))//заменить на is??????
                        {
                            itemToDelete = item;
                        }
                    }
                }

                if (itemToDelete != null)
                {
                    cell.RemoveGameItem(itemToDelete);
                }
            }
        }
    }
}