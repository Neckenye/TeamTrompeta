using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using App.Source.Game;
using System.Collections.Generic;
using System.Numerics;
using static System.Net.Mime.MediaTypeNames;
using System.Threading;

namespace TcGame
{
    public class MyGame : Game
    {
        public Hud hud { private set; get; }
        public List<ObjectToCollect> objectList = new List<ObjectToCollect>();
        public ObjectToCollect objectToCollect { private set; get; }
        public Player player { private set; get; }
        public TimeTxt timeTxt { private set; get; }
        public Background background { get; private set; }
        private static MyGame instance;

        private float timer;
        //public static float timeLeft = 120f;
        public static float timeLeft = 2;  //PER SABER SI VA
        public static bool timeOver = false;

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

            timer = 0f;

            ObjectToCollect first = Engine.Get.Scene.Create<ObjectToCollect>();
            ObjectToCollect second = Engine.Get.Scene.Create<ObjectToCollect>();
            ObjectToCollect third = Engine.Get.Scene.Create<ObjectToCollect>();
            ObjectToCollect forth = Engine.Get.Scene.Create<ObjectToCollect>();

            objectList.Add(first);
            objectList.Add(second);
            objectList.Add(third);
            objectList.Add(forth);


            Engine.Get.Scene.Create<TimeTxt>();
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
            ObjectToCollect first = Engine.Get.Scene.Create<ObjectToCollect>();
            ObjectToCollect second = Engine.Get.Scene.Create<ObjectToCollect>();
            ObjectToCollect third = Engine.Get.Scene.Create<ObjectToCollect>();
            ObjectToCollect forth = Engine.Get.Scene.Create<ObjectToCollect>();

            objectList.Add(first);
            objectList.Add(second);
            objectList.Add(third);
            objectList.Add(forth);


            for (int i = objectList.Count - 1; i >= 0; i--)
            {
                objectList[i].Update(dt);
                if (player.GetGlobalBounds().Intersects(objectList[i].GetGlobalBounds()))
                {
                    objectList.RemoveAt(i);
                }

            }
        }
        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}

