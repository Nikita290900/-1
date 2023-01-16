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
using myGame.MenuSys;

namespace myGame
{
    class Help
    {              
       bool statekey = true;
       Texture2D key;
       Texture2D his;
       SpriteFont font_help;
       KeyboardState oldState;
       

        public void LoadContent(ContentManager Content)
        {
            key = Content.Load<Texture2D>("key");
            his = Content.Load<Texture2D>("his");
            font_help = Content.Load<SpriteFont>("MenuFont");
        }
        public void Update()
        {            
           KeyboardState state = Keyboard.GetState();
           if (state.IsKeyDown(Keys.Escape))
               Game1.gameState = Game1.GameState.Menu;

           if (state.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
               statekey = false;

           if (state.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
               statekey = true;

         oldState = state;
        }
        public void Drow(SpriteBatch spriteBatch)
        {
           // spriteBatch.DrawString(font_help, text_help, new Vector2(40, 40), Color.Red );
            Color[] colorstate = { Color.White, Color.White };
            spriteBatch.Begin();
            if (statekey == true)
            {
                spriteBatch.Draw(key, Vector2.Zero, Color.White);
                colorstate[1] = Color.Gold;
            }
            else
            {
                spriteBatch.Draw(his, Vector2.Zero, Color.White);
                colorstate[0] = Color.Gold;
            }

            spriteBatch.DrawString(font_help, "История", new Vector2(15, 30), colorstate[0]);
            spriteBatch.DrawString(font_help, "Управление", new Vector2(15, 60), colorstate[1]);
            spriteBatch.End();

        }
       
    }
}
