using SFML.Graphics;
using SFML.System;
using System;
using System.Threading;

namespace TcGame
{   
    public class Hud : Actor
    {
        public float time = 20f; //Este tiempo cuando se acabe será game over
        public int pointsColected;
        public int finalPoints;

        private bool coinColect = true;

        private Text noTimeTxt; // Este es el texto de GAME OVER
        private Text txt;
        private Text puntFinal; // Este es el texto de PUNTUACION FINAL
        private Text timer;

        private Sprite cuadradoGigante; // Esta es la imagen de fondo del Game over
        
        public Hud()
        {
            Layer = ELayer.Hud;
            Font f = new Font("Data/Fonts/LuckiestGuy.ttf");

            cuadradoGigante = new Sprite(new Texture("Data/Textures/Hud/nigga.png"));
            cuadradoGigante.Scale = cuadradoGigante.Scale * 8; //se escala la imagen para hacerla gigante y que tape toda la pantalla

            txt = new Text("", f);
            timer = new Text("", f);
            puntFinal = new Text("", f);
            noTimeTxt = new Text("GAME OVER", f);

            noTimeTxt.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
            noTimeTxt.Scale = noTimeTxt.Scale * 3;

            puntFinal.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
            puntFinal.Position = new Vector2f(Engine.Get.Window.Size.X / 2 - 120, Engine.Get.Window.Size.Y / 2 + 150);


            txt.Position = new Vector2f(10, 10);
            timer.Position = new Vector2f(Engine.Get.Window.Size.X - 50, 10);
            noTimeTxt.Position = new Vector2f(Engine.Get.Window.Size.X / 2 - 230, Engine.Get.Window.Size.Y / 2 - 50);

            txt.DisplayedString = ($"Points Colected: {pointsColected}");
            timer.DisplayedString = ($"{time}");

            noTimeTxt.FillColor = Color.Red;
            txt.FillColor = Color.White;
            timer.FillColor = Color.White;
            puntFinal.FillColor = Color.White;

        }

        public override void Update(float dt)
        {
            base.Update(dt);
            SetText();

            time -= dt;

            if (coinColect)
            {
                finalPoints = pointsColected;
            }
        }

        public void SetText()
        {
            txt.DisplayedString = ($"Points Colected: {pointsColected}");
            timer.DisplayedString = ($"{time:F0}");
        }

        public void AddPoint()
        {
            pointsColected++;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(txt);
            target.Draw(timer);


            if (time <= 0) // Cuando se acabe el tiempo se muestra el GAME OVER con el gris de fondo
            {
                coinColect = false;
                puntFinal.DisplayedString = ($"Points Colected: {finalPoints}");

                target.Draw(cuadradoGigante);
                target.Draw(noTimeTxt);
                target.Draw(puntFinal);

            }
        }
    }
}
