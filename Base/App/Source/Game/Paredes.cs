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
            Sprite = new Sprite(new Texture("Data/Textures/Object/BlueNote.PNG"));
            Sprite.Color = Color.Red;
            Layer = ELayer.Back;
            Position = new Vector2f(rand.Next(30, (int)Engine.Get.Window.Size.X - 30), rand.Next(30, (int)Engine.Get.Window.Size.Y - 30));
            Sprite.Scale = new Vector2f(0.05f, 0.05f);
        }

        public override void Update(float dt)
        {
            base.Update(dt);
        }
    }
}
