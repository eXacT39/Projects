using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.Drawing;

namespace Lab1_3
{
    public abstract class Gun
    {
        public int ClipSize;
        public int Dispersion;
        protected SoundPlayer soundShoot;
        private readonly SoundPlayer soundEmpty = new SoundPlayer("sound/ammoempty.wav");

        private int _countBullet;
        public int countBullet
        {
            get
            {
                return _countBullet;
            }
            set
            {
                if (value > ClipSize)
                    throw new Exception("bullets are greater then clipSize");
                if (value < 0)
                    throw new Exception("bullets are not enougth");
                _countBullet = value;
            }
        }

        public Point? MakeShoot(Crosshair crosshair)
        {
            if (countBullet > 0)
            {
                soundShoot.Play();
                --countBullet;
                Random curDispersion = new Random(Dispersion);
                int xDispersion = new Random(curDispersion);
                int yDispersion = new Random(curDispersion);
                // Use dispersion
                return new Point(crosshair.Center.X + xDispersion, crosshair.Center.Y - yDispersion);
            }
            else
            {
                soundEmpty.Play();
                return null;
            }
        }

        public void Reload()
        {
            countBullet = ClipSize;
        }
    }
}
