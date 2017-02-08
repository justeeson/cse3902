
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
        public int currentFrame;

        public TurtleSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
        }

        public void Update(GameTime gameTime)
        {

        }
        public void ChangeDirection()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 16;
            int height = 24;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            // make change to xCoordinate so that Mario can  move left to right
            Rectangle destinationRectangle = new Rectangle(700, 160, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.CornflowerBlue);
            spriteBatch.End();
        }
    }
}
