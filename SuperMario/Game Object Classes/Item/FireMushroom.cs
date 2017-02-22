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
    public class FireMushroom : IItem
    {
        private Game1 myGame;
        public ISprite Sprite;
        public Rectangle Rectangle { get; set; }

        public FireMushroom(Game1 game)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateFireMushroom();
            myGame.sprite = Sprite;
            Rectangle = new Rectangle(400, 160, 0, 8);

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
            this.Sprite = new CleanSprite(SpriteFactory.fireMushroomTexture);
            myGame.store.arrayOfSprites[3] = Sprite;
            myGame.Mario.MarioFireState();
            this.Rectangle = new Rectangle();
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }
    }
}
