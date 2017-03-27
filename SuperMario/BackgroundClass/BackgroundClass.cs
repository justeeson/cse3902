using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SuperMario
{
    public class Background : IBackground
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        public Background(Game1 game, Vector2 location)
        {
            this.MyGame = game;
            this.Sprite = SpriteFactory.CreateBackground();
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
            int marioLocation = Mario.LocationX;
            location = new Vector2(marioLocation+location.X, location.Y);
            Sprite.Draw(spriteBatch, this.Location);
        }

    }
}
