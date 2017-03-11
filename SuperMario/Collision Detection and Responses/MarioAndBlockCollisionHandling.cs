using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    public class MarioAndBlockCollisionHandling
    {
        public static void HandleCollision(IMario mario, IBlock item)
        {
            Rectangle collisionRectangle;
            ISprite block = item.Sprite;
            
                collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
                if (collisionRectangle.Bottom == block.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
                {
                    mario.LocationY += collisionRectangle.Height+1;
                    block.CollisionSprite();
                    item.BecomeUsed();
                }
                else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
                {
                    mario.LocationY -= collisionRectangle.Height+1;
                    Mario.JumpStatus = false;
                    mario.ResetVelocity();
                }
                else if (collisionRectangle.Right == block.Area(item.Location).Right)
                {
                    mario.LocationX += collisionRectangle.Width+1;
                }
                else if (collisionRectangle.Left == block.Area(item.Location).Left)
                {
                    mario.LocationX -= collisionRectangle.Width+1;
                }

          

        }

    }
}
