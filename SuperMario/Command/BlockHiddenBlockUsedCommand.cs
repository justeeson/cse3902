using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Command
{
    class BlockHiddenBlockUsedCommand : ICommand
    {
        private Game1 myGame;

        public BlockHiddenBlockUsedCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Block.HiddenToUsed();
        }
    }
}
