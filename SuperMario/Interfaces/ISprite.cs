using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMario.Interfaces
{
    public interface ISprite
    {
        void Update(GameTime time);
        void Draw(SpriteBatch spriteBatch, Vector2 destination);
        void ChangeDirection();
    }
}
