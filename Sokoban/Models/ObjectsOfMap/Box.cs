namespace Sokoban
{
    public class Box: IGameObject
    {
        private const string FileName = "box.png";
        public bool BoxOnFinish { get; private set; }

        public Box()
        {
            
        }

        public bool IsMotionless()
        {
            return false;
        }

        public string GetImageFile()
        {
            return FileName;
        }
    }
}