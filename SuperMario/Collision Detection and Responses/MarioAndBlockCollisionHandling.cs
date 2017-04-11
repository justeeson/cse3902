using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class MarioAndBlockCollisionHandling
    {
        public static void HandleCollision(IMario mario, IBlock item)
        {
            Rectangle collisionRectangle = new Rectangle();
            ISprite block = item.Sprite;
            if (block.Area(item.Location).Equals(collisionRectangle)) {
                return;
            }
            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if ((collisionRectangle.Width <= collisionRectangle.Height) /*|| Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.Left)*/)
            {
                WidthSmallerThanHeight(mario, item, collisionRectangle, block);
            }
            else
            {
                /*Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.Left)*/
                HeightSmallerThanWidth(mario, item, collisionRectangle, block);
            }
        }

        private static void WidthSmallerThanHeight(IMario mario, IBlock item, Rectangle collisionRectangle, ISprite block)
        {
            if (block.Area(item.Location).Right < mario.Area().Right)
            {
                Mario.LocationX += collisionRectangle.Width;
            }
            else if (block.Area(item.Location).Right >= mario.Area().Right)
            {
                Mario.LocationX -= (collisionRectangle.Width);
            }
            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
            {
                Mario.LocationY += collisionRectangle.Height;
                Mario.ResetVelocity();
                block.CollisionSprite();
                item.BecomeUsed();
            }
            else if (collisionRectangle.Top == block.Area(item.Location).Top)
            {   
                Mario.GroundedStatus = true;
                Mario.DisableJump = false;
                Mario.JumpStatus = false;
                Mario.LocationY -= (collisionRectangle.Height);
                MarioAndEnemyCollisionHandling.SetBonusPoint(false);
                Mario.ResetVelocity();
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
            }
            else if (block.Area(item.Location).Top <= mario.Area().Top)
            {
                Mario.LocationY += collisionRectangle.Height;
                Mario.ResetVelocity();
                block.CollisionSprite();
                item.BecomeUsed();
            }

            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if (collisionRectangle.Right == block.Area(item.Location).Right)
            {
              
                Mario.LocationX += collisionRectangle.Width + 1;
                if (item is FlagPole)
                {
                    item.BecomeUsed();
                }
            }
            else if (collisionRectangle.Left == block.Area(item.Location).Left)
            {
              
                Mario.LocationX -= (collisionRectangle.Width + 1);
                if (item is FlagPole)
                {
                    item.BecomeUsed();
                }

            }
        }

    }
}
