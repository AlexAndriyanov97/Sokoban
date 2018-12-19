using System.Windows.Forms;

namespace Sokoban
{
    public interface IController
    {
        void DownloadRecords();
        void SetPressedKey(Keys key);

        int GetScore();

        Map GetMap();
    }
}