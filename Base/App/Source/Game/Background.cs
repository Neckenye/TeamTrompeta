using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
    public class Background : StaticActor
    {
        public Background()
        {
            Layer = ELayer.Background;
            //Sprite = new Sprite(new Texture("Data/Textures/background.png"));
            
            Texture texture = new Texture("Data/Textures/background.png");
            Sprite = new Sprite(texture);

            var textureSize = texture.Size;
            var windowSize = Engine.Get.Window.Size;


            float scaleX = (float)windowSize.X / textureSize.X;
            float scaleY = (float)windowSize.Y / textureSize.Y;

            Sprite.Scale = new Vector2f(scaleX, scaleY);
            Position = new Vector2f(0, 0);
        }
        public override void Update(float dt)
        {
        }
    }
}

