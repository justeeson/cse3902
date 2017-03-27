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
using SuperMario.MarioClass;

namespace SuperMario
{
    public class MarioFireball : IProjectile
    {
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        private int currentFrame;
        public Texture2D Texture { get; set; }
        public int LocationX;
        public int LocationY;
        const int MAX_DISTANCE = 500;
        public Boolean fire;
        private int bounce;
        private int startingLocation;
        private SpriteBatch spriteBatch;
        private int movementTimer;
        private int marioOrientation;
        private int yVelocity, yAcceleration;

        public MarioFireball()
        {
            currentFrame = 0;
            fire = false;
            movementTimer = 0;
            yVelocity = 0;
            startingLocation = 0;
            bounce = 50;
            yAcceleration = -1;
        }


        public void Update(GameTime GameTime)
        {

            
            if (Math.Abs(LocationX - startingLocation) > MAX_DISTANCE)
            {
                fire = false;
            }
            
            if (fire == true)
            {
                movementTimer += GameTime.ElapsedGameTime.Milliseconds;
                if (movementTimer > 50)
                {
                    if (marioOrientation == (int)MarioStateMachine.Orientations.StandingRight || marioOrientation == (int)MarioStateMachine.Orientations.RunningRight
                        || marioOrientation == (int)MarioStateMachine.Orientations.CrouchingRight)
                            LocationX += 6;
                    else if (marioOrientation == (int)MarioStateMachine.Orientations.StandingLeft || marioOrientation == (int)MarioStateMachine.Orientations.RunningLeft
                        || marioOrientation == (int)MarioStateMachine.Orientations.CrouchingLeft)
                             LocationX -= 6;
                }
                if (movementTimer > 100)
                {
                    LocationY = LocationY + yVelocity;
                }
            }
        }

        public void Fire(int orientation, int LocationX, int LocationY)
        {
            this.LocationX = LocationX;
            startingLocation = LocationX;
            this.LocationY = LocationY;
            yVelocity = 3;
            marioOrientation = orientation;
            fire = true;
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(fire == true)
                {
                int width = Texture.Width;
                int height = Texture.Height;
                int row = (int)((float)currentFrame / (float)1);
                int column = currentFrame % 1;
                this.spriteBatch = spriteBatch;
                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle(LocationX - Camera.cameraPositionX, LocationY, width / 2, height / 2);
                spriteBatch.Begin();
                spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                spriteBatch.End();
            }
        }

        public void LoadContent(ContentManager Content)
        {
            Texture = Content.Load<Texture2D>("fireball");
        }
    }
}
