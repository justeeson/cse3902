using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Interfaces
{
    public interface IItem
    {
        bool MovingLeft { get; set; }
        bool IsFalling { get; set; }
        ISprite Sprite { get; set; }
        Game1 MyGame { get; set; }
        bool HasBeenUsed { get; set; }
        Vector2 Location { get; set; }
        Rectangle Area();
        void UpdateCollision();
        void Update(GameTime GameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
