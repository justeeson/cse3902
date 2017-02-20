using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.MarioClass;
using Microsoft.Xna.Framework.Input;

namespace SuperMario.Sprites
{
    public class JumpingRightBigMarioState : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int startFrame;
        private int totalFrames;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;

        public JumpingRightBigMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 19;
            startFrame = currentFrame;
            totalFrames = 3;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 150;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newState = Keyboard.GetState();
            if (newState.IsKeyDown(Keys.Up))
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    currentFrame++;
                }
                if (currentFrame == startFrame + totalFrames)
                    currentFrame = startFrame;
                if (Mario.locationY == 0)
                {
                    Mario.locationY = 400;
                }
                else
                {
                    Mario.locationY--;
                }
            }
            else
            {
                currentFrame = 18;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = mario.Texture.Width / mario.Columns;
            int height = mario.Texture.Height / mario.Rows;
            int row = (int)((float)currentFrame / (float)mario.Columns);
            int column = currentFrame % mario.Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(mario.Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}