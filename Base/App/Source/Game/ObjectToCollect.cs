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
        private float cooldown = 5.0f;
        public ObjectToCollect()
        {
            Sprite = new Sprite(new Texture("Data/Textures/Object/BlueNote.png"));
            Layer = ELayer.Back;
            Position = new Vector2f(rand.Next(30, (int)Engine.Get.Window.Size.X-30), rand.Next(30, (int)Engine.Get.Window.Size.Y-30));            
            Sprite.Scale = new Vector2f(0.1f, 0.1f);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            /*
            cooldown -= dt;
            if (cooldown <= 0)
            {
                Destroy();
            }
            */
        }

        /*public FloatRect GetLocalBounds()
        {
            return Sprite.GetLocalBounds();
        }
        public FloatRect GetGlobalBounds()
        {
            return Transform.TransformRect(GetLocalBounds());
        }*/
    }
}