using System;
using System.Windows.Forms;

namespace Sokoban
{
    class Program
    {
        static void Main(string[] args)
        {
            var controller = new Controller();
            controller.CreateGame(2);
            Application.Run(new SokobanWindow(controller));
        }
    }
}