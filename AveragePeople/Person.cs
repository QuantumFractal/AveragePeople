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
    class Person : GameObject
    {
        public String name { get; set; }
        public Vector2 pos { get; set; }
        public Texture2D texture { get; set; }
        public Dictionary<String, Animation> animations;
        public enum States { walking, standing };
        States personState;

        public Person(String givenName, Vector2 givenPosition, Texture2D givenTexture)
        {
            name = givenName;
            pos = givenPosition;
            texture = givenTexture;
            animations = new Dictionary<String, Animation>();
            personState = States.standing;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            //spriteBatch.Draw(texture, pos, Color.White);
            if(personState == States.standing)
            {
                spriteBatch.Draw(texture, pos, Color.White);
            }

            else if(personState == States.walking)
            {
                Rectangle source = animations["walking"].GetFrame(gameTime);

                Vector2 origin = new Vector2(animations["walking"].frameSize.X / 2.0f, animations["walking"].frameSize.Y);

                spriteBatch.Draw(animations["walking"].spriteMap, pos, source, Color.White);
            }

        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            //Console.WriteLine(gameTime.ElapsedGameTime.Seconds);
            if(keyboard.IsKeyDown(Keys.D))
            {
                personState = States.walking;
                pos = new Vector2(pos.X + 1, pos.Y);
            }
            if(keyboard.IsKeyUp(Keys.D))
            {
                personState = States.standing;
            }
        }
    }
}
