using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Lab1_3
{
    public class Game
    {
        public Gun Gun;
        public Crosshair Crosshair = new Crosshair();
        public List <BulletAperture> bulletApertures = new List <BulletAperture> ();

        public Game()
        {
            GameCommon.GlobalTimer.Tick += new EventHandler(timer_Tick);
            Gun = new Deagle(); // Temporary
            Gun.Reload();       //
        }

        public void Click()
        {
            Point? bulletPlace = Gun.MakeShoot(Crosshair);
            if (bulletPlace.HasValue)
            {
                bulletApertures.Add(new BulletAperture(bulletPlace.Value, GameCommon.BulletLifeTime));
                Crosshair.Shoot();
            }
        }

        public void Start()
        {
            GameCommon.GlobalTimer.Start();
        }

        public void Draw(Graphics graphics)
        {
            Crosshair.Draw(graphics);
            foreach (BulletAperture bulletAperture in bulletApertures)
            {
                bulletAperture.Draw(graphics);
            }
        }

        public void SetMousePos(Point curPos)
        {
            Crosshair.SetCoods(curPos);
        }

        public void ChooseWeapon(string weapon)
        {
            switch (weapon)
            {
                case "Deagle": Gun = new Deagle(); break;
                    //ADD weapons
                case "AK 47": ; break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            Crosshair.Tick();
            foreach (BulletAperture bulletAperture in bulletApertures)
            {
                bulletAperture.Decrease();
            }
            bulletApertures.RemoveAll(bulletAperture => !bulletAperture.IsAlive());
        }
    }
}
