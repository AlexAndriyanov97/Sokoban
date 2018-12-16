namespace Sokoban
{
    public class EmptyCell : IGameObject
    {
        private const string FileName = "box.png";

        public EmptyCell()
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