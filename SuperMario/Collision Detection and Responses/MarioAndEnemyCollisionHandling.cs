using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.MarioClass;

namespace SuperMario.Collision_Detection_and_Responses
{
    class MarioAndEnemyCollisionHandling
    {
        

        public static void HandleCollision(IMario mario, IEnemy item)
        {
            
            ISprite enemy = item.Sprite;

            Rectangle collisionRectangle = Rectangle.Intersect(mario.Area(), enemy.Area(item.Location));
            if (collisionRectangle.Bottom == enemy.Area(item.Location).Bottom && collisionRectangle.Width > collisionRectangle.Height)
            {
                CollideBottom( mario,  item,  collisionRectangle);
            }
            else if (collisionRectangle.Top == enemy.Area(item.Location).Top && collisionRectangle.Width > collisionRectangle.Height)
            {
                CollideTop(mario, item, collisionRectangle);

            }
            else if (collisionRectangle.Right == enemy.Area(item.Location).Right)
            {
                CollideRight(mario, item, collisionRectangle);
            }
            else if (collisionRectangle.Left == enemy.Area(item.Location).Left)
            {
                CollideLeft(mario, item, collisionRectangle);
            }

        }




       static void  CollideBottom(IMario mario, IEnemy item, Rectangle collisionRectangle)
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
            else if (item.CanAttack)
            {

                if (Mario.StarStatus)
                {
                    item.GetKilled();
                    item.CanAttack = false;
                }
            }

        }

        static void CollideTop(IMario mario, IEnemy item, Rectangle collisionRectangle)
        {
            Mario.LocationY -= collisionRectangle.Height + 1;
            item.GetKilled();
            item.CanAttack = false;
        }

        static void CollideRight(IMario mario, IEnemy item, Rectangle collisionRectangle)
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
        static void CollideLeft(IMario mario, IEnemy item, Rectangle collisionRectangle)
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
