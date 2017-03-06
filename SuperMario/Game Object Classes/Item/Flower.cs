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
        public Game1 MyGame { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 location { get; set; }

        public Flower(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateFlower();
            MyGame.sprite = Sprite;
            Rectangle = new Rectangle(100, 160, 4, 8);
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
            this.Sprite = new CleanSprite(SpriteFactory.flowerTexture);
            //MyGame.store.arrayOfSprites[4] = Sprite;
            MyGame.Mario.MarioFireState();
            this.Rectangle = new Rectangle();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(location.X, location.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
