
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
    class TurtleSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        private int currentFrame;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        public TurtleSprite(Texture2D texture, int rows, int columns, Vector2 location)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Location = location;
            currentFrame = 1;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 400;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame++;
            }

            if (currentFrame == 4)
            { currentFrame = 1; }

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 17;
            int height = 24;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(700, 160, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public Rectangle Area()
        {
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            return new Rectangle((int)Location.X, (int)Location.Y, width, height);
        }
        void CollisionSprite()
        {

        }
    }
}
