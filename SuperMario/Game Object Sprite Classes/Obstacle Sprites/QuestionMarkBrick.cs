using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework.Content;

namespace SuperMario
{
    class QuestionMarkBrickSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }

        private int currentFrame;
        private int timeSinceLastFrame;
        private int millisecondsPerFrame;
        private bool hasBeenUsed;

        public QuestionMarkBrickSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            timeSinceLastFrame = 0;
            millisecondsPerFrame = 350;
            hasBeenUsed = false;
        }

        public void Update(GameTime gameTime)
        {
            if(!hasBeenUsed)
            {
                timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceLastFrame > millisecondsPerFrame)
                {
                    timeSinceLastFrame -= millisecondsPerFrame;
                    currentFrame++;
                }

                if (currentFrame == 3)
                { currentFrame = 0; }
            }
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 52;
            int height = 34;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(400, 250, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
        public Rectangle Area()
        {
            int width  = 30; //Texture.Width / Columns;
            int height =30;// Texture.Height / Rows;
            return new Rectangle(400, 250, width, height);
        }
        public void CollisionSprite()
        {
            Texture = SpriteFactory.solidBrickWithCrewsTexture;
            hasBeenUsed = true;
            currentFrame = 0;
        }
    }
}
