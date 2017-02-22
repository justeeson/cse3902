using Microsoft.Xna.Framework;
using SuperMario.Collision_Detection_and_Responses;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Collision_Detection_and_Responses
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

            foreach (IBlock item in store.blockArray)
            {

                Rectangle blockRect = item.Sprite.Area();

                if (marioRect.Intersects(blockRect))
                {
                    MarioAndBlockCollisionHandling.HandleCollision(store.GameClass.Mario, item);
                }

            }

            foreach (IEnemy item in store.enemyArray)
            {

                Rectangle enemyRect = item.Sprite.Area();

                if (marioRect.Intersects(enemyRect))
                {
                    MarioAndEnemyCollisionHandling.HandleCollision(store.GameClass.Mario, item);
                }

            }
        }
    }
}
