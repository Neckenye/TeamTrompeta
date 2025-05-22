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

        private Sprite telonNegro;


        public PantallaNegraVision()
        {
            Layer = ELayer.Middle;

            Texture texture = new Texture("Data/Textures/Hud/niga2.png");

            telonNegro = new Sprite(texture);
            telonNegro.Scale = telonNegro.Scale * 0.95f;

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
                time = 6.5f;
            }
            else if (time <= 5)
            {
                target.Draw(telonNegro);
            }
        }
    }
}
