using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace Lab1_3
{
    public static class GameCommon
    {
        public const int TimerInterval = 100;
        public const int CrosshairOffsetMin = 5;
        public const int CrosshairOffsetMax = 30;
        public const int CrosshairSectorLen = 15;
        public const int ShootExpansion = 12;
        public const int BulletLifeTime = TimerInterval * 50;

        public static Timer GlobalTimer = new Timer() { Interval = TimerInterval };

        public static int sqrDistanceAB(Point pointA, Point pointB)
        {
            return (pointA.X - pointB.X) * (pointA.X - pointB.X) + (pointA.Y - pointB.Y) * (pointA.Y - pointB.Y);
        }
    }
}