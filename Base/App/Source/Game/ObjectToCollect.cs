using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using static System.Net.Mime.MediaTypeNames;

namespace TcGame
{ 
    public class ObjectToCollect : Actor
    {
        private Sprite sprite;
        public ObjectToCollect()
        {
            Layer = ELayer.Front;
            sprite = new Sprite(new Texture("Data/Textures/Object/Coin.png"));
            Position = new Vector2f(Engine.Get.Window.Size.X / 2, Engine.Get.Window.Size.Y / 2);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
