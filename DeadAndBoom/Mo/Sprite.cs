using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeadAndBoom.Mo
{
    public class Sprite
    {
        protected Texture2D texture;

        public Vector2 Position;
        public Vector2 Velocity;
        public float Speed;

        public Input Input;
        public bool IsRemoved = false;

        public Rectangle Rectangle//для столкновений
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, texture.Width, texture.Height);
            }
        }

        public Sprite (Texture2D texture)
        {
            this.texture = texture;
        }

        public virtual void Update (GameTime gameTime, List<Sprite> sprites)//попал ли в игрока бома на ту пустату которой он окружон
        {

        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, Position, Color.Yellow);
        }
    }
}
