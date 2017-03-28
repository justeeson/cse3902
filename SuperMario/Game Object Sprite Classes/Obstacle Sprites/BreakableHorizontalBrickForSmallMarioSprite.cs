using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario;

class BreakableHorizontalBrickForSmallMarioSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        private int currentFrame;
        private int timer;
        private Boolean isNotDestroyed;

    public BreakableHorizontalBrickForSmallMarioSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            isNotDestroyed = true;
            timer = 0;
        }

        public void Update(GameTime GameTime)
        {
            timer++;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (isNotDestroyed)
            {
                int width = 32;
                int height = 32;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle;
            if (timer == 1) {
                timer = 0;
                 destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
            }
            else
            {
                 destinationRectangle = new Rectangle((int)location.X, (int)location.Y-20, width, height);

            }
            spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            
        }
    public Rectangle Area(Vector2 location)
    {
        if (isNotDestroyed)
        {
            int width = 32;
            int height = 32;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        return new Rectangle(0, 0, 0, 0);
    }
    public void CollisionSprite()
    {
        isNotDestroyed = false;
    }
}

