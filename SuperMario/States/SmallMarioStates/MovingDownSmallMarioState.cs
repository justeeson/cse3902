﻿using System;
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
    public class MovingUpRightSmallMario : IMarioState
    {
        private Mario mario;
        private int currentFrame;

        public MovingUpRightSmallMario(Mario mario)
        {
            this.mario = mario;
            currentFrame = 10;
        }

        public void Update(GameTime gameTime)
        {
            KeyboardState newKeyboardState = Keyboard.GetState();
            GamePadState newGamepadState = GamePad.GetState(PlayerIndex.One);
            if (newKeyboardState.IsKeyDown(Keys.Up) || newGamepadState.IsButtonDown(Buttons.LeftThumbstickUp))
            {
                currentFrame = 10;
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
                currentFrame = 6;
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