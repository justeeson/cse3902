using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Collision_Detection_and_Responses
{
    public class MarioAndBlockCollisionHandling
    {
        public static void HandleCollision(IMario mario, ISprite block)
        {
            Rectangle collisionRectangle;
            
                collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area());
                if (collisionRectangle.Bottom == block.Area().Bottom && collisionRectangle.Width > collisionRectangle.Height)
                {
                    Mario.locationY += collisionRectangle.Height+1;
                    block.CollisionSprite();
                }
                else if (collisionRectangle.Top == block.Area().Top && collisionRectangle.Width > collisionRectangle.Height)
                {
                    Mario.locationY -= collisionRectangle.Height+1;
                }
                else if (collisionRectangle.Right == block.Area().Right)
                {
                    Mario.locationX += collisionRectangle.Width+1;
                }
                else if (collisionRectangle.Left == block.Area().Left)
                {
                    Mario.locationX -= collisionRectangle.Width+1;
                }
           
        }

    }
}
