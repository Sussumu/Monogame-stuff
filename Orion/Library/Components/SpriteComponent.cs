using Engine.Library.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Library.Graphics
{
    /// <summary>
    /// Handles the drawing of a Texture2D sprite
    /// </summary>
    class SpriteComponent : Component
    {
        Texture2D sprite;

        public SpriteComponent(string spriteName)
        {
            sprite = Game.Instance.Content.Load<Texture2D>(spriteName);
        }

        public void Draw(Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            Game.Instance.spriteBatch.Draw(sprite, position, null, color, rotation, origin, scale, effects, layerDepth);
        }

        /// <summary>
        /// Draw() that allows to texture resizing
        /// </summary>
        public void Draw(Vector2 position, int width, int height, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects effects, float layerDepth)
        {
            Game.Instance.spriteBatch.Draw(sprite, new Rectangle((int)position.X, (int)position.Y, width, height),
                null, color, rotation, origin, effects, layerDepth);
        }
    }
}
