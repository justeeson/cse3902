using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario.Command
{
    class BlockQuestionBecomeUsedCommand : ICommand
    {
        private Game1 myGame;

        public BlockQuestionBecomeUsedCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            myGame.Block.BecomeUsed();
        }
    }
}
