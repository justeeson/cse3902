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
    public class Star : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 location { get; set; }

        public Star(Game1 game, Vector2 location)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateStar();
            myGame.sprite = Sprite;
            Rectangle = new Rectangle(500, 160, 4, 8);
            this.location = location;
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public Rectangle Area()
        {
            return Rectangle;
        }
        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.starTexture);
            this.Rectangle = new Rectangle();
            //myGame.store.arrayOfSprites[6] = Sprite;
            Mario.StarPowerUp();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(location.X, location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
