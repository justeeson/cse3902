using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class BlockLogic : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 location { get; set; }

        public BlockLogic(Game1 game)
        {
            myGame = game;
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }

        public void BrickToDisappear()
        {
           //new SolidBrick(myGame);
        }

        public void HiddenToUsed()
        {
           //new HiddenBrick(myGame);
        }

        public void BecomeUsed()
        {
            //new QuestionMarkBrickToUsed(myGame);
        }
    }
}
