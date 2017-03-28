﻿using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;

namespace SuperMario.Collision_Detection_and_Responses
{
    public class ProjectileAndEnemyCollisionHandling
    {
        public static void HandleCollision(IEnemy enemy, MarioFireball ball)
        {
            enemy.GetKilled();
            enemy.canAttack = false;
            ball.KillFireball();
        }

    }
}
