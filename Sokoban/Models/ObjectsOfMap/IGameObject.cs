using System.Drawing;

namespace Sokoban
{
    public interface IGameObject
    {
        bool IsMotionless();
        
        string GetImageFile();

        Point GetPosition();

        void SetPosition(Point position);
    }
}