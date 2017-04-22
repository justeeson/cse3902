using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SuperMario.Levels
{
    class LevelGenerator
    {
        private int floorX;
        private int floorY;
        private string[] enemyType;
        private string[] blockType;
        private string[] itemType;
        private static Random rnd = new Random();

        public LevelGenerator()
        {
            enemyType = new string[2] { "Goomba", "Koopa" };
            blockType = new string[8] { "QuestionBlock", "HorizontalBlock", "Pipe", "MediumPipe", "HighPipe", "PipeToUnderground", "hiddenBlock", "SolidBrick" };
            itemType = new string[] { "coin", "star", "firemushroom", "godMushroom", "flower" };
            createLevel();
        }

        public void createLevel()
        {
            floorX = -416;
            floorY = 448;
            XmlDocument doc = new XmlDocument();
            XmlNode docNode = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(docNode);

            XmlNode levelNode = doc.CreateElement("Level");
            doc.AppendChild(levelNode);
            while (floorY > 415)
            {
                while (floorX < 6760)
                {
                    XmlNode floorNode = doc.CreateElement("CurlyBrick");
                    XmlAttribute floorAttributeX = doc.CreateAttribute("x");
                    floorAttributeX.Value = floorX.ToString();
                    floorNode.Attributes.Append(floorAttributeX);
                    XmlAttribute floorAttributeY = doc.CreateAttribute("y");
                    floorAttributeY.Value = floorY.ToString();
                    floorNode.Attributes.Append(floorAttributeY);
                    levelNode.AppendChild(floorNode);
                    floorX += 32;
                }
                floorY -= 32;
                floorX = -416;
            }

            int limit = 10;
            for (int k = 1; k <= limit; k++)
            {
                int r = rnd.Next(1, 10);
                switch (enemyType[r % 2])
                {
                    case "Goomba":
                        floorX = rnd.Next((500 / limit) * 10 * k + 200, (500 / limit) * 10 * k + 700);
                        XmlNode goombaNode = doc.CreateElement("Goomba");
                        XmlAttribute goombaAttributeX = doc.CreateAttribute("x");
                        goombaAttributeX.Value = floorX.ToString();
                        goombaNode.Attributes.Append(goombaAttributeX);
                        XmlAttribute goombaAttributeY = doc.CreateAttribute("y");
                        goombaAttributeY.Value = "100";
                        goombaNode.Attributes.Append(goombaAttributeY);
                        levelNode.AppendChild(goombaNode);
                        break;
                    case "Koopa":
                        floorX = rnd.Next((500 / limit) * 10 * k + 200, (500 / limit) * 10 * k + 700);
                        XmlNode koopaNode = doc.CreateElement("Koopa");
                        XmlAttribute koopaAttributeX = doc.CreateAttribute("x");
                        koopaAttributeX.Value = floorX.ToString();
                        koopaNode.Attributes.Append(koopaAttributeX);
                        XmlAttribute koopaAttributeY = doc.CreateAttribute("y");
                        koopaAttributeY.Value = "100";
                        koopaNode.Attributes.Append(koopaAttributeY);
                        levelNode.AppendChild(koopaNode);
                        break;
                }
            }

            // Still working on it 
            limit = 20;
            for (int k = 1; k <= limit; k++)
            {
                int r = rnd.Next(1, 100);
                switch (blockType[r % 8])
                {
                    case "QuestionBlock":
                        floorX = rnd.Next((500 / limit) * 10 * k + 200, (500 / limit) * 10 * k + 700);
                        string itemName = itemType[r % 5];
                        XmlNode questionNode = doc.CreateElement("QuestionBlock");
                        XmlAttribute questionAttributeX = doc.CreateAttribute("x");
                        questionAttributeX.Value = floorX.ToString();
                        questionNode.Attributes.Append(questionAttributeX);
                        XmlAttribute questionAttributeY = doc.CreateAttribute("y");
                        questionAttributeY.Value = "280";
                        questionNode.Attributes.Append(questionAttributeY);
                        XmlAttribute questionAttributeItem = doc.CreateAttribute("item");
                        questionAttributeItem.Value = itemName;
                        questionNode.Attributes.Append(questionAttributeItem);
                        levelNode.AppendChild(questionNode);
                        break;
                    case "HorizontalBlock":
                        floorX = rnd.Next((500 / limit) * 10 * k + 200, (500 / limit) * 10 * k + 700);
                        XmlNode horizontalNode = doc.CreateElement("HorizontalBlock");
                        XmlAttribute horizontalAttributeX = doc.CreateAttribute("x");
                        horizontalAttributeX.Value = floorX.ToString();
                        horizontalNode.Attributes.Append(horizontalAttributeX);
                        XmlAttribute horizontalAttributeY = doc.CreateAttribute("y");
                        horizontalAttributeY.Value = "280";
                        horizontalNode.Attributes.Append(horizontalAttributeY);
                        levelNode.AppendChild(horizontalNode);
                        break;
                }
            }



            floorX = 5792;
            floorY = 384;
            for (int j = 1; j <= 9; j++)
            {
                for (int i = 1; i <= j; i++)
                {
                    XmlNode stairNode = doc.CreateElement("SolidBrick");
                    XmlAttribute stairAttributeX = doc.CreateAttribute("x");
                    stairAttributeX.Value = floorX.ToString();
                    stairNode.Attributes.Append(stairAttributeX);
                    XmlAttribute stairAttributeY = doc.CreateAttribute("y");
                    stairAttributeY.Value = floorY.ToString();
                    stairNode.Attributes.Append(stairAttributeY);
                    levelNode.AppendChild(stairNode);
                    floorY -= 32;
                }
                floorY = 384;
                floorX += 32;
            }

            XmlNode flagNode = doc.CreateElement("FlagPole");
            XmlAttribute flagAttributeX = doc.CreateAttribute("x");
            flagAttributeX.Value = "6275";
            flagNode.Attributes.Append(flagAttributeX);
            XmlAttribute flagAttributeY = doc.CreateAttribute("y");
            flagAttributeY.Value = "69";
            flagNode.Attributes.Append(flagAttributeY);
            levelNode.AppendChild(flagNode);

            XmlNode castleNode = doc.CreateElement("Castle");
            XmlAttribute castleAttributeX = doc.CreateAttribute("x");
            castleAttributeX.Value = "6400";
            castleNode.Attributes.Append(castleAttributeX);
            XmlAttribute castleAttributeY = doc.CreateAttribute("y");
            castleAttributeY.Value = "258";
            castleNode.Attributes.Append(castleAttributeY);
            levelNode.AppendChild(castleNode);

            XmlNode marioNode = doc.CreateElement("mario");
            XmlAttribute marioAttributeX = doc.CreateAttribute("x");
            marioAttributeX.Value = "250";
            castleNode.Attributes.Append(marioAttributeX);
            XmlAttribute marioAttributeY = doc.CreateAttribute("y");
            marioAttributeY.Value = "100";
            castleNode.Attributes.Append(marioAttributeY);
            levelNode.AppendChild(marioNode);

            //XmlTextWriter writer = new XmlTextWriter("../../../../Levels/Level1.xml", null);
            //writer.Formatting = Formatting.Indented;
            doc.Save(@"../../../../Levels/Level1.xml");
        }
    }
}
