
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
    class FlagPoleToUsedSprite : ISprite
    {
        public Texture2D Texture { get; set; }
        public int Columns { get; set; }
        private int currentFrame;
        private int counter;
        private int speed;
        private int soundDelay;
        private int width;
        private const int height = 350;
        private const int widthArea = 68;
        private const int heightArea = 350;
        public FlagPoleToUsedSprite(Texture2D texture, int columns)
        {
            counter = 0;
            speed = 16;
            width = 58;
            Texture = texture;
            Columns = columns;
            currentFrame = 1;
            soundDelay = 0;
            Game1Utility.FireworksSoundEffect.Play();
        }

        public void Update(GameTime gameTime)
        {
            soundDelay += gameTime.ElapsedGameTime.Milliseconds;
            if (soundDelay > 1000)
            {
                soundDelay -= 1000;
                Game1Utility.FireworksSoundEffect.Play();
            }
            counter++;
            if (counter % speed == 0)
            {
                currentFrame++;
                if (currentFrame >5 )
                {
                    currentFrame = 5;
                }
            }


        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            int xpostion = 0;
            switch (currentFrame)
            {              
                case 1:
                    xpostion = 181;
                    location = new Vector2((int)location.X +10, (int)location.Y);
                    break;
                case 2:
                    xpostion = 123;
                    location = new Vector2((int)location.X-2, (int)location.Y);
                    break;
                case 3:
                    xpostion = 78;
                    location = new Vector2((int)location.X, (int)location.Y);
                    break;
                case 4:
                    xpostion = 31;
                    break;
                case 5:
                    xpostion = -10;
                    width = 53;
                    location = new Vector2((int)location.X-1, (int)location.Y);
                    break;

            }
            Rectangle sourceRectangle = new Rectangle(xpostion, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, 58, 350);
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public void CollisionSprite()
        { }

        public Rectangle Area(Vector2 location)
        {
            return new Rectangle((int)location.X, (int)location.Y, widthArea, heightArea);
        }
    }
}
