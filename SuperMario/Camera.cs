using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class Camera
    {
        public static int cameraPositionX;
        public static int cameraPositionY;
        public bool disableCamera = false;

        public Camera()
        {
            cameraPositionX = 0;
            cameraPositionY = 0;
        }

        public void UpdateX(int MarioPositionX)
        {
            if (!disableCamera)
            {
                if (MarioPositionX < Game1Utility.finalLevelLocation)
                {
                    if (MarioPositionX > cameraPositionX + Game1Utility.cameraOffset)
                    {
                        cameraPositionX += MarioPositionX - (cameraPositionX + Game1Utility.cameraOffset);
                    }
                    else if (MarioPositionX < cameraPositionX + Game1Utility.cameraOffset && cameraPositionX > (cameraPositionX + Game1Utility.cameraOffset) - MarioPositionX)
                    {
                        cameraPositionX -= (cameraPositionX + Game1Utility.cameraOffset) - MarioPositionX;
                    }
                }
            }
        }
        
        public void SetPositionZero()
        {
            cameraPositionX = 0;
        }
    }
}
