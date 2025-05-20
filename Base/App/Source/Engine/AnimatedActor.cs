using SFML.Graphics;

namespace TcGame
{
  public class AnimatedActor : Actor
  {
    public AnimatedSprite AnimatedSprite { get; set; }

    public override void Draw(RenderTarget target, RenderStates states)
    {
      base.Draw(target, states);

      if (AnimatedSprite != null)
      {
        states.Transform *= Transform;
        target.Draw(AnimatedSprite, states);
      }
    }

    public override void Update(float dt)
    {
      base.Update(dt);

      if (AnimatedSprite != null)
      {
        AnimatedSprite.Update(dt);
      }
    }

    public override FloatRect GetLocalBounds()
    {
      return (AnimatedSprite != null) ? AnimatedSprite.GetLocalBounds() : base.GetLocalBounds();
    }
  }
}

