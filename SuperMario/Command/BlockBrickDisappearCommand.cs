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

        public BlockBrickDisappearCommand(Game1 game)
        {
        }
        public void Execute()
        {
          //  MyGame.Block.BrickToDisappear();
        }
    }
}

