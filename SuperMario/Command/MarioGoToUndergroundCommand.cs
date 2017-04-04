using SuperMario.Interfaces;
using SuperMario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Command
{
    public class MarioGoToUndergroundCommand : ICommand
    {

        private Game1 MyGame;

        public MarioGoToUndergroundCommand(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            // Ned to change the color to black
            MyGame.World.Level = new UnderGroundWorld(MyGame, MyGame.World.Level, "UndergroundWorld.xml");
            MyGame.World.Load();
            Mario.LocationX = 50;
            Mario.LocationY = 50;
            MyGame.CameraPointer.disableCamera = true;
        }

    }

}
