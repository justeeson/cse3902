using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Collision_Detection_and_Responses
{
    class MarioAndEnemyCollisionHandling
    {
        

        public static void HandleCollision(IMario mario, IEnemy item)
        {
            Rectangle collisionRectangle;
            ISprite enemy = item.Sprite;

            collisionRectangle = Rectangle.Intersect(mario.Area(), enemy.Area());
            if (collisionRectangle.Bottom == enemy.Area().Bottom && collisionRectangle.Width > collisionRectangle.Height)
            {
                Mario.locationY += collisionRectangle.Height + 1;

                if (item.canAttack)
                {
                    mario.Dead();
                }
            }
            else if (collisionRectangle.Top == enemy.Area().Top && collisionRectangle.Width > collisionRectangle.Height)
            {
                Mario.locationY -= collisionRectangle.Height + 1;
                enemy.CollisionSprite();
                item.canAttack = false;
            }
            else if (collisionRectangle.Right == enemy.Area().Right)
            {
                Mario.locationX += collisionRectangle.Width + 1;

                if (item.canAttack)
                {
                    mario.Dead();
                }
            }
            else if (collisionRectangle.Left == enemy.Area().Left)
            {
                Mario.locationX -= collisionRectangle.Width + 1;
                if (item.canAttack)
                {
                    mario.Dead();
                }
            }
        }

    }
}
