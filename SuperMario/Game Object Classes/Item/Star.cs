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
        public Game1 MyGame { get; set; }
        public Rectangle Rectangle { get; set; }
        public Vector2 Location { get; set; }

        public Star(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateStar();
            MyGame.sprite = Sprite;
            Rectangle = new Rectangle(500, 160, 4, 8);
            this.Location = location;
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
            this.Sprite = new CleanSprite(SpriteFactory.starTexture);
            this.Rectangle = new Rectangle();
            //MyGame.store.arrayOfSprites[6] = Sprite;
            Mario.StarPowerUp();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            //location = new Vector2(location.X, location.Y);
            Sprite.Draw(spriteBatch, Location);
        }
    }
}
