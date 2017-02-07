using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SuperMario;

using SuperMario.Interfaces;

class Pipe
    {
        private Game1 myGame;

        public Pipe(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreatePipe();
            myGame.sprite = mySprite;
        }
    }

