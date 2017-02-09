using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class QuestionMarkBrickToUsed
    {
        private Game1 myGame;

        public QuestionMarkBrickToUsed(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateSolidBrickWithCrews3();
            myGame.sprite = mySprite;
        }
    }
}
