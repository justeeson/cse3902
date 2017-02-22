using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision_Detection_and_Responses
{
    class MarioAndEnemyCollisionHandling
    {
        Rectangle collisionRectangle;

        public void HandleCollision(IMario mario, ISprite enemy)
        {
            //if(mario.Area().Intersects(enemy.Area()))
            //{
            //    mario.Dead();
            //}
        }

    }
}
