using SFML.Graphics;
using SFML.Window;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace TcGame
{
  public class Actor : Transformable, Drawable
  {
    public Action<Actor> OnDestroy;
    public Vector2f Forward;
    protected float Speed;
    public enum ELayer
    {
      Background,
      Back,
      Middle,
      Front,
      Hud
    }
    public ELayer Layer { get; set; }
    protected Actor()
    {
      Forward = new Vector2f(1, 0);
      Speed = 0;
    }
    public virtual void Update(float dt)
    {
      Position += Forward * Speed * dt;
    }
    public virtual void Draw(RenderTarget target, RenderStates states)
    {

    }
    public void Center()
    {
      Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
    }

    public virtual FloatRect GetLocalBounds()
    {
      return new FloatRect();
    }
    public virtual FloatRect GetGlobalBounds()
    {
      return Transform.TransformRect(GetLocalBounds());
    }
    public void Destroy()
    {
      Engine.Get.Scene.Destroy(this);
    }
    public void PlaySound(string soundName, float volume = 100.0f)
    {
      Engine.Get.SoundMgr.PlaySound(soundName, volume);
    }
  }
}
