using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Sokoban
{
    public class Controller : IController
    {
        private int level;
        private Dictionary<string, int> records = new Dictionary<string, int>();
        public Map map;
        private static Keys keyPressed;
        private bool isGameOver;
        private int score;

        public void CreateGame(int level)
        {
            this.level = level;
            map = new Map(MapStorage.GetMap(level));
            score = 0;
        }

        public void CalculateStep(Keys key)
        {
            keyPressed = key;
            var currentPosition = map.GetPositionOfPlayer();

            if (currentPosition == null)
            {
                throw new InvalidDataException("Нет игрока на карте");
            }

            var x = currentPosition.Value.X;
            var y = currentPosition.Value.Y;


            switch (keyPressed)
            {
                case Keys.Up:
                    if (VerticalStepIsPossible(currentPosition, -1))
                    {
                        MakeStep(x, y, 0, -1);
                    }

                    break;
                case Keys.Right:
                    if (HorizontalStepIsPossible(currentPosition, 1))
                    {
                        MakeStep(x, y, 1, 0);
                    }

                    break;
                case Keys.Down:
                    if (VerticalStepIsPossible(currentPosition, 1))
                    {
                        MakeStep(x, y, 0, 1);
                    }

                    break;
                case Keys.Left:
                    if (HorizontalStepIsPossible(currentPosition, -1))
                    {
                        MakeStep(x, y, -1, 0);
                    }

                    break;
            }
        }

        private void MakeStep(int x, int y, int dx, int dy)
        {
            if (map.mapOfObjects[x + dx, y + dy] is Box || map.mapOfObjects[x + dx, y + dy] is FinishBox)
            {
                if (map.mapOfObjects[x + 2 * dx, y + 2*dy] is Finish)
                {
                    map.mapOfObjects[x + 2 * dx, y + 2*dy] = new FinishBox(x + 2 * dx, y + 2*dy);
                }
                else
                {
                    map.mapOfObjects[x + 2 * dx, y + 2* dy] = new Box(x + 2 * dx, y +2*dy);
                }
            }

            if (map.sourceMap[x, y] is Finish)
            {
                map.mapOfObjects[x, y] = new Finish(x, y);
            }
            else
            {
                map.mapOfObjects[x, y] = new EmptyCell(x, y);
            }


            map.mapOfObjects[x + dx, y + dy] = new Player(x + dx, y + dy);
            score++;
            CheckGameStatus();
        }

        private void CheckGameStatus()
        {
            var countFinishBox = map.mapOfObjects.OfType<FinishBox>().Count();
            if (countFinishBox == map.CountFinishCells)
            {
                isGameOver = true;
            }
        }

        private bool HorizontalStepIsPossible(Point? currentPosition, int dx)
        {
            if (currentPosition == null)
            {
                throw new InvalidDataException("Нет игрока на карте");
            }

            if (currentPosition.Value.X + dx >= map.MapWidth || currentPosition.Value.X + dx < 0 ||
                map.mapOfObjects[currentPosition.Value.X + dx, currentPosition.Value.Y] is Wall)
            {
                return false;
            }

            if (map.mapOfObjects[currentPosition.Value.X + dx, currentPosition.Value.Y] is EmptyCell ||
                map.mapOfObjects[currentPosition.Value.X + dx, currentPosition.Value.Y] is Finish)
            {
                return true;
            }

            if (currentPosition.Value.X + 2 * dx >= map.MapWidth || currentPosition.Value.X + 2 * dx < 0 ||
                map.mapOfObjects[currentPosition.Value.X + 2 * dx, currentPosition.Value.Y] is Wall ||
                map.mapOfObjects[currentPosition.Value.X + 2 * dx, currentPosition.Value.Y] is Box ||
                map.mapOfObjects[currentPosition.Value.X + 2 * dx, currentPosition.Value.Y] is FinishBox
            )
            {
                return false;
            }

            return true;
        }

        private bool VerticalStepIsPossible(Point? currentPosition, int dy)
        {
            if (currentPosition == null)
            {
                throw new InvalidDataException("Нет игрока на карте");
            }

            if (currentPosition.Value.Y + dy >= map.MapHeight || currentPosition.Value.Y + dy < 0 ||
                map.mapOfObjects[currentPosition.Value.X, currentPosition.Value.Y + dy] is Wall)
            {
                return false;
            }

            if (map.mapOfObjects[currentPosition.Value.X, currentPosition.Value.Y + dy] is EmptyCell ||
                map.mapOfObjects[currentPosition.Value.X, currentPosition.Value.Y + dy] is Finish)
            {
                return true;
            }

            if (currentPosition.Value.Y + 2 * dy >= map.MapHeight || currentPosition.Value.Y + 2 * dy < 0 ||
                map.mapOfObjects[currentPosition.Value.X, currentPosition.Value.Y + 2 * dy] is Wall ||
                map.mapOfObjects[currentPosition.Value.X, currentPosition.Value.Y + 2 * dy] is Box ||
                map.mapOfObjects[currentPosition.Value.X, currentPosition.Value.Y + 2 * dy] is FinishBox)

            {
                return false;
            }

            return true;
        }

        public void DownloadRecords()
        {
            throw new System.NotImplementedException();
        }

        public int GetScore()
        {
            return score;
        }

        public void Reset()
        {
            map.mapOfObjects = map.sourceMap;
        }

        public bool GameIsOver()
        {
            return isGameOver;
        }

        public Map GetMap()
        {
            return map;
        }

        public int GetMapWidth()
        {
            return map.MapWidth;
        }

        public int GetMapHeight()
        {
            return map.MapHeight;
        }
    }
}