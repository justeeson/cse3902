using System;
using System.Xml;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;
using SuperMario.Blocks;
using SuperMario.Blockclass;

namespace SuperMario.Levels
{
    public class LevelReader
    {
        Game1 MyGame;
        private Vector2 Location;
        public ILevel Level
        { get; set; }

        public LevelReader(ILevel level, Game1 game)
        {
            this.Level = level;
            MyGame = game;
        }

        public void Load(string fileName)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("../../../../Levels/" + fileName);
            XmlNodeList nodeList = xmlDoc.ChildNodes[1].ChildNodes;
            for (int i = 0; i < nodeList.Count; i++)
            {
                Location.X = Int32.Parse(nodeList[i].Attributes["x"].Value);
                Location.Y = Int32.Parse(nodeList[i].Attributes["y"].Value);
                switch (nodeList[i].Name)
                {
                    case "UsedBlock":
                        Level.BlockList.Add(new SolidBrickWithCrews(MyGame, Location));
                        break;
                    case "QuestionBlock":
                        Level.BlockList.Add(new QuestionMarkBrick(MyGame, Location, nodeList[i].Attributes["item"].Value));
                        break;
                    case "SolidBrick":
                        Level.BlockList.Add(new SolidBrick(MyGame, Location));
                        break;
                    case "HiddenBlock":
                        Level.BlockList.Add(new HiddenBrick(MyGame, Location, nodeList[i].Attributes["item"].Value));
                        break;
                    case "CurlyBrick":
                        Level.BlockList.Add(new BreakableCurlyBrick(MyGame, Location));
                        break;
                    case "HorizontalBlock":
                        Level.BlockList.Add(new BreakableHorizontalBrick(MyGame, Location));
                        break;
                    case "HorizontalBlockWithItem":
                        Level.BlockList.Add(new BreakableHorizontalBrick(MyGame, Location));
                        break;
                    case "Pipe":
                        Level.BlockList.Add(new Pipe(MyGame, Location));
                        break;
                    case "MediumPipe":
                        Level.BlockList.Add(new MediumPipe(MyGame, Location));
                        break;
                    case "HighPipe":
                        Level.BlockList.Add(new HighPipe(MyGame, Location));
                        break;
                    case "PipeToUnderground":
                        Level.BlockList.Add(new PipeToUnderground(MyGame, Location));
                        break;
                    case "UndergroundPipeToGround":
                        Level.BlockList.Add(new UndergroundPipeToGround(MyGame, Location));
                        break;
                    case "FlagPole":
                        Level.BlockList.Add(new FlagPole(MyGame, Location));
                        break;
                    case "Castle":
                        Level.BlockList.Add(new Castle(MyGame, Location));
                        break;
                    case "Sun":
                        Level.BlockList.Add(new Sun(MyGame, Location));
                        break;
                    case "Cannon":
                        Level.BlockList.Add(new Cannon(MyGame, Location));
                        break;
                    case "Goomba":
                        Level.EnemyList.Add(new Goomba(MyGame, Location));
                        break;
                    case "Koopa":
                        Level.EnemyList.Add(new Koopa(MyGame, Location));
                        break;
                    case "Nami":
                        Level.EnemyList.Add(new Nami(MyGame, Location));
                        break;
                    case "flower":
                        Level.ItemList.Add(new Flower(MyGame, Location));
                        break;
                    case "coin":
                        Level.ItemList.Add(new Coin(MyGame, Location));
                        break;
                    case "fireMushroom":
                        Level.ItemList.Add(new FireMushroom(MyGame, Location));
                        break;
                    case "grownupMushroom":
                        Level.ItemList.Add(new GrownupMushroom(MyGame, Location));
                        break;
                    case "star":
                        Level.ItemList.Add(new Star(MyGame, Location));
                        break;
                    case "godMushroom":
                        Level.ItemList.Add(new GodMushroom(MyGame, Location));
                        break;
                    case "Missle":
                        Level.EnemyList.Add(new Missle(MyGame, Location));
                        break;
                    case "drink":
                        Level.ItemList.Add(new EnergyDrink(MyGame, Location));
                        break;
                    case "mario":
                        MyGame.MarioSprite = new Mario(MyGame.Texture, 3, 12, Location);
                        Location.X = 0;
                        Location.Y = 0;
                        Level.BackgroundList.Add(new Background(MyGame, Location));
                        break;

                }
            }
        }
    }
}