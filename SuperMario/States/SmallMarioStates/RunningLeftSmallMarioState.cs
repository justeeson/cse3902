using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

using Microsoft.Xna.Framework.Input;

namespace SuperMario.Sprites
{
    public class RunningLeftSmallMarioState : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int startFrame;
        private int totalFrames;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        private int flashStatus;
        private int nextFlashTime;
        private int millisecondsPerFlash;

        public RunningLeftSmallMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 4;
            startFrame = currentFrame;
            totalFrames = 3;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 150;
            flashStatus = 0;
            nextFlashTime = 0;
            millisecondsPerFlash = 400;
        }

        public void Update(GameTime GameTime)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();
            GamePadState newGamepadState = GamePad.GetState(PlayerIndex.One);

            if (Mario.StarStatus)
            {
                nextFlashTime += GameTime.ElapsedGameTime.Milliseconds;
                if (nextFlashTime > millisecondsPerFlash)
                {
                    nextFlashTime -= millisecondsPerFlash;
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
                if (Mario.JumpStatus)
                {
                    if (Mario.LocationX <= 0)
                    {
                        Mario.LocationX = 800;
                    }
                    else
                    {
                        Mario.LocationX -= 2;
                    }
                    currentFrame = 1;
                }
                else
                {
                    timeSinceLastFrame += GameTime.ElapsedGameTime.Milliseconds;
                    if (timeSinceLastFrame > millisecondsPerFrame)
                    {
                        timeSinceLastFrame -= millisecondsPerFrame;
                        currentFrame--;
                    }
                    if (currentFrame == startFrame - totalFrames)
                        currentFrame = startFrame;
                    if (Mario.LocationX == 0)
                    {
                        Mario.LocationX = 800;
                    }
                    else
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
                Mario.MarioMode = (int)Mario.MarioModes.Small;
                Mario.Orientation = (int)Mario.Orientations.StandingLeft;
                currentFrame = 5;
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
