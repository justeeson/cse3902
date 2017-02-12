using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    public interface IMario
    {
        IMarioState state { get; set; }

        Texture2D Texture { get; set; }

        void LookLeft();
        void LookRight();
        void Jump();
        void Crouch();
        void MarioBigState();
        void MarioSmallState();
        void Dead();
        void MarioFireState();
        void Reset();
        void Update();
        void Draw(SpriteBatch spriteBatch, Vector2 destination);
    }
}
