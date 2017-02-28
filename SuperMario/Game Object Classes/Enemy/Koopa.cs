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
        public bool canAttack { get; set; }
        public ISprite Sprite { get; set; }
        public Game1 myGame { get; set; }
        public Vector2 location { get; set; }
        public Rectangle Area { get; set; }
       
        public Koopa(Game1 game, Vector2 location)
        {
            myGame = game;
            Sprite = SpriteFactory.CreateKoopa();
            myGame.sprite = Sprite;
            canAttack = true;
            this.location = location;
        }

        public void Update(GameTime gameTime)
        {
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(this.Area.X, this.Area.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
