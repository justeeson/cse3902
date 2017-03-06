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
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
       
        public Koopa(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateKoopa();
            MyGame.sprite = Sprite;
            canAttack = true;
            this.Location = location;
        }

        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(this.Area.X, this.Area.Y);
            Sprite.Draw(spriteBatch, location);
        }
    }
}
