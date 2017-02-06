using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario.Sprites
{
    class Mario : ISprite
    {
        public IMarioState state;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int totalFrames;
        //private int timeDelay = 5;

        public Mario(Texture2D texture, int rows, int columns)
        {
            state = new StandingRightSmallMarioState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
        }

        public void ChangeDirection()
        {
            state.ChangeDirection();
        }

        public void Grow()
        {
            state.Grow();
        }

        public void Update()
        {   //Control speed of animation

            /*
            timeDelay--;
            if (timeDelay == 0)
            {
                currentFrame++;
                timeDelay = 4;
            }
            if (currentFrame == totalFrames)
                currentFrame = 0;
                */
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
    }
}
