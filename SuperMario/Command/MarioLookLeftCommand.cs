using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Sprites;

namespace SuperMario.Command
{
    class MarioLookLeftCommand : ICommand
    {
        private Game1 myGame;

        public MarioLookLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite.LookLeft();
        }
    }
}
