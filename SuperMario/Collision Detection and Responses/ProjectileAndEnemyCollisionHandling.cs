using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;

namespace SuperMario.Collision_Detection_and_Responses
{
    public static class ProjectileAndEnemyCollisionHandling
    {
        public static void HandleCollision(IEnemy enemy, IProjectile ball)
        {
            enemy.GetKilled();
            enemy.CanAttack = false;
            ball.KillFireball();
        }

    }
}
