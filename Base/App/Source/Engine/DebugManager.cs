using SFML.Graphics;
using SFML.Window;
using SFML.System;

namespace TcGame
{
  public class DebugManager : Drawable
  {
    private LineDrawer lineDrawer;
    private CircleDrawer circleDrawer;
    private Text[] texts;
    private CircleShape[] circles;
    private uint currentText;
    private uint currentCircle;
    private Font font;

    public void Init()
    {
      currentText = 0;
      currentCircle = 0;

      font = new Font("Data/Fonts/georgia.ttf");
      lineDrawer = new LineDrawer(2000);
      texts = new Text[100];
      circles = new CircleShape[5000];
      circleDrawer = new CircleDrawer(5000);

      for (int i = 0; i < texts.Length; ++i)
      {
        texts[i] = new Text(" ", font);
      }

      for (int i = 0; i < circles.Length; ++i)
      {
        circles[i] = new CircleShape();
      }
    }

    public void DeInit()
    {
      for (int i = 0; i < texts.Length; ++i)
      {
        texts[i].Dispose();
      }

      for (int i = 0; i < circles.Length; ++i)
      {
        circles[i].Dispose();
      }

      texts = null;
      circles = null;
    }

    public void Update(float deltaSeconds)
    {
      lineDrawer.ClearLines();
      circleDrawer.ClearCircles();
      currentText = 0;
      currentCircle = 0;
    }

    public void Circle(Vector2f position, float radius, Color color, float thickness = 2.0f)
    {
      CircleShape circle = circles[currentCircle];

      circle.FillColor = Color.Transparent;
      circle.OutlineColor = color;
      circle.OutlineThickness = thickness;
      circle.Radius = radius;
      circle.Position = position - new Vector2f(radius, radius);

      ++currentCircle;
    }


    public void Line(Vector2f start, Vector2f end, Color color, float thickness)
    {
      lineDrawer.AddLine(start, end, thickness, color);
    }

    public void Box(FloatRect rect, Color color, float thickness = 2.0f)
    {
      Vector2f tl = new Vector2f(rect.Left, rect.Top);
      Vector2f tr = new Vector2f(rect.Left + rect.Width, rect.Top);
      Vector2f bl = new Vector2f(rect.Left, rect.Top + rect.Height);
      Vector2f br = new Vector2f(rect.Left + rect.Width, rect.Top + rect.Height);

      lineDrawer.AddLine(tl, tr, thickness, color);
      lineDrawer.AddLine(tl, bl, thickness, color);
      lineDrawer.AddLine(tr, br, thickness, color);
      lineDrawer.AddLine(bl, br, thickness, color);
    }

    public void Arrow(Vector2f start, Vector2f offset, Color color, float thickness = 2.0f)
    {
      Vector2f end = start + offset;
      Line(start, end, color, thickness);

      const float ArrowAngle = 20.0f;
      const float ArrowDist = 20.0f;

      Vector2f p0 = end + (start - end).Normal().Rotate(ArrowAngle) * ArrowDist;
      Vector2f p1 = end + (start - end).Normal().Rotate(-ArrowAngle) * ArrowDist;

      Line(end, p0, color, thickness);
      Line(end, p1, color, thickness);
    }

    public void Label(Vector2f position, string displayedString, Color color, uint size = 25)
    {
      Text text = texts[currentText];

      text.CharacterSize = size;
      text.FillColor = color;
      text.DisplayedString = displayedString;
      text.Position = position;

      text.Font = font;
      currentText = (uint)(currentText + 1 % texts.Length);
    }

    public void Label(Vector2f position, Vector2f offset, string displayedString, Color color, uint size = 25)
    {
      Label(position + offset, displayedString, color, size);
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
      target.Draw(circleDrawer, states);

      target.Draw(lineDrawer, states);

      for (uint i = 0; i < currentText; ++i)
      {
        target.Draw(texts[i], states);
      }

      for (uint i = 0; i < currentCircle; ++i)
      {
        target.Draw(circles[i], states);
      }
    }
  }
}
