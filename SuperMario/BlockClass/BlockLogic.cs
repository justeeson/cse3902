using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class BlockLogic : IBlock
    {
        Game1 mygame;
        public BlockLogic(Game1 game)
        {
            mygame = game;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            throw new NotImplementedException();
        }

        //public void BrickToDisappear()
        //{
        //   new SolidBrick(mygame);
        //   Game1.listOfObjects[11] = mygame.sprite;
        //}

        //public void HiddenToUsed()
        //{
        //    new HiddenBrick(mygame);
        //    Game1.listOfObjects[13] = mygame.sprite;
        //}

        //public void BecomeUsed()
        //{
        //    new QuestionMarkBrickToUsed(mygame);
        //    Game1.listOfObjects[9] = mygame.sprite;
        //}
    }
}
