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
        bool MovingLeft { get; set; }
        bool IsFalling { get; set; }
        bool CanAttack { get; set; }
        Vector2 Location { get; set; }
        ISprite Sprite { get; set; }
        Game1 MyGame { get; set; }
        void Update(GameTime GameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void GetKilled(bool killedBySmashed);
        void ChangeDirection();
    }
}
