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
        public LevelGenerator()
        {

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
                doc.CreateWhitespace("\r\n\r\n");
                floorY -= 32;
                floorX = -416;
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
            marioAttributeX.Value = "6400";
            castleNode.Attributes.Append(marioAttributeX);
            XmlAttribute marioAttributeY = doc.CreateAttribute("y");
            marioAttributeY.Value = "258";
            castleNode.Attributes.Append(marioAttributeY);
            levelNode.AppendChild(marioNode);

            //XmlTextWriter writer = new XmlTextWriter("../../../../Levels/Level1.xml", null);
            //writer.Formatting = Formatting.Indented;
            doc.Save(@"../../../../Levels/Level1.xml");
        }
    }
}
