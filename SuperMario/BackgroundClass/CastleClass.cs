using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMario
{
    public class Castle : IBackground
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        public Castle(Game1 game, Vector2 location)
        {
            this.MyGame = game;
            this.Sprite = SpriteFactory.CreateCastle();
            this.Location = location;
        }

        public void Used()
        {

        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, this.Location);
        }

    }
}
