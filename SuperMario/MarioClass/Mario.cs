using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using SuperMario.Sprites;
using System.Timers;

namespace SuperMario
{
    public class Mario : IMario
    {
        public IMarioState state { get; set; }
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public static int locationX { get; set; }
        public static int locationY { get; set; }
        public static Boolean starStatus;
        public static Boolean invulnStatus;
        private int invulnTimer;
        private int starPowerTimer;

        public enum Orientations
        {
            CrouchingRight, CrouchingLeft,
            JumpingRight, JumpingLeft,
            RunningRight, RunningLeft,
            StandingRight, StandingLeft,
            Dead
        };

        public enum MarioModes
        { Big, Fire, Small };

        public static int orientation, marioMode;
        IMarioState[,] StateArray;

        public Mario(Texture2D texture, int rows, int columns)
        {
            state = new StandingRightSmallMarioState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            locationX = 400;
            locationY = 350;
            starPowerTimer = 0;
            invulnTimer = 0;
            invulnStatus = false;
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
        public void MoveUpRight()
        {
            if (marioMode == (int)MarioModes.Small)
            {
                orientation = (int)Orientations.RunningRight;
                if (!(state is MovingUpRightDiagonalSmallMario))
                {
                    state = new MovingUpRightDiagonalSmallMario(this);
                }
            }
            else if (marioMode == (int)MarioModes.Fire)
            {
                orientation = (int)Orientations.RunningRight;
                if (!(state is MovingUpRightDiagonalFireMario))
                {
                    state = new MovingUpRightDiagonalFireMario(this);
                }
            }
            else if (marioMode == (int)MarioModes.Big)
            {
                orientation = (int)Orientations.RunningRight;
                if (!(state is MovingUpRightDiagonalBigMario))
                {
                    state = new MovingUpRightDiagonalBigMario(this);
                }
            }
        }

        public void MoveUpLeft()
        {
            if (marioMode == (int)MarioModes.Small)
            {
                orientation = (int)Orientations.RunningLeft;
                if (!(state is MovingUpLeftDiagonalSmallMario))
                {
                    state = new MovingUpLeftDiagonalSmallMario(this);
                }
            }

            else if (marioMode == (int)MarioModes.Fire)
            {
                orientation = (int)Orientations.RunningLeft;
                if (!(state is MovingUpLeftDiagonalFireMario))
                {
                    state = new MovingUpLeftDiagonalFireMario(this);
                }
            }
            else if (marioMode == (int)MarioModes.Big)
            {
                orientation = (int)Orientations.RunningLeft;
                if (!(state is MovingUpLeftDiagonalBigMario))
                {
                    state = new MovingUpLeftDiagonalBigMario(this);
                }
            }
        }

        public void MoveDownRight()
        {
            if (marioMode == (int)MarioModes.Small)
            {
                orientation = (int)Orientations.RunningRight;
                if (!(state is MovingDownRightDiagonalSmallMario))
                {
                    state = new MovingDownRightDiagonalSmallMario(this);
                }
            }

            else if (marioMode == (int)MarioModes.Fire)
            {
                orientation = (int)Orientations.RunningRight;
                if (!(state is MovingDownRightDiagonalFireMario))
                {
                    state = new MovingDownRightDiagonalFireMario(this);
                }
            }

            else if (marioMode == (int)MarioModes.Big)
            {
                orientation = (int)Orientations.RunningRight;
                if (!(state is MovingDownRightDiagonalBigMario))
                {
                    state = new MovingDownRightDiagonalBigMario(this);
                }
            }
        }

        public void MoveDownLeft()
        {
            if (marioMode == (int)MarioModes.Small)
            {
                orientation = (int)Orientations.RunningLeft;
                if (!(state is MovingDownLeftDiagonalSmallMario))
                {
                    state = new MovingDownLeftDiagonalSmallMario(this);
                }
            }

            else if (marioMode == (int)MarioModes.Fire)
            {
                orientation = (int)Orientations.RunningLeft;
                if (!(state is MovingDownLeftDiagonalFireMario))
                {
                    state = new MovingDownLeftDiagonalFireMario(this);
                }
            }

            else if (marioMode == (int)MarioModes.Big)
            {
                orientation = (int)Orientations.RunningLeft;
                if (!(state is MovingDownLeftDiagonalBigMario))
                {
                    state = new MovingDownLeftDiagonalBigMario(this);
                }
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

        public void TakeDamage() { }

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

       

        public void Reset()
        {
            orientation = (int)Orientations.StandingRight;
            marioMode = (int)MarioModes.Small;
            state = getState(orientation, marioMode);
        }

        public void Update(GameTime gameTime)
        {
            if (starStatus)
            {
                starPowerTimer += gameTime.ElapsedGameTime.Milliseconds;
                if(starPowerTimer > 10000)
                {
                    StarPowerUp();
                }
            }
            if(invulnStatus)
            {
                invulnTimer += gameTime.ElapsedGameTime.Milliseconds;
                if (invulnTimer > 3500)
                {
                    Mario.invulnStatus = false;
                    invulnTimer = 0;
                }
            }
            state.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            state.Draw(spriteBatch, new Vector2(locationX, locationY));
        }

        public static void StarPowerUp()
        {
            if (starStatus == false)
                starStatus = true;
            else
                starStatus = false;
        }

        public static void Invulnerability()
        {
                invulnStatus = true;
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