namespace Sokoban
{
    public class Wall : IGameObject
    {
        
        private const string FileName = "wall.png";


        public Wall()
        {
        }

        public bool IsMotionless()
        {
            return true;
        }

        public string GetImageFile()
        {
            return FileName;
        }
    }
}