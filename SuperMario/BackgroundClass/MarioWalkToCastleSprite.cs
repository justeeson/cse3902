
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario
{
    class MarioWalkToCastleSprite : IMario
    {
        public Texture2D Texture { get; set; }
        public int Columns { get; set; }
        public MarioStateMachine StateMachine
        {
            get;
        }
        private int currentFrame;
        private int count;
        private int timer;
        int xCoordinate;
        private string currentMarioStatus;
        private bool reachedCastle;
        public MarioWalkToCastleSprite(Texture2D texture, int columns, string marioStatus)
        {
            Texture = texture;
            Columns = columns;
            reachedCastle = false;
            StateMachine = new MarioStateMachine(this);
            currentMarioStatus = marioStatus;
            currentFrame = 10;
            count = 300;
            xCoordinate = 150;
        }

        public void Update(GameTime gameTime)
        {
            timer++;
            if (timer > count)
            {
                timer -= count;
                currentFrame++;
                if (currentFrame == 15)
                { currentFrame = 10; }
            }
            if (xCoordinate < 320)
            {
                xCoordinate += 1;
            }
            else
            {
                reachedCastle = true;
            }
            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int width = 0;
            int height =0;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;
            if (currentMarioStatus.Equals("small"))
            {
                width = 20;
                height = 40;
            }
            else if (currentMarioStatus.Equals("big"))
            {

            }
            else
            {

            }                    
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(xCoordinate+200, 320, width, height);
            if (reachedCastle)
            {
                sourceRectangle = new Rectangle();
                destinationRectangle = new Rectangle();
            }
            spriteBatch.Begin();
            spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }

        public IMarioState State { get; set; }


        
        public Rectangle Area()
        {
            return new Rectangle();
        }

        public bool isDead()
        {
            return true;
        }

        public void Jump()
        {
        }

        public void LookLeft()
        {
        }

        public void LookRight()
        {
        }

        public void LookDown()
        {
        }

        public void MarioBigState()
        {
        }

        public void MarioSmallState()
        {
        }

        public void Dead()
        {
        }

        public void MarioFireState()
        {
        }

        public void Reset()
        {
        }

        public void ResetVelocity()
        {
        }

        public void ThrowFire()
        {
        }

        public void Run()
        {
        }
    }
}
