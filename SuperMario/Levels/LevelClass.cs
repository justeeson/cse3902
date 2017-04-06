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
    public class LevelClass : ILevel
    {
        public Game1 MyGame { get; set; }
        public List<IItem> ItemList { get; set; }
        public List<IEnemy> EnemyList { get; set; }
        public List<IBlock> BlockList { get; set; }
        public List<IBackground> BackgroundList { get; set; }
        public Camera Camera;
        public LevelReader Reader;
        private string currentFileName;

        public LevelClass(Game1 game, string fileName)
        {
            MyGame = game;
            ItemList = new List<IItem>();
            EnemyList = new List<IEnemy>();
            BlockList = new List<IBlock>();
            BackgroundList = new List<IBackground>();
            Reader = new LevelReader(this, game);
            currentFileName = fileName;
        }
        public void Load()
        {
            Reader.Load(currentFileName);
            SortBlocks(BlockList);
        }

        public void Reset()
        {
            ItemList.Clear();
            EnemyList.Clear();
            BlockList.Clear();
            BackgroundList.Clear();
        }

        public void SortBlocks(List<IBlock> list)
        {
            for (int i = (list.Count - 1); i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (list.ElementAt(j - 1).Location.Y > list.ElementAt(j).Location.Y)
                    {
                        IBlock temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;

                    }
                }
            }
        }


        public void Update(GameTime GameTime)
        {

            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Update(GameTime);
            }

            foreach (IBlock block in BlockList)
            {
                block.Update(GameTime);
            }
            foreach (IItem item in ItemList)
            {
                item.Update(GameTime);

            }
            foreach (IBackground background in BackgroundList)
            {
                background.Update(GameTime);
            }
        }
        public void Draw(Vector2 location)
        {
            foreach (IBackground background in BackgroundList)
            {
                background.Draw(MyGame.SpriteBatch, location);
            }
            foreach (IItem item in ItemList)
            {
                item.Draw(MyGame.SpriteBatch, location);
            }
            foreach (IBlock block in BlockList)
            {
                block.Draw(MyGame.SpriteBatch, location);
            }

            foreach (IEnemy enemy in EnemyList)
            {
                enemy.Draw(MyGame.SpriteBatch, location);
            }
        }

        public void addFlower(Vector2 location)
        {
            ItemList.Add(new Flower(MyGame, location));
        }
        public void addMushroom(Vector2 location)
        {
            ItemList.Add(new GrownupMushroom(MyGame, location));
        }
        public void addFireMushroom(Vector2 location)
        {
            ItemList.Add(new FireMushroom(MyGame, location));
        }
        public void addCoin(Vector2 location)
        {
            ItemList.Add(new Coin(MyGame, location));
        }
        public void addStar(Vector2 location)
        {
            ItemList.Add(new Star(MyGame, location));
        }

        public void ReturnGround()
        {
        }
    }
}