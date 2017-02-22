using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    interface IItem
    {
        Rectangle Area();
        void UpdateCollision();
        void Draw(SpriteBatch spriteBatch, Vector2 location);

    }
}
