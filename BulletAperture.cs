using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab1_3
{
    public class BulletAperture
    {
        private Point _position;
        private int _lifetime;
        private static Brush bulletBrush = Brushes.Black;

        public BulletAperture(Point position, int lifetime)
        {
            _position = position;
            _lifetime = lifetime;
        }

        public void Decrease()
        {
            --_lifetime;
        }
        public bool IsAlive()
        {
            return _lifetime > 0;
        }
        public void Draw(Graphics graphics)
        {
            graphics.FillEllipse(bulletBrush, _position.X, _position.Y, 10, 10);
        }
    }
}
