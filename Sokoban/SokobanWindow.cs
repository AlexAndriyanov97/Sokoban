using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Sokoban
{
    public class SokobanWindow : Form
    {
        private const int elementSize = 65;
        private readonly Dictionary<string, Bitmap> bitmaps = new Dictionary<string, Bitmap>();
        private readonly IController controller;
        private Button reset;
        private Timer timer = new Timer();
        private int timerCounter = 0;

        public SokobanWindow(IController controller)
        {
            timer.Interval = 1000;
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            this.controller = controller;
            ClientSize = new Size(elementSize * controller.GetMap().MapWidth,
                elementSize * controller.GetMap().MapHeight + 32);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            var imagesDirectory = new DirectoryInfo("images");
            foreach (var e in imagesDirectory.GetFiles("*.png"))
                bitmaps[e.Name] = (Bitmap) Image.FromFile(e.FullName);
        }

        void timer_Tick(object sender, EventArgs e)
        {
            ++timerCounter;
            Invalidate();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = "Sokoban";
            DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.TranslateTransform(0, 32);
            e.Graphics.FillRectangle(new TextureBrush(bitmaps["ground_01.png"]), 0, 0,
                elementSize * controller.GetMap().MapWidth, elementSize * controller.GetMap().MapHeight + 32);
            foreach (var a in controller.GetMap().mapOfObjects)
            {
                var point = a.GetPosition();
                point.X *= elementSize;
                point.Y *= elementSize;
                e.Graphics.DrawImage(bitmaps[a.GetImageFile()], point);
            }

            e.Graphics.ResetTransform();
            e.Graphics.DrawString(timerCounter.ToString(), new Font("Arial", 16), Brushes.Red, 64, 0);
            e.Graphics.DrawString(controller.GetScore().ToString(), new Font("Arial", 16), Brushes.Green, 0, 0);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            controller.CalculateStep(e.KeyCode);
            if (controller.GameIsOver())
            {
                //TODO
            }

            Invalidate();
        }
    }
}