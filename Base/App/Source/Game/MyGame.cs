using App.Source.Game;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Numerics;

namespace TcGame
{
    public class MyGame : Game
    {
        public List<ObjectToCollect> objectList = new List<ObjectToCollect>();
        public Front front { private set; get; }
        public Hud hud { private set; get; }
        public Background background { get; private set; }

        private float timer;

        private static MyGame instance;

      

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
            front = Engine.Get.Scene.Create<Front>();

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


            hud.Update(dt);

            timer += dt;

            if (timer > 5)
            {
                objectList[0].Destroy();
                objectList[1].Destroy();
                objectList[2].Destroy();
                objectList[3].Destroy();
                objectList.RemoveAll(x => x != null);
                timer = 0f;

                ObjectToCollect first = Engine.Get.Scene.Create<ObjectToCollect>();
                ObjectToCollect second = Engine.Get.Scene.Create<ObjectToCollect>();
                ObjectToCollect third = Engine.Get.Scene.Create<ObjectToCollect>();
                ObjectToCollect forth = Engine.Get.Scene.Create<ObjectToCollect>();

                objectList.Add(first);
                objectList.Add(second);
                objectList.Add(third);
                objectList.Add(forth);
            }

            for (int i = objectList.Count - 1; i >= 0; i--)
            {
                objectList[i].Update(dt);
                if (front.GetGlobalBounds().Intersects(objectList[i].GetGlobalBounds()))
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



