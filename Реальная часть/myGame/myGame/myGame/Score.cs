using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace myGame
{
    class Score
    {
        string[] score_name = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
        public static int[] score_kol = new int[11] { 0, 0,  0 ,  0 ,  0 ,  0 ,  0 , 0 ,  0 , 0, 0  };
        SpriteFont font_score;
        String text_score = "Рекорды";
        Texture2D fon_sco;

        

        public void Update_Score()
        {
            
            for (int i = 0; i < 11; i++)
            {
                // сравниваем два соседних элемента.
                for (int j = 0; j < 11 - i - 1; j++)
                {
                    if (score_kol[j] < score_kol[j + 1])
                    {
                        // если они идут в неправильном порядке, то  
                        //  меняем их местами. 
                        int tmp = score_kol[j]; 
                        score_kol[j] = score_kol[j + 1]; 
                        score_kol[j + 1] = tmp;
                    }
                }
            }

           /*int bf;
            for(int a=0;a<10;a++)
            {
                if (a < score)
                    continue;
                else
                    bf = a;
                    a = score;

            }*/


        }

        public void Update()
        {
            
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Escape))
                Game1.gameState = Game1.GameState.Menu;

            
        }
        public void Drow(SpriteBatch spriteBatch)
        {
           
            int y=90;
            /*for (int i = 0; i < 10; i++)            {
                Score.score_name[i] = "Name";
                Score.score_kol[i] = "000";}*/

          Update_Score();
            spriteBatch.Begin();
            spriteBatch.Draw(fon_sco, Vector2.Zero, Color.White);
            spriteBatch.DrawString(font_score, text_score, new Vector2(40, 35), Color.SeaGreen);

            for (int i = 0; i < 10; i++)
            {
                spriteBatch.DrawString(font_score, score_name[i], new Vector2(50, y), Color.PaleGreen);
                spriteBatch.DrawString(font_score, System.Convert.ToString(score_kol[i]), new Vector2(280, y), Color.Aqua);
               y += 45;
             }           
            spriteBatch.End();
        }
        public void LoadContent(ContentManager Content)

        {
           
            fon_sco = Content.Load<Texture2D>("score");
            font_score = Content.Load<SpriteFont>("ScoreFont");
        }
    }
}
