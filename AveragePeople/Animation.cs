#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Storage;
using Microsoft.Xna.Framework.GamerServices;
#endregion

namespace AveragePeople
{
    class Animation
    {
        public Texture2D spriteMap;
        public Vector2 frameSize;
        public int totalFrames;

        float time;
        // duration of time to show each frame
        float frameTime = 0.1f;
        // an index of the current frame being shown
        int frameIndex;


        public Animation(Texture2D givenSpriteMap, Vector2 givenFrameSize, int givenFrames)
        {
            spriteMap = givenSpriteMap;
            frameSize = givenFrameSize;
            totalFrames = givenFrames;
        }

        public Rectangle GetFrame(GameTime gameTime)
        {
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            while (time > frameTime)
            {
                // Play the next frame in the SpriteSheet
                frameIndex++;
                // reset elapsed time
                time = 0f;
            }
            if (frameIndex > totalFrames) frameIndex = 1;

            return new Rectangle(frameIndex * (int) frameSize.X, 0, (int) frameSize.X, (int) frameSize.Y);
        }
    }
}
