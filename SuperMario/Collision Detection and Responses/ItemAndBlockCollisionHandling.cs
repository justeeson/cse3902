using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class ItemAndBlockCollisionHandling
    {
        public static void HandleCollision(IItem powerup, IBlock item)
        {
            Rectangle collisionRectangle;
            ISprite block = item.Sprite;
            collisionRectangle = Rectangle.Intersect(powerup.Sprite.Area(powerup.Location), block.Area(item.Location));
            if (collisionRectangle.Bottom == block.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
            {
                powerup.Location = new Vector2(powerup.Location.X, powerup.Location.Y + collisionRectangle.Height + 2);
            }
            else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
            {
                if(powerup is Star)
                    powerup.Location = new Vector2(powerup.Location.X, powerup.Location.Y - (collisionRectangle.Height + 50));
                else
                    powerup.Location = new Vector2(powerup.Location.X, powerup.Location.Y - (collisionRectangle.Height + 2));
                powerup.IsFalling = false;
                
            }

            collisionRectangle = Rectangle.Intersect(powerup.Sprite.Area(powerup.Location), block.Area(item.Location));
            if (collisionRectangle.Right == block.Area(item.Location).Right)
            {
                powerup.Location = new Vector2(powerup.Location.X + collisionRectangle.Width + 1, powerup.Location.Y);
                powerup.MovingLeft = false;
            }
            else if (collisionRectangle.Left == block.Area(item.Location).Left)
            {
                powerup.Location = new Vector2(powerup.Location.X - (collisionRectangle.Width + 1), powerup.Location.Y);
                powerup.MovingLeft = true;
            }
        }
    }
}
