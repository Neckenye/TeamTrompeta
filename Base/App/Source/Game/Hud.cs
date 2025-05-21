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
        public Hud()
        {
            Layer = ELayer.Hud;
            Font f = new Font("Data/Fonts/LuckiestGuy.ttf");
            txt = new Text("", f);
            timer = new Text("", f);
            noTimeTxt = new Text("GAME OVER", f);
            noTimeTxt.FillColor = Color.Red;
            txt.Position = new Vector2f(10, 10);
            txt.FillColor = Color.White;
            txt.DisplayedString = ($"Points Colected: {pointsColected}");
            timer.Position = new Vector2f(Engine.Get.Window.Size.X - 50, 10);
            timer.FillColor = Color.White;
            timer.DisplayedString = ($"{time}");
        }

        public override void Update(float dt)
        {

            Console.WriteLine(Position);
            Console.WriteLine(txt);

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
            
            if (time >= 121)
            {
                target.Draw(noTimeTxt);
            }
        }
    }
}
