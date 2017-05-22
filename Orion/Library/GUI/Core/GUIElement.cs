using Engine.Library.Components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Engine.Library.GUI.Core
{
    class GUIElement
    {
        #region Variables

        public bool Visible = true;
        protected float layerDepth;

        public bool isDraggable = false;

        public TransformComponent transform;
        protected int width;
        protected int height;
        protected Color color;

        protected List<GUIElement> Childs { get; set; }

        #endregion

        public GUIElement()
        {
            Childs = new List<GUIElement>();
        }
        
        /// <summary>
        /// Returns if the point is inside the polygon
        /// </summary>
        public bool Contains(Vector2 P)
        {
            // Counter-clockwise vectors representing the rectangle
            Vector2 W = new Vector2(transform.GetPosition().X, transform.GetPosition().Y);
            Vector2 Z = new Vector2(transform.GetPosition().X, transform.GetPosition().Y + height);
            Vector2 Y = new Vector2(transform.GetPosition().X + width, transform.GetPosition().Y + height);
            Vector2 X = new Vector2(transform.GetPosition().X + width, transform.GetPosition().Y);
            return (IsLeft(X, Y, P) > 0 && IsLeft(Y, Z, P) > 0 && IsLeft(Z, W, P) > 0 && IsLeft(W, X, P) > 0);
        }

        private float IsLeft(Vector2 A, Vector2 B, Vector2 C)
        {
            return ((B.X - A.X) * (C.Y - A.Y) - (C.X - A.X) * (B.Y - A.Y));
        }

        // Needs to be overrided
        public virtual void Draw()
        {
        }
    }
}
