using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class HiddenBrick
    {
        private Game1 myGame;

        public HiddenBrick(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateSolidBrickWithCrews2();
            myGame.sprite = mySprite;
        }
    }
}
