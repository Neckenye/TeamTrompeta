using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

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
            objectList = Engine.Get.Scene.Create<ObjectToCollect>();

            ObjectToCollect first = new ObjectToCollect();
            objectList.Add(first);
        }
        //Hola

        public void DeInit()
        {

        }
        public void Update(float dt)
        {
            hud.Update(dt);

            timer += dt;

            if (timer > 5)
            {
                timer = 0f;
                objectList.Add(new ObjectToCollect());
            }

            if (objectList.Count > 3)
            {
                objectList.RemoveAt(0);
            }
        }

        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}


