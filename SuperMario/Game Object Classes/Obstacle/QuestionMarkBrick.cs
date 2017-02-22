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
    public class QuestionMarkBrick : IBlock
    {
        private Game1 myGame;
        public ISprite Sprite;

        public QuestionMarkBrick(Game1 game)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateQuestionMarkBrick();
            myGame.sprite = Sprite;
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, location);
        }
    }
}
