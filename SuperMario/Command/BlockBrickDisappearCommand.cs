using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario.Command
{
    class BlockBrickDisappearCommand : ICommand
    {
        private Game1 MyGame;

        public BlockBrickDisappearCommand(Game1 game)
        {
            MyGame = game;
        }
        public void Execute()
        {
          //  MyGame.Block.BrickToDisappear();
        }
    }
}

