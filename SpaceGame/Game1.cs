using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SpaceGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D pixel;
        Ship ship;

        EnemySpawner enemySpawner;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pixel = new Texture2D(GraphicsDevice,1,1);
            pixel.SetData(new Color[]{Color.White});
            ship = new Ship(pixel,new Vector2(400,420));
            enemySpawner = new EnemySpawner(pixel);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

                ship.Update(enemySpawner.Squares);

                enemySpawner.Update();

                for (int i = 0; i < ship.Shots.Count; i++)
                {
                    for (int j = 0; j < enemySpawner.Squares.Count; j++)
                    {
                        if(ship.Shots[i].Box.Intersects(enemySpawner.Squares[j].box))
                        {
                            ship.Shots.RemoveAt(i);
                            enemySpawner.Squares.RemoveAt(j);
                            i--;
                            if(i <0) break;
                            j--;
                        }
                    }
                }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();

            ship.Draw(_spriteBatch);
            enemySpawner.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
