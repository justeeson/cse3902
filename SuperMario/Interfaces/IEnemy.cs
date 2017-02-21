using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public interface IEnemy : IObject
    {
        ISprite Sprite { get; set; }
        Game1 myGame { get; set; }
        Rectangle Area { get; set; }
        void Update(GameTime gameTime);
        void TakeDamage(IMario mario);
        void AttackEnemy();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
