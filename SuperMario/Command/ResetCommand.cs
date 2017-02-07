using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.MarioClass;
using SuperMario.Blocks;


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
            myGame.Mario.Small();
            //myGame.QuestionBlock = new QuestionBlockClass(myGame);
            //myGame.HiddenBlock = new HiddenBlockClass(myGame);
            //myGame.BrickBlock = new BrickClass(myGame);
        }
    }
}
