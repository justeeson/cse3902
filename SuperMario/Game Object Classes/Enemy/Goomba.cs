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
    public class Goomba : IEnemy
    {
        private bool alive = false;
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Rectangle Area { get; set; }

        public Goomba(Game1 game)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateGoomba();
            myGame.sprite = Sprite;
        }
        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }
        public void TakeDamage(IMario mario)
        {
            if (alive)
            {
                mario.Dead();
            }
        }
        public void AttackEnemy()
        {
            alive = true;
           // this.Sprite = new GoombaSprite(myGame.enemies);
            this.Area = new Rectangle(120, 120, 32, 28);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(this.Area.X, this.Area.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }

}
