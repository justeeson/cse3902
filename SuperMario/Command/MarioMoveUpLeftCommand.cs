﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario.Command
{
    class MarioMoveUpLeftCommand : ICommand
    { 
        private Game1 myGame;

        public MarioMoveUpLeftCommand(Game1 game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.Mario.MoveUpLeft();
        }
    }
}
