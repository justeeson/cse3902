using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMario.Collision_Detection_and_Responses;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperMario
{
    public class Missle : IEnemy
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
        public Missle(Game1 game, Vector2 location)
        {
            MovingLeft = true;
            IsFalling = true;
            MyGame = game;
            Sprite = SpriteFactory.CreateGoomba();
            CanAttack = true;
            playDeathSoundEffect = false;
            Location = location;
        }
        public void GetKilled(bool killedBySmashed)
        {
           
        }
        public void ChangeDirection()
        {
            

        }
        public void Update(GameTime GameTime)
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
                Location = new Vector2(Location.X - 4, Location.Y);
            else
                Location = new Vector2(Location.X + 4, Location.Y);

            if (IsFalling)
                Location = new Vector2(Location.X, Location.Y + 4);

            
            Sprite.Update(GameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
           
        }
    }

}
