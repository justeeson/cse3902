using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;


    class BreakableHorizontalBrickSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public Vector2 Location { get; set; }
        private int currentFrame;

        private Boolean isNotDestroyed;

    public BreakableHorizontalBrickSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            isNotDestroyed = true;
        }

        public void Update(GameTime GameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            if (isNotDestroyed)
            {
                int width = 31;
                int height = 31;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;

                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
            
        }
    public Rectangle Area(Vector2 location)
    {
        if (isNotDestroyed)
        {
            int width = 31;//Texture.Width / Columns;
            int height = 31;//Texture.Height / Rows;
            return new Rectangle((int)location.X, (int)location.Y, width, height);
        }
        return new Rectangle(0, 0, 0, 0);
    }
    public void CollisionSprite()
    {
        isNotDestroyed = false;
    }
}

