using Microsoft.Xna.Framework;
using SuperMario.Command;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class MarioAndEnemyCollisionHandling
    {
        private static int consecutiveBonusPoint;
        public static int ConsecutiveBonusPoint
        { get { return consecutiveBonusPoint; } set { consecutiveBonusPoint = value; } }

        public static void HandleCollision(IMario mario, IEnemy item)
        {         
            ISprite enemy = item.Sprite;
            Rectangle collisionRectangle = Rectangle.Intersect(mario.Area(), enemy.Area(item.Location));
            if (collisionRectangle.Top == enemy.Area(item.Location).Top && collisionRectangle.Width + 2 > collisionRectangle.Height)
            {
                CollideTop(mario, item);

            }
            else if (collisionRectangle.Bottom == enemy.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
            {
                CollideBottom( mario,  item,  collisionRectangle);
            }
            else if (collisionRectangle.Right == enemy.Area(item.Location).Right)
            {
                CollideRight(mario, item, collisionRectangle);
                item.ChangeDirection();
            }
            else if (collisionRectangle.Left == enemy.Area(item.Location).Left)
            {
                CollideLeft(mario, item, collisionRectangle);
                item.ChangeDirection();
            }

        }




       private static void  CollideBottom(IMario mario, IEnemy item, Rectangle collisionRectangle)
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
            else if (item.CanAttack && !(item is Missle) && !(item is Octopus) && !(item is Nami))
            {

                if (Mario.StarStatus)
                {
                    item.GetKilled(false);
                    item.CanAttack = false;
                }
            }

        }

        private static void CollideTop(IMario mario,  IEnemy item)
        {   
            Mario.ResetVelocity();
            Mario.JumpStatus = false;
            Mario.GroundedStatus = false;
            if ((item is Missle) || (item is Octopus) || (item is Nami))
            {
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
               
            }
            else
            {
                item.GetKilled(true);
                item.CanAttack = false;

            }
            Mario.LocationY = (Mario.LocationY - 125);         
        }

        private static void CollideRight(IMario mario, IEnemy item, Rectangle collisionRectangle)
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
            else if (item.CanAttack && !(item is Missle) && !(item is Octopus) && !(item is Nami))
            {

                if (Mario.StarStatus)
                {
                    item.GetKilled(true);
                    ConsecutiveBonusPoint = ConsecutiveBonusPoint + 1;
                    item.CanAttack = false;
                }
            }
        }
        private static void CollideLeft(IMario mario, IEnemy item, Rectangle collisionRectangle)
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
            else if (item.CanAttack && !(item is Missle) && !(item is Octopus) && !(item is Nami))
            {

                if (Mario.StarStatus)
                {
                    item.GetKilled(false);
                    item.CanAttack = false;
                }
            }

        }
        public static void SetBonusPoint(bool var)
        {
            if (var == false)
            {
                ConsecutiveBonusPoint = 1;
            }
        }
       

    }
}
