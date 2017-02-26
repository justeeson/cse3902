using Microsoft.Xna.Framework;
using SuperMario.Collision_Detection_and_Responses;
using SuperMario.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class ObjectAndSpriteStore
    {
        public Game1 GameClass;
        public ArrayList itemArray = new ArrayList();
        public ArrayList enemyArray = new ArrayList();
        public ArrayList blockArray = new ArrayList();
        public ArrayList arrayOfSprites = new ArrayList();


        private Goomba goomba;
        private Koopa koopa;

        private Coin coin;
        private FireMushroom fireMushroom;
        private Flower flower;
        private GrownupMushroom growupMushroom;
        private Star star;

        private BreakableCurlyBrick breakableCurlyBrick;
        private BreakableHorizontalBrick breakableHorizontalBrick;
        private HiddenBrick hiddenBrick;
        private Pipe pipe;
        private QuestionMarkBrick questionMarkBrick;
        private QuestionMarkBrickToUsed questionMarkBrickToUsed;
        private SolidBrick solidBrick;
        private SolidBrickWithCrews solidBrickWithCrews;
        public ObjectAndSpriteStore(Game1 game)
        {
            GameClass = game;
        }
       

        public void Initialize(Game1 game)
        {
            arrayOfSprites = new ArrayList();
            itemArray = new ArrayList();
            enemyArray = new ArrayList();
            blockArray = new ArrayList();

            goomba = new Goomba(game);
            arrayOfSprites.Add(game.sprite);
            koopa = new Koopa(game);
            arrayOfSprites.Add(game.sprite);

            coin = new Coin(game);
            arrayOfSprites.Add(game.sprite);
            fireMushroom = new FireMushroom(game);
            arrayOfSprites.Add(game.sprite);
            flower = new Flower(game);
            arrayOfSprites.Add(game.sprite);
            growupMushroom = new GrownupMushroom(game);
            arrayOfSprites.Add(game.sprite);
            star = new Star(game);
            arrayOfSprites.Add(game.sprite);
           


            solidBrick = new SolidBrick(game);
            arrayOfSprites.Add(game.sprite);
            solidBrickWithCrews = new SolidBrickWithCrews(game);
            arrayOfSprites.Add(game.sprite);
            questionMarkBrick = new QuestionMarkBrick(game);
            arrayOfSprites.Add(game.sprite);
            breakableCurlyBrick = new BreakableCurlyBrick(game);
            arrayOfSprites.Add(game.sprite);
            breakableHorizontalBrick = new BreakableHorizontalBrick(game);
            arrayOfSprites.Add(game.sprite);
            pipe = new Pipe(game);
            arrayOfSprites.Add(game.sprite);
            hiddenBrick = new HiddenBrick(game);
            arrayOfSprites.Add(game.sprite);

            enemyArray.Add(koopa);
            enemyArray.Add(goomba);

            itemArray.Add(coin);
            itemArray.Add(growupMushroom);
            itemArray.Add(fireMushroom);
            itemArray.Add(star);
            itemArray.Add(flower);

            blockArray.Add(solidBrick);
            blockArray.Add(solidBrickWithCrews);
            blockArray.Add(questionMarkBrick);
            blockArray.Add(breakableCurlyBrick);
            blockArray.Add(breakableHorizontalBrick);
            blockArray.Add(pipe);
            blockArray.Add(hiddenBrick);

        }

        public void Update()
        {

        GameTime gameTime = GameClass.gameTime;
        koopa.Update(gameTime);
        goomba.Update(gameTime);

       coin.Update();
       fireMushroom.Update();
       flower.Update();
       growupMushroom.Update();
       star.Update();

        breakableCurlyBrick.Update(gameTime);
        breakableHorizontalBrick.Update(gameTime);
        hiddenBrick.Update(gameTime);
        pipe.Update(gameTime);
        questionMarkBrick.Update(gameTime);
        //questionMarkBrickToUsed.Update();
        solidBrick.Update(gameTime);
        solidBrickWithCrews.Update(gameTime);
        CollisionHandling.Update(this);
        }

        void Draw()
        {/*
           goomba.Draw(GameClass.spriteBatch, goomba.locationX);
           */

        }
    }
}
