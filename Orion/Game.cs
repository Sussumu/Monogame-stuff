using Engine.Library.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Engine
{
    public class Game : Microsoft.Xna.Framework.Game
    {
        // An easy way to access its methods
        public static Game Instance;

        // A scene always has to be instanced in game
        public Scene ActualScene { get; set; }

        GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch { get; set; }

        public Game()
        {
            Instance = this;

            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }
		
        protected override void Initialize()
        {
            ActualScene = new StartupScene();

            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 600;
            graphics.ApplyChanges();

            base.Initialize();
        }
		
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            ActualScene.Load(Content);
        }
		
        protected override void UnloadContent()
        {
            ActualScene.Unload(null);
        }

        protected override void Update(GameTime gameTime)
        {
            ActualScene.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            ActualScene.ClearScreen();
            ActualScene.Draw(gameTime);

            base.Draw(gameTime);
        }
    }
}
