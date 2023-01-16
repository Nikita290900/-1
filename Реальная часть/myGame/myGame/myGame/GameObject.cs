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
    class GameObject
    {
        public Texture2D sprite;
        public Vector2 position;
        public float rotation;
        public bool alive;
        public int live;
        public Rectangle rectangle;
        public Color[] tex_data;

        public GameObject(Texture2D loadTexture)
        {
            sprite = loadTexture;

            position = Vector2.Zero;
            rotation = 0.0f;

            rectangle = new Rectangle((int)position.X, (int)position.Y, sprite.Width, sprite.Height);
            tex_data = new Color[sprite.Width * sprite.Height];
            sprite.GetData(tex_data);

            live = 3;
            alive = false;
        }
      
    }
}
