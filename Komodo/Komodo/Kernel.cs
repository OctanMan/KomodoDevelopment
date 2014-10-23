using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Komodo.Interfaces;
using Komodo.Managers;
//using Indiefreaks.Xna.Profiler;
//using Indiefreaks.AOP.Profiler;

namespace Komodo
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    class Kernel : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        CollisionAlarm cAlarm;
        ControlManager mCtrlManager;
        IEntityManager mEntityManager;
        ISceneManager mSceneManager;
        IRenderer mRenderer;
        //ISceneGraph mSceneGraph;
        IAIComponentManager mAIManager;
        ICollisionManager mCManager;
        //Texture2D texture;
        //VisualAsset vAsset;
        //List<X2DToken> actualFuckingDrawingListTime;
        private Rectangle TitleSafe;

        public Color SingletonCol = Color.Purple;
       

        //.Net has 'eager initialisation' of static classes
        private static readonly Kernel mInstance = new Kernel();

        private Kernel()
        {
            this.IsFixedTimeStep = true;
            graphics = new GraphicsDeviceManager(this);
            
            /*For when the time comes ;)
            graphics.PreferredBackBufferHeight = 1366;
            graphics.PreferredBackBufferWidth = 768;
            graphics.IsFullScreen = true;
            */
            Content.RootDirectory = "Content";


           // var profilerGameComponent = new ProfilerGameComponent(this, "ProfilerFont"); ProfilingManager.Run = true; Components.Add(profilerGameComponent);
        }

        //Get Singleton reference of Kernel 
        public static  Kernel Instance()
        {
            return mInstance;
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

            //Initialise our Manager Instances here - using parameterless constructors
            cAlarm = null;
            mEntityManager = null;
            mSceneManager = null;
            mRenderer = null;
            //mSceneGraph = null;
            mAIManager = null;
            mCManager = null;

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            

            //MANAGER CLASSES*********************************************************************
            //singleton Control Manager to ensure constant ability for player input
            mCtrlManager = new ControlManager(); mCtrlManager.ManagerSetup(mCtrlManager);
            //AI Component Manager for assigning minds (AI) to entities
            mAIManager = new AIComponentManager();

            mSceneManager = new SceneManager();
            
            mEntityManager = new EntityManager();
            mRenderer = new RenderManager();
             
            //Services, spriteBatch, mSceneManager, mAIManager, mCManager
            
            //GAMETIME COMPONENTS***************************************************************** 
            cAlarm = new CollisionAlarm();
            mCManager = new CollisionManager(cAlarm);
           
            //mSceneGraph = new SceneGraph();
         
            
           
            //MANAGER SETUP**********************************************************************
            //Set up references of other managers and components once all have been created

            mRenderer.ManagerSetup(mSceneManager, spriteBatch, Services);
            mSceneManager.ManagerSetup(mEntityManager, mCManager);
            mEntityManager.ManagerSetup(Services, spriteBatch, mAIManager);
       

            //Create A New Scene - This is done through hard coded parameters at the moment - passing parameters should be worked on
            mSceneManager.NewScene();


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
        /// 

        protected Rectangle GetTitleSafeArea(float percent)
        {
            Rectangle retval = new Rectangle(
                graphics.GraphicsDevice.Viewport.X,
                graphics.GraphicsDevice.Viewport.Y,
                graphics.GraphicsDevice.Viewport.Width,
                graphics.GraphicsDevice.Viewport.Height);
            return retval;
        }

        protected override void Update(GameTime gameTime)
        {
            //HERE IN THE UPDATE METHOD DIFFERENT MANAGERS ARE CALLED TO UPDATE AND RENDER IN THE GAME LOOP
            //BY HAVING THE KERNEL CONTROL WHEN TO UPDATE AND RENDER, WE CAN DE-COUPLE THE LOOP IF
            //CIRCUMSTANCES DICTATE IT - IE. LOADING THE GAME IN THE BACKGROUND WHILE DISPLAYING A LOADING SCREEN


            // Allows the game to exit
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
              //  this.Exit();

            // TODO: Add your update logic here
            
            //UPDATE VARIOUS GAME COMPONENTS VIA MANAGERS*******************************************************************
            
            //Get player input and update PlayerMind position/actions
            mCtrlManager.UpdateInput();

            //Update Entities through their Minds (including the player position)
            mAIManager.MindControlUpdate();
                        
            //See what the result of player and AI actions are, check for collisions, Add/Remove entities and modify the SceneGraph
            mSceneManager.UpdateSceneSnapshot();

           
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            //GraphicsDevice.Clear(SingletonCol);

            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            mRenderer.Draw(ref gameTime);
            
            spriteBatch.End();
           

            
            // TODO: Add your drawing code here 
            
            base.Draw(gameTime);
            
            
        }
    }
}
