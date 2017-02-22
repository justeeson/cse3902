using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Sprites;

namespace SuperMario.Command
{
    class MarioShrinkCommand : ICommand
    {
        private Game1 myGame;

        public MarioShrinkCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            //myGame.sprite.Shrink();
        }
    }
}
