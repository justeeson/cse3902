﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Xna.Framework;
using SuperMario.Interfaces;

namespace SuperMario.Collision
{

    [TestClass]
    public class CollisionTestRight : IObject
    {
        public Rectangle Area { get; set; }


        public class RightTest
        {
            public Rectangle Area { get; set; }
            public RightTest(int X, int Y, int width, int height)
            {
                this.Area = new Rectangle(X, Y, width, height);
            }

        }
        [TestMethod()]
        public void TestRight()
        {

            Rectangle collisionRectangle;
            RightTest obj = new RightTest(50, 16, 10, 10);
            RightTest mario = new RightTest(20, 80, 80, 80);
            for (int y = 0; y < 100; y++)
            {
                mario.Area = new Rectangle(20 + y, 80, 80, 80);
                collisionRectangle = Rectangle.Intersect(mario.Area, obj.Area);
                if (collisionRectangle.Right == obj.Area.Right && collisionRectangle.Width > collisionRectangle.Height)
                {
                    Assert.Fail();
                }
               
            }
        }

    }
}
