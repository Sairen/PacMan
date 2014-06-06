using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PacMan.GameItems;
using System.Threading;

namespace PacMan
{
     public static class Game
    {
        private static void Initialize()
        {
            theMapMaker = new MapMaker();
            GameField = new List<Cell>();
            managerOfCells = new CellsManager();
        }

        private static MapMaker theMapMaker;
        private static List<Cell> GameField;
        private static CellsManager managerOfCells;
        private static PlayerMover moverOfPlayer;
        private static EnemyMover moverOfEnemies;

        private static bool isWorking = true;
         

        public static void Main()
        {
            Initialize();
            ThreadPool.QueueUserWorkItem(CycleRedraw);
            var key = Console.ReadKey();
            //ProcessEnteredKey(key);

            while (isWorking)
            {
                GameField = theMapMaker.MakeLevel1();

            }

            if (ExitIsFound() == true)
            {
                isWorking = false;
            }

        }

        private static bool ExitIsFound()
        {
            bool result = false;
            List<Cell> allExits = managerOfCells.GetExitCellsList(GameField);
            Cell playerCell = managerOfCells.GetPlayerCell(GameField);
            foreach (var item in allExits)
            {
                if (item == playerCell)
                {
                    result = true;
                }
            }
            return result;
        }


        private static void CycleRedraw(object state)
        {
        }

        private static void DrawMap()
        {
            string result = string.Empty;

            for (int y = 0; y < 10; y++)
            {
                for (int x = 0; x < 10; x++)
                {
                    result = result + managerOfCells.GetCellByCoord(x, y, GameField);
                }
                result = result + Environment.NewLine;
            }
        }
    }
}
