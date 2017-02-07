using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class SolidBrickWithCrews
    {
        private Game1 myGame;

        public SolidBrickWithCrews(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateSolidBrickWithCrews();
            myGame.sprite = mySprite;
        }
    }
}
