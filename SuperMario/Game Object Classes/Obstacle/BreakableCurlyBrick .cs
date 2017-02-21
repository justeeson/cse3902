using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class BreakableCurlyBrick : IBlock
    {
        private Game1 myGame;

        public BreakableCurlyBrick(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateBreakableCurlyBrick();
            myGame.sprite = mySprite;
        }
    }
}
