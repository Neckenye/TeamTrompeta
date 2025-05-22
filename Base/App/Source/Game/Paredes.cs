using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TcGame
{
    public class Paredes : StaticActor
    {
        Random rand = new Random();
        private float cooldown = 5.0f;
        public Paredes()
        {
            Sprite = new Sprite(new Texture("Data/Textures/Object/Pared.PNG"));
            Layer = ELayer.Back;
            Position = new Vector2f(rand.Next(30, (int)Engine.Get.Window.Size.X - 30), rand.Next(30, (int)Engine.Get.Window.Size.Y - 30));
            Sprite.Scale = new Vector2f(0.4f, 0.4f);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
