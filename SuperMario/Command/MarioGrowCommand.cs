using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Sprites;

namespace SuperMario.Command
{
    class MarioGrowCommand : ICommand
    {
        private Game1 myGame;

        public MarioGrowCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
           // myGame.sprite.Grow();
        }
    }
}
