using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame
{
    public class Shot
    {
         private Texture2D texture;
        private Vector2 position;
        private Rectangle box;

        public Rectangle Box
        {
            get{return box;}
        }

        public Shot(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position + new Vector2(5,0);
            box = new Rectangle((int)position.X,(int)position.Y,10,10);
        }

        public void Update()
        {
            position.Y--;
            box.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, box, Color.White);
            
        }
    }
}