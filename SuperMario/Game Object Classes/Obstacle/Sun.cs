using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using SuperMario.Collision_Detection_and_Responses;
using Microsoft.Xna.Framework.Input;
using System;

namespace SuperMario
{
    public class Sun : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Vector2 Location { get; set; }
        public Rectangle Area { get; set; }
        private bool MovingLeft { get; set; }
        private int count;
        private const int maxCount = 50;
        public Sun(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateSun();
            Location = location;
            count = 0;
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

            count++;
            if (count == maxCount)
            {
                MyGame.World.Level.EnemyList.Add(new Octopus(MyGame, Location));
                count = 0;
            }
            Sprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, new Vector2(Location.X - Camera.CameraPositionX, Location.Y));
           
        }

        public void BrickToDisappear()
        {}

        public void HiddenToUsed()
        {}

        public void BecomeUsed()
        {}
    }

}
