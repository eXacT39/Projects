using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;

namespace Lab1_3
{
    class Deagle:Gun
    {
        public Deagle()
        {
            ClipSize = 7;
            Dispersion = 5;
            soundShoot = new SoundPlayer("D:\\Studying\\4 курс\\Zenkin\\Graphics\\Lab1_3\\sound\\deagle-1.wav");
        }
    }
}
