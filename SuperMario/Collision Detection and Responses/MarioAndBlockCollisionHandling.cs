using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Collision_Detection_and_Responses
{
    class MarioAndBlockCollisionHandling
    {
        Rectangle collisionRectangle;

        public void HandleCollision(Mario mario, ISprite block)
        {
            if(mario.Area().Intersects(block.Area()))
            {
                collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area());
                mario.locationX -= collisionRectangle.Width;
                mario.locationY -= collisionRectangle.Height;
            }
        }

    }
}
