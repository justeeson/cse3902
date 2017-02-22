﻿using Microsoft.Xna.Framework;
using SuperMario.Collision_Defection_and_Responses;
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


        public Goomba goomba;
        public Koopa koopa;

        public Coin coin;
        public FireMushroom fireMushroom;
        public Flower flower;
        public GrownupMushroom growupMushroom;
        public Star star;

        public BreakableCurlyBrick breakableCurlyBrick;
        public BreakableHorizontalBrick breakableHorizontalBrick;
        public HiddenBrick hiddenBrick;
        public Pipe pipe;
        public QuestionMarkBrick questionMarkBrick;
        public QuestionMarkBrickToUsed questionMarkBrickToUsed;
        public SolidBrick solidBrick;
        public SolidBrickWithCrews solidBrickWithCrews;
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
       // hiddenBrick.Update();
        pipe.Update(gameTime);
        questionMarkBrick.Update(gameTime);
        //questionMarkBrickToUsed.Update();
        solidBrick.Update(gameTime);
        solidBrickWithCrews.Update(gameTime);
        CollisionHandling.Update(this);
        }
    }
}