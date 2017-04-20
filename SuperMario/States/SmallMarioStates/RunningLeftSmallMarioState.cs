using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

using Microsoft.Xna.Framework.Input;
using SuperMario.MarioClass;

namespace SuperMario.Sprites
{
    public class RunningLeftSmallMarioState : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int startFrame;
        private const int totalFrames = 3;
        private int timeSinceLastFrame;
        private bool resetFrames;
        private const int millisecondsPerFrame = 150;
        private int flashStatus;
        private int nextFlashTime;

        public RunningLeftSmallMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 4;
            startFrame = currentFrame;
            timeSinceLastFrame = 0;
            resetFrames = false;
            flashStatus = 0;
            nextFlashTime = 0;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();
            GamePadState newGamepadState = GamePad.GetState(PlayerIndex.One);

            if (Mario.StarStatus)
            {
                nextFlashTime += gameTime.ElapsedGameTime.Milliseconds;
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
            if (newKeyboardState.IsKeyDown(Keys.Left) || newGamepadState.IsButtonDown(Buttons.LeftThumbstickLeft) || newKeyboardState.IsKeyDown(Keys.A))
            {
                if (Mario.JumpStatus && Mario.RunStatus)
                {
                    if (Mario.LocationX >= Game1Utility.MovingLeftOffset) 
                    {
                        Mario.LocationX -= 7;
                    }
                    currentFrame = 1;
                    resetFrames = true;
                }
                else if (Mario.JumpStatus)
                {
                    if (Mario.LocationX >= Game1Utility.MovingLeftOffset)
                    {
                        Mario.LocationX -= 3;
                    }
                    currentFrame = 1;
                    resetFrames = true;
                }
                else
                {
                    if(resetFrames)
                    {
                        currentFrame = 4;
                        resetFrames = false;
                    }
                    timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                    if (timeSinceLastFrame > millisecondsPerFrame)
                    {
                        timeSinceLastFrame -= millisecondsPerFrame;
                        currentFrame--;
                    }
                    if (currentFrame == startFrame - totalFrames)
                        currentFrame = startFrame;
                    if (Mario.LocationX >= Game1Utility.MovingLeftOffset)
                    {
                        if (Mario.RunStatus == true)
                        {
                            Mario.LocationX -= 4;
                        }
                        else
                            Mario.LocationX -= 2;
                    }
                }
            }
            else if (Mario.JumpStatus)
            {
                currentFrame = 1;
            }
            else
            {
                currentFrame = 4;
                mario.StateMachine.MarioMode = (int)MarioStateMachine.MarioModes.Small;
                mario.StateMachine.Orientation = (int)MarioStateMachine.Orientations.StandingLeft;
            }
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
