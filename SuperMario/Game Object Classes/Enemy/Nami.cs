using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMario.Collision_Detection_and_Responses;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperMario
{
    public class Nami : IEnemy
    {
        public bool MovingLeft { get; set; }
        public bool CanAttack { get; set; }
        public bool IsFalling { get; set; }
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        public int CameraPositionX { get; set; }
        private bool up;
        public Nami(Game1 game, Vector2 location)
        {
            MovingLeft = true;
            IsFalling = true;
            MyGame = game;
            Sprite = SpriteFactory.CreateNami();
            CanAttack = true;
            Location = location;
            up = true;
        }
        public void GetKilled(bool killedBySmashed)
        {
           
        }
        public void ChangeDirection()
        {
            

        }
        public void Update(GameTime gameTime)
        {   if(Location.Y < 100) { up = false; }            
            else if(Location.Y > 400) { up = true;}
            if (up) { Location = new Vector2(Location.X, Location.Y - 2); }
            else { Location = new Vector2(Location.X, Location.Y + 2); }               
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
           
        }
    }

}
