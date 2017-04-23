using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class EnemyAndEnemyCollisionHandling
    {
        public static void HandleCollision(IEnemy enemy, IEnemy item)
        {   if (!(enemy is Missle) && !(enemy is Octopus) && !(enemy is Nami) && !(item is Missle) && !(item is Octopus) && !(item is Nami))
            {
                ISprite block = item.Sprite;
                Rectangle collisionRectangle = Rectangle.Intersect(enemy.Sprite.Area(enemy.Location), block.Area(item.Location));
                if (collisionRectangle.Bottom == block.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + collisionRectangle.Height + 1);
                }
                else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y - (collisionRectangle.Height + 1));
                    enemy.IsFalling = false;
                }

                else if (collisionRectangle.Right == enemy.Sprite.Area(enemy.Location).Right)
                {
                    enemy.Location = new Vector2(enemy.Location.X - (collisionRectangle.Width + 0), enemy.Location.Y);
                    enemy.MovingLeft = true;
                    item.MovingLeft = false;
                    enemy.ChangeDirection();
                    item.ChangeDirection();
                }
                else if (collisionRectangle.Left == enemy.Sprite.Area(enemy.Location).Left)
                {
                    enemy.Location = new Vector2(enemy.Location.X + (collisionRectangle.Width + 0), enemy.Location.Y);
                    enemy.MovingLeft = false;
                    item.MovingLeft = true;
                    enemy.ChangeDirection();
                    item.ChangeDirection();
                }

            }

        }

    }
}
