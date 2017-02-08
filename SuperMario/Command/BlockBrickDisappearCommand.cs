﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Command
{
    class BlockBrickDisappearCommand : ICommand
    {
        private Game1 myGame;

        public BlockBrickDisappearCommand(Game1 game)
        {
            myGame = game;
        }
        public void Execute()
        {
            // Brick Block object file does not exist
            //myGame.BrickBlock.BrickToDisappear();
        }
    }
}
