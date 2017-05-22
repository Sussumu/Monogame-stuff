using Engine.Library.GUI.Core;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Engine.Library.Input
{
    class MouseHandler
    {
        public GUIElement draggedElement = null;
        MouseState mouseState, oldMouseState;

        // Event to mouse clicks
        public delegate void MouseClickHandler(GUIElement button, MouseState mouseState);
        public event MouseClickHandler Click;
        public event MouseClickHandler Hover;
        public delegate void MouseDragHandler(GUIElement button, int xRel, int yRel);
        public event MouseDragHandler Drag;

        public void Update(List<GUIElement> GUIElements)
        {
            mouseState = Mouse.GetState();

            // Key pressed
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                oldMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                foreach (GUIElement element in GUIElements)
                {
                    if (element.Contains(new Vector2(mouseState.X, mouseState.Y)))
                    {
                        OnClick(element, mouseState);
                        if (element.isDraggable)
                        {
                            draggedElement = element;
                            break;
                        }                            
                    }
                }
            }
            // Key released
            if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                oldMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                foreach (GUIElement element in GUIElements)
                {
                    if (element.Contains(new Vector2(mouseState.X, mouseState.Y)))
                    {
                        OnClick(element, mouseState);
                        draggedElement = null;
                        break;
                    }
                }
            }
            // Key pressing
            else if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                oldMouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                foreach (GUIElement element in GUIElements)
                {
                    if (draggedElement != null)
                    {
                        OnDrag(draggedElement, mouseState.X - oldMouseState.X, mouseState.Y - oldMouseState.Y);
                        break;
                    }
                }
            }
            // Mouse hover
            else if (mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released)
            {
                foreach (GUIElement element in GUIElements)
                {
                    if (element.Contains(new Vector2(mouseState.X, mouseState.Y)))
                    {
                        OnHover(element, mouseState);
                        break;
                    }
                }
            }

            oldMouseState = mouseState;
        }

        // Raise the event to mouse click
        protected virtual void OnClick(GUIElement element, MouseState mouseState)
        {
            Click(element, mouseState);
        }

        // Raise the event to mouse drag
        protected virtual void OnDrag(GUIElement element, int xRel, int yRel)
        {
            Drag(element, xRel, yRel);
        }

        // Raise the event to mouse hover
        protected virtual void OnHover(GUIElement element, MouseState mouseState)
        {
            Hover(element, mouseState);
        }
    }
}
