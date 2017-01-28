using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sprint0.Interfaces;
using Sprint0.Sprites;
using Sprint0;

namespace Sprint0.Command
{
    // This file is modified from http://web.cse.ohio-state.edu/~boggus/3902/slides/KillMarioCommand.cs
    class MovingAnimatedMarioCommand : ICommand
    {
        private Game1 myGame;

        public MovingAnimatedMarioCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.sprite = new MovingAnimatedMarioSprite(myGame.texture, 1, 4);
        }
    }
}
