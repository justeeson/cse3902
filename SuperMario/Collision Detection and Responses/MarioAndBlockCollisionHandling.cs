using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Collision_Detection_and_Responses
{
    public class MarioAndBlockCollisionHandling
    {
        public static void HandleCollision(IMario mario, IBlock item)
        {
            KeyboardState KeyboardStatus = Keyboard.GetState();
            Rectangle collisionRectangle = new Rectangle();
            ISprite block = item.Sprite;
            if (block.Area(item.Location).Equals(collisionRectangle)) {
                return;
            }
            collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
            if (collisionRectangle.Width < collisionRectangle.Height
            && (KeyboardStatus.IsKeyDown(Keys.Right) || KeyboardStatus.IsKeyDown(Keys.Left)
            || KeyboardStatus.IsKeyDown(Keys.A) || KeyboardStatus.IsKeyDown(Keys.D)))
            {
                if (collisionRectangle.Right == block.Area(item.Location).Right)
                {
                    Mario.LocationX += collisionRectangle.Width + 1;
                }
                else if (collisionRectangle.Left == block.Area(item.Location).Left)
                {
                    Mario.LocationX -= (collisionRectangle.Width + 1);
                }
                collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
                if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
                {
                    Mario.LocationY += collisionRectangle.Height + 5;
                    block.CollisionSprite();
                    item.BecomeUsed();
                }
                else if (collisionRectangle.Top == block.Area(item.Location).Top)
                {
                    //Mario.GroundedStatus = true;
                    Mario.LocationY -= collisionRectangle.Height + 5;
                    //Mario.JumpStatus = false;
                    mario.ResetVelocity();
                }
            }
            else
            {
                if (collisionRectangle.Top == block.Area(item.Location).Top)
                {
                    Mario.GroundedStatus = true;
                    Mario.LocationY -= (collisionRectangle.Height + 5);
                    Mario.JumpStatus = false;
                    mario.ResetVelocity();
                }
                else if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
                {
                    Mario.LocationY += collisionRectangle.Height;
                    block.CollisionSprite();
                    item.BecomeUsed();
                }

                collisionRectangle = Rectangle.Intersect(mario.Area(), block.Area(item.Location));
                if (collisionRectangle.Right == block.Area(item.Location).Right)
                {
                    Mario.LocationX += collisionRectangle.Width;
                }
                else if (collisionRectangle.Left == block.Area(item.Location).Left)
                {
                    Mario.LocationX -= collisionRectangle.Width;
                }
            }
        }

    }
}
