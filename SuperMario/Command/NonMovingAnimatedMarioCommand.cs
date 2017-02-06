using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Sprites;

namespace SuperMario.Command
{
    // This file is modified from http://web.cse.ohio-state.edu/~boggus/3902/slides/KillMarioCommand.cs
    class NonMovingAnimatedMarioCommand : ICommand
    {
        private Game1 myGame;

        public NonMovingAnimatedMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite.ChangeDirection();
        }
    }
}
