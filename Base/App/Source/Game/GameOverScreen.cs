using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
    public class GameOverScreen : StaticActor
    {
        Font f;
        Text t;
        public GameOverScreen()
        {
            Layer = ELayer.Background;
            Sprite = new Sprite(new Texture("Data/Textures/BlackBackground.jpg"));
            f = new Font("Data/Fonts/LuckiestGuy.ttf");
            t = new Text("Game Over", f);
        }
        public override void Update(float dt)
        {

        }
    }
}
