using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1_3 
{
    public class Crosshair 
    {
        public Point Center;
        private Point previous;
        private static Pen crosshairPen = new Pen(Color.Black, 3f);

        private int _offset = 0;
        public int offset
        {
            get
            {
                return _offset;
            }
            set
            {
                if (value < GameCommon.CrosshairOffsetMin)
                    value = GameCommon.CrosshairOffsetMin;
                if (value > GameCommon.CrosshairOffsetMax)
                    value = GameCommon.CrosshairOffsetMax;
                _offset = value;
            }
        }

        public Crosshair()
        {
            Center = new Point(0, 0);
            previous = new Point(0, 0);            
        }

        public void Shoot()
        {
            offset += GameCommon.ShootExpansion;
        }

        public void SetCoods(Point curPos)
        {
            Center = curPos;
        }

        public void Draw(Graphics graphics)
        {
            graphics.DrawLine(crosshairPen, Center.X + offset, Center.Y, Center.X + offset + GameCommon.CrosshairSectorLen, Center.Y);
            graphics.DrawLine(crosshairPen, Center.X, Center.Y + offset, Center.X, Center.Y + offset + GameCommon.CrosshairSectorLen);
            graphics.DrawLine(crosshairPen, Center.X - offset, Center.Y, Center.X - offset - GameCommon.CrosshairSectorLen, Center.Y);
            graphics.DrawLine(crosshairPen, Center.X, Center.Y - offset, Center.X, Center.Y - offset - GameCommon.CrosshairSectorLen);
        }

        public void Tick()
        {
            int dist = GameCommon.sqrDistanceAB(Center, previous);
            if (dist == 0)
            {
                crosshairStand();
            }
            else
            {
                crosshairMove(dist);
            }
                
            previous = Center;
        }

        private void crosshairStand()
        {
            offset -= 5;
        }

        private void crosshairMove(int intensive)
        {
            offset += (intensive / 300);
        }

    }
}
