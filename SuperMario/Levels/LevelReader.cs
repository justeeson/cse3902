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
            xmlDoc.Load("../../../../Levels/Level.xml");
            XmlNodeList nodeList = xmlDoc.ChildNodes[1].ChildNodes;
            for(int i = 0; i < nodeList.Count; i++)
            {
                Location.X = Int32.Parse(nodeList[i].Attributes["x"].Value);
                Location.Y = Int32.Parse(nodeList[i].Attributes["y"].Value);
                switch (nodeList[i].Name)
                {
                    case "UsedBlock":
                        LevelClass.BlockList.Add(new SolidBrickWithCrews(MyGame, Location));
                        break;
                    case "QuestionBlock":
                        LevelClass.BlockList.Add(new QuestionMarkBrick(MyGame, Location));
                        break;
                    case "SolidBrick":
                        LevelClass.BlockList.Add(new SolidBrick(MyGame, Location));
                        break;
                    case "HiddenBlock":
                        LevelClass.BlockList.Add(new HiddenBrick(MyGame, Location));
                        break;
                    case "CurlyBrick":
                        LevelClass.BlockList.Add(new BreakableCurlyBrick(MyGame, Location));
                        break;
                    case "HorizontalBlock":
                        LevelClass.BlockList.Add(new BreakableHorizontalBrick(MyGame, Location));
                        break;
                    case "HorizontalBlockWithItem":
                        // This Block need more implementation
                        LevelClass.BlockList.Add(new BreakableHorizontalBrick(MyGame, Location));
                        break;
                    case "Pipe":
                        LevelClass.BlockList.Add(new Pipe(MyGame, Location));
                        break;
                    case "MediumPipe":
                        // TO DO: This need to be medium pipe instead of short
                        LevelClass.BlockList.Add(new Pipe(MyGame, Location));
                        break;
                    case "HighPipe":
                        // TO DO: This need to be high pipe instead of short
                        LevelClass.BlockList.Add(new Pipe(MyGame, Location));
                        break;
                    case "FlagPole":
                        // TO DO: This need to be FlagPole

                    case "Castle":
                        // TO DO: This need to be Castle

                    case "Goomba":
                        LevelClass.EnemyList.Add(new Goomba(MyGame, Location));
                        break;
                    case "Koopa":
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
                    case "grownupMushroom":
                        LevelClass.ItemList.Add(new GrownupMushroom(MyGame, Location));
                        break;
                    case "star":
                        LevelClass.ItemList.Add(new Star(MyGame, Location));
                        break;
                    
                    case "mario":
                        MyGame.MarioSprite = new Mario(MyGame.texture, 3, 12, Location);
                        Location.X = 0;
                        Location.Y = 0;
                        LevelClass.BackgroundList.Add(new Background(MyGame, Location));
                        break;

                }
            }
        }
    }
}