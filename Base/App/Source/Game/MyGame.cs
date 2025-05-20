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
        }
        //Hola

        public void DeInit()
        {

        }
        public void Update(float dt)
        {
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


