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
        int delay = 100;

        enum Orientations
            { CrouchingRight, CrouchingLeft,
            JumpingRight, JumpingLeft,
            RunningRight, RunningLeft,
            StandingRight, StandingLeft,
            Dead};

        enum MarioModes
        { Big, Fire, Small};

        private int orientation, marioMode;
        IMarioState[,] StateArray;

        public Mario(Texture2D texture, int rows, int columns)
        {
            state = new StandingRightSmallMarioState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            totalFrames = Rows * Columns;
            orientation = (int)Orientations.StandingRight;
            marioMode = (int)MarioModes.Small;

            //makes state assignments easy to manage
            StateArray = new IMarioState[3, 9] { 
                {new CrouchingRightBigMarioState(this), new CrouchingLeftBigMarioState(this), new JumpingRightBigMarioState(this),
                    new JumpingLeftBigMarioState(this), new RunningRightBigMarioState(this), new RunningLeftBigMarioState(this),
                    new StandingRightBigMarioState(this), new StandingLeftBigMarioState(this), new DeadBigMarioState(this)}, 

                {new CrouchingRightFireMarioState(this), new CrouchingLeftFireMarioState(this), new JumpingRightFireMarioState(this),
                    new JumpingLeftFireMarioState(this), new RunningRightFireMarioState(this), new RunningLeftFireMarioState(this),
                    new StandingRightFireMarioState(this), new StandingLeftFireMarioState(this), new DeadFireMarioState(this)}, 

                {new CrouchingRightSmallMarioState(this), new CrouchingLeftSmallMarioState(this), new JumpingRightSmallMarioState(this),
                    new JumpingLeftSmallMarioState(this), new RunningRightSmallMarioState(this), new RunningLeftSmallMarioState(this),
                    new StandingRightSmallMarioState(this), new StandingLeftSmallMarioState(this), new DeadSmallMarioState(this)} };
        }

        private IMarioState getState(int orient, int mMode)
        {
            return StateArray[mMode, orient];
        }

        public void LookLeft()
        {
            //if already looking left then start running else look left
            if (orientation == (int)Orientations.StandingLeft)
            {
                orientation = (int)Orientations.RunningLeft;
                state = getState(orientation, marioMode);
            }
            else if (orientation != (int)Orientations.Dead)
            {
                orientation = (int)Orientations.StandingLeft;
                state = getState(orientation, marioMode);
            }
            System.Threading.Thread.Sleep(delay);
        }

        public void LookRight()
        {
            //if already looking right then start running else look right
            if (orientation == (int)Orientations.StandingRight)
            {
                orientation = (int)Orientations.RunningRight;
                state = getState(orientation, marioMode);
            }
            else if (orientation != (int)Orientations.Dead)
            {
                orientation = (int)Orientations.StandingRight;
                state = getState(orientation, marioMode);
            }
            System.Threading.Thread.Sleep(delay);
        }

        public void Jump()
        {
            if (orientation == (int)Orientations.CrouchingRight)
            {
                orientation = (int)Orientations.StandingRight;
                state = getState(orientation, marioMode);
            }
            else if (orientation == (int)Orientations.CrouchingLeft)
            {
                orientation = (int)Orientations.StandingLeft;
                state = getState(orientation, marioMode);
            }
            else if (orientation == (int)Orientations.StandingRight || orientation == (int)Orientations.RunningRight)
            {
                orientation = (int)Orientations.JumpingRight;
                state = getState(orientation, marioMode);
            }
            else if (orientation == (int)Orientations.StandingLeft || orientation == (int)Orientations.RunningLeft)
            {
                orientation = (int)Orientations.JumpingLeft;
                state = getState(orientation, marioMode);
            }
            System.Threading.Thread.Sleep(delay);
        }
        public void Crouch()
        {
            if (orientation == (int)Orientations.JumpingRight)
            {
                orientation = (int)Orientations.StandingRight;
                state = getState(orientation, marioMode);
            }
            else if (orientation == (int)Orientations.JumpingLeft)
            {
                orientation = (int)Orientations.StandingLeft;
                state = getState(orientation, marioMode);
            }
            else if (orientation == (int)Orientations.StandingRight || orientation == (int)Orientations.RunningRight)
            {
                if (marioMode != (int)MarioModes.Small)
                {
                    orientation = (int)Orientations.CrouchingRight;
                    state = getState(orientation, marioMode);
                }
                else
                {
                    return;
                }
            }
            else if (orientation == (int)Orientations.StandingLeft || orientation == (int)Orientations.RunningLeft)
            {
                if (marioMode != (int)MarioModes.Small)
                {
                    orientation = (int)Orientations.CrouchingLeft;
                    state = getState(orientation, marioMode);
                }
                else
                {
                    return;
                }
            }
            else
            {
                //do nothing
            }
            System.Threading.Thread.Sleep(delay);
        }
        public void Big()
        {
            if (marioMode != (int)MarioModes.Big)
            {
                marioMode = (int)MarioModes.Big;
                state = getState(orientation, marioMode);
            }
        }

        public void Small()
        {
            if (marioMode != (int)MarioModes.Small)
            {
                marioMode = (int)MarioModes.Small;
                state = getState(orientation, marioMode);
            }
        }

        public void Fire()
        {
            if (marioMode != (int)MarioModes.Fire)
            {
                marioMode = (int)MarioModes.Fire;
                state = getState(orientation, marioMode);
            }
        }

        public void Dead()
        {
            if (orientation != (int)Orientations.Dead)
            {
                orientation = (int)Orientations.Dead;
                state = getState(orientation, marioMode);
            }
        }

        public void Reset()
        {
            orientation = (int)Orientations.StandingRight;
            marioMode = (int)MarioModes.Small;
            state = getState(orientation, marioMode);          
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
