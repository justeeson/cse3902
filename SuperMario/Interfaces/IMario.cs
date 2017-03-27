using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.MarioClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    public interface IMario
    {
        IMarioState State { get; set; }
        Texture2D Texture { get; set; }
        MarioStateMachine StateMachine { get; }
        Rectangle Area();
        bool isDead();
        void Jump();
        void LookLeft();
        void LookRight();
        void LookDown();
        void MarioBigState();
        void MarioSmallState();
        void Dead();
        void MarioFireState();
        void Reset();
        void ResetVelocity();
        void Fire();
        void Run();
        void Update(GameTime GameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
