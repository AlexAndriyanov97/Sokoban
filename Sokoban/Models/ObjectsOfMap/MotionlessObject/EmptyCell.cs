using System.Drawing;

namespace Sokoban
{
    public class EmptyCell : IGameObject
    {
        private const string FileName = "ground_01.png";
        private Point currentPosition;
        
        
        public EmptyCell(int x,int y)
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