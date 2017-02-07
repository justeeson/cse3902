using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class Coin
    {
        private Game1 myGame;

        public Coin(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateCoin();
            myGame.sprite = mySprite;
        }
    }
}
