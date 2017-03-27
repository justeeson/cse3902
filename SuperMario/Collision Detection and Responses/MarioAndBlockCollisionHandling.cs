using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    public class MarioAndBlockCollisionHandling
    {
        public static void HandleCollision(IMario mario, IBlock item)
        {   
            Rectangle collisionRectangle = new Rectangle();
            ISprite block = item.Sprite;
            if (!block.Area(item.Location).Equals(collisionRectangle)){
                collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
                if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
                {
                    Mario.LocationY += collisionRectangle.Height + 5;
                    block.CollisionSprite();
                    item.BecomeUsed();
                }
                else if (collisionRectangle.Top == block.Area(item.Location).Top)
                {
                    Mario.GroundedStatus = true;
                    Mario.LocationY -= collisionRectangle.Height + 5;
                    Mario.JumpStatus = false;
                    mario.ResetVelocity();
                }
                collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
                if (collisionRectangle.Right == block.Area(item.Location).Right)
                {
                    Mario.LocationX += collisionRectangle.Width + 0;
                }
                else if (collisionRectangle.Left == block.Area(item.Location).Left)
                {
                    Mario.LocationX -= collisionRectangle.Width + 0;
                }

            }

        }

    }
}
