using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Conways_game_of_life
{
    public class Conways
    {
        int[,] board;
        int tileWidth = 20;
        int cols;
        int rows;

        Texture2D pixel;
        bool start = false;
        MouseState mOldState;
        KeyboardState kOldState;

        float timer = 0.1f;
        float stepTime = 1f/10f;

        public Conways(Texture2D pixel)
        {
            rows = 480/tileWidth;
            cols = 800/tileWidth;
            board = new int[rows, cols];
            this.pixel = pixel;
        }

        public void Update()
        {
            if(start)
            {
                if(timer <= 0)
                {
                int[,] newBoard = new int[rows,cols];

                for (int i = 1; i < rows-1; i++)
                {
                    for (int j = 1; j < cols-1; j++)
                    {
                        int aliveNeighbours = 0;

                        for (int m = -1; m <= 1; m++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {

                                aliveNeighbours += board[i+m,j+l];
                            }
                        }

                        aliveNeighbours -= board[i,j];

                        if(board[i,j] == 1 && aliveNeighbours< 2)
                            newBoard[i,j] = 0;

                        else if(board[i,j] == 1 && aliveNeighbours == 4)
                            newBoard[i,j] = 0;
                        else if(board[i,j] == 0 && aliveNeighbours == 3)
                            newBoard[i,j] = 1;
                        else
                            newBoard[i,j] = board[i,j];
                    }
                }
                board = newBoard;
                timer += stepTime;
                }
                timer-= 1f/60f;
                start = !(Keyboard.GetState().IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space));
            }
            else
            {
                PaintBoard();

                if(Keyboard.GetState().IsKeyDown(Keys.C))
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            board[i,j] = 0;
                        }
                    }
            }

            kOldState = Keyboard.GetState();
            
        }

        private void PaintBoard()
        {
            MouseState mState = Mouse.GetState();
            Point mouseGridPos = (mState.Position.ToVector2()/tileWidth).ToPoint();
            if(mState.LeftButton == ButtonState.Pressed && mOldState.LeftButton == ButtonState.Released)
                if(!(mouseGridPos.X < 0 || mouseGridPos.X >= cols) && !(mouseGridPos.Y < 0 || mouseGridPos.Y >= rows))
                    board[mouseGridPos.Y,mouseGridPos.X] = board[mouseGridPos.Y,mouseGridPos.X]==1 ?0 :1;

            start = Keyboard.GetState().IsKeyDown(Keys.Space) && kOldState.IsKeyUp(Keys.Space);
            mOldState = mState;
        }


        public void Start()
        {
            start = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Color color = board[i,j] == 1 ? Color.Black : Color.White;
                    spriteBatch.Draw(pixel,new Rectangle(j*tileWidth,i*tileWidth,tileWidth,tileWidth),color);
                }
            }

            DrawGrid(spriteBatch);
        }

        void DrawGrid(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < cols; i++)
            {
                Rectangle rec = new Rectangle(i*tileWidth,0,1,480);
                spriteBatch.Draw(pixel,rec, Color.Gray);
            }
            for (int i = 0; i < rows; i++)
            {
                Rectangle rec = new Rectangle(0,i*tileWidth,800,1);
                spriteBatch.Draw(pixel,rec, Color.Gray);
            }
        }
    }
}