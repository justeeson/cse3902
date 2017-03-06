﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;

namespace SuperMario.Command
{
    public class MarioBecomeFireCommand : ICommand
    {
        private Game1 MyGame;

        public MarioBecomeFireCommand(Game1 game)
        {
            MyGame = game;
        }

        public void Execute()
        {
            MyGame.Mario.MarioFireState();
        }
    }
}
