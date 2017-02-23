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
        public Vector2 position;
        static public CreateLevel LoadLevelFromFile(String filename)
        {
            CreateLevel level = null;
            filename = String.Concat("Content/", filename);
            using (StreamReader stream = new StreamReader(filename))
            {
                stream.ReadLine();
            }
            return level;
        }

        public void LoadLevel(StreamReader stream, Game1 game)
        {
            String tag;
            XmlReader reader = XmlReader.Create("Level.xml");
            while (reader.Read()){
                if (reader.HasAttributes)
                {
                    position.X = Int32.Parse(reader.GetAttribute("x"));
                    position.Y = Int32.Parse(reader.GetAttribute("y"));
                    switch (reader.Name)
                    {
                        case "Goomba":
                            break;
                        case "Koopa":
                            break;
                        case "SolidBrick":
                            break;
                        case "HiddenBlock":
                            break;
                        case "QuestionBlock":
                            break;
                        case "BreakableCurlyBrick":
                            break;
                        case "BreakableHorizontalBrick":
                            break;
                        case "SolidBrickWithCrews":
                            break;
                        case "UsedBlock":
                            break;
                        case "Pipe":
                            break;
                        case "Coin":
                            break;
                        case "Flower":
                            break;
                        case "GrownupMushroom":
                            break;
                        case "FireMushroom":
                            break;
                        case "Star":
                            break;
                        default:
                            break;
                    }
                }
            }
        }
    }
}