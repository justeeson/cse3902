
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class KoopaMoveRightSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;

        private int turtleState;
        private enum turtleStates { Normal, InShell, Dead}

        public KoopaMoveRightSprite(Texture2D texture, int columns)
        {
            Texture = texture;
            Columns = columns;
            currentFrame = 0;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 400;
            turtleState = (int)turtleStates.Normal;
        }

        public void Update(GameTime GameTime)
        {
            if (turtleState == (int)turtleStates.Normal)
            {
                timeSinceLastFrame += GameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    currentFrame++;
                }

                if (currentFrame == 2)
                { currentFrame = 0; }
            }
            else if (turtleState == (int)turtleStates.InShell)
            {
                currentFrame = 2;
            }
            else
            {
                currentFrame = 3;
            }

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 27;
            int height = 24;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public Rectangle Area(Vector2 location)
        {
            if (turtleState == (int)turtleStates.Dead)
            {
                return new Rectangle(0,0,0,0);
            }
            int width = 16;
            int height = 24;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        public void CollisionSprite()
        {
            if (turtleState == (int)turtleStates.Normal)
            {
                turtleState = (int)turtleStates.InShell;
            }
            else if (turtleState == (int)turtleStates.InShell)
            {
                turtleState = (int)turtleStates.Dead;
            }
        }
    }
}
