using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;


    class BreakableHorizontalBrickSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        public int currentFrame;

        public BreakableHorizontalBrickSprite(Texture2D texture, int rows, int columns, Vector2 location)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            Location = location;
            currentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            int width = 36;
            int height = 34;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(500, 250, width, height);
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

    }
}

