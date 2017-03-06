using System;
using System.Xml;
using Microsoft.Xna.Framework;

namespace SuperMario.Levels
{
    public class LevelReader
    {
        Game1 MyGame;
        public Vector2 location;
        public LevelClass level;

        public LevelReader(LevelClass level, Game1 game)
        {
            this.level = level;
            MyGame = game;
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
                    case "solidblockwithcrews":
                        LevelClass.BlockList.Add(new SolidBrickWithCrews(MyGame, location));
                        break;
                    case "questionBlock":
                        LevelClass.BlockList.Add(new QuestionMarkBrick(MyGame, location));
                        break;
                    case "solidbrick":
                        LevelClass.BlockList.Add(new SolidBrick(MyGame, location));
                        break;
                    case "hiddenBlock":
                        LevelClass.BlockList.Add(new HiddenBrick(MyGame, location));
                        break;
                    case "BreakableCurlyBrick":
                        LevelClass.BlockList.Add(new BreakableCurlyBrick(MyGame, location));
                        break;
                    case "horizontalblock":
                        LevelClass.BlockList.Add(new BreakableHorizontalBrick(MyGame, location));
                        break;
                    case "pipe":
                        LevelClass.BlockList.Add(new Pipe(MyGame, location));
                        break;

                    case "goomba":
                        LevelClass.EnemyList.Add(new Goomba(MyGame, location));
                        break;
                    case "koopa":
                        LevelClass.EnemyList.Add(new Koopa(MyGame, location));
                        break;

                    case "flower":
                        LevelClass.ItemList.Add(new Flower(MyGame, location));
                        break;
                    case "coin":
                        LevelClass.ItemList.Add(new Coin(MyGame, location));
                        break;
                    case "fireMushroom":
                        LevelClass.ItemList.Add(new FireMushroom(MyGame, location));
                        break;
                    case "GrownupMushroom":
                        LevelClass.ItemList.Add(new GrownupMushroom(MyGame, location));
                        break;
                    case "star":
                        LevelClass.ItemList.Add(new Star(MyGame, location));
                        break;

                }
            }

            /*XmlReader reader = XmlReader.Create("Level1");
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "solidBrickWithCrews"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new SolidBrickWithCrews(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "solidBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new SolidBrick(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "questionMarkBlock"))
                {

                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new QuestionMarkBrick(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "questionMarkBrickToUsed"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new QuestionMarkBrickToUsed(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "breakableCurlyBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new BreakableCurlyBrick(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "breakableHorizontalBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new BreakableHorizontalBrick(MyGame, location));
                    }
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "hiddenBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new HiddenBrick(MyGame, location));
                    }
                }


                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "pipe"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Pipe(MyGame, location));
                    }
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "goomba"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.EnemyList.Add(new Goomba(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "koopa"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.EnemyList.Add(new Koopa(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "flower"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new Flower(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "coin"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new Coin(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "fireMushroom"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new FireMushroom(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "grownupMushroom"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new GrownupMushroom(MyGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "star"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new Star(MyGame, location));
                    }
                }
            }*/
        }
    }
}