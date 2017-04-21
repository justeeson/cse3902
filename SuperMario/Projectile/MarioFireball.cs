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
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

namespace SuperMario
{
    public class MarioFireball : IProjectile
    {
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public float LocationX { get; set; }
        public float LocationY { get; set; }
        private int currentFrame;
        private int mode;
        public Texture2D Texture { get; set; }
        public bool Fire
        { get; set; }
        private int startingLocation;
        private int movementTimer;
        private SoundEffect soundEffect;
        private int xOffset;
        private int marioOrientation;
        private int yVelocity;

        public MarioFireball()
        {
            currentFrame = 0;
            Fire = false;
            movementTimer = 0;
            yVelocity = 0;
            startingLocation = 0;
            xOffset = 0;
        }


        public void Update(GameTime gameTime)
        {
            if (Math.Abs(LocationX - startingLocation) > Game1Utility.FireballMaxDistance)
            {
                Fire = false;
            }

            if (Fire)
            {
                movementTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (movementTimer > 50)
                {
                    if (marioOrientation == (int)MarioStateMachine.Orientations.StandingRight || marioOrientation == (int)MarioStateMachine.Orientations.RunningRight
                        || marioOrientation == (int)MarioStateMachine.Orientations.CrouchingRight)
                    {
                        LocationX += 6;                       
                    }
                    else if (marioOrientation == (int)MarioStateMachine.Orientations.StandingLeft || marioOrientation == (int)MarioStateMachine.Orientations.RunningLeft
                        || marioOrientation == (int)MarioStateMachine.Orientations.CrouchingLeft)
                    {
                        LocationX -= 6;                       
                    }
                    if (movementTimer > 100)
                    {
                        LocationY = LocationY + yVelocity;
                    }
                }
            }
        }

        public void KillFireball()
        {
            Fire = false;
        }
        public void MarioFire(int orientation, int marioMode, int LocationX, int LocationY)
        {

            soundEffect.Play();
            this.LocationX = LocationX;
            startingLocation = LocationX;
            this.LocationY = LocationY + 35;
            yVelocity = 3;
            marioOrientation = orientation;
            mode = marioMode;
            if (mode == (int)MarioStateMachine.MarioModes.Fire)
                Fire = true;
        }
        public void Draw(SpriteBatch myspriteBatch)
        {
            if(Fire)
                {
                int width = 27;
                int height = 27;
                int row = currentFrame;
                int column = currentFrame % 1;
                if(marioOrientation == (int)MarioStateMachine.Orientations.StandingRight || marioOrientation == (int)MarioStateMachine.Orientations.RunningRight
                        || marioOrientation == (int)MarioStateMachine.Orientations.CrouchingRight)
                {
                    xOffset = 35;
                }
                else if (marioOrientation == (int)MarioStateMachine.Orientations.StandingLeft || marioOrientation == (int)MarioStateMachine.Orientations.RunningLeft
                        || marioOrientation == (int)MarioStateMachine.Orientations.CrouchingLeft)
                {
                    xOffset = 10;
                }
                Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
                Rectangle destinationRectangle = new Rectangle((int)LocationX - Camera.CameraPositionX + xOffset, (int)LocationY, width / 2, height / 2);
                myspriteBatch.Begin();
                myspriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
                myspriteBatch.End();
            }
        }

        public Rectangle Area()
        {
            if (!Fire)
            {
                return new Rectangle();

            }
            int width = 15;
            int height = 15;
            return new Rectangle((int)LocationX, (int)LocationY, width/2, height/2);
        }
        public void LoadContent(ContentManager Content)
        {
            soundEffect = Content.Load<SoundEffect>("fireballSoundEffect");
            Texture = Content.Load<Texture2D>("fireball");
        }
    }
}
