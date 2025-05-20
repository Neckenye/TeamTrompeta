using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
  public class Background : StaticActor
  {
    public Background()
    {
      Layer = ELayer.Background;
      Sprite = new Sprite(new Texture("Data/Textures/Background.png"));
    }
    public override void Update(float dt)
    {
    }
  }
}

