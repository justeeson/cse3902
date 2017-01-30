using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Sprint0.Interfaces;

namespace Sprint0.Sprites
{
    class MovingNonAnimatedMarioSprite : ISprite
    {
        // Modify from http://rbwhitaker.wikidot.com/monogame-texture-atlases-2
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int width;
        private int height;
        int velocity = -3;
        int yCoordinate = 0;

        public MovingNonAnimatedMarioSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            width = Texture.Width / Columns;
            height = Texture.Height / Rows;
        }
        public void Update()
        {   //controll speed
            if (Game1.yPos >= Game1.yMax - Texture.Height / Rows)
            {
                velocity = -3;
            }
            else if (Game1.yPos <= 0)
            {
                velocity = 3;
            }
            Game1.yPos += velocity;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Rectangle sourceRectangle = new Rectangle(0, 0, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
