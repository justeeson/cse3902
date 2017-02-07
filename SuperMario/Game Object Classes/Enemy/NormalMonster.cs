using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class NormalMonster
    {
        private Game1 myGame;

        public NormalMonster(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateNormalMonster();
            myGame.sprite = mySprite;
        }
    }
}
