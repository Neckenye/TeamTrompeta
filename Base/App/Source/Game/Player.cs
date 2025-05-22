using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System.Collections.Generic;
using System;
using SFML.Audio;

namespace TcGame
{
    public class Player : StaticActor
    {
        public Player()
        {
            Layer = ELayer.Front;
            Sprite = new Sprite(new Texture("Data/Textures/Player/TrumpetHand.png"));
            FloatRect localBounds = Sprite.GetLocalBounds();
            Sprite.Origin = new Vector2f(localBounds.Width / 2f, localBounds.Height / 2f);
            Position = new Vector2f (Engine.Get.Window.Size.X/2, Engine.Get.Window.Size.Y/2);
            Sprite.Scale = new Vector2f(0.7f, 0.7f);
            Speed = 400;
        }

        public override void Update(float dt)
        {
            base.Update(dt);
            

            Forward = new Vector2f(0, 0);
            if (Keyboard.IsKeyPressed(Keyboard.Key.A) && (Position.X >= 0 + GetGlobalBounds().Width / 4))
            {
                Forward = new Vector2f(-1, Forward.Y).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.D) && (Position.X <= Engine.Get.Window.Size.X - GetGlobalBounds().Width / 4))
            {
                Forward = new Vector2f(1, Forward.Y).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W) && (Position.Y >= 0 + GetGlobalBounds().Height / 4))
            {
                Forward = new Vector2f(Forward.X, -1).Normal();
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S) && (Position.Y <= Engine.Get.Window.Size.Y - GetGlobalBounds().Height / 4))
            {
                Forward = new Vector2f(Forward.X, 1).Normal();
            }
            
            CheckCollision();
            CheckCollision2();
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
        private void CheckCollision2()
        {
            List<Paredes> lenemies= Engine.Get.Scene.GetAll<Paredes>();

            foreach (Paredes enemies in lenemies)
            {
                if (enemies.GetGlobalBounds().Intersects(this.GetGlobalBounds()))
                {
                    Engine.Get.Scene.Destroy(enemies);
                    Hud hud = Engine.Get.Scene.GetFirst<Hud>();
                    hud.RemovePoint();
                }
            }
        }
    }
}
