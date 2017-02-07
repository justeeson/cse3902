using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class FireMushroom
    {
        private Game1 myGame;

        public FireMushroom(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateFireMushroom();
            myGame.sprite = mySprite;
        }
    }
}
