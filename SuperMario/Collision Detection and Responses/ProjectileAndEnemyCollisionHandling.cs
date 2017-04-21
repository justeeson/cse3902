using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class ProjectileAndEnemyCollisionHandling
    {
        public static void HandleCollision(IEnemy enemy, IProjectile ball)
        {
            if (!(enemy is Missle) && !(enemy is Octopus) && !(enemy is Nami))
            {
                enemy.GetKilled(false);
                enemy.CanAttack = false;
                ball.KillFireball();
            }
        }

    }
}
