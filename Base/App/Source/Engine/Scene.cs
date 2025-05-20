using System.Collections.Generic;
using SFML.Graphics;
using System;

namespace TcGame
{
  public class Scene : Drawable
  {
    private List<Actor> actors = new List<Actor>();
    private List<Actor> actorsToDestroy = new List<Actor>();
    private List<Actor> actorsToAdd = new List<Actor>();

    public T Create<T>(Actor Parent = null) where T : Actor
    {
      return Create(typeof(T)) as T;
    }

    public object Create(Type type)
    {
      Actor actor = null;
      if (type.IsSubclassOf(typeof(Actor)))
      {
        actor = Activator.CreateInstance(type) as Actor;
        actorsToAdd.Add(actor);
      }
      return actor;
    }
    public void Destroy(Actor actor)
    {
      actorsToAdd.Remove(actor);
      actorsToDestroy.Add(actor);

      if (actor.OnDestroy != null)
      {
        actor.OnDestroy(actor);
      }
    }

    public void Update(float dt)
    {
      // Remove destroyed actors
      actors.RemoveAll(actorsToDestroy.Contains);

      // Add new actors
      actors.AddRange(actorsToAdd);
      actorsToAdd.Clear();

      // Update actors
      foreach (Actor actor in actors)
      {
        actor.Update(dt);
      }
    }

    public void Draw(RenderTarget target, RenderStates states)
    {
      foreach (Actor a in actors)
        if (a.Layer == Actor.ELayer.Background)
          a.Draw(target, states);
      foreach (Actor a in actors)
        if (a.Layer == Actor.ELayer.Back)
          a.Draw(target, states);
      foreach (Actor a in actors)
        if (a.Layer == Actor.ELayer.Middle)
          a.Draw(target, states);
      foreach (Actor a in actors)
        if (a.Layer == Actor.ELayer.Front)
          a.Draw(target, states);
      foreach (Actor a in actors)
        if (a.Layer == Actor.ELayer.Hud)
          a.Draw(target, states);
    }
    public List<T> GetAll<T>() where T : Actor
    {
      return actors.FindAll(x => !actorsToDestroy.Contains(x)).FindAll(x => x is T).ConvertAll(x => x as T);
    }
    public T GetFirst<T>() where T : Actor
    {
      return actors.Find(x => x is T) as T;
    }
    public T GetRandom<T>() where T : Actor
    {
      Random r = new Random();
      List<T> tActors = GetAll<T>();
      return (tActors.Count > 0) ? tActors[r.Next(tActors.Count)] : null;
    }
  }
}
