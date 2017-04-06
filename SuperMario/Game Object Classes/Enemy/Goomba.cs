using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace SuperMario
{
    public class Goomba : IEnemy
    {
        public bool MovingLeft { get; set; }
        public bool CanAttack { get; set; }
        public bool IsFalling { get; set; }
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        public int CameraPositionX { get; set; }
        private bool playDeathSoundEffect;
        private bool dead;
        private int deadCounter = 10;
        public Goomba(Game1 game, Vector2 location)
        {
            MovingLeft = true;
            IsFalling = true;
            MyGame = game;
            Sprite = SpriteFactory.CreateGoomba();
            CanAttack = true;
            playDeathSoundEffect = false;
            Location = location;
            dead = false;
        }
        public void GetKilled()
        {
            if (!dead)
            {
                this.Sprite = new GoombaBeingKilledSprite(SpriteFactory.goombaTexture,4,8);
                dead = true;
                MyGame.PlayerStat.SetScoreValue(400);
            }
        }
        public void ChangeDirection()
        {
            

        }
        public void Update(GameTime GameTime)
        {
            if (Location.X - Camera.CameraPositionX < 0)
            {
                MovingLeft = false;
                Location = new Vector2(Location.X + 2, Location.Y);
            }
    
            if (MovingLeft)
                Location = new Vector2(Location.X - 4, Location.Y);
            else
                Location = new Vector2(Location.X + 4, Location.Y);

            if (IsFalling)
                Location = new Vector2(Location.X, Location.Y + 4);

            if (dead)
            {
                if(playDeathSoundEffect == false)
                {
                    playDeathSoundEffect = true;
                    Game1Utility.GoombaStompSoundEffect.Play();
                }
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
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
        }
    }

}
