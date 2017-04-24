using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMario.Collision_Detection_and_Responses;
using Microsoft.Xna.Framework.Input;
using System;

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
        private MouseState mouseState;
        private Point mousePoint;
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
        public void GetKilled(bool killedBySmashed)
        {
            if (!dead)
            {
                this.Sprite = new GoombaBeingKilledSprite(SpriteFactory.goombaTexture,8);
                dead = true;
                if (killedBySmashed) {
                    MyGame.PlayerStat.SetScoreValue(600 * MarioAndEnemyCollisionHandling.ConsecutiveBonusPoint);
                }
                else
                {
                    MyGame.PlayerStat.SetScoreValue(200);
                }
            }
        }
        public void ChangeDirection()
        {
            if (MovingLeft)
                Location = new Vector2(Location.X - 2, Location.Y-1);
            else
                Location = new Vector2(Location.X + 2, Location.Y-1);
        }
        public void Update(GameTime gameTime)
        {
            mouseState = Game1.GetInstance.MouseState;
            mousePoint = new Point(mouseState.X + Camera.CameraPositionX, mouseState.Y);    
            if(Sprite.Area(Location).Contains(mousePoint) && Mario.GodStatus)
            {
                this.GetKilled(true);
                this.CanAttack = false;
                Game1Utility.BoltSoundEffect.Play();
            }
 
            if (Location.X < 50)
            {
                MovingLeft = false;
            }
    
            if (MovingLeft)
                Location = new Vector2(Location.X - 2, Location.Y);
            else
                Location = new Vector2(Location.X + 2, Location.Y);

            if (IsFalling)
                Location = new Vector2(Location.X, Location.Y + 2);

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
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
           
        }
    }

}
