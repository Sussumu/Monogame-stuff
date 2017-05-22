using Engine.Library.Components;
using Engine.Library.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Library.GUI.Core
{
    class Image : GUIElement
    {
        SpriteComponent backgroundImage;

        /// <summary>
        /// Creates a simple image to show on screen
        /// </summary>
        /// <param name="imageName">The name you used on Monogame Content Manager</param>
        public Image(int x, int y, int width, int height, float rotation, string imageName, float layerDepth)
        {
            transform = new TransformComponent(new Vector2(x, y), rotation);
            this.width = width;
            this.height = height;
            backgroundImage = new SpriteComponent(imageName);
            color = Color.White;

            this.layerDepth = layerDepth;
        }

        public override void Draw()
        {
            if (Visible)
            {
                backgroundImage.Draw(transform.GetPosition(), width, height, color, transform.GetRotation(),
                            transform.GetPivot(), transform.GetScale(), SpriteEffects.None, layerDepth);
            }
        }
    }
}
