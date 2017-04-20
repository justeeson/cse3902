using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMario.Collision_Detection_and_Responses;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperMario
{
    public class Sun : IEnemy
    {
        public bool MovingLeft { get; set; }
        public bool CanAttack { get; set; }
        public bool IsFalling { get; set; }
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        public int CameraPositionX { get; set; }
        public Sun(Game1 game, Vector2 location)
        {
            MovingLeft = true;
            IsFalling = true;
            MyGame = game;
            Sprite = SpriteFactory.CreateSun();
            CanAttack = true;
            Location = location;
        }
        public void GetKilled(bool killedBySmashed)
        {
           
        }
        public void ChangeDirection()
        {
            

        }
        public void Update(GameTime gameTime)
        {
            if (Location.X < 20)
            {
                MovingLeft = false;
            }
            if (Location.X > 5500)
            {
                MovingLeft = true;
            }
            if (MovingLeft)
                Location = new Vector2(Location.X - 5, Location.Y);
            else
                Location = new Vector2(Location.X + 5, Location.Y);
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
           
        }
    }

}
