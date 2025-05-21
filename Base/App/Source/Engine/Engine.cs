using System;
using System.Threading;
using SFML.Window;
using SFML.Graphics;
using SFML.System;

namespace TcGame
{
  public class Engine
  {
    /// <summary>
    /// Singleton instance
    /// </summary>
    private static Engine instance;

    /// <summary>
    /// Returns the Singleton Instance
    /// </summary>
    public static Engine Get
    {
      get
      {
        if (instance == null)
        {
          instance = new Engine();
        }

        return instance;
      }
    }

    /// <summary>
    /// Private Constructor (Singleton pattern purposes)
    /// </summary>
    private Engine()
    {

    }
    public Scene Scene { private set; get; }
    public SoundManager SoundMgr { private set; get; }
    public Vector2f MousePos { get { return new Vector2f(Mouse.GetPosition(Window).X, Mouse.GetPosition(Window).Y); } }
    public RenderWindow Window { private set; get; }

    public Random random = new Random(DateTime.Now.Millisecond);

    public float Time;

    private void Init()
    {
      VideoMode videoMode = new VideoMode(1024, 768);
      Window = new RenderWindow(videoMode, "Arkanoid");
      Window.SetVerticalSyncEnabled(true);

      SoundMgr = new SoundManager();
      Scene = new Scene();
    }

    private void DeInit()
    {
      Window.Dispose();
    }

    private void Update(float dt)
    {
      Window.DispatchEvents();

      if (Keyboard.IsKeyPressed(Keyboard.Key.Escape))
      {
        Window.Close();
      }

      Scene.Update(dt);
      SoundMgr.Update(dt);

      Time += dt;
    }

    private void Draw()
    {
      Window.Clear(new Color(100, 100, 100));

      Window.Draw(Scene);

      Window.Display();
    }

    private bool IsAlive()
    {
      return Window.IsOpen;
    }

    public void Run(Game game)
    {
      Init();
      game.Init();

      if (game != null)
      {
        const int FPS = 60;
        const double deltaSeconds = 1.0 / FPS;

        const double maxTimeDiff = 5.0;
        const int maxSkippedFrames = 5;

        DateTime initialTime = DateTime.Now;
        int skippedFrames = 1;
        double nextTime = (DateTime.Now - initialTime).TotalMilliseconds / 1000.0;

        // Game Loop
        while (IsAlive())
        {
          double currTime = (DateTime.Now - initialTime).TotalMilliseconds / 1000.0;

          if ((currTime - nextTime) > maxTimeDiff)
          {
            nextTime = currTime;
          }

          if (currTime >= nextTime)
          {
            nextTime += deltaSeconds;

            // Update step
            Update((float)deltaSeconds);
            game.Update((float)deltaSeconds);
            if ((currTime < nextTime) || (skippedFrames > maxSkippedFrames))
            {
              // Draw step
              Draw();
              skippedFrames = 1;
            }
            else
            {
              skippedFrames++;
            }
          }
          else
          {
            int sleepTime = (int)(1000.0 * (nextTime - currTime));
            if (sleepTime > 0)
            {
              Thread.Sleep(sleepTime);
            }
          }
        }
      }

      game.DeInit();
      DeInit();
    }
  }
}
