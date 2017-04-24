using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class EnemyAndBlockCollisionHandling
    {
        public static void HandleCollision(IEnemy enemy, IBlock item)
        {
           
            ISprite block = item.Sprite;
            Rectangle collisionRectangle = Rectangle.Intersect(enemy.Sprite.Area(enemy.Location), block.Area(item.Location));
            if (!(enemy is Missle) && !(enemy is Octopus) && !(enemy is Nami))
            {
                if (collisionRectangle.Width > collisionRectangle.Height)
                {
                    HeightGreaterThanWidth(enemy, item, collisionRectangle, block);
                }
                else
                {
                    WidthGreaterThanHeight(enemy, item, collisionRectangle, block);

                }
            }

        }
        private static void HeightGreaterThanWidth(IEnemy enemy, IBlock item, Rectangle collisionRectangle, ISprite block)
        {
            if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
            {
                enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + collisionRectangle.Height+3);
            }
            else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
            {
                enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y - (collisionRectangle.Height + 3));
                enemy.IsFalling = false;
            }

            collisionRectangle = Rectangle.Intersect(enemy.Sprite.Area(enemy.Location), block.Area(item.Location));
            if (collisionRectangle.Right == block.Area(item.Location).Right)
            {
                enemy.MovingLeft = false;
                enemy.ChangeDirection();
                enemy.Location = new Vector2(enemy.Location.X + collisionRectangle.Width, enemy.Location.Y);
            }
            else if (collisionRectangle.Left == block.Area(item.Location).Left)
            {
                enemy.MovingLeft = true;
                enemy.ChangeDirection();
                enemy.Location = new Vector2(enemy.Location.X - (collisionRectangle.Width), enemy.Location.Y);
            }

        }
        private static void WidthGreaterThanHeight(IEnemy enemy, IBlock item, Rectangle collisionRectangle, ISprite block)
        {
            if (collisionRectangle.Right == block.Area(item.Location).Right)
            {
                enemy.MovingLeft = false;
                enemy.ChangeDirection();
                enemy.Location = new Vector2(enemy.Location.X + collisionRectangle.Width, enemy.Location.Y);
            }
            else if (collisionRectangle.Left == block.Area(item.Location).Left)
            {
                enemy.MovingLeft = true;
                enemy.ChangeDirection();
                enemy.Location = new Vector2(enemy.Location.X - (collisionRectangle.Width), enemy.Location.Y);
            }
            collisionRectangle = Rectangle.Intersect(enemy.Sprite.Area(enemy.Location), block.Area(item.Location));

            if (collisionRectangle.Bottom == block.Area(item.Location).Bottom)
            {
                enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y + collisionRectangle.Height + 3);
            }
            else if (collisionRectangle.Top == block.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
            {
                enemy.Location = new Vector2(enemy.Location.X, enemy.Location.Y - (collisionRectangle.Height + 3));
                enemy.IsFalling = false;
            }

        }

    }
}
