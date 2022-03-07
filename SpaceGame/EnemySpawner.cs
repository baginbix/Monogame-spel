using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame
{
    public class EnemySpawner
    {
         private List<Enemy> squares = new List<Enemy>();
        private float timer = 0;
        private float spawnTime = 3;
        Random rand = new Random();

        private Texture2D texture;

        public List<Enemy> Squares
        {
            get{ return squares;}
        }

        public EnemySpawner(Texture2D texture)
        {
            this.texture = texture;
            timer = spawnTime;
        }
        public void Update()
        {

            if(timer <= 0)
            {
                squares.Add(new Enemy(texture,RandomVector()));
                timer += spawnTime;
            }
            timer -= 1f/60f;

            foreach (var item in squares)
            {
                item.Update();
            }
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