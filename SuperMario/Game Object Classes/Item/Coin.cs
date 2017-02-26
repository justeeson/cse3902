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
    public class Coin : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Rectangle { get; set; }
        public static int LocationX;
        public static int LocationY;
        public Coin(Game1 game)
        {
            myGame = game;
            this.Sprite = SpriteFactory.CreateCoin();
            myGame.sprite = this.Sprite;
            Rectangle = new Rectangle(200, 160, 4, 8);

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
            this.Sprite = new CleanSprite(SpriteFactory.coinTexture);
            myGame.store.arrayOfSprites[2] = Sprite;
            this.Rectangle = new Rectangle();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(location.X, location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
