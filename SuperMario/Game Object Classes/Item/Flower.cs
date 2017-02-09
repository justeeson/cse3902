using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class Flower
    {
        private Game1 myGame;

        public Flower(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateFlower();
            myGame.sprite = mySprite;
        }
    }
}
