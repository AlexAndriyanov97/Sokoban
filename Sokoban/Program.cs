using System;
using System.Windows.Forms;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
            controller.CreateGame(1);
            Application.Run(new SokobanWindow(controller));
        }
    }
}