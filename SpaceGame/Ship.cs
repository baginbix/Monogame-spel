using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SpaceGame
{
    public class Ship
    {
        private List<Shot> shots = new List<Shot>();
         private Texture2D texture;
        private Vector2 position;
        public Rectangle box;
        private Vector2 closestEnemy = new Vector2(-100000,-100000);

        public List<Shot> Shots
        {
            get{return shots;}
        }

        public Ship(Texture2D texture, Vector2 position)
        {
            this.texture = texture;
            this.position = position;
            box = new Rectangle((int)position.X,(int)position.Y,20,20);
        }

        public void Update(List<Enemy> enemies)
        {
            FindClosestEnemy(enemies);

            UpdateShots();

            Shoot();
            Move();
        }

        void FindClosestEnemy( List<Enemy> enemies)
        {
                        
            foreach (var enemy in enemies)
            {
                if(enemy.box.Y > closestEnemy.Y)
                    closestEnemy = enemy.box.Location.ToVector2();
            }
        }

        private void UpdateShots()
        {
             foreach (var item in shots)
            {
                item.Update();
            }
        }

        private void Shoot()
        {
                if(position.X == closestEnemy.X)
                    shots.Add(new Shot(texture, position));

        }

        private void Move()
        {
            if(closestEnemy.X == -100000) return;
            if(position.X> closestEnemy.X)
                position.X--;
            else if(position.X < closestEnemy.X)
                position.X++; 

            box.Location = position.ToPoint();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, box, Color.White);
            foreach (var item in shots)
            {
                item.Draw(spriteBatch);
            }
        }
    }
}