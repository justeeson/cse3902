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
        public Game1 myGame;
        public ISprite Sprite;
        public int locationX, locationY;

        public Rectangle Rectangle { get; set; }
        public Coin(Game1 game)
        {
            myGame = game;
            this.Sprite = SpriteFactory.CreateCoin();
            myGame.sprite = this.Sprite;
            Rectangle = new Rectangle(200, 160, 10, 15);

        }

        public void Update()
        {
            Sprite.Update(myGame.gameTime);
        }
        public Rectangle Area()
        {
            return Rectangle;
        }

        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.coinTexture);
            this.Rectangle = new Rectangle();
        }

        public void destroyItem()
        {
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }
    }
}
