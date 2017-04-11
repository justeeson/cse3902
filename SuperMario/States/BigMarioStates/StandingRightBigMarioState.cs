using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.MarioClass;
using SuperMario.Command;

namespace SuperMario.Sprites
{
    public class StandingRightBigMarioState : IMarioState
    {
        private int currentFrame;
        private Mario mario;
        private int flashStatus;
        private int nextFlashTime;

        public StandingRightBigMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 18;
            flashStatus = 0;
            nextFlashTime = 0;
            millisecondsPerFlash = 400;
        }

        public void Update(GameTime GameTime)
        {
            if (MarioStateMachine.Crouching == 1 && MarioStateMachine.GotoUnderground)
            {
                ICommand gotoUnderground = new MarioGoToUndergroundCommand(Game1.GetInstance);
                gotoUnderground.Execute();
            }
            if (Mario.StarStatus)
            {
                nextFlashTime += GameTime.ElapsedGameTime.Milliseconds;
                if (nextFlashTime > Game1Utility.MillisecondsPerFlash)
                {
                    nextFlashTime -= Game1Utility.MillisecondsPerFlash;
                    if (flashStatus == 0)
                    {
                        flashStatus = 1;
                    }

                    else if (flashStatus == 1)
                    {
                        flashStatus = 0;
                    }

                }
            }
            else
            {
                flashStatus = 0;
            }
            if (Mario.JumpStatus)
                currentFrame = 22;
            else
                currentFrame = 18;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = mario.Texture.Width / mario.Columns;
            int height = mario.Texture.Height / mario.Rows;
            int row = (int)((float)currentFrame / (float)mario.Columns);
            int column = currentFrame % mario.Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * 2, height * 2);

            spriteBatch.Begin(SpriteSortMode.Immediate, BlendState.AlphaBlend);
            if (flashStatus == 1)
            {
                spriteBatch.Draw(mario.Texture, destinationRectangle, sourceRectangle, Color.White * 0.5f);
            }
            else
            {
                spriteBatch.Draw(mario.Texture, destinationRectangle, sourceRectangle, Color.White);
            }
            spriteBatch.End();
        }
    }
}
