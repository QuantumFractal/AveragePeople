﻿#region Using Statements
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
    interface ObjectManager
    {
        void Update(GameTime gameTime, KeyboardState keyboardState);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
