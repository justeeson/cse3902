using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.Sprites;


namespace SuperMario.MarioClass
{
    public class Mario : IMario
    {
        public IMarioState state { get; set; }
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int totalFrames;
        enum Orientations
            { CrouchingRight, CrouchingLeft,
            JumpingRight, JumpingLeft,
            RunningRight, RunningLeft,
            StandingRight, StandingLeft,
            Dead };
        int orientation;

        public Mario(Texture2D texture, int rows, int columns)
        {
            state = new StandingRightSmallMarioState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
            orientation = (int)Orientations.StandingRight;
        }

        public void LookLeft()
        {
            //if already looking left then start running else look left
            if (orientation == (int)Orientations.StandingLeft)
            {
                state = new RunningLeftSmallMarioState(this);
                orientation = (int)Orientations.RunningLeft;
            }
            else
            {
                state = new StandingLeftSmallMarioState(this);
                orientation = (int)Orientations.StandingLeft;
            }
        }

        public void LookRight()
        {
            //if already looking right then start running else look right
            if (orientation == (int)Orientations.StandingRight)
            {
                state = new RunningRightSmallMarioState(this);
                orientation = (int)Orientations.RunningRight;
            }
            else
            {
                state = new StandingRightSmallMarioState(this);
                orientation = (int)Orientations.StandingRight;
            }
        }

        public void Jump()
        {
            state = new JumpingRightSmallMarioState(this);
        }
        public void Crouch()
        {
            state = new CrouchingRightSmallMarioState(this);

        }
        public void Big()
        {
            // Need a new state for mario is Big Mario
            state = new StandingRightSmallMarioState(this);

        }
        public void Small()
        {
            // Need a new state for mario is Small
            state = new StandingRightSmallMarioState(this);

        }
        public void Dead()
        {
            // Need a new state for mario is Dead
            state = new StandingRightSmallMarioState(this);

        }
        public void Fire()
        {
            // Need a new state for mario is Fire
            state = new StandingRightSmallMarioState(this);

        }
        public void Update()
        {
            state.Update();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, location);
        }
    }
}
