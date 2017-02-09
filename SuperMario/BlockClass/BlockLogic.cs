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
            //Game1.listOfObjects = ObjectArray.Instance.ArrayOfObjectsX(mygame);
            if (!isHidden)
            {
                new SolidBrick(mygame);
                Game1.listOfObjects[11] = mygame.sprite;
            }

            isHidden = true;
        }

        public void HiddenToUsed()
        {
            //Game1.listOfObjects = ObjectArray.Instance.ArrayOfObjectsC(mygame);
            if(isHidden)
            {
                new BreakableHorizontalBrickToUsed(mygame);
                Game1.listOfObjects[11] = mygame.sprite;
            }

            isHidden = false;
        }

        public void BecomeUsed()
        {
            //Game1.listOfObjects = ObjectArray.Instance.ArrayOfObjectsZ(mygame);
            new QuestionMarkBrickToUsed(mygame);
            Game1.listOfObjects[9] = mygame.sprite;
        }
    }
}
