﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    class SolidBrickWithCrewsSprite3 : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;

        public SolidBrickWithCrewsSprite3(Texture2D texture, int rows, int columns)
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
            int width = 32;
            int height = 32;
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
            int width = Texture.Width / Columns;
            int height = Texture.Height / Rows;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        public void CollisionSprite()
        {

        }
    }
}
