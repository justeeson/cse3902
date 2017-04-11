using SuperMario.Interfaces;
using SuperMario.Levels;
using SuperMario.MarioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Command
{
    public class MarioGoToUndergroundCommand : ICommand
    {

        public Game1 MyGame { get; set; }

        public MarioGoToUndergroundCommand(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.World.Level = new UnderGroundWorld(MyGame, MyGame.World.Level, "UndergroundWorld.xml");
            MyGame.World.Load();
            Mario.LocationX = 50;
            Mario.LocationY = 50;
            MyGame.CameraPointer.DisableCamera = true;
            MarioStateMachine.GotoUnderground = false;
            MarioStateMachine.GotoGround = true;
            MarioStateMachine.Crouching = 0;
        }

    }

}
