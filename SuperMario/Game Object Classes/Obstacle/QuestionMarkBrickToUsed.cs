using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class QuestionMarkBrickToUsed : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 location { get; set; }

        public QuestionMarkBrickToUsed(Game1 game, Vector2 location)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateSolidBrickWithCrews3();
            myGame.sprite = Sprite;
            this.location = location;
        }
        public void BrickToDisappear()
        {
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
            location = new Vector2(location.X, location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
