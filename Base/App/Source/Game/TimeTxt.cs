using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using TcGame;

namespace App.Source.Game
{
    public class TimeTxt : Actor
    {
        private Text noTimeTxt; //GAMEOVER TXT
        private Text timeTxt;
        private Font font;

        public TimeTxt()
        {
            //txt game over
            font = new Font("Data/Fonts/LuckiestGuy.ttf");
            noTimeTxt = new Text("PERRO SANCHES HA DIMITIDO.", font, 60); // TEXT DE GAME OVER AQUIII
            noTimeTxt.FillColor = Color.Red;
            noTimeTxt.Position = new SFML.System.Vector2f(200, 300);
            Layer = ELayer.Hud;

            //txt temps regresivo
            timeTxt = new Text("", font, 40);
            timeTxt.FillColor = Color.White;
            timeTxt.Position = new SFML.System.Vector2f(20, 20);
            Layer = ELayer.Hud;
        }

        public override void Update(float dt)
        {
            int sec = (int)Math.Floor(MyGame.timeLeft);
            int min = sec / 60;
            int secs = sec % 60;
            string timerTxt = $"Tren en...  {min:D2}:{secs:D2}"; //TEXT DE TEMPS RESTANT AQUIII
            timeTxt.DisplayedString = timerTxt;
        }

        public override void Draw(RenderTarget target, RenderStates states) 
        {
            if (!MyGame.timeOver)
            {
                target.Draw(timeTxt, states);
            }
            else 
            {
                target.Draw(noTimeTxt, states);
            }
        }



    }
}
