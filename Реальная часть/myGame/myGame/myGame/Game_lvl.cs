using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace myGame
{   
    
    public class Game_lvl
    {
        Random rnd = new Random();
              

        public void New()
        {            
            itsGame.gg.alive = true;
            itsGame.gg.position = new Vector2(150, 150);
            Game1.timer.Elapsed += new ElapsedEventHandler(ShowTime);
            Game1.timer.Interval = 500;
            Game1.timer.Start();
            itsGame.hit = false;
            //Game1.show = 1;

           foreach (var z in itsGame.sword)
            {
                z.position = new Vector2(rnd.Next(0, 790), rnd.Next(605, 615));                
                z.alive = true;
            }

            foreach (var z in itsGame.spear)
            {
                //z.position = new Vector2(rnd.Next(150, 750), rnd.Next(150, 550));
                z.alive = false;
            }

            foreach (var z in itsGame.horse)
            {
               // z.position = new Vector2(rnd.Next(150, 750), rnd.Next(150, 550));
                z.alive = false;
            }

            itsGame.GameOver = false;
            itsGame.tm = 0;
            itsGame.score = 0;
          
        }

    public void ShowTime(object source, ElapsedEventArgs e)
        {
            itsGame.tm++;
        }

    public void sword()
    {
        
        foreach (var z in itsGame.sword)
        {
            z.position = new Vector2(rnd.Next(0, 800), rnd.Next(605, 615)); 
           
            z.alive = true;
        }

    }
    public void spear()
    {
        foreach (var f in itsGame.spear)
        {
            f.position = new Vector2(rnd.Next(0, 800), rnd.Next(-15, -5));
          
            f.alive = true;
        }
    }
    public void horse()
    {
        foreach (var m in itsGame.horse)
        {
            m.position = new Vector2(rnd.Next(805, 815), rnd.Next(0, 600));
           
            m.alive = true;
        }
    }

    }
}
