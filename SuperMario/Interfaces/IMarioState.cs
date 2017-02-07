using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario.Interfaces
{
    interface IMarioState
    {
        void Update();
        void Grow();
        void Draw(SpriteBatch spriteBatch, Vector2 location);

    }
}
