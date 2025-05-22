using SFML.Graphics;
using SFML.System;
using System;
using System.Threading;

namespace TcGame
{   
    public class Hud : Actor
    {
        public float time = 120f;
        public int pointsColected;

        private Text noTimeTxt;
        private Text txt;
        private Text timer;
        private Sprite cuadradoGigante;
        

        public Hud()
        {
            Layer = ELayer.Hud;
            Font f = new Font("Data/Fonts/LuckiestGuy.ttf");

            cuadradoGigante = new Sprite(new Texture("Data/Textures/Hud/niga2.png"));
            cuadradoGigante.Scale = cuadradoGigante.Scale * 8;

            txt = new Text("", f);
            timer = new Text("", f);
            noTimeTxt = new Text("GAME OVER", f);

            noTimeTxt.Origin = new Vector2f(GetLocalBounds().Width, GetLocalBounds().Height) / 2.0f;
            noTimeTxt.Scale = noTimeTxt.Scale * 3;

            txt.Position = new Vector2f(10, 10);
            timer.Position = new Vector2f(Engine.Get.Window.Size.X - 50, 10);
            noTimeTxt.Position = new Vector2f(Engine.Get.Window.Size.X / 2 - 230, Engine.Get.Window.Size.Y / 2 - 50);

            txt.DisplayedString = ($"Points Colected: {pointsColected}");
            timer.DisplayedString = ($"{time}");

            noTimeTxt.FillColor = Color.Red;
            txt.FillColor = Color.Blue;
            timer.FillColor = Color.Blue;

        }

        public override void Update(float dt)
        {
            base.Update(dt);
            SetText();

            time -= dt;
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


            if (time <= 0)
            {
                target.Draw(cuadradoGigante);
                target.Draw(noTimeTxt);
            }
        }
    }
}
