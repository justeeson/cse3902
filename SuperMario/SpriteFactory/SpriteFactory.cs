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
        public static Texture2D GoombaTexture;
        public static Texture2D FlowerTexture;
        public static Texture2D CoinTexture;
        public static Texture2D GrowupMushroomTexture;
        public static Texture2D FireMushroomTexture;
        public static Texture2D StarTexture;
        public static Texture2D KoopaTexture;
        public static Texture2D SolidBrickTexture;
        public static Texture2D SolidBrickWithCrewsTexture;
        public static Texture2D QuestionMarkBrickTexture;
        public static Texture2D BrickableHorizontalBrickTexture;
        public static Texture2D BreakableCurlyBrickTexture;
        public static Texture2D PipeTexture;

        public void LoadAllTextures(ContentManager content)
        {
            KoopaTexture = content.Load<Texture2D>("turtle");
            FlowerTexture = content.Load<Texture2D>("flower");
            CoinTexture = content.Load<Texture2D>("coin");
            GrowupMushroomTexture = content.Load<Texture2D>("growupMushroom");
            FireMushroomTexture = content.Load<Texture2D>("fireMushroom");
            StarTexture = content.Load<Texture2D>("star");
            GoombaTexture = content.Load<Texture2D>("normalMonster");
            SolidBrickTexture = content.Load<Texture2D>("solidBrick");
            SolidBrickWithCrewsTexture = content.Load<Texture2D>("unbreakablebrickwith4screws");
            QuestionMarkBrickTexture = content.Load<Texture2D>("questionMarkBrick");
            BrickableHorizontalBrickTexture = content.Load<Texture2D>("brickableHorizontalBrick");
            BreakableCurlyBrickTexture = content.Load<Texture2D>("breakableCurlyBrick");
            PipeTexture = content.Load<Texture2D>("pipe");
        }


        public static ISprite CreateKoopa()
        {
            return new KoopaSprite(KoopaTexture, 32, 32);
        }
        public static ISprite CreateFlower()
        {
            return new FlowerSprite(FlowerTexture, 32, 32);
        }

        public static ISprite CreateCoin()
        {
            return new CoinSprite(CoinTexture, 32, 32);
        }

        public static ISprite CreateGrowupMushroom()
        {
            return new GrowupMushroomSprite(GrowupMushroomTexture, 32, 32);
        }
        public static ISprite CreateFireMushroom()
        {
            return new FireMushroomSprite(FireMushroomTexture, 32, 32);
        }
        public static ISprite CreateStar()
        {
            return new StarSprite(StarTexture, 32, 32);
        }
        public static ISprite CreateGoomba()
        {
            return new GoombaSprite(GoombaTexture, 32, 32);
        }
        public static ISprite CreateSolidBrick()
        {
            return new SolidBrickSprite(SolidBrickTexture, 32, 32);
        }
        public static ISprite CreateSolidBrickWithCrews()
        {
            return new SolidBrickWithCrewsSprite(SolidBrickWithCrewsTexture, 32, 32);
        }

        public static ISprite CreateHiddenBrick()
        {
            return new HiddenBrickSprite(SolidBrickWithCrewsTexture, 32, 32);
        }

        public static ISprite CreateSolidBrickWithCrews3()
        {
            return new SolidBrickWithCrewsSprite3(SolidBrickWithCrewsTexture, 32, 32);
        }

        public static ISprite CreateQuestionMarkBrick()
        {
            return new QuestionMarkBrickSprite(QuestionMarkBrickTexture, 32, 32);
        }

        public static ISprite CreateBreakableHorizonalBrick()
        {
            return new BreakableHorizontalBrickSprite(BrickableHorizontalBrickTexture, 32, 32);
        }
        public static ISprite CreateBreakableCurlyBrick()
        {
            return new BreakableCurlyBrickSprite(BreakableCurlyBrickTexture, 32, 32);
        }
        public static ISprite CreatePipe()
        {
            return new PipeSprite(PipeTexture, 32, 32);
        }
    }
}
