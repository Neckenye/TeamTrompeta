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
        public float time = 700f;

        private Sprite cuadradoGigante;


        public PantallaNegraVision()
        {
            Layer = ELayer.Middle;

            cuadradoGigante = new Sprite(new Texture("Data/Textures/Hud/nigga.png"));
            cuadradoGigante.Scale = cuadradoGigante.Scale * 8;
        }

        public override void Update(float dt)
        {
            base.Update(dt);

            time -= dt;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {

            
            //Si el tiempo es 0 resetealo, y si es menos de 5 se muestra la pantalla negra
             
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
