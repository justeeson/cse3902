using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperMario;
using SuperMario.Interfaces;
using System.Collections;

namespace SuperMario
{
    public class SpriteFactory
    {
        public static Texture2D goombaTexture;
        public static Texture2D flowerTexture;
        public static Texture2D coinTexture;
        public static Texture2D growupMushroomTexture;
        public static Texture2D fireMushroomTexture;
        public static Texture2D starTexture;
        public static Texture2D koopaMoveLeftTexture;
        public static Texture2D koopaMoveRightTexture;
        public static Texture2D solidBrickTexture;
        public static Texture2D solidBrickWithCrewsTexture;
        public static Texture2D questionMarkBrickTexture;
        public static Texture2D brickableHorizontalBrickTexture;
        public static Texture2D breakableCurlyBrickTexture;
        public static Texture2D pipeTexture;
        public static Texture2D mediumPipeTexture;
        public static Texture2D highPipeTexture;
        public static Texture2D backgroundTexture;
        public static Texture2D flagPoleTexture;
        public static Texture2D castleTexture;
        public static Texture2D undergroundPipeTexture;

        public static void LoadAllTextures(ContentManager content)
        {
            koopaMoveLeftTexture = content.Load<Texture2D>("turtleMoveLeft");
            koopaMoveRightTexture = content.Load<Texture2D>("turtleMoveRight");
            flowerTexture = content.Load<Texture2D>("flower");
            coinTexture = content.Load<Texture2D>("coin");
            growupMushroomTexture = content.Load<Texture2D>("growupMushroom");
            fireMushroomTexture = content.Load<Texture2D>("fireMushroom");
            starTexture = content.Load<Texture2D>("star");
            goombaTexture = content.Load<Texture2D>("normalMonster");
            solidBrickTexture = content.Load<Texture2D>("solidBrick");
            solidBrickWithCrewsTexture = content.Load<Texture2D>("unbreakablebrickwith4screws");
            questionMarkBrickTexture = content.Load<Texture2D>("questionMarkBrick");
            brickableHorizontalBrickTexture = content.Load<Texture2D>("brickableHorizontalBrick");
            breakableCurlyBrickTexture = content.Load<Texture2D>("breakableCurlyBrick");
            pipeTexture = content.Load<Texture2D>("pipe");
            mediumPipeTexture = content.Load<Texture2D>("pipe2");
            highPipeTexture = content.Load<Texture2D>("pipe3");
            backgroundTexture = content.Load<Texture2D>("background3");
            flagPoleTexture = content.Load<Texture2D>("FlagPole");
            castleTexture = content.Load<Texture2D>("castle");
            undergroundPipeTexture = content.Load<Texture2D>("UndergroundPipe");
        }

        public static ISprite CreateKoopaMoveLeft()
        {
            return new KoopaMoveLeftSprite(koopaMoveLeftTexture, 32, 32);
        }
        public static ISprite CreateKoopaMoveRight()
        {
            return new KoopaMoveRightSprite(koopaMoveRightTexture, 32, 32);
        }
        public static ISprite CreateFlower()
        {
            return new FlowerSprite(flowerTexture, 32, 32);
        }

        public static ISprite CreateCoin()
        {
            return new CoinSprite(coinTexture, 32, 32);
        }

        public static ISprite CreateGrowupMushroom()
        {
            return new GrowupMushroomSprite(growupMushroomTexture, 32, 32);
        }
        public static ISprite CreateFireMushroom()
        {
            return new FireMushroomSprite(fireMushroomTexture, 32, 32);
        }
        public static ISprite CreateStar()
        {
            return new StarSprite(starTexture, 32, 32);
        }
        public static ISprite CreateGoomba()
        {
            return new GoombaSprite(goombaTexture, 32, 32);
        }
        public static ISprite CreateSolidBrick()
        {
            return new SolidBrickSprite(solidBrickTexture, 32, 32);
        }
        public static ISprite CreateSolidBrickWithCrews()
        {
            return new SolidBrickWithCrewsSprite(solidBrickWithCrewsTexture, 32, 32);
        }

        public static ISprite CreateHiddenBrick()
        {
            return new HiddenBrickSprite(solidBrickWithCrewsTexture, 32, 32);
        }

        public static ISprite CreateSolidBrickWithCrews3()
        {
            return new SolidBrickWithCrewsSprite3(solidBrickWithCrewsTexture, 32, 32);
        }

        public static ISprite CreateQuestionMarkBrick()
        {
            return new QuestionMarkBrickSprite(questionMarkBrickTexture, 32, 32);
        }

        public static ISprite CreateBreakableHorizonalBrick()
        {
            return new BreakableHorizontalBrickSprite(brickableHorizontalBrickTexture, 32, 32);
        }
        public static ISprite CreateBreakableCurlyBrick()
        {
            return new BreakableCurlyBrickSprite(breakableCurlyBrickTexture, 32, 32);
        }
        public static ISprite CreatePipe()
        {
            return new PipeSprite(pipeTexture, 32, 32);
        }
        public static ISprite CreateMediumPipe()
        {
            return new MediumPipeSprite(mediumPipeTexture, 32, 32);
        }
        public static ISprite CreateHighPipe()
        {
            return new HighPipeSprite(highPipeTexture, 32, 32);
        }
        public static ISprite CreateUndergroundPipeToGround()
        {
            return new UndergroundPipeSprite(undergroundPipeTexture, 32, 32);
        }
        // Might need to created a new pipe sprite class
        public static ISprite CreatePipeToUnderground()
        {
            return new HighPipeSprite(highPipeTexture, 32, 32);
        }
        public static ISprite CreateBackground()
        {
            return new BackgroundSprite(backgroundTexture, 32, 32);
        }
        public static ISprite CreateCastle()
        {
            return new CastleSprite(castleTexture, 32, 32);
        }
        public static ISprite CreateFlagPole()
        {
            return new FlagPoleSprite(flagPoleTexture, 32, 32);
        }
    }
}
