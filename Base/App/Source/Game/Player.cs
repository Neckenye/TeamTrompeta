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

            FloatRect localBounds = Sprite.GetLocalBounds();
            Sprite.Origin = new Vector2f(localBounds.Width / 2f, 0f);

            Position = new Vector2f (Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
            Speed = 300;
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            Vector2f direction = new Vector2f(0, 0);
            float halfWidth = GetGlobalBounds().Width / 2;
            float halfHeight = GetGlobalBounds().Height / 2;
            Vector2u windowSize = Engine.Get.Window.Size;

            if (Keyboard.IsKeyPressed(Keyboard.Key.A) && Position.X - halfWidth > 0)
                direction.X -= 1;

            if (Keyboard.IsKeyPressed(Keyboard.Key.D) && Position.X + halfWidth < windowSize.X)
                direction.X += 1;

            if (Keyboard.IsKeyPressed(Keyboard.Key.W) && Position.Y - halfHeight > 0)
                direction.Y -= 1;

            if (Keyboard.IsKeyPressed(Keyboard.Key.S) && Position.Y + halfHeight < windowSize.Y)
                direction.Y += 1;

            if (direction != new Vector2f(0, 0))
            {
                Forward = direction.Normal();
                Position += Forward * Speed * dt;
            }
            else
            {
                Forward = new Vector2f(0, 0);
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
