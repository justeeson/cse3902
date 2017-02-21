using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.MarioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    class CollsionHandler
    {
        Game1 game;
        public MariovsItemsHandling itemResponder;
      

        public CollsionHandler(Mario mario, Game1 game)
        {
            this.game = game;
            itemResponder = new MariovsItemsHandling(game);
        }

        public void Detect(Mario mario, List<ISprite> items)
        {
           
            Rectangle marioRect = mario.Area();
            foreach (ISprite item in items)
            {
                Rectangle itemRect = item.Area();
                if (marioRect.Intersects(itemRect))
                {
                    itemResponder.MariovsItemsResponder(mario, item);
                    
                }
               
            }
        }
    }
}
