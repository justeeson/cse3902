using SuperMario.Game_Object_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMario.Interfaces;

namespace SuperMario
{
    public class BlockLogic : IBlock
    {
        Game1 mygame;
        bool isHidden = false;
        public BlockLogic(Game1 game)
        {
            mygame = game;
        }

        public void BrickToDisappear()
        {
           new SolidBrick(mygame);
           Game1.listOfObjects[11] = mygame.sprite;
        }

        public void HiddenToUsed()
        {
            new HiddenBrick(mygame);
            Game1.listOfObjects[13] = mygame.sprite;
        }

        public void BecomeUsed()
        {
            new QuestionMarkBrickToUsed(mygame);
            Game1.listOfObjects[9] = mygame.sprite;
        }
    }
}
