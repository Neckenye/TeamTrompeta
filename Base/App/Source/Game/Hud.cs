using SFML.Graphics;
using SFML.System;
using System;
using System.Threading;

namespace TcGame
{   
    public class Hud : Actor
    {

        public float time = 120f; //Este tiempo cuando se acabe será game over
        public int pointsColected;
        public int finalPoints;

        private bool coinColect = true;

        private Text gameOverTxt;
        private Text noCoinsTxt;
        private Text txt;
        private Text puntFinal; // Este es el texto de PUNTUACION FINAL
        private Text timer;

        private Sprite cuadradoGigante; // Esta es la imagen de fondo del Game over
       
        
        public Hud()
        {
            Layer = ELayer.Hud;
            Font f = new Font("Data/Fonts/LuckiestGuy.ttf");

            cuadradoGigante = new Sprite(new Texture("Data/Textures/Hud/niga2.png"));
            cuadradoGigante.Scale = cuadradoGigante.Scale * 8;

            txt = new Text("", f);
            timer = new Text("", f);
            puntFinal = new Text("", f);
            gameOverTxt = new Text("GAME OVER", f);
            noCoinsTxt = new Text("NO COINS LEFT", f);
            

            gameOverTxt.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
            gameOverTxt.Scale = gameOverTxt.Scale * 3;

            noCoinsTxt.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
            noCoinsTxt.Scale = noCoinsTxt.Scale * 2;

            puntFinal.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
            puntFinal.Position = new Vector2f(Engine.Get.Window.Size.X / 2 - 120, Engine.Get.Window.Size.Y / 2 + 150);

            txt.Position = new Vector2f(10, 10);
            timer.Position = new Vector2f(Engine.Get.Window.Size.X - 50, 10);
            gameOverTxt.Position = new Vector2f(Engine.Get.Window.Size.X / 2 - 230, Engine.Get.Window.Size.Y / 2 - 50);
            noCoinsTxt.Position = new Vector2f(Engine.Get.Window.Size.X / 2 - 200, Engine.Get.Window.Size.Y / 2 + 50);


            txt.DisplayedString = ($"Points Colected: {pointsColected}");
            timer.DisplayedString = ($"{time}");

            gameOverTxt.FillColor = Color.Red;
            noCoinsTxt.FillColor = Color.Red;
            txt.FillColor = Color.Blue;
            timer.FillColor = Color.Blue;
            puntFinal.FillColor = Color.Blue;

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
        public void RemovePoint()
        {
            pointsColected--;
        }
        public override void Draw(RenderTarget target, RenderStates states)
        {
            target.Draw(txt);
            target.Draw(timer);


            if (time <= 0)
            {
                coinColect = false;
                puntFinal.DisplayedString = ($"Points Colected: {finalPoints}");

                target.Draw(cuadradoGigante);
                target.Draw(gameOverTxt);
                target.Draw(noCoinsTxt);
                target.Draw(puntFinal);
            }
            if (pointsColected < 0)
            {
                coinColect = false;                

                target.Draw(cuadradoGigante);
                target.Draw(gameOverTxt);
                target.Draw(noCoinsTxt);
                target.Draw(puntFinal);

            }
        }
    }
}
