using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.Interfaces;
using SuperMario.Game_Object_Classes;
using System.Xml;
using Microsoft.Xna.Framework;

namespace SuperMario.Levels
{
    class LevelReader
    {
        Game1 myGame;
        public Vector2 location;
        public LevelClass level;

        public LevelReader(LevelClass level, Game1 game)
        {
            this.level = level;
            myGame = game;
        }

        public void Loader()
        {
            XmlReader reader = XmlReader.Create("Level.xml");
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "solidBrickWithCrews"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new SolidBrickWithCrews(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "solidBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new SolidBrick(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "questionMarkBlock"))
                {

                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new QuestionMarkBrick(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "questionMarkBrickToUsed"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new QuestionMarkBrickToUsed(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "breakableCurlyBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new BreakableCurlyBrick(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "breakableHorizontalBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new BreakableHorizontalBrick(myGame, location));
                    }
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "hiddenBrick"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new HiddenBrick(myGame, location));
                    }
                }


                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "pipe"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.BlockList.Add(new Pipe(myGame, location));
                    }
                }

                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "goomba"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.EnemyList.Add(new Goomba(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "koopa"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.EnemyList.Add(new Koopa(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "flower"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new Flower(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "coin"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new Coin(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "fireMushroom"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new FireMushroom(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "grownupMushroom"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new GrownupMushroom(myGame, location));
                    }
                }
                else if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "star"))
                {
                    if (reader.HasAttributes)
                    {
                        location.X = Int32.Parse(reader.GetAttribute("x"));
                        location.Y = Int32.Parse(reader.GetAttribute("y"));
                        level.ItemList.Add(new Star(myGame, location));
                    }
                }
            }
        }
    }
}