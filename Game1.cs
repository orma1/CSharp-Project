#region data
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
#endregion

namespace OrProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        #region data
        public static DlgtUpdate EVENT_UPDATE;
        public static DlgtDraw EVENT_DRAW;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D maptex;
        Drawing car;
        Texture2D cartex;
        Engine engine;
        Vehicle vehicle;
        Camera cam;
        #endregion

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

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Stat.Initialize(Content, spriteBatch, GraphicsDevice);
            maptex = Content.Load<Texture2D>("Track");
            cartex = Content.Load<Texture2D>("car");
            Stat.background = new Background(maptex);
            engine = new Engine(8f, 0.5f);
            vehicle = new Vehicle(cartex, new Vector2(300, 260), new Vector2(0,0), engine, true);
            vehicle.basicKeys = new PlayerKeys(Keys.Up, Keys.Down, Keys.Right, Keys.Left);
            vehicle.scale = Vector2.One * 0.4f;
            vehicle.makeTransparentColor(Color.White);
            cam = new Camera (new Viewport(GraphicsDevice.Viewport.Bounds), vehicle, new Vector2(1f));
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (EVENT_UPDATE != null) EVENT_UPDATE(gameTime);
            cam.UpdateMatri();
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, null, null, null,
                null, cam.matri);
            if (EVENT_DRAW != null) EVENT_DRAW();
            Stat.background.Draw();
            vehicle.Draw();
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
