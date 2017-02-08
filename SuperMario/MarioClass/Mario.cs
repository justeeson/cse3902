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
        int delay = 50;

        enum Orientations
            { CrouchingRight, CrouchingLeft,
            JumpingRight, JumpingLeft,
            RunningRight, RunningLeft,
            StandingRight, StandingLeft,
            Dead};
        enum MarioModes
        { Big, Fire, Small};

        int orientation, marioMode;
        
        public Mario(Texture2D texture, int rows, int columns)
        {
            state = new StandingRightSmallMarioState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
            orientation = (int)Orientations.StandingRight;
            marioMode = (int)MarioModes.Small;
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
            if (orientation == (int)Orientations.CrouchingRight)
            {
                state = new StandingRightSmallMarioState(this);
                orientation = (int)Orientations.StandingRight;
            }
            else if (orientation == (int)Orientations.CrouchingLeft)
            {
                state = new StandingLeftSmallMarioState(this);
                orientation = (int)Orientations.StandingLeft;
            }
            else if (orientation == (int)Orientations.StandingRight || orientation == (int)Orientations.RunningRight)
            {
                state = new JumpingRightSmallMarioState(this);
                orientation = (int)Orientations.JumpingRight;
            }
            else if (orientation == (int)Orientations.StandingLeft || orientation == (int)Orientations.RunningLeft)
            {
                state = new JumpingLeftSmallMarioState(this);
                orientation = (int)Orientations.JumpingLeft;
            }
            else
            {
                //do nothing
            }
            System.Threading.Thread.Sleep(delay);
        }
        public void Crouch()
        {
            if (orientation == (int)Orientations.JumpingRight)
            {
                state = new StandingRightSmallMarioState(this);
                orientation = (int)Orientations.StandingRight;
            }
            else if (orientation == (int)Orientations.JumpingLeft)
            {
                state = new StandingLeftSmallMarioState(this);
                orientation = (int)Orientations.StandingLeft;
            }
            else if (orientation == (int)Orientations.StandingRight || orientation == (int)Orientations.RunningRight)
            {
                state = new CrouchingRightSmallMarioState(this);
                orientation = (int)Orientations.CrouchingRight;
            }
            else if (orientation == (int)Orientations.StandingLeft || orientation == (int)Orientations.RunningLeft)
            {
                state = new CrouchingLeftSmallMarioState(this);
                orientation = (int)Orientations.CrouchingLeft;
            }
            else
            {
                //do nothing
            }
            System.Threading.Thread.Sleep(delay);
        }
        public void Big()
        {
            
        }

        public void Small()
        {
            if (marioMode != (int)MarioModes.Small)
            {
                marioMode = (int)MarioModes.Small;
                switch (orientation)
                {
                    case (int)Orientations.CrouchingLeft:
                        state = new CrouchingLeftSmallMarioState(this);
                        break;
                    case (int)Orientations.CrouchingRight:
                        state = new CrouchingRightSmallMarioState(this);
                        break;
                    case (int)Orientations.JumpingLeft:
                        state = new JumpingLeftSmallMarioState(this);
                        break;
                    case (int)Orientations.JumpingRight:
                        state = new JumpingRightSmallMarioState(this);
                        break;
                    case (int)Orientations.RunningLeft:
                        state = new RunningLeftSmallMarioState(this);
                        break;
                    case (int)Orientations.RunningRight:
                        state = new RunningRightSmallMarioState(this);
                        break;
                    case (int)Orientations.StandingLeft:
                        state = new StandingLeftSmallMarioState(this);
                        break;
                    case (int)Orientations.StandingRight:
                        state = new StandingRightSmallMarioState(this);
                        break;
                    default:
                        state = new StandingRightSmallMarioState(this);
                        break;
                }
            }
        }

        public void Fire()
        {
            // Need a new state for mario is Fire
            state = new StandingRightSmallMarioState(this);

        }

        public void Dead()
        {
            // Need a new state for mario is Dead
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
