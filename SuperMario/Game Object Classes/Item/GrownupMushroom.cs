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
    public class GrownupMushroom : IItem
    {
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Rectangle { get; set; }
        public GrownupMushroom(Game1 game)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateGrowupMushroom();
            myGame.sprite = Sprite;
            Rectangle = new Rectangle(300, 160, 0, 0);

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
            this.Sprite = new CleanSprite(SpriteFactory.growupMushroomTexture);
            myGame.store.arrayOfSprites[5] = Sprite;
            this.Rectangle = new Rectangle();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }
    }
}
