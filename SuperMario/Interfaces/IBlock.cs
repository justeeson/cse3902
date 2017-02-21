using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Interfaces
{
    public interface IBlock : IObject
    {
        ISprite Sprite { get; set; }
        Game1 Mygame { get; set; }
        Rectangle Area { get; set; }
        void Update();
        void BrickToDisappear();
        void HiddenToUsed();
        void BecomeUsed();
        void Draw(SpriteBatch spriteBatch, Vector2 location);
    }
}
