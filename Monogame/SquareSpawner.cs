using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Monogame
{
    public class SquareSpawner
    {
        private List<Square> squares = new List<Square>();
        private float timer = 0;
        private float spawnTime = 3;
        Random rand = new Random();

        private Texture2D texture;

        public List<Square> Squares
        {
            get{ return squares;}
        }

        public SquareSpawner(Texture2D texture)
        {
            this.texture = texture;
            timer = spawnTime;
        }
        public void Update()
        {

            if(timer <= 0)
            {
                squares.Add(new Square(texture,RandomVector()));
                timer += spawnTime;
            }
            timer -= 1f/60f;
        }

        private Vector2 RandomVector()
        {
            return new Vector2(rand.Next(0,800),0);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var item in squares)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}