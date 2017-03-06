using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace SuperMario.Interfaces
{
    public interface IMarioState
    {
        void Update(GameTime GameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);

    }
}
