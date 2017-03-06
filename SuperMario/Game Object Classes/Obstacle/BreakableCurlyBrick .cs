using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class BreakableCurlyBrick : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 location { get; set; }

        public BreakableCurlyBrick(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateBreakableCurlyBrick();
            MyGame.sprite = Sprite;
            this.location = location;

        }
        public void BrickToDisappear()
        {
            new SolidBrick(MyGame, location);
        }
        public void HiddenToUsed()
        {
        }
        public void BecomeUsed()
        {
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(this.Area.X, this.Area.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
