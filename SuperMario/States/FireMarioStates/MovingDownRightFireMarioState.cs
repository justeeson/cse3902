﻿using System;
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
    class MovingDownRightFireMarioState : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int flashStatus;
        private int nextFlashTime;
        private int millisecondsPerFlash;

        public MovingDownRightFireMarioState(Mario mario)
        {
            this.mario = mario;
            currentFrame = 35;
            flashStatus = 0;
            nextFlashTime = 0;
            millisecondsPerFlash = 400;
        }

        public void Update(GameTime gameTime)
        {
           KeyboardState newKeyboardState = Keyboard.GetState();
            GamePadState newGamepadState = GamePad.GetState(PlayerIndex.One);
            if (Mario.starStatus || Mario.invulnStatus)
            {
                nextFlashTime += gameTime.ElapsedGameTime.Milliseconds;
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
            if (newKeyboardState.IsKeyDown(Keys.Down) || newGamepadState.IsButtonDown(Buttons.LeftThumbstickDown) || newKeyboardState.IsKeyDown(Keys.S))
            {
                currentFrame = 35;
                if (Mario.locationY == 400)
                {
                    Mario.locationY = 0;
                }
                else
                {
                    Mario.locationY++;
                }
            }
            else
            {
                Mario.marioMode = (int)Mario.MarioModes.Fire;
                Mario.orientation = (int)Mario.Orientations.StandingRight;
                currentFrame = 30;
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