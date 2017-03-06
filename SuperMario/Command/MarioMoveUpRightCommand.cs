using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario.Command
{
    public class MarioMoveUpRightCommand : ICommand
    { 
        private Game1 myGame;

        public MarioMoveUpRightCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Mario.MoveUpRight();
        }
    }
}
