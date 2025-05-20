using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
  public class CircleDrawer : Drawable
  {
    private Vertex[] vertices;
    private RenderStates rs;
    private uint currentVertex;

    public CircleDrawer(uint maxCircles)
    {
      vertices = new Vertex[maxCircles * 4];
      rs = new RenderStates(new Texture("Data/Textures/Circle.png"));
      currentVertex = 0;

      for (int i = 0; i < maxCircles * 4; ++i)
      {
        vertices[i] = new Vertex();
      }
    }

    public void AddCircle(Vector2f position, float radius, Color color)
    {
      vertices[currentVertex + 0].Position = position + new Vector2f(-radius, +radius);
      vertices[currentVertex + 1].Position = position + new Vector2f(-radius, -radius);
      vertices[currentVertex + 2].Position = position + new Vector2f(+radius, -radius);
      vertices[currentVertex + 3].Position = position + new Vector2f(+radius, +radius);

      vertices[currentVertex + 0].Color = color;
      vertices[currentVertex + 1].Color = color;
      vertices[currentVertex + 2].Color = color;
      vertices[currentVertex + 3].Color = color;

      currentVertex += 4;
    }

    public void ClearCircles()
    {
      currentVertex = 0;
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
      target.Draw(vertices, 0, currentVertex, PrimitiveType.Quads, rs);
    }
  }
}
