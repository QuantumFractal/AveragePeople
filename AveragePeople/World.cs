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
    class World : ObjectManager
    {
        Tile[,] tileMap;
        public List<Person> personList { get; set; }

        Vector2 tileMapAnchor;

        private int TILESIZE = 32;

        public Dictionary<String, Texture2D> tileSprites;
        public Dictionary<String, Texture2D> personSprites;
        public Dictionary<String, Texture2D> animationMaps;

        private Animation guyAnimation;

        public Dictionary<String, Tile> tileSet { get; set; }
        Vector2 size;

        public World(Vector2 givenSize)
        {
            size = givenSize;
            tileMap = new Tile[(int) size.X, (int) size.Y];
            tileSet = new Dictionary<string, Tile>();
            tileMapAnchor = new Vector2(0,0);
            personList = new List<Person>();
            
            tileSprites = new Dictionary<String, Texture2D>();
            personSprites = new Dictionary<String, Texture2D>();
            animationMaps = new Dictionary<String, Texture2D>();
        }

        public void InitTiles()
        {
            tileSet.Add("grass", new Tile(size, tileSprites["grass"]));
            tileSet.Add("stone", new Tile(size, tileSprites["stone"]));


            personList.Add(new Person("guy", new Vector2(100,100), personSprites["guy"]));

            guyAnimation = new Animation(animationMaps["guy_walking"], new Vector2(32, 32), 4);
            personList[0].animations.Add("walking", guyAnimation);
        }
        
        public void GenerateTerrain()
        {
            Random rnd = new Random();

            //Paint it green!
            for (int i = 0; i < size.X; i++)
            {
                for (int j = 0; j < size.Y; j++)
                {
                    if (rnd.Next(0, 2) == 0)
                        tileMap[i, j] = tileSet["grass"].Clone();
                    else
                        tileMap[i, j] = tileSet["stone"].Clone();

                    tileMap[i, j].pos = new Vector2(i * TILESIZE + tileMapAnchor.X, j * TILESIZE + tileMapAnchor.Y);
                }
            }
        }

        public void Update(GameTime gameTime, KeyboardState keyboardState)
        {
            personList[0].Update(gameTime, keyboardState);

        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            //Assuming .Begin() has been called
            
            foreach (Tile tile in tileMap)
            {
                tile.Draw(gameTime, spriteBatch);
            }

            //Render Guy
            personList[0].Draw(gameTime, spriteBatch);
            
        }
    }
}
