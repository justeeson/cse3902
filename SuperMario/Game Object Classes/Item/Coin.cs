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
        public Game1 MyGame { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 Location { get; set; }

        public Coin(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateCoin();
            MyGame.sprite = this.Sprite;
            Rectangle = new Rectangle(200, 160, 4, 8);
            Location = location;
        }

        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public Rectangle Area()
        {
            return Rectangle;
        }

        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.coinTexture);
            //MyGame.store.arrayOfSprites[2] = Sprite;
            this.Rectangle = new Rectangle();
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, Location);
        }
    }
}
