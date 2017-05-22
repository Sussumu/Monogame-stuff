using Engine.Library.GameObjects;
using Engine.Library.Graphics;
using Engine.Library.GUI.Core;
using Engine.Library.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Orion.Library.Utils;
using Orion.Nodes.Prefabs;
using System;
using System.Collections.Generic;

namespace Engine.Library.Scenes
{
	/// <summary>
	/// Use this to initialize other scenes or if your game doesn't have any scene yet
	/// </summary>
	class StartupScene : Scene
    {
        public override SceneState ActualState { get; set; }
        public override List<IGameObject> GameObjects { get; set; }
        MouseHandler mouseHandler;
        public List<GUIElement> GUIElements;
		PerformanceHelper perf;

		private Person person;
		
		SpriteFont font;
		Random random = new Random();

		public override void Load(ContentManager content)
        {
            Game.Instance.IsMouseVisible = true;
            mouseHandler = new MouseHandler();
			GameObjects = new List<IGameObject>();
			GUIElements = new List<GUIElement>();
			perf = new PerformanceHelper();
			
            mouseHandler.Click += new MouseHandler.MouseClickHandler(HandleClick);
            mouseHandler.Hover += new MouseHandler.MouseClickHandler(HandleHover);
            mouseHandler.Drag += new MouseHandler.MouseDragHandler(HandleDrag);

			person = new Person(content);

			for (int i = 0; i < 100; i++)
				GameObjects.Add(person);

			font = content.Load<SpriteFont>("Fonts/Font");
		}

        public override void Unload(Scene newScene)
        {
            Game.Instance.ActualScene = newScene;
        }

        public override void ClearScreen()
        {
            Game.Instance.GraphicsDevice.Clear(Color.White);
        }

        public override void Update(GameTime gameTime)
        {
			mouseHandler.Update(GUIElements);
        }

		public override void Draw(GameTime gameTime)
        {
            Game.Instance.spriteBatch.Begin();
			
            foreach (var element in GUIElements)
            {
                element.Draw();
            }

			foreach (var gameObject in GameObjects)
			{
				foreach (SpriteComponent drawable in gameObject.Components.FindAll(c => c.GetType() == typeof(SpriteComponent)))
				{
					drawable.Draw(new Vector2(random.Next(0, 800), random.Next(0, 600)), 64, 64, Color.White, 0, new Vector2(0, 0), new Vector2(1, 1), SpriteEffects.None, 0);
				}
			}

			// Draws time since last frame on (20, 20)
			Game.Instance.spriteBatch.DrawString(font, gameTime.ElapsedGameTime.TotalMilliseconds.ToString(), new Vector2(20, 20), Color.Black);

			Game.Instance.spriteBatch.End();
        }

        private void HandleClick(GUIElement listener, MouseState mouseState)
        {
        }

        private void HandleDrag(GUIElement listener, int xRel, int yRel)
        {
        }

        private void HandleHover(GUIElement listener, MouseState mouseState)
        {
        }
    }
}
