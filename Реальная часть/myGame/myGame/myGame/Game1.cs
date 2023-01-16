using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using myGame.MenuSys;


namespace myGame
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static GameState gameState = GameState.Menu;
        Menu menu;
        Help help;
        Texture2D zast_1;
        Texture2D zast_2;
        Score score;
        itsGame itsgame;
        SpriteFont font_zast;
        Game_lvl game_lvl = new Game_lvl();
        Random rnd = new Random();   
        public static Timer timer = new Timer();
        Timer timer2 = new Timer();
        public static int show=1;

        public enum GameState
        {
            Game,
            Zast,
            Menu,
            Help,
            Score
        }             

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;

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
            menu = new Menu();
            help = new Help();
            score = new Score();
            itsgame = new itsGame();
            

            MenuItem newGame = new MenuItem("Начать игру");
            MenuItem resumeGame = new MenuItem("Продолжить игру");
            MenuItem scoreGame = new MenuItem("Рекорды");
            MenuItem helpGame = new MenuItem("Справка");            
            MenuItem exitGame = new MenuItem("Выход");

            resumeGame.Active = false;

            newGame.Click +=new EventHandler(newGame_Click);
            resumeGame.Click += new EventHandler(resumeGame_Click);
            scoreGame.Click += new EventHandler(scoreGame_Click);
            helpGame.Click += new EventHandler(helpGame_Click);
            exitGame.Click += new EventHandler(exitGame_Click);

            menu.Items.Add(newGame);
            menu.Items.Add(resumeGame);
            menu.Items.Add(scoreGame);
            menu.Items.Add(helpGame);
            menu.Items.Add(exitGame);

            base.Initialize();
        }
       
        void scoreGame_Click(object sender, EventArgs e)
        {
            gameState = GameState.Score;
        }
        void helpGame_Click(object sender, EventArgs e)
        {
            gameState = GameState.Help;
        }
        void exitGame_Click(object sender, EventArgs e)
        {
            this.Exit();
        }
        void newGame_Click(object sender, EventArgs e)
        {
            show = 1;

            timer2.Elapsed += new ElapsedEventHandler(ShowTime_menu);
            timer2.Interval = 8000;
            timer2.Start();
            gameState = GameState.Zast;
            menu.Items[1].Active = true;
            
          //  if (show == 3)
                
            
                 
        }

        public void ShowTime_menu(object source, ElapsedEventArgs e)
        {            
            if (show == 3)
            {
                game_lvl.New();
                gameState = GameState.Game;
                
                timer2.Stop();
                timer2.Close();
                show = 1;
            }else show++;

        }

        void resumeGame_Click(object sender, EventArgs e)
        {
            gameState = GameState.Game;
        }
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
       

        protected override void LoadContent()
        {
            menu.LoadContent(Content);
            help.LoadContent(Content);
            score.LoadContent(Content);
            itsgame.LoadContent(Content);

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // TODO: use this.Content to load your game content here

            zast_1 = Content.Load<Texture2D>("zast_1");
            zast_2 = Content.Load<Texture2D>("zast_2");
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {

            // Allows the game to exit
            if (gameState == GameState.Menu)
                menu.Update();
            else if (gameState == GameState.Help)
                help.Update();
            else if (gameState == GameState.Score )
                score.Update();
            else if (gameState == GameState.Game)
                itsgame.Update();
            
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
           
            // TODO: Add your drawing code here
            if (gameState == GameState.Menu)
                menu.Drow(spriteBatch);
            else if (gameState == GameState.Help)
                help.Drow(spriteBatch);
            else if (gameState == GameState.Score)
                score.Drow(spriteBatch);
            else if (gameState == GameState.Game)
                   itsgame.Drow(spriteBatch);
             else if (gameState == GameState.Zast){
                                    spriteBatch.Begin();
                                    if (show == 1)
                                    {
                                        spriteBatch.Draw(zast_1, Vector2.Zero, Color.White);                                       
                                    }
                                    if (show == 2)
                                    {
                                        spriteBatch.Draw(zast_2, Vector2.Zero, Color.White);
                                    }
                                                     spriteBatch.End();               
                
            }
               /* switch (show)
                {
                    case 1: spriteBatch.Begin(); spriteBatch.Draw(zast_1, Vector2.Zero, Color.White); spriteBatch.End(); break;
                    case 2: spriteBatch.Begin(); spriteBatch.Draw(zast_2, Vector2.Zero, Color.White); spriteBatch.End(); break;
                    case 3:  break;
                }
            }*/ 
            
            base.Draw(gameTime);
        }
    }
    
}
