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
    public class MovingDownLeftSmallMario : IMarioState
    {
        private Mario mario;
        private int currentFrame;
        private int flashStatus;

        public MovingDownLeftSmallMario(Mario mario)
        {
            this.mario = mario;
            currentFrame = 5;
            flashStatus = 0;            
        }

        public void Update(GameTime gameTime)
        {
            mario.StateMachine.MarioMode = (int)MarioStateMachine.MarioModes.Small;
            mario.StateMachine.Orientation = (int)MarioStateMachine.Orientations.StandingLeft;
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