using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class ProjectileAndBlockCollisionHandling
    {
        public static void HandleCollision(IProjectile projectile, IBlock item)
        {
            ISprite block = item.Sprite;
            Rectangle collisionRectangle = Rectangle.Intersect(projectile.Area(), block.Area(item.Location));
            if (collisionRectangle.Bottom == block.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
            {
                projectile.KillFireball();
            }
            else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
            {
                    projectile.LocationY = projectile.LocationY - (collisionRectangle.Height + 45);               
            }

            collisionRectangle = Rectangle.Intersect(projectile.Area(), block.Area(item.Location));
            if (collisionRectangle.Right == block.Area(item.Location).Right)
            {
                projectile.KillFireball();

            }
            else if (collisionRectangle.Left == block.Area(item.Location).Left)
            {
                projectile.KillFireball();
            }



        }

    }
}
