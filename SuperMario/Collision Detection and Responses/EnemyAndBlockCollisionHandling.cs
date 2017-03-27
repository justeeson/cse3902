using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    public class EnemyAndBlockCollisionHandling
    {
        public static void HandleCollision(IEnemy enemy, IBlock item)
        {
            Rectangle collisionRectangle;
            ISprite block = item.Sprite;
            /*if (enemy.Location.X - Camera.cameraPositionX  < 5)
            {
                enemy.movingLeft = false;
            }
            else if (enemy.Location.X - Camera.cameraPositionX > Game1.xMax - 5)
            {
                enemy.movingLeft = true;
            }*/
                

            collisionRectangle = Rectangle.Intersect(enemy.Sprite.Area(enemy.Location), block.Area(item.Location));
            if(collisionRectangle.Width > collisionRectangle.Height)
            {
                if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + collisionRectangle.Height + 2);
                }
                else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y - (collisionRectangle.Height + 2));
                    enemy.isFalling = false;
                }

                collisionRectangle = Rectangle.Intersect(enemy.Sprite.Area(enemy.Location), block.Area(item.Location));
                if (collisionRectangle.Right == block.Area(item.Location).Right)
                {
                    enemy.Location = new Vector2(enemy.Location.X + collisionRectangle.Width + 1, enemy.Location.Y);
                    enemy.movingLeft = false;
                    enemy.ChangeDirection();
                }
                else if (collisionRectangle.Left == block.Area(item.Location).Left)
                {
                    enemy.Location = new Vector2(enemy.Location.X - (collisionRectangle.Width + 1), enemy.Location.Y);
                    enemy.movingLeft = true;
                    enemy.ChangeDirection();
                }
            }
            else
            {
                if (collisionRectangle.Right == block.Area(item.Location).Right)
                {
                    enemy.Location = new Vector2(enemy.Location.X + collisionRectangle.Width + 1, enemy.Location.Y);
                    enemy.movingLeft = false;
                    enemy.ChangeDirection();
                }
                else if (collisionRectangle.Left == block.Area(item.Location).Left)
                {
                    enemy.Location = new Vector2(enemy.Location.X - (collisionRectangle.Width + 1), enemy.Location.Y);
                    enemy.movingLeft = true;
                    enemy.ChangeDirection();
                }
                collisionRectangle = Rectangle.Intersect(enemy.Sprite.Area(enemy.Location), block.Area(item.Location));
                
                if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + collisionRectangle.Height + 2);
                }
                else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y - (collisionRectangle.Height + 2));
                    enemy.isFalling = false;
                }

            }

        }

    }
}
