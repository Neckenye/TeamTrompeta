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
    public class PantallaNegraVision : StaticActor
    {
        public float time = 7f;

        private Sprite cuadradoGigante;


        public PantallaNegraVision()
        {
            Layer = ELayer.Middle;

            cuadradoGigante = new Sprite(new Texture("Data/Textures/Hud/niga2.png"));
            cuadradoGigante.Scale = cuadradoGigante.Scale * 8;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            time -= dt;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            if (time <= 0)
            {
                time = 7f;
            }
            else if (time <= 5)
            {
                target.Draw(cuadradoGigante);
            }
        }
    }
}
