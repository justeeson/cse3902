using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario
{
    public class Pipe : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 Location { get; set; }

        public Pipe(Game1 game, Vector2 location)
        {
            MyGame = game;
            Sprite = SpriteFactory.CreatePipe();
            MyGame.sprite = Sprite;
            this.Location = location;
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
        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            Sprite.Draw(spriteBatch, Location);
        }
    }
}
