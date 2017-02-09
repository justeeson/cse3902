
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
    class QuestionMarkBrickSprite : ISprite
    {
        // Modify from http://rbwhitaker.wikidot.com/monogame-texture-atlases-2
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int count;
        private int timer;
        public QuestionMarkBrickSprite(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            count = 300;
        }

        public void Update(GameTime gameTime)
        {   
            timer += gameTime.ElapsedGameTime.Milliseconds;
            if (timer > count)
            {
                timer -= count;
                currentFrame++; ;
                if (currentFrame == 3)
                { currentFrame = 0; }
            }

        }
        public void ChangeDirection()
        {

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 52;
            int height = 34;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;

            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            // make change to xCoordinate so that Mario can  move left to right
            Rectangle destinationRectangle = new Rectangle(400, 250, width, height);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
