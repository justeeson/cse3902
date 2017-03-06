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
    class HiddenBrickSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        private int currentFrame;

        private Boolean isHidden = true;

        public HiddenBrickSprite(Texture2D texture, int rows, int columns)
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
            if (isHidden == false)
            {
                int width = 36;
                int height = 34;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle(100, 250, width, height);
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }
        public Rectangle Area()
        {
            int width = 28;//Texture.Width / Columns;
            int height = 26;//Texture.Height / Rows;
            return new Rectangle(100, 250, width, height);
        }
        public void CollisionSprite()
        {
            isHidden = false;
        }
    }
}
