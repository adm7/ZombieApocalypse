using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ZombiePrototype
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        Texture2D whiteRectangle;
        Texture2D redRectangle;
        Entity[] entities;

        private int population = 500;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //*******************Dialog Code**************
            string value = "200";
            if (Utils.InputBox("XXX Zombie Apocalypse XXXX", "Outbreak Population:", ref value) == DialogResult.OK)
            {
                population = Convert.ToInt32(value);
                base.Initialize();
            }
            else 
            { 
                Application.Exit();
            }
            //***********************************
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            entities = new Entity[population];

            for (int i = 0; i < population-1; i++)
                entities[i] = new Human();

            whiteRectangle = new Texture2D(GraphicsDevice, 1, 1);
            whiteRectangle.SetData(new[] { Color.White });

            //Zombie
            entities[population - 1] = new Zombie();

            redRectangle = new Texture2D(GraphicsDevice, 1, 1);
            redRectangle.SetData(new[] { Color.Red });
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            spriteBatch.Dispose();
            whiteRectangle.Dispose();
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updatingmothe world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                this.Exit();

            //if (gameTime.ElapsedGameTime.Milliseconds % 100 == 0)
            for (int i = 0; i < population; i++)
                entities[i].action();


            for (int i = 0; i < population; i++)
            { 
                if (entities[i].GetType() == typeof(Human))
                {
                    foreach (Entity j in entities)
                    {
                        if (j.GetType() == typeof(Zombie) && entities[i].getPos() == j.getPos())
                            entities[i] = new Zombie();
                    }
                }
            }

            //Console.WriteLine(gameTime.ElapsedGameTime.);
            
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            for (int i = 0; i < population; i++)
            {
                if (entities[i].GetType() == typeof(Human))
                    spriteBatch.Draw(whiteRectangle, entities[i].getPos(), Color.White);
                else
                    spriteBatch.Draw(redRectangle, entities[i].getPos(), Color.Red);
            }
     
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
