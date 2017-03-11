using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperMario;
using SuperMario.Interfaces;
using System.Collections;
using Microsoft.Xna.Framework;

namespace SuperMario
{
    public class MarioFireball : IProjectile
    {
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        private int currentFrame;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public static int LocationX;
        public static int LocationY;
        public int Columns { get; set; }
        private static Boolean fire;
        private int bounce;
        private SpriteBatch spriteBatch;
        private int movementTimer;
        private static int marioOrientation;
        private static int yVelocity, yAcceleration;
        public MarioFireball(Texture2D texture, int rows, int columns)
        {
            Texture = texture;
            Rows = rows;
            Columns = columns;
            currentFrame = 0;
            fire = false;
            movementTimer = 0;
            yVelocity = 0;
            bounce = 50;
            yAcceleration = -1;
        }

        public void Update(GameTime GameTime)
        {
            if(fire == true)
            {
                movementTimer += GameTime.ElapsedGameTime.Milliseconds;
                if (movementTimer > 50)
                {
                    if (marioOrientation == (int)Mario.Orientations.StandingRight)
                        LocationX+=5;
                    else if (marioOrientation == (int)Mario.Orientations.StandingLeft)
                        LocationX-=5;
                }
            }
            if (movementTimer > 100)
            {
                LocationY = LocationY - yVelocity;
                yVelocity = yVelocity + yAcceleration;
                if (LocationY >= 400)
                {
                    LocationY = 400 - bounce;
                    yVelocity = 15;
                    bounce = bounce - 10;
                    if(bounce == 0)
                    {
                        fire = false;
                    }
                }
            }
        }

        public static void Fire(int orientation)
        {
            yVelocity = 15;
            marioOrientation = orientation;
            fire = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if((Mario.MarioMode == (int)Mario.MarioModes.Fire) && (fire == true))
                {
                int width = Texture.Width;
                int height = Texture.Height;
                int row = (int)((float)currentFrame / (float)Columns);
                int column = currentFrame % Columns;
                this.spriteBatch = spriteBatch;
                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle(LocationX, LocationY, width / 2, height / 2);
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }
    }
}
