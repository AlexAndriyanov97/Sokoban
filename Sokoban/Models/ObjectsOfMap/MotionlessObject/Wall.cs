using System.Drawing;

namespace Sokoban
{
    public class Wall : IGameObject
    {
        
        private const string FileName = "block_05.png";
        private Point currentPosition;

        public Wall(int x,int y)
        {
            currentPosition = new Point(x,y);
        }

        public bool IsMotionless()
        {
            return true;
        }

        public string GetImageFile()
        {
            return FileName;
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