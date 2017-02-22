using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
   public class Koopa : IEnemy
    {
        private bool alive = true;
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Area { get; set; }
        public Koopa(Game1 game)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateKoopa();
            myGame.sprite = Sprite;
            Area = Sprite.Area();

        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void TakeDamage(IMario mario)
        {
            alive = false;
            this.Sprite = new KoopaDieSprite(SpriteFactory.koopaTexture, 4, 8);
            myGame.store.arrayOfSprites[1] = this.Sprite;

            this.Area = new Rectangle(120, 120, 4, 8);

        }
        public void AttackEnemy(IMario mario)
        {
            if (alive)
            {
                mario.Dead();
            }

        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(this.Area.X, this.Area.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
