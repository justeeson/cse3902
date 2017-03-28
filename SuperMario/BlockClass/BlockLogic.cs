using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class BlockLogic : IBlock
    {
        public ISprite Sprite { get; set; }
        public Game1 MyGame { get; set; }
        public Rectangle Area { get; set; }
        public Vector2 Location { get; set; }

        public BlockLogic(Game1 game)
        {
            MyGame = game;
        }
        public void Update(GameTime GameTime)
        {
            Sprite.Update(GameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
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
    }
}
