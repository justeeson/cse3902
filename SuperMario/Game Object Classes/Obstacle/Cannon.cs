using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Blocks
{
    public class Cannon : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 Location { get; set; }
        private int missleCounter;
        private const int missleMax =500;
        public Cannon(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreateCannon();
            MyGame.Sprite = Sprite;
            this.Location = location;
            missleCounter = 0;
        }

        public void BrickToDisappear()
        {
        }
        public void HiddenToUsed()
        {
        }
        public void BecomeUsed()
        {
        }
        public void Update(GameTime gameTime)
        {
            missleCounter++;
            if (missleCounter == missleMax)
            {
                MyGame.World.Level.EnemyList.Add(new Missle(MyGame, new Vector2(Location.X, Location.Y)));
                missleCounter = 0;
            }
            Sprite.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            location = new Vector2(Location.X - Camera.CameraPositionX, Location.Y);
            Sprite.Draw(spriteBatch, location);
        }

    }
}
