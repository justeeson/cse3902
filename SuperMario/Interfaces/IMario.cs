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
        IMarioState State { get; set; }

        Texture2D Texture { get; set; }

        Rectangle Area();
        void Jump();
        void LookLeft();
        void LookRight();
        void LookDown();
        void MarioBigState();
        void MarioSmallState();
        void Dead();
        void MarioFireState();
        void Reset();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
