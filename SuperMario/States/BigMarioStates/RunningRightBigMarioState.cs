using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Sprites
{
    public class RunningRightBigMarioState : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int startFrame;
        private int totalFrames;
        private int timeDelay;

        public RunningRightBigMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 7;
            startFrame = currentFrame;
            totalFrames = 3;
            timeDelay = 10;
        }

        public void Update()
        {
            timeDelay--;
            if (timeDelay == 0)
            {
                currentFrame++;
                timeDelay = 10;
            }
            if (currentFrame == startFrame + totalFrames)
                currentFrame = startFrame;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = mario.Texture.Width / mario.Columns;
            int height = mario.Texture.Height / mario.Rows;
            int row = (int)((float)currentFrame / (float)mario.Columns);
            int column = currentFrame % mario.Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, 350, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(mario.Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }


    }
}
