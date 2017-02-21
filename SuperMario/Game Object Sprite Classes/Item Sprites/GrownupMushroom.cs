
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
    class GrowupMushroomSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        public int currentFrame;
        public ISprite Sprite { get; set; }
        public Rectangle rectangle { get; set; }
        private SpriteBatch spriteBatch;

        public GrowupMushroomSprite(Texture2D texture, int rows, int columns, Vector2 location)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            Location = location;

        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 28;
            int height = 28;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            this.spriteBatch = spriteBatch;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(300, 160, width, height);
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
