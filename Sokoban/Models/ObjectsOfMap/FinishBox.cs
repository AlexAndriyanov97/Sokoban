using System.Drawing;

namespace Sokoban
{
    public class FinishBox:IGameObject
    {
        private const string FileName = "crate_05.png";
        public bool BoxOnFinish { get; private set; }
        private Point currentPosition;
        
        public FinishBox(int x,int y)
        {
            currentPosition =new Point(x,y);
        }

        public bool IsMotionless()
        {
            return false;
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