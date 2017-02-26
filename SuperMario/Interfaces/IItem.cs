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
        ISprite Sprite { get; set; }
        Game1 myGame { get; set; }
        Rectangle Rectangle { get; set; }
        Rectangle Area();
        void UpdateCollision();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
