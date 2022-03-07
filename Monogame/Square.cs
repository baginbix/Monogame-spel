
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Monogame
{
    public class Square
    {
        private Texture2D texture;
        private Vector2 position;
        public Rectangle box;

        public Square(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            box = new Rectangle((int)position.X,(int)position.Y,20,20);
        }

        public void Update()
        {
            if(Mouse.GetState().LeftButton == ButtonState.Pressed)
            {
                Vector2 direction = Mouse.GetState().Position.ToVector2() - position;
                direction.Normalize();
                position += direction * 3;
                box.Location = position.ToPoint();
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, box, Color.White);
            
        }
    }
}