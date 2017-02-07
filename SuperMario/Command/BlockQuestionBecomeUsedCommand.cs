using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Sprites;


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
            // Question Block object file does not exist
            //myGame.QuestionBlock.questionToUsed();
        }
    }
}
