using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sokoban
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            var selectLevel = new Form();
            selectLevel.ClientSize = new Size(100,200);
            listBox = new ListBox();
            listBox.Size = new Size(100,200);
            var arrayLevels = MapStorage.GetArrayLevels();
            foreach (var item in arrayLevels)
            {
                listBox.Items.Add(item);
            }
            selectLevel.Controls.Add(listBox);
            listBox.SelectedIndexChanged += listBox_SelectedIndexChanged;
            selectLevel.Show();
        }
        
        
        void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedLevel =(int) listBox.SelectedItem;
            
            var controller = new Controller();
            controller.CreateGame(selectedLevel);
            var form = new SokobanWindow(controller);
            form.Show();
        }
    }
}