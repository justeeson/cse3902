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
    public class Mario : ISprite
    {
        public IMarioState state;
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int totalFrames;
        //private int timeDelay = 5;

        public Mario(Texture2D texture, int rows, int columns)
        {
            state = new SmallMarioStandingRightState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
        }

        public void Update()
        {
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }

        public void SetState(IMarioState marioState)
        {
            state = marioState;
        }

        //not done yet
        private bool isFacingLeft(IMarioState marioState)
        {
            System.Type[] leftType = new System.Type[4];
            leftType[0] = new SmallMarioCrouchingLeftState(this).GetType();
            leftType[1] = new SmallMarioJumpingLeftState(this).GetType();
            leftType[2] = new SmallMarioRunningLeftState(this).GetType();
            leftType[3] = new SmallMarioStandingLeftState(this).GetType();

            for (int i = 0; i < leftType.Length; i++)
            {
                if (leftType[i].IsInstanceOfType(marioState.GetType()))
                {
                    return true;
                }
            }

            return false;
        }

        //commands
        public void LookRight()
        {
            if (state.GetType() == new SmallMarioStandingRightState(this).GetType())
            {
                SetState(new SmallMarioRunningRightState(this));
            }
            else
            {
                SetState(new SmallMarioStandingRightState(this));
            }
        }
        //rest of command methods w/ logic to be added
    }
}
