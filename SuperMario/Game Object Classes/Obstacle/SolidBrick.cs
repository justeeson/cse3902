using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class SolidBrick
    {
        private Game1 myGame;

        public SolidBrick(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateSolidBrick();
            myGame.sprite = mySprite;
        }
    }
}
