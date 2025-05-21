using App.Source.Game;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace TcGame
{
    public class MyGame : Game
    {
        public ObjectToCollect objectToCollect { private set; get; }
        public Front front { private set; get; }
        public Hud hud { private set; get; }
        public Background background { get; private set; }

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
            objectToCollect = Engine.Get.Scene.Create<ObjectToCollect>();

            Engine.Get.Scene.Create<TimeTxt>();

        }
        //Hola

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
            objectToCollect.Update(dt);
        }

        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }


    }
}


