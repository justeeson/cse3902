using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMario.Levels
{
    class CreateLevel
    {
        private IList<IItem> itemList;
        private IList<IEnemy> enemyList;
        private IList<IBlock> blockList;
        public Mario mario;

        public CreateLevel(IList<IItem> i, IList<IEnemy> e, IList<IBlock> b, Mario m)
        {
            itemList = i;
            enemyList = e;
            blockList = b;
            mario = m;
        }

        public void DrawDraw(SpriteBatch spriteBatch, Vector2 location)
        {
            foreach (IEnemy enemy in enemyList)
            {
                enemy.Draw(spriteBatch, location);
            }
            foreach (IItem item in itemList)
            {
                item.Draw(spriteBatch, location);
            }
            foreach (IBlock block in blockList)
            {
                block.Draw(spriteBatch, location);
            }

            mario.Draw(spriteBatch, location);
        }

        public void Update()
        {
            foreach (IEnemy enemy in enemyList)
            {
               // enemy.Update(gameTime);
            }
            foreach (IBlock block in blockList)
            {
                //block.Update(gameTime);
            }

            foreach (IItem item in itemList)
            {
              //  item.Update(gameTime);
            }
            //mario.Update(gameTime);
        }
    }
}