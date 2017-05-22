using Microsoft.Xna.Framework;

namespace Engine.Library.Components
{
    /// <summary>
    /// Handles the position, rotation and transformations of your object
    /// </summary>
    class TransformComponent : Component
    {
        #region Variables

        private Vector2 position;
        private float rotation;
        private Vector2 pivot;
        private Vector2 scale;

        #endregion

        #region Getters

        public Vector2 GetPosition() { return position; }
        public float GetRotation() { return rotation; }
        public Vector2 GetPivot() { return pivot; }
        public Vector2 GetScale() { return scale; }

        #endregion

        #region Constructors

        public TransformComponent(Vector2 position)
        {
            this.position = position;
            rotation = 0.0f;
            pivot = Vector2.Zero;
            scale = new Vector2(1, 1);
        }

        public TransformComponent(Vector2 position, float rotation)
        {
            this.position = position;
            this.rotation = rotation;
            pivot = Vector2.Zero;
            scale = new Vector2(1, 1);
        }

        #endregion

        #region Auxiliary Methods

        public void Translate(float x, float y)
        {
            position.X += x;
            position.Y += y;
        }

        public void TranslateAbsolute(float x, float y)
        {
            position.X = x;
            position.Y = y;
        }

        public void Rotate(float angle)
        {
            rotation += angle;
        }

        public void Scale(float factor)
        {
            scale *= factor;
        }

        public void Scale(Vector2 factor)
        {
            scale *= factor;
        }

        #endregion
    }
}
