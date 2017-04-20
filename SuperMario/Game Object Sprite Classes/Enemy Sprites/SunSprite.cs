using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class SunSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Columns { get; set; }
        private int currentFrame;

        private const int width =85;
        private const int height = 85;
        private int counter;
        private const int maxCounter = 50;
        public SunSprite(Texture2D texture, int columns)
        {
            Texture = texture;
            Columns = columns;
            currentFrame = 0;
            counter = 0;
        }

        public void Update(GameTime GameTime)
        {
            counter++;
            if(counter == maxCounter)
            {
                currentFrame++;
               
            }
            if(counter == maxCounter * 2)
            {
                counter = 0;
                currentFrame = 0;
            }

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
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
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        public void CollisionSprite()
        {
           
        }
    }
}
