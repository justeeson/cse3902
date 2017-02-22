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
    public class Flower : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Rectangle { get; set; }
        public Flower(Game1 game)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateFlower();
            myGame.sprite = Sprite;
            Rectangle = new Rectangle(100, 160, 0, 0);

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
            this.Sprite = new CleanSprite(SpriteFactory.flowerTexture);
            myGame.store.arrayOfSprites[4] = Sprite;
            this.Rectangle = new Rectangle();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }
    }
}
