// Took lots of code from https://github.com/CartBlanche/MonoGame-Samples/blob/master/Primitives/PrimitiveBatch.cs

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Engine.Library.GUI.Core
{
    class PrimitiveDrawing
    {
        GraphicsDevice graphicsDevice;
        BasicEffect effect;

        // Max value before call drawing
        const int defaultBufferSize = 500;
        int actualBufferPosition = 0;

        VertexPositionColor[] vertices = new VertexPositionColor[defaultBufferSize];

        bool isDrawing = false;

        PrimitiveType primitiveType;
        int numVertsPerPrimitive;

        public PrimitiveDrawing(GraphicsDevice graphicsDevice)
        {
            this.graphicsDevice = graphicsDevice;

            effect = new BasicEffect(graphicsDevice);
            effect.VertexColorEnabled = true;
            effect.Projection = Matrix.CreateOrthographicOffCenter
                                (0, graphicsDevice.Viewport.Width,
                                graphicsDevice.Viewport.Height, 0,
                                0, 1);
            effect.World = Matrix.Identity;
            effect.View = Matrix.CreateLookAt(Vector3.Zero, Vector3.Forward,
                          Vector3.Up);
        }

        public void Begin(PrimitiveType primitiveType)
        {
            // Check if our implementation works
            if (primitiveType != PrimitiveType.LineStrip &&
                primitiveType != PrimitiveType.TriangleStrip)
            {
                this.primitiveType = primitiveType;
                numVertsPerPrimitive = NumVertsPerPrimitive(primitiveType);

                effect.CurrentTechnique.Passes[0].Apply();

                if (!isDrawing) isDrawing = true;
            }
        }

        /// <summary>
        /// Add an array of vertices of same color.
        /// </summary>
        public void AddVertices(Vector2[] vertices, Color color)
        {
            for (int i = 0; i < vertices.Length; i++)
            {
                AddVertex(vertices[i], color);
            }
        }

        public void AddVertex(Vector2 vertex, Color color)
        {
            if (!isDrawing) throw new InvalidOperationException("Needs to call Begin() first!");

            // If our buffer limit is not enough to load the new vertices
            bool newPrimitive = ((actualBufferPosition % numVertsPerPrimitive) == 0);
            if (newPrimitive && (actualBufferPosition + numVertsPerPrimitive) >= vertices.Length)
            {
                Flush();
            }
            
            vertices[actualBufferPosition].Position = new Vector3(vertex, 0);
            vertices[actualBufferPosition].Color = color;

            actualBufferPosition++;
        }

        /// <summary>
        /// Calls the drawing.
        /// </summary>
        private void Flush()
        {
            if (isDrawing)
            {
                if (actualBufferPosition == 0) { return; }

                int primitiveCount = actualBufferPosition / numVertsPerPrimitive;

                graphicsDevice.DrawUserPrimitives(primitiveType, vertices, 0, primitiveCount);

                actualBufferPosition = 0;
            }
        }

        public void End()
        {
            if (isDrawing) Flush();
        }

        private int NumVertsPerPrimitive(PrimitiveType primitive)
        {
            switch (primitive)
            {
                case PrimitiveType.LineList:
                    return 2;
                case PrimitiveType.TriangleList:
                    return 3;
                default:
                    throw new InvalidOperationException("primitive is not valid");
            }
        }
    }
}
