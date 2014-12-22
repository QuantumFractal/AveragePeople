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
        public enum Direction { north, east, south, west };
        Direction direction;
        States personState;
        

        public Person(String givenName, Vector2 givenPosition, Texture2D givenTexture)
        {
            name = givenName;
            pos = givenPosition;
            texture = givenTexture;
            animations = new Dictionary<String, Animation>();
            personState = States.standing;
            direction = Direction.east;
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            //spriteBatch.Draw(texture, pos, Color.White);
            if(personState == States.standing)
            {
                if(direction == Direction.west)
                    spriteBatch.Draw(texture, pos, new Rectangle(0,0,32,32), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1.0f);

                else
                    spriteBatch.Draw(texture, pos, Color.White);
            }

            else if(personState == States.walking)
            {
                Rectangle source = animations["walking"].GetFrame(gameTime);

                Vector2 origin = new Vector2(animations["walking"].frameSize.X / 2.0f, animations["walking"].frameSize.Y);


                if(direction == Direction.west)
                    spriteBatch.Draw(animations["walking"].spriteMap, pos, source, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1.0f);
                else
                    spriteBatch.Draw(animations["walking"].spriteMap, pos, source, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f);

            }

        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            //Console.WriteLine(gameTime.ElapsedGameTime.Seconds);
            if(keyboard.IsKeyDown(Keys.D))
            {
                personState = States.walking;
                direction = Direction.east;
                pos = new Vector2(pos.X + 1, pos.Y);
            }

            if (keyboard.IsKeyDown(Keys.A))
            {
                personState = States.walking;
                direction = Direction.west;
                pos = new Vector2(pos.X - 1, pos.Y);
            }

            if (keyboard.IsKeyDown(Keys.S))
            {
                personState = States.walking;
                //direction = Direction.south;
                pos = new Vector2(pos.X, pos.Y + 1);
            }

            if (keyboard.IsKeyDown(Keys.W))
            {
                personState = States.walking;
                //direction = Direction.north;
                pos = new Vector2(pos.X, pos.Y - 1);
            }


            if(keyboard.IsKeyUp(Keys.D) && 
               keyboard.IsKeyUp(Keys.A) &&
               keyboard.IsKeyUp(Keys.S) &&
               keyboard.IsKeyUp(Keys.W))
            {
                personState = States.standing;
            }
        }
    }
}
