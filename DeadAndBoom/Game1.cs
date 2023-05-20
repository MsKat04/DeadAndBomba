using DeadAndBoom.Mo;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace DeadAndBoom
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        public static int ScreenHeight;
        public static int ScreenWidth;
        public static Random Random;

        private List<Sprite> _sprites;
        private float _timer;
        private bool _hasStarted;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            Random= new Random();
            ScreenHeight = _graphics.PreferredBackBufferHeight;
            ScreenWidth = _graphics.PreferredBackBufferWidth;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            var playerTexture = Content.Load<Texture2D>("demon");

            _sprites = new List<Sprite>()
            {
                new Player (playerTexture)
                {
                    Position = new Vector2((ScreenWidth/2) - (playerTexture.Width/2), ScreenHeight - playerTexture.Height),
                    Input = new Input
                    {
                        Left = Keys.A,
                        Right= Keys.D,
                    },
                    Speed = 10f,
                }
            };
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                _hasStarted = true;

            if (!_hasStarted)
                return;

            _timer += (float)gameTime.ElapsedGameTime.TotalSeconds;

            foreach (var sprite in _sprites)
                sprite.Update(gameTime, _sprites);

            if(_timer > 0.35f)
            {
                _timer = 0;
                _sprites.Add(new Bomba(Content.Load<Texture2D>("star")));
            }

            for (int i = 0; i < _sprites.Count; i++)
            {
                var sprite = _sprites[i];
                if (sprite.IsRemoved)
                {
                    _sprites.RemoveAt(i);
                    i--;
                }

                if (sprite is Player)
                {
                    var player = sprite as Player;
                    if (player.HasDied)
                        LoadContent();//для смерти
                    
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            foreach(var sprite in _sprites)
                sprite.Draw(_spriteBatch);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}