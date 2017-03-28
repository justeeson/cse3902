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
        public bool MovingLeft { get; set; }
        public bool IsFalling { get; set; }
        public bool CanAttack { get; set; }
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        private bool dead;
        private int deadCounter = 10;

        public Koopa(Game1 game, Vector2 location)
        {
            MovingLeft = true;
            IsFalling = true;
            MyGame = game;
            Sprite = SpriteFactory.CreateKoopaMoveLeft();
            MyGame.Sprite = Sprite;
            CanAttack = true;
            this.Location = location;
        }
        public void GetKilled()
        {
            if (!dead)
            {
                this.Sprite = new GoombaBeingKilledSprite(SpriteFactory.koopaMoveLeftTexture, 4, 8);
                dead = true;
            }
        }
        public void ChangeDirection()
        {
            if (!MovingLeft)
            {
                this.Sprite = new KoopaMoveRightSprite(SpriteFactory.koopaMoveRightTexture, 4, 8);
            }
            else
            {
                this.Sprite = new KoopaMoveLeftSprite(SpriteFactory.koopaMoveLeftTexture, 4, 8);
            }

        }
        public void Update(GameTime GameTime)
        {
            if (Location.X - Camera.cameraPositionX < 0)
            {
                MovingLeft = !MovingLeft;
            }

            if (MovingLeft)
                Location = new Vector2(Location.X - 4, Location.Y);
            else
                Location = new Vector2(Location.X + 4, Location.Y);

            if (IsFalling)
                Location = new Vector2(Location.X, Location.Y + 4);

            if (dead)
            {
                deadCounter--;
            }
            if (deadCounter == 0)
            {
                Sprite = new CleanSprite(SpriteFactory.goombaTexture);
            }

            Sprite.Update(GameTime);

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.cameraPositionX, Location.Y));
        }
    }
}
