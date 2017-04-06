using Microsoft.Xna.Framework;
using SuperMario.Collision_Detection_and_Responses;
using SuperMario.Interfaces;
using SuperMario.Levels;
using SuperMario.MarioClass;
using SuperMario.Blockclass;
using SuperMario.Blocks;
using SuperMario.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Collision_Detection_and_Responses
{
    class CollisionHandling
    {
        public static Boolean bottomCollision;
        private CollisionHandling()
        {

        }
        public static void Update(ILevel level, Game1 game)
        {
            int marioCheck = 0;
            int itemCheck = 0;
            Rectangle marioRect = game.MarioSprite.Area();
            IMario mario = game.MarioSprite;

            MarioDetection(level,  game,  marioRect, mario);
            BlockDetection(level, game, marioRect, marioCheck);
            EnemyDetection(level,  game,  marioRect,  mario);
            ItemDetection(level,  game,  marioRect,  itemCheck);
            FireballDetection(level,  game,  marioRect, mario);

        }



        private static void MarioDetection(ILevel level, Game1 game, Rectangle marioRect, IMario mario)
        {
            foreach (IItem item in level.ItemList)
            {
                Rectangle itemRect = item.Area();

                if (marioRect.Intersects(itemRect))
                {
                    MarioAndItemCollisionResponser.Response(game.MarioSprite, item);
                }
            }
        }
        
        private static void BlockDetection(ILevel level, Game1 game, Rectangle marioRect, int marioCheck)
        {
            bottomCollision = false;
            for (int index = 0; index < level.BlockList.Count; index++)
            {
                IBlock item = level.BlockList[index];
                Rectangle blockRect = item.Sprite.Area(item.Location);
                Rectangle testRect = marioRect;
                testRect.Y += 1;
                if (marioRect.Intersects(blockRect))
                {
                    //Mario.DisableJump = false;
                    MarioAndBlockCollisionHandling.HandleCollision(game.MarioSprite, item);
                    if (item is PipeToUnderground)
                    {
                        if (MarioStateMachine.Crouching == 1)
                        {
                            item.BecomeUsed();
                        }
                    }
                    else if (item is UndergroundPipeToGround)
                    {
                        if (MarioStateMachine.Crouching == 1)
                        {
                            item.BecomeUsed();
                        }
                    }
                }
                else
                {
                    if (testRect.Intersects(blockRect))
                    {
                        Mario.DisableJump = false;
                        Mario.GroundedStatus = true;
                        marioCheck = 1;
                    }
                }
                testRect.Y -= 1;
                blockRect = item.Sprite.Area(item.Location);
                
                for (int i = 0; i < level.EnemyList.Count; i++)
                {
                    IEnemy enemyInList = level.EnemyList.ElementAt<IEnemy>(i);

                    if (blockRect.Intersects(enemyInList.Sprite.Area(enemyInList.Location)))
                        EnemyAndBlockCollisionHandling.HandleCollision(enemyInList, item);
                    else
                        enemyInList.IsFalling = true;
                }
            }

            if (marioCheck == 0)
            {
                Mario.DisableJump = true;
                Mario.GroundedStatus = false;
            }

            
        }


        private static void EnemyDetection(ILevel level, Game1 game, Rectangle marioRect, IMario mario)
        {
            foreach (IEnemy item in level.EnemyList)
            {

                Rectangle enemyRect = item.Sprite.Area(item.Location);

                if (marioRect.Intersects(enemyRect) && !game.MarioSprite.isDead())
                {
                    MarioAndEnemyCollisionHandling.HandleCollision(game.MarioSprite, item);
                }

            }


            for (int i = 0; i < level.EnemyList.Count - 1; i++)
            {
                for (int j = i + 1; j < level.EnemyList.Count; j++)
                {
                    IEnemy enemy1 = level.EnemyList.ElementAt<IEnemy>(i);
                    IEnemy enemy2 = level.EnemyList.ElementAt<IEnemy>(j);
                    if (enemy1.Sprite.Area(enemy1.Location).Intersects(enemy2.Sprite.Area(enemy2.Location)))
                    {
                        EnemyAndEnemyCollisionHandling.HandleCollision(enemy1, enemy2);
                    }
                }
            }
        }


        private static void ItemDetection(ILevel level, Game1 game, Rectangle marioRect, int itemCheck)
        {

            for (int i = 0; i < level.ItemList.Count; i++)
            {
                for (int j = 0; j < level.BlockList.Count; j++)
                {
                    IItem item = level.ItemList.ElementAt<IItem>(i);
                    IBlock block = level.BlockList.ElementAt<IBlock>(j);
                    if (item.Sprite.Area(item.Location).Intersects(block.Sprite.Area(block.Location)))
                    {
                        ItemAndBlockCollisionHandling.HandleCollision(item, block);
                    }

                    else
                    {
                        Rectangle testRect = item.Sprite.Area(item.Location);
                        testRect.Y += 2;
                        if (testRect.Intersects(block.Sprite.Area(block.Location)))
                        {
                            itemCheck = 1;
                        }
                        testRect.Y -= 2;
                    }

                }

                if (itemCheck == 0)
                {
                    IItem item = level.ItemList.ElementAt<IItem>(i);
                    item.IsFalling = true;
                }
            }
        }




        private static void FireballDetection(ILevel level, Game1 game, Rectangle marioRect, IMario mario)
        {
            foreach (MarioFireball aFireball in Game1.Mfireballs)
            {
                Rectangle projectileRect = aFireball.Area();
                for (int i = 0; i < level.BlockList.Count; i++)
                {
                    IBlock block = level.BlockList.ElementAt<IBlock>(i);
                    if (projectileRect.Intersects(block.Sprite.Area(block.Location)))
                    {
                        ProjectileAndBlockCollisionHandling.HandleCollision(aFireball, block);
                    }
                }
                projectileRect = aFireball.Area();
                for (int i = 0; i < level.EnemyList.Count; i++)
                {
                    IEnemy enemyInList = level.EnemyList.ElementAt<IEnemy>(i);

                    if (projectileRect.Intersects(enemyInList.Sprite.Area(enemyInList.Location)))
                        ProjectileAndEnemyCollisionHandling.HandleCollision(enemyInList, aFireball);

                }
            }
        }

    }
}
