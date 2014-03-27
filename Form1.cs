using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Lab1_3
{
    public partial class Form1 : Form
    {
        public Game game;

        public Form1()
        {
            InitializeComponent();
            game = new Game();
            game.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor.Hide();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor.Show();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            game.SetMousePos(new Point(e.X, e.Y));
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            game.Click();
            pictureBox1.Refresh();
        }
    }
}
