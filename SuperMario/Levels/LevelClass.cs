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
    public class LevelClass
    {
        public Game1 MyGame;
        public static List<IItem> ItemList = new List<IItem>();
        public static List<IEnemy> EnemyList = new List<IEnemy>();
        public static List<IBlock> BlockList = new List<IBlock>();
        public static List<IBackground> BackgroundList = new List<IBackground>();
        public static IMario Player;
        public Camera camera;

        public LevelReader Loader;
        private int count = 0;

        public LevelClass(Game1 game)
        {
            MyGame = game;
            Loader = new LevelReader(this, game);

        }
        public void Load()
        {
            Loader.Load();
        }

        public void Reset()
        {
            ItemList.Clear();
            EnemyList.Clear();
            BlockList.Clear();
            BackgroundList.Clear();
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

    }
}