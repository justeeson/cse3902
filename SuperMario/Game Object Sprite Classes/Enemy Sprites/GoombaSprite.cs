using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class GoombaSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;

        private int goombaState;
        private enum goombaStates { Normal, Smashed, Dead }

        public GoombaSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 1;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 350;
        }

        public void Update(GameTime gameTime)
        {
            if (goombaState == (int)goombaStates.Normal)
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    currentFrame++;
                }

                if (currentFrame == 2)
                { currentFrame = 0; }
            }
            else if (goombaState == (int)goombaStates.Smashed)
            {
                currentFrame = 2;
            }

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 26;
            int height = 24;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(600, 160, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public Rectangle Area()
        {
            int width = 22;//Texture.Width / Columns;
            int height = 22;//Texture.Height / Rows;
            return new Rectangle(600 - 4, 160, width, height);
        }
        public void CollisionSprite()
        {
            if (goombaState == (int)goombaStates.Normal)
            {
                goombaState = (int)goombaStates.Smashed;
            }
        }
    }
}
