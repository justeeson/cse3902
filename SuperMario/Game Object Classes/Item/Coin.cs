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
        public bool HasBeenUsed { get; set; }
        public Vector2 Location { get; set; }
        public bool MovingLeft { get; set; }
        public bool IsFalling { get; set; }

        public Coin(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateCoin();
            MyGame.Sprite = this.Sprite;
            HasBeenUsed = false;
            Location = location;
        }

        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public Rectangle Area()
        {
            if (HasBeenUsed)
                return new Rectangle(0, 0, 0, 0);
            else
                return Sprite.Area(Location);
        }

        public void UpdateCollision()
        {
            this.Sprite = new CleanSprite(SpriteFactory.coinTexture);
            //MyGame.store.arrayOfSprites[2] = Sprite;
            HasBeenUsed = true;
            MyGame.PlayerStat.SetCoinValue();
            MyGame.PlayerStat.SetScoreValue(200);

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.cameraPositionX, Location.Y));
        }
    }
}
