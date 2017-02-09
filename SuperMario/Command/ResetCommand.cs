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
        private Game1 myGame;

        public ResetCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Mario.Reset();
            Game1.listOfObjects = ObjectArray.Instance.ArrayOfObjects(myGame);
        }
    }
}
