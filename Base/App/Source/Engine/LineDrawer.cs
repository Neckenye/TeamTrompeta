using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
  public class LineDrawer : Drawable
  {
    private Vertex[] vertices;
    private RenderStates rs;
    private uint currentLine;

    public LineDrawer(uint maxLines)
    {
      vertices = new Vertex[maxLines * 4];
      rs = new RenderStates(new Texture("Data/Textures/Pixel.png"));
      currentLine = 0;

      for (int i = 0; i < maxLines * 4; ++i)
      {
        vertices[i] = new Vertex();
      }
    }

    public void AddLine(Vector2f p0, Vector2f p1, float thickness, Color color)
    {
      Vector2f offset = MathUtil.Rotate((p0 - p1), 90.0f).Normal() * thickness;

      vertices[currentLine + 0].Position = p0 - offset;
      vertices[currentLine + 1].Position = p0 + offset;
      vertices[currentLine + 2].Position = p1 + offset;
      vertices[currentLine + 3].Position = p1 - offset;

      vertices[currentLine + 0].Color = color;
      vertices[currentLine + 1].Color = color;
      vertices[currentLine + 2].Color = color;
      vertices[currentLine + 3].Color = color;

      currentLine += 4;
    }

    public void ClearLines()
    {
      currentLine = 0;
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
      rs.Transform = states.Transform;
      target.Draw(vertices, 0, currentLine, PrimitiveType.Quads, rs);
    }
  }
}
