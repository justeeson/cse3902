using Microsoft.Xna.Framework;
using SuperMario.Collision_Detection_and_Responses;
using SuperMario.Interfaces;
using SuperMario.Levels;
using SuperMario.MarioClass;
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
            int marioCheck = 0;
            int itemCheck = 0;
            Rectangle marioRect = game.MarioSprite.Area();
            IMario mario = game.MarioSprite;

            MarioDetection( level,  game,  marioRect, mario);
            BlockDetection(level, game, marioRect, marioCheck);
            EnemyDetection( level,  game,  marioRect,  mario);
            ItemDetection( level,  game,  marioRect,  itemCheck);
            FireballDetection( level,  game,  marioRect, mario);

        }



        private static void MarioDetection(LevelClass level, Game1 game, Rectangle marioRect, IMario mario)
        {
            foreach (IItem item in LevelClass.ItemList)
            {
                Rectangle itemRect = item.Area();

                if (marioRect.Intersects(itemRect))
                {
                    MarioAndItemCollisionResponser.Response(game.MarioSprite, item);
                }
            }
        }


        private static void BlockDetection(LevelClass level, Game1 game, Rectangle marioRect, int marioCheck)
        {
            foreach (IBlock item in LevelClass.BlockList)
            {
                Rectangle blockRect = item.Sprite.Area(item.Location);
                Rectangle testRect = marioRect;
                testRect.Y += 5;
                if (marioRect.Intersects(blockRect))
                {
                    Mario.DisableJump = false;
                    MarioAndBlockCollisionHandling.HandleCollision(game.MarioSprite, item);
                }
                else if (true)
                {

                    if (testRect.Intersects(blockRect))
                    {
                        Mario.DisableJump = false;
                        Mario.GroundedStatus = true;
                        marioCheck = 1;
                    }
                    testRect.Y -= 5;
                }
                blockRect = item.Sprite.Area(item.Location);
                foreach (MarioFireball fireBall in Game1.Mfireballs)
                {
                    Rectangle ballRect = fireBall.Area();
                    if (ballRect.Intersects(blockRect))
                    {

                        MarioAndBlockCollisionHandling.HandleCollision(game.MarioSprite, item);
                    }
                }

                for (int i = 0; i < LevelClass.EnemyList.Count; i++)
                {
                    IEnemy enemyInList = LevelClass.EnemyList.ElementAt<IEnemy>(i);

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


        private static void EnemyDetection(LevelClass level, Game1 game, Rectangle marioRect, IMario mario)
        {
            foreach (IEnemy item in LevelClass.EnemyList)
            {

                Rectangle enemyRect = item.Sprite.Area(item.Location);

                if (marioRect.Intersects(enemyRect) && !game.MarioSprite.isDead())
                {
                    MarioAndEnemyCollisionHandling.HandleCollision(game.MarioSprite, item);
                }

            }


            for (int i = 0; i < LevelClass.EnemyList.Count - 1; i++)
            {
                for (int j = i + 1; j < LevelClass.EnemyList.Count; j++)
                {
                    IEnemy enemy1 = LevelClass.EnemyList.ElementAt<IEnemy>(i);
                    IEnemy enemy2 = LevelClass.EnemyList.ElementAt<IEnemy>(j);
                    if (enemy1.Sprite.Area(enemy1.Location).Intersects(enemy2.Sprite.Area(enemy2.Location)))
                    {
                        EnemyAndEnemyCollisionHandling.HandleCollision(enemy1, enemy2);
                    }
                }
            }
        }


        private static void ItemDetection(LevelClass level, Game1 game, Rectangle marioRect, int itemCheck)
        {

            for (int i = 0; i < LevelClass.ItemList.Count; i++)
            {
                for (int j = 0; j < LevelClass.BlockList.Count; j++)
                {
                    IItem item = LevelClass.ItemList.ElementAt<IItem>(i);
                    IBlock block = LevelClass.BlockList.ElementAt<IBlock>(j);
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
                    IItem item = LevelClass.ItemList.ElementAt<IItem>(i);
                    item.IsFalling = true;
                }
            }
        }




        private static void FireballDetection(LevelClass level, Game1 game, Rectangle marioRect, IMario mario)
        {
            foreach (MarioFireball aFireball in Game1.Mfireballs)
            {
                Rectangle projectileRect = aFireball.Area();
                for (int i = 0; i < LevelClass.BlockList.Count; i++)
                {
                    IBlock block = LevelClass.BlockList.ElementAt<IBlock>(i);
                    if (projectileRect.Intersects(block.Sprite.Area(block.Location)))
                    {
                        ProjectileAndBlockCollisionHandling.HandleCollision(aFireball, block);
                    }
                }
                projectileRect = aFireball.Area();
                for (int i = 0; i < LevelClass.EnemyList.Count; i++)
                {
                    IEnemy enemyInList = LevelClass.EnemyList.ElementAt<IEnemy>(i);

                    if (projectileRect.Intersects(enemyInList.Sprite.Area(enemyInList.Location)))
                        ProjectileAndEnemyCollisionHandling.HandleCollision(enemyInList, aFireball);

                }
            }
        }

    }
}
