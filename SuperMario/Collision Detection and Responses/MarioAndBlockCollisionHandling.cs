using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;
using System;
using System.IO;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class MarioAndBlockCollisionHandling
    {
        public static void HandleCollision(IMario mario, IBlock item)
        {
            Rectangle collisionRectangle = new Rectangle();
            ISprite block = item.Sprite;
            if (item is FlagPole)
            {
                item.BecomeUsed();
            }
            if (block.Area(item.Location).Equals(collisionRectangle)) {
                return;
            }
            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if ((collisionRectangle.Width <= collisionRectangle.Height))
            {
                WidthSmallerThanHeight(mario, item, collisionRectangle, block);
            }
            else
            {
                HeightSmallerThanWidth(mario, item, collisionRectangle, block);
            }
        }

        private static void WidthSmallerThanHeight(IMario mario, IBlock item, Rectangle collisionRectangle, ISprite block)
        {
            if (block.Area(item.Location).Right < mario.Area().Right)
            {
                Mario.LocationX += collisionRectangle.Width;
                writeCollision(mario.Area(), block.Area(item.Location), "left");
            }
            else if (block.Area(item.Location).Right >= mario.Area().Right)
            {
                Mario.LocationX -= (collisionRectangle.Width);
                writeCollision(mario.Area(), block.Area(item.Location), "right");
            }
            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
            {
                Mario.LocationY += collisionRectangle.Height;
                Mario.ResetVelocity();
                block.CollisionSprite();
                item.BecomeUsed();
                writeCollision(mario.Area(), block.Area(item.Location), "top");
            }
            else if (collisionRectangle.Top == block.Area(item.Location).Top)
            {   
                Mario.GroundedStatus = true;
                Mario.DisableJump = false;
                Mario.JumpStatus = false;
                Mario.LocationY -= (collisionRectangle.Height);
                MarioAndEnemyCollisionHandling.SetBonusPoint(false);
                Mario.ResetVelocity();
                writeCollision(mario.Area(), block.Area(item.Location), "bottom");
            }
        }

        private static void HeightSmallerThanWidth(IMario mario, IBlock item, Rectangle collisionRectangle, ISprite block)
        {
            if (block.Area(item.Location).Top > mario.Area().Top)
            {
                Mario.GroundedStatus = true;
                Mario.DisableJump = false;
                Mario.JumpStatus = false;
                Mario.LocationY -= (collisionRectangle.Height);
                MarioAndEnemyCollisionHandling.SetBonusPoint(false);
                Mario.ResetVelocity();
                writeCollision(mario.Area(), block.Area(item.Location), "bottom");
            }
            else if (block.Area(item.Location).Top <= mario.Area().Top)
            {
                Mario.LocationY += collisionRectangle.Height;
                Mario.ResetVelocity();
                block.CollisionSprite();
                item.BecomeUsed();
                writeCollision(mario.Area(), block.Area(item.Location), "top");
            }

            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if (collisionRectangle.Right == block.Area(item.Location).Right)
            {
                Mario.LocationX += collisionRectangle.Width + 1;
                writeCollision(mario.Area(), block.Area(item.Location), "left");
            }
            else if (collisionRectangle.Left == block.Area(item.Location).Left)
            {
                Mario.LocationX -= (collisionRectangle.Width + 1);
                writeCollision(mario.Area(), block.Area(item.Location), "right");
            }
        }


        public static void writeCollision(Rectangle Mario, Rectangle Block, string direction)
        {
        }

    }
}
