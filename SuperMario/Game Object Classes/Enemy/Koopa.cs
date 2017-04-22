using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SuperMario
{
   public class Koopa : IEnemy
    {
        public bool MovingLeft { get; set; }
        public bool IsFalling { get; set; }
        public bool CanAttack { get; set; }
        private MouseState mouseState;
        private Point mousePoint;
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        private bool dead;
        private int deadCounter = 10;
        private bool playDeathSoundEffect;
        private bool shell;
        public Koopa(Game1 game, Vector2 location)
        {
            MovingLeft = true;
            IsFalling = true;
            MyGame = game;
            Sprite = SpriteFactory.CreateKoopaMoveLeft();
            MyGame.Sprite = Sprite;
            CanAttack = true;
            this.Location = location;
            playDeathSoundEffect = false;
            shell = false;
            dead = false;

        }
        public void GetKilled(bool killedBySmashed)
        {
            if (!dead)
            {
                this.Sprite = new GoombaBeingKilledSprite(SpriteFactory.koopaMoveLeftTexture, 8);
                dead = true;
                if (killedBySmashed)
                {
                    MyGame.PlayerStat.SetScoreValue(600);
                }
                else
                {
                    MyGame.PlayerStat.SetScoreValue(200);
                }
            }
        }
        public void ChangeDirection()
        {
            if (!MovingLeft)
            {
                this.Sprite = new KoopaMoveRightSprite(SpriteFactory.koopaMoveRightTexture, 8);
            }
            else
            {
                this.Sprite = new KoopaMoveLeftSprite(SpriteFactory.koopaMoveLeftTexture, 8);
            }

        }
        public void Update(GameTime gameTime)
        {
            mouseState = Game1.GetInstance.MouseState;
            mousePoint = new Point(mouseState.X + Camera.CameraPositionX, mouseState.Y);
            if (Sprite.Area(Location).Contains(mousePoint) && Mario.GodStatus)
            {
                this.GetKilled(true);
                this.CanAttack = false;
                Game1Utility.BoltSoundEffect.Play();
            }

            if (Location.X < 50)
            {
                MovingLeft = false;
                ChangeDirection();

            }

            if (MovingLeft)
                Location = new Vector2(Location.X - 2, Location.Y);
            else
                Location = new Vector2(Location.X + 2, Location.Y);

            if (IsFalling)
                Location = new Vector2(Location.X, Location.Y + 2);

            if (dead)
            {
                if (playDeathSoundEffect == false)
                {
                    playDeathSoundEffect = true;
                    Game1Utility.GoombaStompSoundEffect.Play();
                }
                deadCounter--;
            }
            if (deadCounter == 0)
            {
                Sprite = new CleanSprite(SpriteFactory.koopaMoveLeftTexture);
            }
            Sprite.Update(gameTime);

        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
        }
    }
}
