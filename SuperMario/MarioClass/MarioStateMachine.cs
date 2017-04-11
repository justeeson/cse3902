using SuperMario.Interfaces;
using SuperMario.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.MarioClass
{
    public class MarioStateMachine : IMarioStateMachine
    {
        private Mario player;
        public int Orientation
        { get; set; }
        public int MarioMode
        { get; set; }
        IMarioState[,] StateArray;
        public static int Crouching
        { get; set; }

        public enum Orientations
        {
            CrouchingRight, CrouchingLeft,
            RunningRight, RunningLeft,
            StandingRight, StandingLeft,
            Dead
        };

        public enum MarioModes
        { Big, Fire, Small };

        public MarioStateMachine(Mario mario)
        {
            player = mario;
            Orientation = (int)Orientations.StandingRight;
            MarioMode = (int)MarioModes.Small;

            StateArray = new IMarioState[3, 7] {
                {new MovingDownRightBigMarioState(player), new MovingDownLeftBigMarioState(player),
                 new RunningRightBigMarioState(player), new RunningLeftBigMarioState(player),
                 new StandingRightBigMarioState(player), new StandingLeftBigMarioState(player), new DeadBigMarioState(player)},

                {new MovingDownRightFireMarioState(player), new MovingDownLeftFireMarioState(player),
                 new RunningRightFireMarioState(player), new RunningLeftFireMarioState(player),
                 new StandingRightFireMarioState(player), new StandingLeftFireMarioState(player), new DeadFireMarioState(player)},

                {new MovingDownRightSmallMario(player), new MovingDownLeftSmallMario(player),
                new RunningRightSmallMarioState(player), new RunningLeftSmallMarioState(player),
                    new StandingRightSmallMarioState(player), new StandingLeftSmallMarioState(player), new DeadSmallMarioState(player)} };
        }

        public MarioStateMachine(IMario mario)
        {
            
            Orientation = (int)Orientations.StandingRight;
        }

        public IMarioState GetState
        {
            get { return StateArray[MarioMode, Orientation]; }
        }

        public bool isFacingLeft()
        {
            if (Orientation == (int)Orientations.CrouchingLeft
               || Orientation == (int)Orientations.RunningLeft
               || Orientation == (int)Orientations.StandingLeft)
                return true;
            else
                return false;
        }
        
        public void LookLeft()
        {
            if (Orientation == (int)Orientations.StandingLeft)
            {
                Orientation = (int)Orientations.RunningLeft;
                player.State = GetState;
            }

            else if (Orientation != (int)Orientations.Dead && (Orientation != (int)Orientations.RunningLeft))
            {
                Orientation = (int)Orientations.StandingLeft;
            }
        }

        public void LookRight()
        {
            if (Orientation == (int)Orientations.StandingRight)
            {
                Orientation = (int)Orientations.RunningRight;
            }
            else if (Orientation != (int)Orientations.Dead && (Orientation != (int)Orientations.RunningRight))
            {
                Orientation = (int)Orientations.StandingRight;
            }
        }

        public void LookDown()
        {
            if (Orientation == (int)Orientations.StandingRight || Orientation == (int)Orientations.RunningRight)
            {
                Crouching = 1;
                Orientation = (int)Orientations.CrouchingRight;
            }
            else if (Orientation == (int)Orientations.StandingLeft || Orientation == (int)Orientations.RunningLeft)
            {
                Crouching = 1;
                Orientation = (int)Orientations.CrouchingLeft;
            }
        }

        public void Dead()
        {
            Orientation = (int)Orientations.Dead;
        }

        public bool isDead()
        {
            return Orientation == (int)Orientations.Dead;
        }

        public void MarioBigState()
        {
            MarioMode = (int)MarioModes.Big;
            if (Orientation == (int)Orientations.Dead)
            {
                Orientation = (int)Orientations.StandingRight;
            }
        }

        public void MarioSmallState()
        {
            MarioMode = (int)MarioModes.Small;
            if (Orientation == (int)Orientations.Dead)
            {
                Orientation = (int)Orientations.StandingRight;
            }
        }

        public void MarioFireState()
        {
            MarioMode = (int)MarioModes.Fire;
            if (Orientation == (int)Orientations.Dead)
            {
                Orientation = (int)Orientations.StandingRight;
            }
        }

        public void Reset()
        {
            Orientation = (int)Orientations.StandingRight;
            MarioMode = (int)MarioModes.Small;
        }
    }
}
