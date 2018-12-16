namespace Sokoban
{
    public class Finish : IGameObject
    {
        private const string FileName = "finish.png";

        public Finish()
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