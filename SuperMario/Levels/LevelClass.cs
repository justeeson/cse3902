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
    class LevelClass
    {
        public Game1 myGame;
        public List<IItem> ItemList = new List<IItem>();
        public List<IEnemy> EnemyList = new List<IEnemy>();
        public List<IBlock> BlockList = new List<IBlock>();
        public List<IBackground> BackgroundList = new List<IBackground>();

        public LevelReader loader;
        private int count = 0;
        public LevelClass(Game1 game)
        {
            myGame = game;
            loader = new LevelReader(this, game);

        }
        public void Load()
        {
            loader.Loader();
        }

        public void Update(GameTime gameTime)
        {
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Update(gameTime);
            }
            foreach (IBlock block in BlockList)
            {
                block.Update(gameTime);
            }
            foreach (IItem item in ItemList)
            {
                item.Update(gameTime);

            }
            foreach (IBackground background in BackgroundList)
            {
                background.Update(gameTime);
            }
        }
        public void Draw(Vector2 location)
        {
            foreach (IBackground background in BackgroundList)
            {
                background.Draw(myGame.spriteBatch, location);
            }
            foreach (IItem item in ItemList)
            {
                item.Draw(myGame.spriteBatch, location);
            }
            foreach (IBlock block in BlockList)
            {
                block.Draw(myGame.spriteBatch, location);
            }
            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Draw(myGame.spriteBatch, location);
            }
        }
    }
}