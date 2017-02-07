using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using SuperMario;
using SuperMario.Interfaces;


public class SpriteFactory
{
    private Texture2D turtleTexture;
    private Texture2D flowerTexture;
    private Texture2D coinTexture;
    private Texture2D growupMushroomTexture;
    private Texture2D fireMushroomTexture;
    private Texture2D starTexture;
    private Texture2D normalMonsterTexture;
    private Texture2D solidBrickTexture;
    private Texture2D solidBrickWithCrewsTexture;
    private Texture2D questionMarkBrickTexture;
    private Texture2D brickableHorizontalBrickTexture;
    private Texture2D breakableCurlyBrickTexture;
    private Texture2D pipeTexture;



    private static SpriteFactory instance = new SpriteFactory();

    public static SpriteFactory Instance
    {
        get
        {
            return instance;
        }
    }

    private SpriteFactory()
    {
    }

    public void LoadAllTextures(ContentManager content)
    {
        turtleTexture = content.Load<Texture2D>("turtle");
        flowerTexture = content.Load<Texture2D>("flower");
        coinTexture = content.Load<Texture2D>("coin");
        growupMushroomTexture = content.Load<Texture2D>("growupMushroom");
        fireMushroomTexture = content.Load<Texture2D>("fireMushroom");
        starTexture = content.Load<Texture2D>("star");
        normalMonsterTexture = content.Load<Texture2D>("normalMonster");
        solidBrickTexture = content.Load<Texture2D>("solidBrick");
        solidBrickWithCrewsTexture = content.Load<Texture2D>("unbreakablebrickwith4screws");
        questionMarkBrickTexture = content.Load<Texture2D>("questionMarkBrick");
        brickableHorizontalBrickTexture = content.Load<Texture2D>("brickableHorizontalBrick");
        breakableCurlyBrickTexture = content.Load<Texture2D>("breakableCurlyBrick");
        pipeTexture=content.Load<Texture2D>("pipe");
        

}


    public ISprite CreateTurtle()
    {
        return new TurtleSprite(turtleTexture, 32,32);
    }
    public ISprite CreateFlower()
    {
        return new FlowerSprite(flowerTexture, 32, 32);
    }

    public ISprite CreateCoin()
    {
        return new CoinSprite(coinTexture, 32, 32);
    }

    public ISprite CreateGrowupMushroom()
    {
        return new GrowupMushroomSprite(growupMushroomTexture, 32, 32);
    }
    public ISprite CreateFireMushroom()
    {
        return new FireMushroomSprite(fireMushroomTexture, 32, 32);
    }
    public ISprite CreateStar()
    {
        return new StarSprite(starTexture, 32, 32);
    }
    public ISprite CreateNormalMonster()
    {
        return new NormalMonsterSprite(normalMonsterTexture, 32, 32);
    }
    public ISprite CreateSolidBrick()
    {
        return new SolidBrickSprite(solidBrickTexture, 32, 32);
    }
    public ISprite CreateSolidBrickWithCrews()
    {
        return new SolidBrickWithCrewsSprite(solidBrickWithCrewsTexture, 32, 32);
    }

    public ISprite CreateQuestionMarkBrick()
    {
        return new QuestionMarkBrickSprite(questionMarkBrickTexture, 32, 32);
    }

    public ISprite CreateBreakableHorizonalBrick()
    {
        return new BreakableHorizontalBrickSprite(brickableHorizontalBrickTexture, 32, 32);
    }
    public ISprite CreateBreakableCurlyBrick()
    {
        return new BreakableCurlyBrickSprite(breakableCurlyBrickTexture, 32, 32);
    }
    public ISprite CreatePipe()
    {
        return new PipeSprite(pipeTexture, 32, 32);
    }
}
