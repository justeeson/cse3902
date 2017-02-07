using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class Star
    {
        private Game1 myGame;

        public Star(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateStar();
            myGame.sprite = mySprite;
        }
    }
}
