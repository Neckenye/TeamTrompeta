using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System;

namespace TcGame
{
    public class Player : StaticActor
    {
        public Player()
        {
            Layer = ELayer.Front;
            Sprite = new Sprite(new Texture("Data/Textures/Player/TrumpetHand.png"));
            Sprite.Scale = new Vector2f(0.2f, 0.2f);
            Position = new Vector2f (Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
            Speed = 300;
        }

        public override void Update(float dt)
        {
            base.Update(dt);


            Vector2f direction = new Vector2f(0, 0);

            if (Keyboard.IsKeyPressed(Keyboard.Key.A) && (Position.X >= 0 + GetGlobalBounds().Width / 6))
            {
                direction.X -= 1;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) && (Position.X <= Engine.Get.Window.Size.X - GetGlobalBounds().Width))
            {
                direction.X += 1;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) && (Position.Y >= 0 + GetGlobalBounds().Height / 6))
            {
                direction.Y -= 1;
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) && (Position.Y <= Engine.Get.Window.Size.Y - GetGlobalBounds().Height))
            {
                direction.Y += 1;
            }

            if (direction != new Vector2f(0, 0))
            {
                Forward = direction.Normal();
                Position += Forward * Speed * dt;
            }

            CheckCollision();
        }
        private void CheckCollision()
        {
            List<ObjectToCollect> lcoin = Engine.Get.Scene.GetAll<ObjectToCollect>();

            foreach (ObjectToCollect coin in lcoin)
            {
                if (coin.GetGlobalBounds().Intersects(this.GetGlobalBounds()))
                {
                    Engine.Get.Scene.Destroy(coin);
                    Hud hud = Engine.Get.Scene.GetFirst<Hud>();
                    hud.AddPoint();
                }
            }
        }
    }
}
