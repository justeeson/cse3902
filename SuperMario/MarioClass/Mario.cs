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
        public IMarioState State { get; set; }
        public Texture2D Texture { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int LocationX { get; set; }
        public int LocationY { get; set; }
        public static Boolean StarStatus;
        public static Boolean InvulnStatus;
        private int yVelocity, yAcceleration;
        public static Boolean JumpStatus;
        private int invulnTimer;
        private int starPowerTimer;

        public enum Orientations
        {
            CrouchingRight, CrouchingLeft,
            RunningRight, RunningLeft,
            StandingRight, StandingLeft,
            Dead
        };

        public enum MarioModes
        { Big, Fire, Small };

        public static int Orientation, MarioMode;
        IMarioState[,] StateArray;

        public Mario(Texture2D texture, int rows, int columns, Vector2 location)
        {
            State = new StandingRightSmallMarioState(this);
            Texture = texture;
            Rows = rows;
            Columns = columns;
            LocationX = (int)location.X;
            LocationY = (int)location.Y;
            starPowerTimer = 0;
            invulnTimer = 0;
            yAcceleration = -1;
            yVelocity = 0;
            JumpStatus = true;
            InvulnStatus = false;
            StarStatus = false;
            Orientation = (int)Orientations.StandingRight;
            MarioMode = (int)MarioModes.Small;


            StateArray = new IMarioState[3, 7] {
                {new MovingDownRightBigMarioState(this), new MovingDownLeftBigMarioState(this),
                 new RunningRightBigMarioState(this), new RunningLeftBigMarioState(this),
                    new StandingRightBigMarioState(this), new StandingLeftBigMarioState(this), new DeadBigMarioState(this)},

                {new MovingDownRightFireMarioState(this), new MovingDownLeftFireMarioState(this),
                new RunningRightFireMarioState(this), new RunningLeftFireMarioState(this),
                    new StandingRightFireMarioState(this), new StandingLeftFireMarioState(this), new DeadFireMarioState(this)},

                {new MovingDownRightSmallMario(this), new MovingDownLeftSmallMario(this),
                new RunningRightSmallMarioState(this), new RunningLeftSmallMarioState(this),
                    new StandingRightSmallMarioState(this), new StandingLeftSmallMarioState(this), new DeadSmallMarioState(this)} };
        }

        private IMarioState getState(int orient, int mMode)
        {
            return StateArray[mMode, orient];
        }


        public void LookLeft()
        {
            if (Orientation == (int)Orientations.StandingLeft)
            {
                Orientation = (int)Orientations.RunningLeft;
                State = getState(Orientation, MarioMode);
            }

            else if (Orientation != (int)Orientations.Dead && !(Orientation == (int)Orientations.RunningLeft))
            {
                Orientation = (int)Orientations.StandingLeft;
                State = getState(Orientation, MarioMode);
            }
        }

        public void LookRight()
        {
            if (Orientation == (int)Orientations.StandingRight)
            {
                Orientation = (int)Orientations.RunningRight;
                State = getState(Orientation, MarioMode);
            }
            else if (Orientation != (int)Orientations.Dead && !(Orientation == (int)Orientations.RunningRight))
            {
                Orientation = (int)Orientations.StandingRight;
                State = getState(Orientation, MarioMode);
            }
        }

        public void LookDown()
        {
            if (Orientation == (int)Orientations.StandingRight || Orientation == (int)Orientations.RunningRight)
            {
                Orientation = (int)Orientations.CrouchingRight;
                State = getState(Orientation, MarioMode);
            }
            else if (Orientation == (int)Orientations.StandingLeft || Orientation == (int)Orientations.RunningLeft)
            {
                Orientation = (int)Orientations.CrouchingLeft;
                State = getState(Orientation, MarioMode);
            }
        }


        public void Dead()
        {
            if (Orientation != (int)Orientations.Dead)
            {
                Orientation = (int)Orientations.Dead;
                State = getState(Orientation, MarioMode);
            }
        }

        public bool isDead()
        {
            return Orientation == (int)Orientations.Dead;
        }

        public void MarioBigState()
        {
            if (MarioMode != (int)MarioModes.Big)
            {
                MarioMode = (int)MarioModes.Big;
            }
            if (Orientation == (int)Orientations.Dead)
            {
                Orientation = (int)Orientations.StandingRight;
            }
            State = getState(Orientation, MarioMode);
        }

        public void MarioSmallState()
        {
            if (MarioMode != (int)MarioModes.Small)
            {
                MarioMode = (int)MarioModes.Small;
            }
            if (Orientation == (int)Orientations.Dead)
            {
                Orientation = (int)Orientations.StandingRight;
            }
            State = getState(Orientation, MarioMode);
        }

        public void MarioFireState()
        {
            if (MarioMode != (int)MarioModes.Fire)
            {
                MarioMode = (int)MarioModes.Fire;
            }
            if (Orientation == (int)Orientations.Dead)
            {
                Orientation = (int)Orientations.StandingRight;
            }
            State = getState(Orientation, MarioMode);
        }

        public void Jump()
        {
            if (Mario.JumpStatus == false && !isDead())
            {
                yVelocity = 15;
                Mario.JumpStatus = true;
            }
        }

        public void Reset()
        {
            Orientation = (int)Orientations.StandingRight;
            MarioMode = (int)MarioModes.Small;
            State = getState(Orientation, MarioMode);
            LocationX = 400;
            LocationY = 350;
        }

        public void Update(GameTime GameTime)
        {
            if (StarStatus)
            {
                starPowerTimer += GameTime.ElapsedGameTime.Milliseconds;
                if (starPowerTimer > 10000)
                {
                    StarPowerUp();
                }
            }
            if (InvulnStatus)
            {
                invulnTimer += GameTime.ElapsedGameTime.Milliseconds;
                if (invulnTimer > 1800)
                {
                    Mario.InvulnStatus = false;
                    invulnTimer = 0;
                }
            }
            if (JumpStatus)
            {
                LocationY = LocationY - yVelocity;
                yVelocity = yVelocity + yAcceleration;
                /*if (LocationY >= 350)
                    Mario.JumpStatus = false;*/
            }
            State.Update(GameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            State.Draw(spriteBatch, new Vector2(LocationX, LocationY));
        }

        public static void StarPowerUp()
        {
            if (StarStatus == false)
                StarStatus = true;
            else
                StarStatus = false;
        }

        public static void Invulnerability()
        {

            InvulnStatus = true;

        }

        public Rectangle Area()
        {
            if (MarioMode == (int)MarioModes.Small)
                return new Rectangle(LocationX + 12, LocationY + 27, 29, 33);
            else
                return new Rectangle(LocationX + 10, LocationY + 1, 33, 65);
        }
    }
}