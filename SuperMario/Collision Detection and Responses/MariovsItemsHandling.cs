using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.MarioClass;

namespace SuperMario
{
    class MariovsItemsHandling
    {

        Rectangle collisionRectangle;
        Game1 game;
        public MariovsItemsHandling(Game1 game)
         {
            this.game = game;
        }
        public void MariovsItemsResponder(Mario mario, IItem item)
        {
            collisionRectangle = Rectangle.Intersect(mario.Area(), item.Area());
            mario.locationX -= collisionRectangle.Width;
            mario.locationY -= collisionRectangle.Height;
        }

    }
}
