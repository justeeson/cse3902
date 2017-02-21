
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
    class StarSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        private int currentFrame;
        private int count;
        private int timer;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        public ISprite Sprite { get; set; }
        public Rectangle rectangle { get; set; }
        private SpriteBatch spriteBatch;

        public StarSprite(Texture2D texture, int rows, int columns, Vector2 location)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 1;
            count = 300;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 250;
            Location = location;

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
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 28;
            int height = 27;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            this.spriteBatch = spriteBatch;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(500, 160, width, height);
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
        public void CollisionSprite()
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, 0, 0);
            Rectangle destinationRectangle = new Rectangle(0, 0, 0, 0);

            this.spriteBatch.Begin();
            this.spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            this.spriteBatch.End();

        }
    }
}
