using System;
using System.ComponentModel.Design;
using System.Drawing;

namespace Sokoban
{
    public class Player : IGameObject
    {
        private const string FileName = "player_05.png";

        public string Name { get; private set; }
        private Point currentPosition;

        public Player(int x, int y)
        {
            currentPosition = new Point(x, y);
        }

        public string GetImageFile()
        {
            return FileName;
        }

        public void Move(int deltaX, int deltaY)
        {
            currentPosition.X += deltaX;
            currentPosition.Y += deltaY;
        }

        public bool IsMotionless()
        {
            return false;
        }

        public Point GetPosition()
        {
            return currentPosition;
        }

        public void SetPosition(Point position)
        {
            currentPosition = position;
        }
    }
}