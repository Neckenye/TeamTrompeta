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
    public class ObjectToCollect : StaticActor
    {
        Random rand = new Random();
        public ObjectToCollect()
        {
            Sprite = new Sprite(new Texture("Data/Textures/Object/Coin.png"));
            Layer = ELayer.Middle;
            Position = new Vector2f(rand.Next(0, (int)Engine.Get.Window.Size.X), rand.Next(0, (int)Engine.Get.Window.Size.Y));
            Origin = new Vector2f(GetLocalBounds().Width / 2.0f, GetLocalBounds().Height / 2.0f);
            
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
