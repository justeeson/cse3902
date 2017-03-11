using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    public class EnemyAndEnemyCollisionHandling
    {
        public static void HandleCollision(IEnemy enemy, IEnemy item)
        {
            Rectangle collisionRectangle;
            ISprite block = item.Sprite;
            
                collisionRectangle = Rectangle.Intersect(enemy.Sprite.Area(enemy.Location), block.Area(item.Location));
                if (collisionRectangle.Bottom == block.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + collisionRectangle.Height+1);
                }
                else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
                {
                    enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y - (collisionRectangle.Height+1));
                    enemy.isFalling = false;
                }

                if (collisionRectangle.Right == block.Area(item.Location).Right)
                {
                    enemy.Location = new Vector2(enemy.Location.X + collisionRectangle.Width + 1, enemy.Location.Y);
                    enemy.movingLeft = !enemy.movingLeft;
                    item.movingLeft = !item.movingLeft;
                }
                else if (collisionRectangle.Left == block.Area(item.Location).Left)
                {
                    enemy.Location = new Vector2(enemy.Location.X - (collisionRectangle.Width + 1), enemy.Location.Y);
                    enemy.movingLeft = !enemy.movingLeft;
                    item.movingLeft = !item.movingLeft;
            }

          

        }

    }
}
