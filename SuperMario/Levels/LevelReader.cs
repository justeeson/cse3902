using System;
using System.Xml;
using Microsoft.Xna.Framework;

namespace SuperMario.Levels
{
    public class LevelReader
    {
        Game1 myGame;
        public Vector2 location;
        public LevelClass level;

        public LevelReader(LevelClass level, Game1 game)
        {
            this.level = level;
            myGame = game;
        }

        public void Load()
        {
            XmlDocument xmlDoc = new XmlDocument(); // Create an XML document object
            xmlDoc.Load("../../../../Levels/level1.xml");
            XmlNodeList nodeList = xmlDoc.ChildNodes[1].ChildNodes;
            for(int i = 0; i < nodeList.Count; i++)
            {
                location.X = Int32.Parse(nodeList[i].Attributes["x"].Value);
                location.Y = Int32.Parse(nodeList[i].Attributes["y"].Value);
                switch (nodeList[i].Name)
                {
                    case "solidbrickwithcrews":
                        LevelClass.BlockList.Add(new SolidBrickWithCrews(myGame, location));
                        break;
                    case "questionBlock":
                        LevelClass.BlockList.Add(new QuestionMarkBrick(myGame, location));
                        break;
                    case "solidbrick":
                        LevelClass.BlockList.Add(new SolidBrick(myGame, location));
                        break;
                    case "hiddenBlock":
                        LevelClass.BlockList.Add(new HiddenBrick(myGame, location));
                        break;
                    case "BreakableCurlyBrick":
                        LevelClass.BlockList.Add(new BreakableCurlyBrick(myGame, location));
                        break;
                    case "horizontalblock":
                        LevelClass.BlockList.Add(new BreakableHorizontalBrick(myGame, location));
                        break;
                    case "pipe":
                        LevelClass.BlockList.Add(new Pipe(myGame, location));
                        break;

                    case "goomba":
                        LevelClass.EnemyList.Add(new Goomba(myGame, location));
                        break;
                    case "koopa":
                        LevelClass.EnemyList.Add(new Koopa(myGame, location));
                        break;

                    case "flower":
                        LevelClass.ItemList.Add(new Flower(myGame, location));
                        break;
                    case "coin":
                        LevelClass.ItemList.Add(new Coin(myGame, location));
                        break;
                    case "fireMushroom":
                        LevelClass.ItemList.Add(new FireMushroom(myGame, location));
                        break;
                    case "GrownupMushroom":
                        LevelClass.ItemList.Add(new GrownupMushroom(myGame, location));
                        break;
                    case "star":
                        LevelClass.ItemList.Add(new Star(myGame, location));
                        break;

                }
            }
        }
    }
}