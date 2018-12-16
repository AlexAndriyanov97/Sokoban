using System.Collections.Generic;

namespace Sokoban
{
    public class Controller : IController
    {
        private int level;
        private Dictionary<string, int> records = new Dictionary<string, int>();
        private string map;
        private Player player;
        
        void CreateGame(int level)
        {
            map = MapStorage.GetMap(level);
            player = new Player();
        }


        public void DownloadRecords()
        {
            throw new System.NotImplementedException();
        }
    }
}