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
    class SolidBrickWithCrewsSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        private int currentFrame;
        private int locationX;
        private int locationY;

        public SolidBrickWithCrewsSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
        }

        public void Update(GameTime GameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 36;
            int height = 34;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            locationX = (int)location.X;
            locationY = (int)location.Y;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(locationX, locationY, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public Rectangle Area()
        {
            int width = 30;//Texture.Width / Columns;
            int height = 30;// Texture.Height / Rows;
            return new Rectangle(locationX - 2, locationY, width, height);
        }
        public void CollisionSprite()
        {

        }
    }
}
