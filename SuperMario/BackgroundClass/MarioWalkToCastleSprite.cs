
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
        private int startFrame;
        private int totalFrames;
        private int currentFrame;
        private int yCoordinate;
        private int count;
        private int distance;
        private int timer;
        private int xCoordinate;    
        private bool reachedCastle;
        public MarioWalkToCastleSprite(Texture2D texture, int columns, string marioStatus)
        {
            Texture = texture;
            Columns = columns;
            reachedCastle = false;
            if (marioStatus.Equals("small"))
            { currentFrame = 7; }
            else if (marioStatus.Equals("big"))
            { currentFrame = 19; }
            else if (marioStatus.Equals("fire"))
            { currentFrame = 31; }
            startFrame = currentFrame;
            totalFrames = 3;
            count = 150;
            yCoordinate = 320;
            xCoordinate = 150;
            distance = xCoordinate + 170;
        }

        public void Update(GameTime gameTime)
        {
            timer+= gameTime.ElapsedGameTime.Milliseconds;
            if (timer > count)
            {
                timer -= count;
                currentFrame++;
                if (currentFrame == (startFrame + totalFrames))
                { currentFrame = startFrame; }
            }
            if(yCoordinate < 355)
            {
                yCoordinate++;
            }
            if (xCoordinate < distance)
            {
                xCoordinate++;
            }
            else
            {
                reachedCastle = true;
            }
            
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Columns = 12;
            int width = 28;
            int height = 36;
            int row = (int)((float)currentFrame / (float)Columns);
            int column = currentFrame % Columns;                
            Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
            Rectangle destinationRectangle = new Rectangle(xCoordinate+200, yCoordinate, width*2, height*2);
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


        public MarioStateMachine StateMachine
        { get;
        }
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
