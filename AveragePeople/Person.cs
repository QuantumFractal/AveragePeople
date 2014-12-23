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


        public Dictionary<String, String> keymap;

        public int speed;
        public enum States { walking, standing };
        public enum Directions { north, east, south, west, northeast, };
        
        public Dictionary<String, Vector2> directions;
 
        Directions direction;
        States personState;
        

        public Person(String givenName, Vector2 givenPosition, Texture2D givenTexture)
        {
            name = givenName;
            pos = givenPosition;
            texture = givenTexture;
            animations = new Dictionary<String, Animation>();

            keymap = new Dictionary<string, string>();
            keymap.Add("north", "W");
            keymap.Add("west", "A");
            keymap.Add("south", "S");
            keymap.Add("east", "D");

            personState = States.standing;
            direction = Directions.east;

            speed = 2;

            directions = new Dictionary<string, Vector2>();
            initDirections(keymap);
        }


        //SHOULDNT BE HERE BUT WHAT EVER
        private static string Alphabetize(string s)
        {
            // 1.
            // Convert to char array.
            char[] a = s.ToCharArray();

            // 2.
            // Sort letters.
            Array.Sort(a);

            // 3.
            // Return modified string.
            return new string(a);
        }

        public void initDirections(Dictionary<String, String> keymap)
        {
            directions.Add(keymap["north"]               , new Vector2(0.0f, 1.0f));
            directions.Add(Alphabetize(keymap["north"]+keymap["east"]), new Vector2(1.0f, 1.0f));
            directions.Add(keymap["east"]                , new Vector2(1.0f, 0.0f));
            directions.Add(Alphabetize(keymap["south"]+keymap["east"]), new Vector2(1.0f, -1.0f));
            directions.Add(keymap["south"]               , new Vector2(0.0f, -1.0f));
            directions.Add(Alphabetize(keymap["south"]+keymap["west"]), new Vector2(-1.0f, -1.0f));
            directions.Add(keymap["west"]                , new Vector2(-1.0f, 0.0f));
            directions.Add(Alphabetize(keymap["north"]+keymap["west"]), new Vector2(-1.0f, 1.0f));
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            
            //spriteBatch.Draw(texture, pos, Color.White);
            if(personState == States.standing)
            {
                if(direction == Directions.west)
                    spriteBatch.Draw(texture, pos, new Rectangle(0,0,32,32), Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1.0f);

                else
                    spriteBatch.Draw(texture, pos, Color.White);
            }

            else if(personState == States.walking)
            {
                Rectangle source = animations["walking"].GetFrame(gameTime);

                Vector2 origin = new Vector2(animations["walking"].frameSize.X / 2.0f, animations["walking"].frameSize.Y);


                if(direction == Directions.west)
                    spriteBatch.Draw(animations["walking"].spriteMap, pos, source, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.FlipHorizontally, 1.0f);
                else
                    spriteBatch.Draw(animations["walking"].spriteMap, pos, source, Color.White, 0.0f, new Vector2(0, 0), 1.0f, SpriteEffects.None, 1.0f);
            }

        }

        public void Update(GameTime gameTime, KeyboardState keyboard)
        {
            Keys[] keys = keyboard.GetPressedKeys();
            Vector2 vec = new Vector2(0.0f,0.0f);

            //Get Vector
            try
            {
                if (keys.Length == 1)
                {
                    vec = directions[keys[0].ToString()];
                    personState = States.walking;
                }

                if (keys.Length == 2)
                {
                    vec = directions[keys[0].ToString() + keys[1].ToString()];
                    personState = States.walking;
                }
            }
            catch (KeyNotFoundException e)
            {
                //You've typed some keys that aren't mapped! AGH
                personState = States.standing;
            }

            //Set direction + state
            if (vec.X == -1.0f)
                direction = Directions.west;
            else if(vec.X == 1.0f)
                direction = Directions.east;

            if (vec.X == 0.0f && vec.Y == 0.0f)
                personState = States.standing;

            
            //Flip Y for screen drawing and normalize
            vec = new Vector2(vec.X, -vec.Y);
            //vec.Normalize();

            Console.WriteLine("Position: " + pos.ToString() + " Vector: " + vec.ToString());

            //Add it to the position
            pos = pos + vec * speed;
            
        }

    }
}
