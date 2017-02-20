using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class Star : IItem
    {
        private Game1 myGame;
         ISprite mySprite;

        public Star(Game1 game)
        {
            myGame = game;
             mySprite = SpriteFactory.Instance.CreateStar();
            myGame.sprite = mySprite;
        }
        public Rectangle Area()
        {
            return mySprite.Area();
        }
    }
}
