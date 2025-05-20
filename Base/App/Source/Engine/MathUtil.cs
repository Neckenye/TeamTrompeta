using System;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
  public static class MathUtil
  {
    public static float DEG2RAD = (float)(Math.PI / 180.0f);
    public static float RAD2DEG = (float)(180.0f / Math.PI);

    public static float Size(this Vector2f vector)
    {
      return (float)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
    }

    public static float SizeSquared(this Vector2f vector)
    {
      return (vector.X * vector.X + vector.Y * vector.Y);
    }

    public static Vector2f Normal(this Vector2f vector)
    {
      Vector2f result = vector;

      float size = vector.Size();
      if (size > 0.0f)
      {
        result.X /= size;
        result.Y /= size;
      }

      return result;
    }

    public static float Dot(Vector2f lhs, Vector2f rhs)
    {
      return lhs.X * rhs.X + lhs.Y * rhs.Y;
    }

    public static float Angle(Vector2f lhs, Vector2f rhs)
    {
      return (float)Math.Acos(Dot(lhs.Normal(), rhs.Normal())) * RAD2DEG;
    }

    public static float Cross(Vector2f lhs, Vector2f rhs)
    {
      return (lhs.X * rhs.Y) - (lhs.Y * rhs.X);
    }

    public static float Sign(Vector2f lhs, Vector2f rhs)
    {
      return (Cross(lhs, rhs) <= 0.0f) ? 1.0f : -1.0f;
    }

    public static Vector2f Rotate(this Vector2f v, float angle)
    {
      float sin0 = (float)Math.Sin(angle * DEG2RAD);
      float cos0 = (float)Math.Cos(angle * DEG2RAD);

      if (cos0 * cos0 < 0.001f * 0.001f)
        cos0 = 0.0f;

      Vector2f result = new Vector2f();
      result.X = cos0 * v.X - sin0 * v.Y;
      result.Y = sin0 * v.X + cos0 * v.Y;
      return result;
    }
  }
}
