using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class BreakableHorizontalBrick
    {
        private Game1 myGame;

        public BreakableHorizontalBrick(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateBreakableHorizonalBrick();
            myGame.sprite = mySprite;
        }
    }
}
