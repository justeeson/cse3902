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
        public List<IItem> obtainedItems;
        public MariovsItemsHandling itemResponder;
      

        public CollsionHandler(Mario mario, Game1 game)
        {
            this.game = game;
            itemResponder = new MariovsItemsHandling(game);
            obtainedItems = new List<IItem>();
        }

        public void Detect(Mario mario, List<IItem> items)
        {
           
            Rectangle marioRect = mario.Area();
            foreach (IItem item in items)
            {
                Rectangle itemRect = item.Area();
                if (marioRect.Intersects(itemRect))
                {
                    obtainedItems.Add(item);
                    itemResponder.MariovsItemsResponder(mario, item);
                }
               
            }
        }
    }
}
