using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML.Audio;
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
        public PantallaNegraVision vision { private set; get; }
        private static MyGame instance;

        private float timer;
        //public static float timeLeft = 120f;
        public static float timeLeft = 120;  //PER SABER SI VA
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
            vision = Engine.Get.Scene.Create<PantallaNegraVision>();
            
            //----- NO TOCAR NO TOQUEIS LOS HUEVOS ------
            CreateCoinSpawner();
            CreateCoinSpawner();
            CreateCoinSpawner();
            CreateCoinSpawner();

            CreateParedSpawner();
            //-------------------------------------------
            /* NO TOCAR NO TOQUEIS LOS HUEVOS, Esto hace 4 COINS y 1 PARED cada 7 segundos. Tienes 2 segundos para
               ver donde estan las monedas y donde esta la siguiente pared, los otros 5 segundos restantes son para
               coger las monedas sin chocarte, con una pared negra en el frente, es la gracia del puto juego.
            */
            timer = 0f;
        }
        public void DeInit()
        {
        }
        public void Update(float dt)
        {
            /*
            for (int i = objectList.Count - 1; i >= 0; i--)
            {
                objectList[i].Update(dt);
                if (player.GetGlobalBounds().Intersects(objectList[i].GetGlobalBounds()))
                {
                    objectList.RemoveAt(i);
                }
            }*/

            /*if (player.GetGlobalBounds().Intersects(objectToCollect.GetGlobalBounds()))
            {
                hud.AddPoint();
            }*/
        }
        private void CreateCoinSpawner()
        {
            ActorSpawner<ObjectToCollect> spawner;
            spawner = Engine.Get.Scene.Create <ActorSpawner<ObjectToCollect>>();
            spawner.MinPosition = new Vector2f (25, 25);
            spawner.MaxPosition = new Vector2f (Engine.Get.Window.Size.X - 25, Engine.Get.Window.Size.Y - 25);
            spawner.Reset();
        }

        private void CreateParedSpawner()
        {
            ActorSpawner<Paredes> spawner;
            spawner = Engine.Get.Scene.Create<ActorSpawner<Paredes>>();
            spawner.MinPosition = new Vector2f(25, 25);
            spawner.MaxPosition = new Vector2f(Engine.Get.Window.Size.X - 25, Engine.Get.Window.Size.Y - 25);
            spawner.Reset();
        }

        private void DestroyAll<T>() where T : Actor
        {
            var actors = Engine.Get.Scene.GetAll<T>();
            actors.ForEach(x => x.Destroy());
        }
    }
}

