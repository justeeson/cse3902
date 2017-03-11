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
        bool movingLeft { get; set; }
        bool isFalling { get; set; }
        bool canAttack { get; set; }
        Vector2 Location { get; set; }
        ISprite Sprite { get; set; }
        Game1 MyGame { get; set; }
        void Update(GameTime GameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
        void GetKilled();
        void ChangeDirection();
    }
}
