using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario.Levels
{
    public class UnderGroundWorld : ILevel
    {
        public Game1 MyGame { get; set; }
        public Collection<IItem> ItemList { get;}
        public Collection<IEnemy> EnemyList { get;}
        public Collection<IBlock> BlockList { get; }
        public IBlock[] BlockListLeftFacingOrder { get; set; }
        public IBlock[] BlockListRightFacingOrder { get; set; }
        public Collection<IBackground> BackgroundList { get;}
        public LevelReader Reader
        { get; set; }
        private ILevel underLevel;
        private string currentFileName;
        public UnderGroundWorld(Game1 game, ILevel level, string fileName)
        {
            this.MyGame = game;
            ItemList = new Collection<IItem>();
            EnemyList = new Collection<IEnemy>();
            BlockList = new Collection<IBlock>();
            BackgroundList = new Collection<IBackground>();
            Reader = new LevelReader(this, game);
            currentFileName = fileName;
            underLevel = level;
            Camera.SetPositionZero();

        }
        public void Load()
        {
            this.Reader.Load(currentFileName);

            BlockListLeftFacingOrder = new IBlock[BlockList.Count];
            BlockListRightFacingOrder = new IBlock[BlockList.Count];

            BlockList.CopyTo(BlockListLeftFacingOrder, 0);
            BlockList.CopyTo(BlockListRightFacingOrder, 0);

            SortBlocksFacingLeft(BlockListLeftFacingOrder);
            SortBlocksFacingRight(BlockListRightFacingOrder);
        }

        public void SortBlocksFacingRight(IBlock[] list)
        {
            for (int i = (list.Length - 1); i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (list.ElementAt(j - 1).Location.X + 800 * list.ElementAt(j - 1).Location.Y >
                        list.ElementAt(j).Location.X + 800 * list.ElementAt(j).Location.Y)
                    {
                        IBlock temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;

                    }
                }
            }
        }

        
        public void SortBlocksFacingLeft(IBlock[] list)
        {
            for (int i = (list.Length - 1); i >= 0; i--)
            {
                for (int j = 1; j <= i; j++)
                {
                    if (list.ElementAt(j - 1).Location.X + 800 * (480 - list.ElementAt(j - 1).Location.Y) >
                        list.ElementAt(j).Location.X + 800 * (480 - list.ElementAt(j).Location.Y))
                    {
                        IBlock temp = list[j - 1];
                        list[j - 1] = list[j];
                        list[j] = temp;

                    }
                }
            }
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
        public void Reset()
        {
            ItemList.Clear();
            EnemyList.Clear();
            BlockList.Clear();
            BackgroundList.Clear();
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

        public void addEnergyDrink(Vector2 location)
        {
            ItemList.Add(new EnergyDrink(MyGame, location));
        }
        public void addGodMushroom(Vector2 location)
        {
            ItemList.Add(new GodMushroom(MyGame, location));
        }
        public void addStar(Vector2 location)
        {
            ItemList.Add(new Star(MyGame, location));
        }
        public void ReturnGround()
        {
            MyGame.World.Level = underLevel;
        }
    }
}
