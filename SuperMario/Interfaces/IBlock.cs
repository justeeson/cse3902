using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public interface IBlock
    {
        ISprite Sprite { get; set; }
        Game1 MyGame { get; set; }
        Rectangle Area { get; set; }
        Vector2 Location { get; set; }

        void Update(GameTime GameTime);
        void BrickToDisappear();
        void HiddenToUsed();
        void BecomeUsed();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
