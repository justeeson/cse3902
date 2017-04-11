
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
    class FireworkSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int timer;
        private const int width = 300;
        private const int height = 250;
        private const int heightArea = 500;
        public FireworkSprite(Texture2D texture, int columns)
        {
            Texture = texture;
            Columns = columns;
            currentFrame = 0;
            timer = 0;
        }

        public void Update(GameTime gameTime)
        {
            timer++;
            if(timer%4 == 0)
            {
                currentFrame++;
                if (currentFrame > 4)
                {
                    currentFrame = 0;
                }
            }
           
           
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X+100, (int)location.Y-50, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void CollisionSprite()
        { }

        public Rectangle Area(Vector2 location)
        {
            int width = Texture.Width / Columns;
            int height = heightArea;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
    }
}
