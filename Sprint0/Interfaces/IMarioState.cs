using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Sprint0.Interfaces
{
    interface IMarioState
    {   void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location, Color color);
        void Jump();
        void Fall();
        void Left();
        void Crouch();
        void Idle();
        void Land();
        void BigMario();
        void SmallMario();
        void FireMario();
        void FireAbilityMario();
        void DeadMario();
    }
}
