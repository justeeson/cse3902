using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    class MarioAndEnemyCollisionHandling
    {
        

        public static void HandleCollision(IMario mario, IEnemy item)
        {
            Rectangle collisionRectangle;
            ISprite enemy = item.Sprite;

            collisionRectangle = Rectangle.Intersect(mario.Area(), enemy.Area(item.Location));
            if (collisionRectangle.Bottom == enemy.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
            {
                Mario.LocationY += collisionRectangle.Height + 1;
                if (item.canAttack && !Mario.StarStatus && !Mario.InvulnStatus)
                {
                    if (Mario.MarioMode == (int)Mario.MarioModes.Fire)
                    {
                        mario.MarioBigState();
                        Mario.Invulnerability();
                    }
                    else if (Mario.MarioMode == (int)Mario.MarioModes.Big)
                    {
                        mario.MarioSmallState();
                        Mario.Invulnerability();
                    }
                    else
                    {
                        mario.Dead();
                    }
                }
                else if(item.canAttack)
                {
                    
                    if (Mario.StarStatus)
                    {
                        item.GetKilled();
                        item.canAttack = false;
                    }
                }
            }
            else if (collisionRectangle.Top == enemy.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
            {
                Mario.LocationY -= collisionRectangle.Height + 1;
                item.GetKilled();
                item.canAttack = false;
            }
            else if (collisionRectangle.Right == enemy.Area(item.Location).Right)
            {
                Mario.LocationX += collisionRectangle.Width + 1;
                if (item.canAttack && !Mario.StarStatus && !Mario.InvulnStatus)
                {
                    if (Mario.MarioMode == (int)Mario.MarioModes.Fire)
                    {
                        mario.MarioBigState();
                        Mario.Invulnerability();
                    }
                    else if (Mario.MarioMode == (int)Mario.MarioModes.Big)
                    {
                        mario.MarioSmallState();
                        Mario.Invulnerability();
                    }
                    else
                    {
                        mario.Dead();
                    }
                }
                else if (item.canAttack)
                {

                    if (Mario.StarStatus)
                    {
                        item.GetKilled();
                        item.canAttack = false;
                    }
                }
            }
            else if (collisionRectangle.Left == enemy.Area(item.Location).Left)
            {
                Mario.LocationX -= collisionRectangle.Width + 1;
                if (item.canAttack && !Mario.StarStatus && !Mario.InvulnStatus)
                {
                    if (Mario.MarioMode == (int)Mario.MarioModes.Fire)
                    {
                        mario.MarioBigState();
                        Mario.Invulnerability();
                    }
                    else if (Mario.MarioMode == (int)Mario.MarioModes.Big)
                    {
                        mario.MarioSmallState();
                        Mario.Invulnerability();
                    }
                    else
                    {
                        mario.Dead();
                    }
                }
                else if (item.canAttack)
                {

                    if (Mario.StarStatus)
                    {
                        item.GetKilled();
                        item.canAttack = false;
                    }
                }
            }
        }

    }
}
