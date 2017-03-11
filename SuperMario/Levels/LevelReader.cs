using System;
using System.Xml;
using Microsoft.Xna.Framework;

namespace SuperMario.Levels
{
    public class LevelReader
    {
        Game1 MyGame;
        public Vector2 Location;
        public LevelClass Level;
        public enum Itemtype { Star, Coin, GreenMushroom, RedMushroom, Flower };

        public LevelReader(LevelClass level, Game1 game)
        {
            this.Level = level;
            MyGame = game;
        }

        public void Load()
        {
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
            xmlDoc.Load("../../../../Levels/level2.xml");
            XmlNodeList nodeList = xmlDoc.ChildNodes[1].ChildNodes;
            for(int i = 0; i < nodeList.Count; i++)
            {
                Location.X = Int32.Parse(nodeList[i].Attributes["x"].Value);
                Location.Y = Int32.Parse(nodeList[i].Attributes["y"].Value);
                switch (nodeList[i].Name)
                {
                    case "usedblock":
                        LevelClass.BlockList.Add(new SolidBrickWithCrews(MyGame, Location));
                        break;
                    case "questionBlock":
                        LevelClass.BlockList.Add(new QuestionMarkBrick(MyGame, Location));
                        break;
                    case "solidbrick":
                        LevelClass.BlockList.Add(new SolidBrick(MyGame, Location));
                        break;
                    case "hiddenBlock":
                        LevelClass.BlockList.Add(new HiddenBrick(MyGame, Location));
                        break;
                    case "BreakableCurlyBrick":
                        LevelClass.BlockList.Add(new BreakableCurlyBrick(MyGame, Location));
                        break;
                    case "horizontalblock":
                        LevelClass.BlockList.Add(new BreakableHorizontalBrick(MyGame, Location));
                        break;
                    case "pipe":
                        LevelClass.BlockList.Add(new Pipe(MyGame, Location));
                        break;

                    case "goomba":
                        LevelClass.EnemyList.Add(new Goomba(MyGame, Location));
                        break;
                    case "koopa":
                        LevelClass.EnemyList.Add(new Koopa(MyGame, Location));
                        break;

                    case "flower":
                        LevelClass.ItemList.Add(new Flower(MyGame, Location));
                        break;
                    case "coin":
                        LevelClass.ItemList.Add(new Coin(MyGame, Location));
                        break;
                    case "fireMushroom":
                        LevelClass.ItemList.Add(new FireMushroom(MyGame, Location));
                        break;
                    case "GrownupMushroom":
                        LevelClass.ItemList.Add(new GrownupMushroom(MyGame, Location));
                        break;
                    case "star":
                        LevelClass.ItemList.Add(new Star(MyGame, Location));
                        break;

                    case "mario":
                        MyGame.MarioSprite = new Mario(MyGame.texture, 3, 12, Location);
                        break;

                }
            }
        }
    }
}