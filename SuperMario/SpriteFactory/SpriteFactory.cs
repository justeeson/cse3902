﻿using System;
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
    public static class SpriteFactory
    {
        public static Texture2D goombaTexture
        { get; set; }
        public static Texture2D flowerTexture
        { get; set; }
        public static Texture2D coinTexture
        { get; set; }
        public static Texture2D growupMushroomTexture
        { get; set; }
        public static Texture2D fireMushroomTexture
        { get; set; }
        public static Texture2D starTexture
        { get; set; }
        public static Texture2D koopaMoveLeftTexture
        { get; set; }
        public static Texture2D koopaMoveRightTexture
        { get; set; }
        public static Texture2D solidBrickTexture
        { get; set; }
        public static Texture2D solidBrickWithCrewsTexture
        { get; set; }
        public static Texture2D questionMarkBrickTexture
        { get; set; }
        public static Texture2D brickableHorizontalBrickTexture
        { get; set; }
        public static Texture2D breakableCurlyBrickTexture
        { get; set; }
        public static Texture2D pipeTexture
        { get; set; }
        public static Texture2D mediumPipeTexture
        { get; set; }
        public static Texture2D highPipeTexture
        { get; set; }
        public static Texture2D backgroundTexture
        { get; set; }
        public static Texture2D flagPoleTexture
        { get; set; }
        public static Texture2D castleTexture
        { get; set; }
        public static Texture2D undergroundPipeTexture
        { get; set; }
        public static Texture2D fireworks
        { get; set; }
        private const int rowNumber = 32;
        private const int columnNumber = 32;
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
            fireworks= content.Load<Texture2D>("fireworks");
        }

        public static ISprite CreateKoopaMoveLeft()
        {
            return new KoopaMoveLeftSprite(koopaMoveLeftTexture, columnNumber);
        }
        public static ISprite CreateKoopaMoveRight()
        {
            return new KoopaMoveRightSprite(koopaMoveRightTexture, columnNumber);
        }
        public static ISprite CreateFlower()
        {
            return new FlowerSprite(flowerTexture, rowNumber, columnNumber);
        }

        public static ISprite CreateCoin()
        {
            return new CoinSprite(coinTexture, rowNumber, columnNumber);
        }

        public static ISprite CreateGrowupMushroom()
        {
            return new GrowupMushroomSprite(growupMushroomTexture, columnNumber);
        }
        public static ISprite CreateFireMushroom()
        {
            return new FireMushroomSprite(fireMushroomTexture, columnNumber);
        }
        public static ISprite CreateStar()
        {
            return new StarSprite(starTexture, columnNumber);
        }
        public static ISprite CreateGoomba()
        {
            return new GoombaSprite(goombaTexture, columnNumber);
        }
        public static ISprite CreateSolidBrick()
        {
            return new SolidBrickSprite(solidBrickTexture, columnNumber);
        }
        public static ISprite CreateSolidBrickWithCrews()
        {
            return new SolidBrickWithCrewsSprite(solidBrickWithCrewsTexture, columnNumber);
        }

        public static ISprite CreateHiddenBrick()
        {
            return new HiddenBrickSprite(solidBrickWithCrewsTexture, columnNumber);
        }

        public static ISprite CreateSolidBrickWithCrews3()
        {
            return new SolidBrickWithCrewsSprite3(solidBrickWithCrewsTexture, rowNumber, columnNumber);
        }

        public static ISprite CreateQuestionMarkBrick()
        {
            return new QuestionMarkBrickSprite(questionMarkBrickTexture, columnNumber);
        }

        public static ISprite CreateBreakableHorizonalBrick()
        {
            return new BreakableHorizontalBrickSprite(brickableHorizontalBrickTexture, columnNumber);
        }
        public static ISprite CreateBreakableCurlyBrick()
        {
            return new BreakableCurlyBrickSprite(breakableCurlyBrickTexture, columnNumber);
        }
        public static ISprite CreatePipe()
        {
            return new PipeSprite(pipeTexture, columnNumber);
        }
        public static ISprite CreateMediumPipe()
        {
            return new MediumPipeSprite(mediumPipeTexture, columnNumber);
        }
        public static ISprite CreateHighPipe()
        {
            return new HighPipeSprite(highPipeTexture, columnNumber);
        }
        public static ISprite CreateUndergroundPipeToGround()
        {
            return new UndergroundPipeSprite(undergroundPipeTexture, columnNumber);
        }
        public static ISprite CreatePipeToUnderground()
        {
            return new HighPipeSprite(highPipeTexture, columnNumber);
        }
        public static ISprite CreateBackground()
        {
            return new BackgroundSprite(backgroundTexture, rowNumber, columnNumber);
        }
        public static ISprite CreateCastle()
        {
            return new CastleSprite(castleTexture, columnNumber);
        }
        public static ISprite CreateFlagPole()
        {
            return new FlagPoleSprite(flagPoleTexture, columnNumber);
        }
        public static ISprite CreateFlagPoleToUsed()
        {
            return new FlagPoleToUsedSprite(flagPoleTexture, columnNumber);
        }
        public static ISprite CreateFirework()
        {
            return new FireworkSprite(fireworks, columnNumber);
        }
    }
}
