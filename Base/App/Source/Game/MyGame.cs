using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Diagnostics.Contracts;

namespace TcGame
{
  public class MyGame : Game
  {
        
    public Hud hud { private set; get; }
    public Background background { get;  private set;}
    public GameOverScreen gameOverScreen { get; private set;}
    private static MyGame instance;
    public static MyGame Get
    {
      get
      {
        if (instance == null)
        {
          instance = new MyGame();
        }

        return instance;
      }
    }
    private MyGame()
    {
    }
    public void Init()
    {
      gameOverScreen = Engine.Get.Scene.Create<GameOverScreen>();

      
    }
       //Hola
    public void DeInit()
    {
    }
    public void Update(float dt)
    {
            
      
    }
    private void DestroyAll<T>() where T : Actor
    {
      var actors = Engine.Get.Scene.GetAll<T>();
      actors.ForEach(x => x.Destroy());
    }
  }
}

