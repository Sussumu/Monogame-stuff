using Engine.Library.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Engine.Library.GUI.Core
{
    class Label : GUIElement
    {
        public string Text { get; set; }
        private SpriteFont font;

        public Label(string text, string fontName, Color color, TransformComponent transform)
        {
            Text = text;
            font = Game.Instance.Content.Load<SpriteFont>(fontName);
            this.color = color;
            this.transform = transform;
        }

        public override void Draw()
        {
            Game.Instance.spriteBatch.DrawString(font, Text, transform.GetPosition(), color,
                transform.GetRotation(), transform.GetPivot(), transform.GetScale(), SpriteEffects.None, layerDepth);
        }
    }
}
