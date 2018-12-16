using System;
using System.ComponentModel.Design;
using System.Drawing;

namespace Sokoban
{
    public class Player : IGameObject
    {
        private const string FileName = "player.png";

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
    }
}