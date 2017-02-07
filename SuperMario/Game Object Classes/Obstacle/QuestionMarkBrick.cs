using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class QuestionMarkBrick
    {
        private Game1 myGame;

        public QuestionMarkBrick(Game1 game)
        {
            myGame = game;
            ISprite mySprite = SpriteFactory.Instance.CreateQuestionMarkBrick();
            myGame.sprite = mySprite;
        }
    }
}
