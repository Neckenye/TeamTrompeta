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
    public class ObjectToCollect : Actor
    {
        private Sprite sprite;
        public ObjectToCollect()
        {
            sprite = new Sprite(new Texture("Data/Textures/Object/Coin.png"));
            Layer = ELayer.Middle;
            Position = new Vector2f(200f, 200f);
        }


    }
}
