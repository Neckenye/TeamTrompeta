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
    public class ObjectToCollect : StaticActor
    {
        public ObjectToCollect()
        {
            Sprite = new Sprite(new Texture("Data/Textures/Object/Coin.png"));
            Layer = ELayer.Middle;
            Position = new Vector2f(0f, 0f);
            Origin = new Vector2f(GetLocalBounds().Width / 2.0f, GetLocalBounds().Height / 2.0f);
        }


    }
}
