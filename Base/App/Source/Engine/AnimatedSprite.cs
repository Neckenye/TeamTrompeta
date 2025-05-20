using SFML.Graphics;
using System.Collections.Generic;
using SFML.Window;
using SFML.System;
using System;

namespace TcGame
{
  public class AnimatedSprite : Transformable, Drawable
  {
    private List<IntRect> frames = new List<IntRect>();
    private Texture texture;
    private Vertex[] vertices = new Vertex[4];
    private float currentTime;
    private int currentFrame;

    public bool Loop { get; set; }

    public int NumFrames { get { return frames.Count; } }

    public float FrameTime { get; set; }

    public AnimatedSprite(Texture text, uint numColumns, uint numRows)
    {
      Loop = true;

      texture = text;
      FrameTime = 0.2f;

      IntRect frame;

      frame.Width = (int)(text.Size.X / numColumns);
      frame.Height = (int)(text.Size.Y / numRows);

      for (int r = 0; r < numRows; ++r)
      {
        for (int c = 0; c < numColumns; ++c)
        {
          frame.Top = r * frame.Width;
          frame.Left = c * frame.Width;
          frames.Add(frame);
        }
      }

      SetFrame(currentFrame);
    }

    private void SetFrame(int frame)
    {
      if (frame < frames.Count)
      {
        IntRect frameRect = frames[frame];

        vertices[0].Position = new Vector2f(0.0f, 0.0f);
        vertices[1].Position = new Vector2f(0.0f, frameRect.Height);
        vertices[2].Position = new Vector2f(frameRect.Width, frameRect.Height);
        vertices[3].Position = new Vector2f(frameRect.Width, 0.0f);

        float left = frameRect.Left;
        float right = left + frameRect.Width;
        float top = frameRect.Top;
        float bottom = top + frameRect.Height;

        vertices[0].TexCoords = new Vector2f(left, top);
        vertices[1].TexCoords = new Vector2f(left, bottom);
        vertices[2].TexCoords = new Vector2f(right, bottom);
        vertices[3].TexCoords = new Vector2f(right, top);

        vertices[0].Color = Color.White;
        vertices[1].Color = Color.White;
        vertices[2].Color = Color.White;
        vertices[3].Color = Color.White;
      }
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
      states.Transform *= Transform;
      states.Texture = texture;

      target.Draw(vertices, 0, 4, PrimitiveType.Quads, states);
    }

    public void Update(float dt)
    {
      currentTime += dt;

      if (currentTime >= FrameTime)
      {
        currentTime = currentTime % FrameTime;

        if (Loop)
        {
          currentFrame = (currentFrame + 1) % NumFrames;
        }
        else
        {
          currentFrame = Math.Min(currentFrame + 1, NumFrames - 1);
        }

        SetFrame(currentFrame);
      }
    }

    public FloatRect GetLocalBounds()
    {
      IntRect frame = frames[currentFrame];
      return new FloatRect(0.0f, 0.0f, frame.Width, frame.Height);
    }
  }
}
