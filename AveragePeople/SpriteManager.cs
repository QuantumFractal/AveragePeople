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
    class SpriteManager
    {
        public Dictionary<String, Texture2D> textureMap { get; set;}

        public SpriteManager()
        {
            textureMap = new Dictionary<string, Texture2D>();

        }

    }
}
