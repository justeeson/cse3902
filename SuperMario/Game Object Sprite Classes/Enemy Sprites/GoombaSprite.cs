using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class GoombaSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        private int goombaState;

        private const int width = 26;
        private const int height = 24;
        private const int widthArea = 24;
        private const int heightArea = 22;
        private enum goombaStates { Normal, Smashed, Dead }

        public GoombaSprite(Texture2D texture, int columns)
        {
            Texture = texture;
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
            if (goombaState == (int)goombaStates.Dead)
            {
                return new Rectangle(0, 0, 0, 0);
            }
            return new Rectangle((int)location.X, (int)location.Y, width, height-1);
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
