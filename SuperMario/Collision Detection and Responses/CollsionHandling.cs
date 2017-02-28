using Microsoft.Xna.Framework;
using SuperMario.Collision_Detection_and_Responses;
using SuperMario.Interfaces;
using SuperMario.Levels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Collision_Detection_and_Responses
{
    class CollisionHandling
    {

        private CollisionHandling()
        {

        }
        public static void Update(LevelClass level, Game1 game)
        {
            Rectangle marioRect = game.Mario.Area();

            foreach (IItem item in LevelClass.ItemList)
            {

                Rectangle itemRect = item.Area();

                if (marioRect.Intersects(itemRect))
                {
                    MarioAndItemCollisionResponser.Response(game.Mario, item);
                }

            }

            foreach (IBlock item in LevelClass.BlockList)
            {

                Rectangle blockRect = item.Sprite.Area();

                if (marioRect.Intersects(blockRect))
                {
                    MarioAndBlockCollisionHandling.HandleCollision(game.Mario, item);
                }

            }

            foreach (IEnemy item in LevelClass.EnemyList)
            {

                Rectangle enemyRect = item.Sprite.Area();

                if (marioRect.Intersects(enemyRect))
                {
                    MarioAndEnemyCollisionHandling.HandleCollision(game.Mario, item);
                }

            }
        }
    }
}
