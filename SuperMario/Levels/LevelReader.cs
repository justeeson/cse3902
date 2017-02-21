using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMario.MarioClass;
using SuperMario.Interfaces;
using SuperMario.Game_Object_Classes;

namespace SuperMario.Levels
{
    class LevelReader
    {
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
            List<IEnemy> enemies = new List<IEnemy>();
            List<IBlock> blocks = new List<IBlock>();
            List<IItem> items = new List<IItem>();
            Mario mario = null;


            String tag;

            stream.ReadLine(); //should be <level>
            while ((tag = stream.ReadLine()) != null && !tag.Equals("</level>"))
            {
                string[] words = tag.Split(' ');
                int? xpos = null;
                int? ypos = null;

                String type = "";
                for (int wordsCount = 1; wordsCount < words.Length; wordsCount++)
                {
                    if (words[wordsCount].Length >= 6)
                    {
                        if (words[wordsCount].Substring(0, 5).Equals("type="))
                        {
                            type = words[wordsCount].Substring(5).Trim('"').ToLower();
                        }
                        else if (words[wordsCount].Substring(0, 5).Equals("xpos="))
                        {
                            xpos = Int32.Parse(words[wordsCount].Substring(5).Trim('"'));
                        }
                        else if (words[wordsCount].Substring(0, 5).Equals("ypos="))
                        {
                            ypos = Int32.Parse(words[wordsCount].Substring(5).Trim('"'));
                        }
                    }
                }
                switch (type.Trim('"'))
                {
                    case "Goomba":
                        enemies.Add(new Goomba(game));
                        break;
                    case "Koopa":
                        enemies.Add(new Koopa(game));
                        break;
                    case "SolidBrick":
                        blocks.Add(new SolidBrick(game));
                        break;
                    case "HiddenBlock":
                        blocks.Add(new HiddenBrick(game));
                        break;
                    case "QuestionBlock":
                        blocks.Add(new QuestionMarkBrick(game));
                        break;
                    case "BreakableCurlyBrick":
                        blocks.Add(new BreakableCurlyBrick(game));
                        break;
                    case "BreakableHorizontalBrick":
                        blocks.Add(new BreakableHorizontalBrick(game));
                        break;
                    case "SolidBrickWithCrews":
                        blocks.Add(new SolidBrickWithCrews(game));
                        break;
                    case "UsedBlock":
                        blocks.Add(new QuestionMarkBrickToUsed(game));
                        break;
                    case "Pipe":
                        blocks.Add(new Pipe(game));
                        break;
                    case "Coin":
                        items.Add(new Coin(game));
                        break;
                    case "Flower":
                        items.Add(new Flower(game));
                        break;
                    case "GrownupMushroom":
                        items.Add(new GrownupMushroom(game));
                        break;
                    case "FireMushroom":
                        items.Add(new FireMushroom(game));
                        break;
                    case "Star":
                        items.Add(new Star(game));
                        break;
                    default:
                        break;
                }
            }
        }
    }
}