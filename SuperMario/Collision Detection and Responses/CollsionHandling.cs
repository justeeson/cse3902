using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Collision_Defection_and_Responses
{
    class CollisionHandling
    {
        public static void Update(ObjectAndSpriteStore store)
        {
            Rectangle marioRect = store.GameClass.Mario.Area();

            foreach (IItem item in store.itemArray)
            {

                Rectangle itemRect = item.Area();

                if (marioRect.Intersects(itemRect))
                {
                    MarioAndItemCollisionResponser.Response(store.GameClass.Mario, item);

                }

            }
        }
    }
}
