using System.Drawing;

namespace Sokoban
{
    public class Finish : IGameObject
    {
        private const string FileName = "ground_02.png";
        private Point currentPosition;
        
        public Finish(int x,int y)
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