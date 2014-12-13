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
    class Tile : GameObject
    {
        private int TILESIZE;

        public Vector2 pos { get; set; }
        Vector2 size;
        public Rectangle rect { get; set; }
        public Texture2D texture { get; set; }

        public Tile(Vector2 givenPosition, Texture2D givenTexture)
        {
            pos = givenPosition;
            texture = givenTexture;
            size = new Vector2(givenTexture.Width, givenTexture.Height);
            rect = new Rectangle( (int) pos.X, (int) pos.Y, (int) size.X, (int) size.Y);
        }

        public Tile(Texture2D givenTexture)
        {
            pos = new Vector2(0, 0);
            texture = givenTexture;
        }

        public Tile Clone()
        {
            return new Tile(pos, texture);
        }

		public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, pos, Color.White);
        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            //Should do nothing... for now!
        }
    }
}
