using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Command
{
    class MarioJumpCommand : ICommand
    {
        private Game1 myGame;

        public MarioJumpCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Mario.Jump();
        }
    }
}
