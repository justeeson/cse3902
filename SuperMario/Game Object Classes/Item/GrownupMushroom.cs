using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class GrownupMushroom
    {
         private Game1 myGame;

        public GrownupMushroom(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateGrowupMushroom();
            myGame.sprite = mySprite;
        }
    }
}
