using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    class itsGame
    {
        SpriteFont font_score;
        SpriteFont font_end;
        Texture2D lvl1_map;
        Texture2D trav;
        GameObject kamn;
        public static GameObject gg;
        Texture2D corsor;
        Texture2D gover;
        Rectangle corsorPos;
        public static int lvl = 2;
        int speed_gg = lvl;        
        GameObject arrow;
        public static GameObject[] sword;
        public static GameObject[] spear;
        public static GameObject[] horse;
        public static bool GameOver = false;
        public static int tm;        
        public static int score;
        Game_lvl game_lvl = new Game_lvl();
        public static bool hit;

        static bool IntersectPixels(Rectangle rectangleA, Color[] dataA,
                                    Rectangle rectangleB, Color[] dataB)
        {
           
            int top = Math.Max(rectangleA.Top, rectangleB.Top);
            int bottom = Math.Min(rectangleA.Bottom, rectangleB.Bottom);
            int left = Math.Max(rectangleA.Left, rectangleB.Left);
            int right = Math.Min(rectangleA.Right, rectangleB.Right);

           
            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                   
                    Color colorA = dataA[(x - rectangleA.Left) +
                                         (y - rectangleA.Top) * rectangleA.Width];
                    Color colorB = dataB[(x - rectangleB.Left) +
                                         (y - rectangleB.Top) * rectangleB.Width];

                   
                    if (colorA.A != 0 && colorB.A != 0)
                    {
                        
                        return true;
                    }
                }
            }
                       
            return false;
        }

        bool dead_all()
        {
            foreach (var z in sword)
            {
                if(z.alive==true)
                    return false;
            }

            foreach (var y in spear)
            {
                if (y.alive == true)
                    return false;
            }

            foreach (var f in horse)
            {
                if (f.alive == true)
                    return false;
            }

            return true;
        }


        public void Update()
        {            
            KeyboardState state = Keyboard.GetState();

            if (state.IsKeyDown(Keys.Escape))
                Game1.gameState = Game1.GameState.Menu;
            if (state.IsKeyDown(Keys.Right))
                gg.position.X += speed_gg ;
            if (state.IsKeyDown(Keys.Left))
                gg.position.X -= speed_gg ;
            if (state.IsKeyDown(Keys.Down))
                gg.position.Y += speed_gg ;
            if (state.IsKeyDown(Keys.Up))
                gg.position.Y -= speed_gg;


            if ((score >= 10) && (score <= 50) && (dead_all() == true))
            {
                game_lvl.spear();  
                               
            }

            else if ((score >= 50) && (score <= 100) && (dead_all() == true))
            {
                
                game_lvl.spear();
                game_lvl.sword();
            }

            else if ((score >= 100) && (score <= 200) && (dead_all() == true))
            {
                
                game_lvl.sword();
                game_lvl.horse();
            }

            else if ((score >= 100) && (score <= 200) && (dead_all() == true))
            {
                game_lvl.spear();
                game_lvl.horse();

            }
            else if ((score >= 200) && (dead_all() == true))
            {
                game_lvl.sword();
                game_lvl.spear();
                game_lvl.horse();

            }
            else if((score <=10) && (dead_all() == true)) {
                
                game_lvl.sword();
            
            }
            
            MouseState m_state = Mouse.GetState();
            gg.rotation = (float)Math.Atan2(m_state.Y - gg.position.Y, m_state.X - gg.position.X);
           


            if (m_state.LeftButton == ButtonState.Pressed)
            {
                arrow.alive = true;
                arrow.position = gg.position;
               // arrow.rotation = gg.rotation;
            }

            gg.rectangle = new Rectangle((int)gg.position.X, (int)gg.position.Y, gg.sprite.Width, gg.sprite.Height);
            gg.tex_data = new Color[gg.sprite.Width * gg.sprite.Height];
            gg.sprite.GetData(gg.tex_data);

            arrow.rectangle = new Rectangle((int)arrow.position.X, (int)arrow.position.Y, arrow.sprite.Width, arrow.sprite.Height);

            kamn.rectangle = new Rectangle((int)kamn.position.X, (int)kamn.position.Y, kamn.sprite.Width, kamn.sprite.Height);
            kamn.tex_data = new Color[kamn.sprite.Width * kamn.sprite.Height];
            kamn.sprite.GetData(kamn.tex_data);

           

           /* if (IntersectPixels(gg.rectangle, gg.tex_data, kamn.rectangle, kamn.tex_data))
                hit = true;*/

           

            foreach (var z in sword)
            { 
                z.rectangle = new Rectangle((int)z.position.X, (int)z.position.Y, z.sprite.Width, z.sprite.Height);

                if (arrow.alive == true)
                {
                    if ((arrow.rectangle.Intersects(z.rectangle)) && (z.alive == true))
                    {
                        arrow.alive = false;
                        z.alive = false;
                        score += 1;
                    }

                }

                if ((z.rectangle.Intersects(gg.rectangle)) && (z.alive==true))
                {
                    gg.alive = false;
                   /* gg.live--;
                    if (gg.live <= 0)
                    {
                        
                        break;
                    }*/
                }
            }


            foreach (var z in spear)
            {
                z.rectangle = new Rectangle((int)z.position.X, (int)z.position.Y, z.sprite.Width, z.sprite.Height);

                if (arrow.alive == true)
                {
                    if ((arrow.rectangle.Intersects(z.rectangle)) && (z.alive == true))
                    {
                        arrow.alive = false;
                        z.alive = false;
                        score += 2;
                    }

                }

                if ((z.rectangle.Intersects(gg.rectangle)) && (z.alive == true))
                {
                    gg.alive = false;
                    /* gg.live--;
                     if (gg.live <= 0)
                     {
                        
                         break;
                     }*/
                }
            }

            foreach (var z in horse)
            {
                z.rectangle = new Rectangle((int)z.position.X, (int)z.position.Y, z.sprite.Width, z.sprite.Height);

                if (arrow.alive == true)
                {
                    if ((arrow.rectangle.Intersects(z.rectangle)) && (z.alive == true))
                    {
                        arrow.alive = false;
                        z.alive = false;
                        score += 3;
                    }

                }

                if ((z.rectangle.Intersects(gg.rectangle)) && (z.alive == true))
                {
                    gg.alive = false;
                    /* gg.live--;
                     if (gg.live <= 0)
                     {
                        
                         break;
                     }*/
                }
            }

            foreach (var z in sword)
            {
                z.rotation = (float)Math.Atan2(gg.position.Y - z.position.Y, gg.position.X - z.position.X);
                z.position += new Vector2((float)Math.Cos(z.rotation), (float)Math.Sin(z.rotation));
                //z.rotation = (float)Math.Atan2(gg.position.Y, gg.position.X);
                //Score.score = (int)Math.Atan2(gg.position.Y, gg.position.X);
                //pos_gg_old = (float)Math.Atan2(gg.position.Y, gg.position.X);
            }

            foreach (var z in spear)
            {
                z.rotation = (float)Math.Atan2(gg.position.Y - z.position.Y, gg.position.X - z.position.X);
                z.position += new Vector2((float)Math.Cos(z.rotation), (float)Math.Sin(z.rotation));
                //z.rotation = (float)Math.Atan2(gg.position.Y, gg.position.X);
                //Score.score = (int)Math.Atan2(gg.position.Y, gg.position.X);
                //pos_gg_old = (float)Math.Atan2(gg.position.Y, gg.position.X);
            }

              foreach (var z in horse)
            {
                z.rotation = (float)Math.Atan2(gg.position.Y - z.position.Y, gg.position.X - z.position.X);
                z.position += new Vector2((float)Math.Cos(z.rotation), (float)Math.Sin(z.rotation));
                //z.rotation = (float)Math.Atan2(gg.position.Y, gg.position.X);
                //Score.score = (int)Math.Atan2(gg.position.Y, gg.position.X);
                //pos_gg_old = (float)Math.Atan2(gg.position.Y, gg.position.X);
            }

            for (int j = 0; j < 10; j++)
            {
                arrow.position += new Vector2((float)Math.Cos(gg.rotation),(float)Math.Sin(gg.rotation));
            }

           /* foreach (var z in sword)
            {
                                //sword[1].position += -(new Vector2((float)Math.Cos(gg.rotation),(float)Math.Sin(gg.rotation)));
                z.position = new Vector2(rnd.Next(800), rnd.Next(600));
                z.rotation = -(gg.rotation);
            }*/
            corsorPos = new Rectangle(m_state.X, m_state.Y, corsor.Width, corsor.Height);

        }
      
        public void Drow(SpriteBatch spriteBatch)
        {
            /* for (int i = 0; i < 10; i++)
            {
                Score.score_name[i] = "name";
                Score.score_kol[i] = "777";
            }*/

            
            spriteBatch.Begin();
            if (gg.alive == true)
            {
                spriteBatch.Draw(lvl1_map, Vector2.Zero, Color.White);
                spriteBatch.Draw(kamn.sprite, Vector2.Zero, Color.White);
                if (gg.alive == true)
                    spriteBatch.Draw(gg.sprite, gg.position, null, Color.White, gg.rotation, new Vector2(20, 50), 1.0f, SpriteEffects.None, 0);

                if (arrow.alive == true)
                    spriteBatch.Draw(arrow.sprite, arrow.position, null, Color.White, gg.rotation, new Vector2(0, 2), 1.0f, SpriteEffects.None, 0);

                foreach (var z in sword)
                {
                    if (z.alive == true)
                        spriteBatch.Draw(z.sprite, z.position, null, Color.White, z.rotation, new Vector2(20, 50), 1.0f, SpriteEffects.None, 0);
                }

                foreach (var z in spear)
                {
                    if (z.alive == true)
                        spriteBatch.Draw(z.sprite, z.position, null, Color.White, z.rotation, new Vector2(20, 50), 1.0f, SpriteEffects.None, 0);
                }

                foreach (var z in horse)
                {
                    if (z.alive == true)
                        spriteBatch.Draw(z.sprite, z.position, null, Color.White, z.rotation, new Vector2(20, 50), 1.0f, SpriteEffects.None, 0);
                }

                
               spriteBatch.Draw(trav, Vector2.Zero, Color.White);
                spriteBatch.Draw(corsor, corsorPos, Color.White);
                spriteBatch.DrawString(font_score, "Счет:" + System.Convert.ToString(score), new Vector2(10, 2), Color.White);
                spriteBatch.DrawString(font_score, "Время:" + System.Convert.ToString(tm), new Vector2(300, 2), Color.White);
            }
            else{
                Game1.timer.Stop();
                     
                spriteBatch.Draw(gover,Vector2.Zero,Color.White);
                spriteBatch.DrawString(font_end, "Счет:" + System.Convert.ToString(score) + "  " + "Время:" + System.Convert.ToString(tm), new Vector2(230, 275), Color.White);
                if (hit == false)
                {
                    Score.score_kol[10] = score;
                    hit = true;
                }                      
            }
            spriteBatch.End();
        }
        public void LoadContent(ContentManager Content)
        {
            font_end = Content.Load<SpriteFont>("EndFont");
            font_score = Content.Load<SpriteFont>("MenuFont");
            lvl1_map = Content.Load<Texture2D>("lvl1_map");

            gg = new GameObject(Content.Load<Texture2D>("GG"));
            

            arrow= new GameObject(Content.Load<Texture2D>("arrow"));
            corsor = Content.Load<Texture2D>("Corsor");
            gover =  Content.Load<Texture2D>("GO");
            sword  = new GameObject[lvl];
            spear = new GameObject[lvl];
            horse = new GameObject[lvl];
            trav = Content.Load<Texture2D>("trav");

            kamn = new GameObject(Content.Load<Texture2D>("kamn1"));
            

            for(int i=0;i<lvl;i++)
            {                
                sword[i] = new GameObject(Content.Load<Texture2D>("sword"));
               
            }

            for (int g = 0; g < lvl; g++)
            {
                horse[g] = new GameObject(Content.Load<Texture2D>("horse"));
                
            }

            for (int t = 0; t < lvl; t++)
            {
                spear[t] = new GameObject(Content.Load<Texture2D>("spear"));
               // spear[t].alive = false;
            }

        }
    }
}
