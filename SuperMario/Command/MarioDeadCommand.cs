using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario.Command
{
    class MarioDeadCommand : ICommand
    { 
        private Game1 MyGame;

        public MarioDeadCommand(Game1 game)
        {
            MyGame = game;
        }

        public void Execute()
        {
            MyGame.MarioSprite.Dead();
        }
    }
}
