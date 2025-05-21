using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
    public class Player : StaticActor
    {
        

        public Player()
        {
            Layer = ELayer.Front;
            Sprite = new Sprite(new Texture("Data/Textures/Player/Plane.png"));
            Position = new Vector2f(Engine.Get.Window.Size.X / 2, Engine.Get.Window.Size.Y / 2);
            Speed = 200;
        }

       
        public override void Update(float dt)
        {
            base.Update(dt);

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                Forward = new Vector2f(-1, Forward.Y).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                Forward = new Vector2f(1, Forward.Y).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                Forward = new Vector2f(Forward.X, -1).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                Forward = new Vector2f(Forward.X, 1).Normal();
            }
        }
    }
}
