using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class Flower : IItem
    {
        private Game1 myGame;
        ISprite mySprite;

        public Flower(Game1 game)
        {
            myGame = game;
             mySprite = SpriteFactory.Instance.CreateFlower();
            myGame.sprite = mySprite;
        }
        public Rectangle Area()
        {
            return mySprite.Area();
        }
    }
}
