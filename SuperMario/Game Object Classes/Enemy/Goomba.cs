using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class Goomba : IEnemy
    {
        public bool canAttack { get; set; }
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Vector2 location { get; set; }
        public Rectangle Area { get; set; }

        public Goomba(Game1 game, Vector2 location)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateGoomba();
            canAttack = true;
            this.location = location;
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
