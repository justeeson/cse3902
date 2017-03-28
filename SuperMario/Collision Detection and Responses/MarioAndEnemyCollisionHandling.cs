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

            collisionRectangle = Rectangle.Intersect(mario.Area(), enemy.Area(item.Location));
            if (collisionRectangle.Bottom == enemy.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
            {
                Mario.LocationY += collisionRectangle.Height + 1;
                if (item.CanAttack && !Mario.StarStatus && !Mario.InvulnStatus)
                {
                    if (mario.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Fire)
                    {
                        mario.MarioBigState();
                        Mario.Invulnerability();
                    }
                    else if (mario.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Big)
                    {
                        mario.MarioSmallState();
                        Mario.Invulnerability();
                    }
                    else
                    {
                        mario.Dead();
                    }
                }
                else if(item.CanAttack)
                {
                    
                    if (Mario.StarStatus)
                    {
                        item.GetKilled();
                        item.CanAttack = false;
                    }
                }
            }
            else if (collisionRectangle.Top == enemy.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
            {
                Mario.LocationY -= collisionRectangle.Height + 1;
                item.GetKilled();
                item.CanAttack = false;
            }
            else if (collisionRectangle.Right == enemy.Area(item.Location).Right)
            {
                item.MovingLeft = true;
                Mario.LocationX += collisionRectangle.Width + 1;
                if (item.CanAttack && !Mario.StarStatus && !Mario.InvulnStatus)
                {
                    if (mario.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Fire)
                    {
                        mario.MarioBigState();
                        Mario.Invulnerability();
                    }
                    else if (mario.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Big)
                    {
                        mario.MarioSmallState();
                        Mario.Invulnerability();
                    }
                    else
                    {
                        mario.Dead();
                    }
                }
                else if (item.CanAttack)
                {

                    if (Mario.StarStatus)
                    {
                        item.GetKilled();
                        item.CanAttack = false;
                    }
                }
            }
            else if (collisionRectangle.Left == enemy.Area(item.Location).Left)
            {
                item.MovingLeft = false;
                Mario.LocationX -= collisionRectangle.Width + 1;
                if (item.CanAttack && !Mario.StarStatus && !Mario.InvulnStatus)
                {
                    if (mario.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Fire)
                    {
                        mario.MarioBigState();
                        Mario.Invulnerability();
                    }
                    else if (mario.StateMachine.MarioMode == (int)MarioStateMachine.MarioModes.Big)
                    {
                        mario.MarioSmallState();
                        Mario.Invulnerability();
                    }
                    else
                    {
                        mario.Dead();
                    }
                }
                else if (item.CanAttack)
                {

                    if (Mario.StarStatus)
                    {
                        item.GetKilled();
                        item.CanAttack = false;
                    }
                }
            }
        }

    }
}
