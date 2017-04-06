using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMario
{
    public class Camera
    {
        public static int CameraPositionX;
        public static int CameraPositionY;
        public bool disableCamera = false;

        public Camera()
        {
            CameraPositionX = 0;
            CameraPositionY = 0;
        }

        public void UpdateX(int MarioPositionX)
        {
            if (!disableCamera)
            {
                if (MarioPositionX < Game1Utility.finalLevelLocation)
                {
                    if (MarioPositionX > CameraPositionX + Game1Utility.cameraOffset)
                    {
                        CameraPositionX += MarioPositionX - (CameraPositionX + Game1Utility.cameraOffset);
                    }
                    else if (MarioPositionX < CameraPositionX + Game1Utility.cameraOffset && CameraPositionX > (CameraPositionX + Game1Utility.cameraOffset) - MarioPositionX)
                    {
                        CameraPositionX -= (CameraPositionX + Game1Utility.cameraOffset) - MarioPositionX;
                    }
                }
            }
        }
        
        public void SetPositionZero()
        {
            CameraPositionX = 0;
        }
    }
}
