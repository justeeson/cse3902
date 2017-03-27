using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMario.Interfaces;
using SuperMario.Game_Object_Classes;

namespace SuperMario.Command
{
    class ResetCommand : ICommand
    {
        private Game1 MyGame;

        public ResetCommand(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
            MyGame.MarioSprite.Reset();
            MyGame.World.Reset();
            MyGame.World.Load();
            MyGame.CameraPointer = new Camera();
            //MyGame.store.Initialize(MyGame);
        }
    }
}
