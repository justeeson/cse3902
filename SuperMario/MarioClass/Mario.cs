using System;
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
        public static int locationX { get; set; }
        public static int locationY { get; set; }

        private Boolean starStatus;
        int delay = 100;

        enum Orientations
        { CrouchingRight, CrouchingLeft,
            JumpingRight, JumpingLeft,
            RunningRight, RunningLeft,
            StandingRight, StandingLeft,
            Dead };

        enum MarioModes
        { Big, Fire, Small };

        private int orientation, marioMode;
        IMarioState[,] StateArray;

        public Mario(Texture2D texture, int rows, int columns)
        {
            state = new StandingRightSmallMarioState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            locationX = 400;
            locationY = 350;
            starStatus = false;
            orientation = (int)Orientations.StandingRight;
            marioMode = (int)MarioModes.Small;

            StateArray = new IMarioState[3, 9] {
                {new MovingDownRightBigMarioState(this), new MovingDownLeftBigMarioState(this), new MovingUpRightBigMarioState(this),
                    new MovingUpLeftBigMarioState(this), new RunningRightBigMarioState(this), new RunningLeftBigMarioState(this),
                    new StandingRightBigMarioState(this), new StandingLeftBigMarioState(this), new DeadBigMarioState(this)},

                {new MovingDownRightFireMarioState(this), new MovingDownLeftFireMarioState(this), new MovingUpRightFireMarioState(this),
                    new MovingUpLeftFireMarioState(this), new RunningRightFireMarioState(this), new RunningLeftFireMarioState(this),
                    new StandingRightFireMarioState(this), new StandingLeftFireMarioState(this), new DeadFireMarioState(this)},

                {new MovingDownRightSmallMario(this), new MovingDownLeftSmallMario(this), new MovingUpRightSmallMario(this),
                    new MovingUpLeftSmallMario(this), new RunningRightSmallMarioState(this), new RunningLeftSmallMarioState(this),
                    new StandingRightSmallMarioState(this), new StandingLeftSmallMarioState(this), new DeadSmallMarioState(this)} };
        }

        private IMarioState getState(int orient, int mMode)
        {
            return StateArray[mMode, orient];
        }

        public void LookLeft()
        {
            if (orientation == (int)Orientations.StandingLeft)
            {
                orientation = (int)Orientations.RunningLeft;
                state = getState(orientation, marioMode);
            }

            else if (orientation != (int)Orientations.Dead && !(orientation == (int)Orientations.RunningLeft))
            {
                orientation = (int)Orientations.StandingLeft;
                state = getState(orientation, marioMode);
            }
        }

        public void LookRight()
        {
            if (orientation == (int)Orientations.StandingRight)
            {
                orientation = (int)Orientations.RunningRight;
                state = getState(orientation, marioMode);
            }
            else if (orientation != (int)Orientations.Dead && !(orientation == (int)Orientations.RunningRight))
            {
                orientation = (int)Orientations.StandingRight;
                state = getState(orientation, marioMode);
            }
        }

        public void LookUp()
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
        }
        public void LookDown()
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
                    orientation = (int)Orientations.CrouchingRight;
                    state = getState(orientation, marioMode);
            }
            else if (orientation == (int)Orientations.StandingLeft || orientation == (int)Orientations.RunningLeft)
            {
                    orientation = (int)Orientations.CrouchingLeft;
                    state = getState(orientation, marioMode);
            }
        }
        public void MarioBigState()
        {
            if (marioMode != (int)MarioModes.Big)
            {
                marioMode = (int)MarioModes.Big;
            }
            if (orientation == (int)Orientations.Dead)
            {
                orientation = (int)Orientations.StandingRight;
            }
            state = getState(orientation, marioMode);
        }

        public void MarioSmallState()
        {
            if (marioMode != (int)MarioModes.Small)
            {
                marioMode = (int)MarioModes.Small;
            }
            if (orientation == (int)Orientations.Dead)
            {
                orientation = (int)Orientations.StandingRight;
            }
            state = getState(orientation, marioMode);
        }

        public void MarioFireState()
        {
            if (marioMode != (int)MarioModes.Fire)
            {
                marioMode = (int)MarioModes.Fire;
            }
            if (orientation == (int)Orientations.Dead)
            {
                orientation = (int)Orientations.StandingRight;
            }
            state = getState(orientation, marioMode);
        }

        public void Dead()
        {
            if (marioMode == (int)MarioModes.Small)
            {
                orientation = (int)Orientations.Dead;
                state = getState(orientation, marioMode);
            }
            else
            {
                marioMode = (int)MarioModes.Small;
                state = getState(orientation, marioMode);
            }
        }

        public void Reset()
        {
            orientation = (int)Orientations.StandingRight;
            marioMode = (int)MarioModes.Small;
            state = getState(orientation, marioMode);          
        }
        
        public void Update(GameTime gameTime)
        {
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, new Vector2(locationX, locationY));
        }
        
        public void StarPowerUp()
        {
            starStatus = true;
        }

        public Rectangle Area()
        {
            if (marioMode == (int)MarioModes.Small)
                return new Rectangle(locationX + 2, locationY + 10, 17, 19);
            else
                return new Rectangle(locationX, locationY, 19, 33);
        }
    }
}