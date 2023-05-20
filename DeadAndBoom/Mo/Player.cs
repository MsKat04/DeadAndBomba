using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadAndBoom.Mo
{
    public class Player : Sprite
    {
        public bool HasDied = false;
        public Player(Texture2D texture2D) : base(texture2D) { }

        public override void Update(GameTime gameTime, List<Sprite> sprites)
        {
            MM();

            foreach(var sprite in sprites)
            {
                if (sprite == this)
                    continue;

                if(sprite.Rectangle.Intersects(this.Rectangle))
                    HasDied= true;
            }

            Position += Velocity;
            Position.X = MathHelper.Clamp(Position.X, 0, Game1.ScreenWidth - Rectangle.Width);
            Velocity = Vector2.Zero; 
        }

        private void MM()
        {
            if (Input == null) return;

            if (Keyboard.GetState().IsKeyDown(Input.Left))
                Velocity.X -= Speed;
            else if (Keyboard.GetState().IsKeyDown(Input.Right))
                Velocity.X += Speed;
        }
    }
}
