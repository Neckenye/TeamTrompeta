using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace TcGame
{
    public class MyGame : Game
    {
        public Hud hud { private set; get; }
        public List<ObjectToCollect> objectList = new List<ObjectToCollect>();
        public ObjectToCollect objectToCollect { private set; get; }
        public Player player { private set; get; }
        public Background background { get; private set; }
        private static MyGame instance;

        private float timer;
        //public static float timeLeft = 120f;
        public static float timeLeft = 2;  //PER SABER SI VA
        public static bool timeOver = false;
        public static float cooldown = 5f;

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
            background = Engine.Get.Scene.Create<Background>();
            hud = Engine.Get.Scene.Create<Hud>();
            player = Engine.Get.Scene.Create<Player>();
            CreateCoinSpawner();

            timer = 0f;
        }
        public void DeInit()
        {
        }
        public void Update(float dt)
        {

            if (!timeOver)
            {
                timeLeft -= dt;

                if (timeLeft <= 0f)
                {
                    timeLeft = 0f;
                    timeOver = true;
                }
            }
            cooldown -= dt;            
            
            for (int i = objectList.Count - 1; i >= 0; i--)
            {
                objectList[i].Update(dt);
                if (player.GetGlobalBounds().Intersects(objectList[i].GetGlobalBounds()))
                {
                    objectList.RemoveAt(i);
                }

            }
        }
        private void CreateCoinSpawner()
        {
            ActorSpawner<ObjectToCollect> spawner;
            spawner = Engine.Get.Scene.Create <ActorSpawner<ObjectToCollect>>();
            spawner.MinPosition = new Vector2f (25, 25);
            spawner.MaxPosition = new Vector2f (Engine.Get.Window.Size.X - 25, Engine.Get.Window.Size.Y - 25);
            spawner.Reset();
        }

        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}

