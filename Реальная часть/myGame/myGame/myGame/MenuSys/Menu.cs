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

namespace myGame.MenuSys
{
    class Menu
    {
        
        public List<MenuItem> Items { get; set; }
        SpriteFont font;
        Texture2D menu_fon;
        
        int vib_item;
        KeyboardState oldState;    
              
        public Menu()
        {
            Items = new List<MenuItem>();
        }

        public void Update()
        {
            KeyboardState state = Keyboard.GetState();
            if (state.IsKeyDown(Keys.Enter))
                Items[vib_item].OnClick();

            int d = 0;
            if (state.IsKeyDown(Keys.Up) && oldState.IsKeyUp(Keys.Up))
                d = -1;
            if (state.IsKeyDown(Keys.Down) && oldState.IsKeyUp(Keys.Down))
                d = 1;

            vib_item += d;
            bool ok = false;
            while (!ok)
            {
                if (vib_item < 0)
                    vib_item = Items.Count - 1;
                else if (vib_item > Items.Count - 1)
                    vib_item = 0;
                else if (Items[vib_item].Active == false)
                    vib_item += d;
                else ok = true;

            }

            oldState = state;
        }
        Color color;
        public void Drow(SpriteBatch spriteBatch)
        {
            

            spriteBatch.Begin();
            spriteBatch.Draw(menu_fon, Vector2.Zero, Color.White);
            int y = 380;
           
            foreach (MenuItem item in Items)
            {
                color = Color.White;
                if (item.Active == false)
                    color = Color.Gray;
                if (item == Items[vib_item])
                {
                    color = Color.Gold;                  
                }
                    
                spriteBatch.DrawString(font, item.Name, new Vector2(40, y), color);
                y += 40;
            }
            spriteBatch.End();
            
        }
            

        public void LoadContent(ContentManager Content)
        {
            menu_fon = Content.Load<Texture2D>("menu_fon");
            font = Content.Load<SpriteFont>("MenuFont");
        }
    }
}
