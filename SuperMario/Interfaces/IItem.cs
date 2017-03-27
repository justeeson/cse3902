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
        bool movingLeft { get; set; }
        bool isFalling { get; set; }
        ISprite Sprite { get; set; }
        Game1 MyGame { get; set; }
        bool hasBeenUsed { get; set; }
        Vector2 Location { get; set; }
        Rectangle Area();
        void UpdateCollision();
        void Update(GameTime GameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
