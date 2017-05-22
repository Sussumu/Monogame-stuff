using Engine.Library.Components;
using Engine.Library.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Library.GUI.Core
{
    enum ButtonState
    {
        NONE,
        HOVER,      // Pointer is over button
        PRESSED,    // Mouse click
        CLICKED     // Mouse click and release
    }

    class Button : GUIElement
    {
        #region Variables
        
        PrimitiveDrawing primitiveDrawing;
        SpriteComponent backgroundImage;
        Vector2[] vertices;

        ButtonState buttonState = ButtonState.NONE;
                
        #endregion

        #region Constructors

        /// <summary>
        /// Creates a monocolored button
        /// </summary>
        public Button(int x, int y, int width, int height, float rotation, Color color, float layerDepth)
        {
            transform = new TransformComponent(new Vector2(x, y), rotation);
            this.width = width;
            this.height = height;
            this.color = color;

            primitiveDrawing = new PrimitiveDrawing(Game.Instance.GraphicsDevice);
            backgroundImage = null;
            vertices = new Vector2[4];
            vertices[0] = new Vector2(x, y);
            vertices[1] = new Vector2(x, y + height);
            vertices[2] = new Vector2(x + width, y + height);
            vertices[3] = new Vector2(x + width, y);

            this.layerDepth = layerDepth;
        }
        
        /// <summary>
        /// Creates a button with background image
        /// </summary>
        /// <param name="imageName">The name you used on Monogame Content Manager</param>
        public Button(int x, int y, int width, int height, float rotation, string imageName, float layerDepth)
        {
            transform = new TransformComponent(new Vector2(x, y), rotation);
            this.width = width;
            this.height = height;
            color = Color.White;

            primitiveDrawing = null;
            backgroundImage = new SpriteComponent(imageName);

            this.layerDepth = layerDepth;
        }

        #endregion
        
        public override void Draw()
        {
            if (Visible)
            {
                // If it is monocolored
                if (backgroundImage == null)
                {
                    primitiveDrawing.Begin(PrimitiveType.TriangleList);
                    primitiveDrawing.AddVertices(vertices, color);
                    primitiveDrawing.End();
                }
                // If it has an image
                else
                {
                    backgroundImage.Draw(transform.GetPosition(), width, height, color, transform.GetRotation(),
                        transform.GetPivot(), transform.GetScale(), SpriteEffects.None, layerDepth);
                }
            }
        }
    }
}
