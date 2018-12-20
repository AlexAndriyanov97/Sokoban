using System.Windows.Forms;

namespace Sokoban
{
    public interface IController
    {
        void DownloadRecords();

        int GetScore();
        void CalculateStep(Keys key);
        bool GameIsOver();
        Map GetMap();

        void Reset();
    }
}