using SuperMario.Interfaces;
using SuperMario.MarioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Command
{
    public class MarioBackToGroundCommand : ICommand
    {
        private Game1 MyGame;

        public MarioBackToGroundCommand(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.World.Level.ReturnGround();
            Mario.LocationX = 5216;
            Mario.LocationY = 250;
            MyGame.CameraPointer.UpdateX((int)Mario.LocationX);
            MyGame.CameraPointer.DisableCamera = false;
            MarioStateMachine.GotoUnderground = false;
            MarioStateMachine.GotoGround = false;
            MarioStateMachine.Crouching = 0;
        }
    }

}
