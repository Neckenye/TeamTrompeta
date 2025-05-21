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

        private RectangleShape backgroundGameOver;

        public TimeTxt()
        {
            //txt game over
            font = new Font("Data/Fonts/LuckiestGuy.ttf");
            noTimeTxt = new Text("PERRO SANCHES HA DIMITIDO.", font, 60); // TEXT DE GAME OVER AQUIII
            noTimeTxt.FillColor = Color.Red;
            //centrat
            FloatRect bounds = noTimeTxt.GetLocalBounds();
            noTimeTxt.Origin = new SFML.System.Vector2f(bounds.Width / 2, bounds.Height / 2);
            noTimeTxt.Position = new SFML.System.Vector2f(1024 / 2, 768 / 2);
            Layer = ELayer.Hud;

            //txt temps regresivo
            timeTxt = new Text("", font, 40);
            timeTxt.FillColor = Color.White;
            timeTxt.Position = new SFML.System.Vector2f(20, 20);
            Layer = ELayer.Hud;

            //pantalla negre
            backgroundGameOver = new RectangleShape(new SFML.System.Vector2f(1024, 768));
            backgroundGameOver.FillColor = new Color(0, 0, 0, 200);
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
                target.Draw(blackOverlay, states);  
                target.Draw(noTimeTxt, states);
            }
        }



    }
}
