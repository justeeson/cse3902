using SuperMario.Interfaces;
using SuperMario.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.MarioClass
{
    public class MarioStateMachine: IMarioStateMachine
    {
        private Mario player;
        public int MarioMode, Orientation;
        IMarioState State;
        IMarioState[,] StateArray;

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

        public IMarioState getState()
        {
            return StateArray[MarioMode, Orientation];
        }

        public void LookLeft()
        {
            if (Orientation == (int)Orientations.StandingLeft)
            {
                Orientation = (int)Orientations.RunningLeft;
                player.State = getState();
            }

            else if (Orientation != (int)Orientations.Dead && !(Orientation == (int)Orientations.RunningLeft))
            {
                Orientation = (int)Orientations.StandingLeft;
                State = getState();
            }
        }

        public void LookRight()
        {
            if (Orientation == (int)Orientations.StandingRight)
            {
                Orientation = (int)Orientations.RunningRight;
                State = getState();
            }
            else if (Orientation != (int)Orientations.Dead && !(Orientation == (int)Orientations.RunningRight))
            {
                Orientation = (int)Orientations.StandingRight;
                State = getState();
            }
        }

        public void LookDown()
        {
            if (Orientation == (int)Orientations.StandingRight || Orientation == (int)Orientations.RunningRight)
            {
                Orientation = (int)Orientations.CrouchingRight;
                State = getState();
            }
            else if (Orientation == (int)Orientations.StandingLeft || Orientation == (int)Orientations.RunningLeft)
            {
                Orientation = (int)Orientations.CrouchingLeft;
                State = getState();
            }
        }

        public void Dead()
        {
            if (Orientation != (int)Orientations.Dead)
            {
                Orientation = (int)Orientations.Dead;
                State = getState();
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
            State = getState();
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
            State = getState();
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
            State = getState();
        }

        public void Reset()
        {
            Orientation = (int)Orientations.StandingRight;
            MarioMode = (int)MarioModes.Small;
        }
    }
}
