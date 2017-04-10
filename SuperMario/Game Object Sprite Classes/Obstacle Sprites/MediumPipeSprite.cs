﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class MediumPipeSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Columns { get; set; }
        private int currentFrame;

        public MediumPipeSprite(Texture2D texture, int columns)
        {
            Texture = texture;
            Columns = columns;
            currentFrame = 0;
        }

        public void Update(GameTime GameTime)
        {

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 40;
            int height = 73;
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
            int width = 40; //Texture.Width / Columns;
            int height = 73;//Texture.Height / Rows;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        public void CollisionSprite()
        {

        }
    }
}
