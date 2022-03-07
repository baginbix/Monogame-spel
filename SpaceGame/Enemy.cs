using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame
{
    public class Enemy
    {
         private Texture2D texture;
        private Vector2 position;
        public Rectangle box;

        public Enemy(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            box = new Rectangle((int)position.X,(int)position.Y,20,20);
        }

        public void Update()
        {
            position.Y++;

            box.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, box, Color.White);
            
        }
    }
}