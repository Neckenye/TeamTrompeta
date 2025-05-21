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
            Position = new Vector2f (Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
            Speed = 200;
        }

        public override void Update(float dt)
        {
            Vector2f movement = new Vector2f(0f, 0f);

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                movement.Y -= Speed * dt;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                movement.Y += Speed * dt;
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                movement.X -= Speed * dt;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                movement.X += Speed * dt;

            Sprite.Position += movement;
        }
    }
}
