using System.Collections.Generic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace TcGame
{
    public class Front : StaticActor
    {
        private float speed = 200f;

        public Front()
        {
            Layer = ELayer.Front;
            Sprite = new Sprite(new Texture("Data/Textures/Player/TrumpetHand.png"));
        }

        public override void Update(float dt)
        {
            Vector2f movement = new Vector2f(0f, 0f);

            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
                movement.Y -= speed * dt;
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
                movement.Y += speed * dt;
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
                movement.X -= speed * dt;
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
                movement.X += speed * dt;

            Sprite.Position += movement;
        }

        private void CheckColission()
        {
            List<ObjectToCollect> notes = new List<ObjectToCollect>();

            foreach (ObjectToCollect coin in notes) 
            {
             //   if (coin.GetGlobalBounds().Intersects(this.GetGlobalBounds))
            }
        }
    }
}