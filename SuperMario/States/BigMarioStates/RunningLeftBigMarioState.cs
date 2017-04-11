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
    public class RunningLeftBigMarioState : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int startFrame;
        private int totalFrames;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        private bool resetFrames;
        private int flashStatus;
        private int nextFlashTime;

        public RunningLeftBigMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 16;
            startFrame = currentFrame;
            totalFrames = 3;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 150;
            resetFrames = false;
            flashStatus = 0;
            nextFlashTime = 0;
        }

        public void Update(GameTime GameTime)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();
            GamePadState newGamepadState = GamePad.GetState(PlayerIndex.One);
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
            if (newKeyboardState.IsKeyDown(Keys.Left) || newGamepadState.IsButtonDown(Buttons.LeftThumbstickLeft) || newKeyboardState.IsKeyDown(Keys.A))
            {
                if (Mario.JumpStatus && Mario.RunStatus)
                {
                    currentFrame = 13;
                    if (Mario.LocationX >= Game1Utility.MovingLeftOffset)
                    {
                        Mario.LocationX -= 7;
                    }
                    resetFrames = true;
                }
                else if (Mario.JumpStatus)
                {
                    currentFrame = 13;
                    if (Mario.LocationX >= Game1Utility.MovingLeftOffset)
                    {
                        Mario.LocationX -= 3;
                    }
                    resetFrames = true;
                }
                else
                {
                    if(resetFrames)
                    {
                        currentFrame = 16;
                        resetFrames = false;
                    }
                    timeSinceLastFrame += GameTime.ElapsedGameTime.Milliseconds;
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
                            Mario.LocationX -= 7;
                        }
                        else
                            Mario.LocationX -= 3;
                    }
                }
            }
            else if (Mario.JumpStatus)
            {
                currentFrame = 13;
            }
            else
            {
                currentFrame = 16;
                mario.StateMachine.MarioMode = (int)MarioStateMachine.MarioModes.Big;
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
