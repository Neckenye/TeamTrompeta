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
            Sprite = new Sprite(new Texture("Data/Textures/Player/Plane.png"));
            Position = new Vector2f (Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
            Speed = 300;
        }

        public override void Update(float dt)
        {
            base.Update(dt);
          

            Forward = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.A) && (Position.X >= 0 + GetGlobalBounds().Width / 6))
            {
                Forward = new Vector2f(-1, Forward.Y).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) && (Position.X <= Engine.Get.Window.Size.X - GetGlobalBounds().Width))
            {
                Forward = new Vector2f(1, Forward.Y).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) && (Position.Y >= 0 + GetGlobalBounds().Height / 6))
            {
                Forward = new Vector2f(Forward.X, -1).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) && (Position.Y <= Engine.Get.Window.Size.Y - GetGlobalBounds().Height))
            {
                Forward = new Vector2f(Forward.X, 1).Normal();
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
