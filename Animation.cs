using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Animation;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace Topic_6_animation_and_classes
{
    public class Animation : Game
    {
        Texture2D tribbleGreyTexture;
        Texture2D tribbleCreamTexture;
        Texture2D tribbleOrangeTexture;
        Texture2D tribbleBrownTexture;

        List<Texture2D> tribbleTextures;

        Tribble tribble1, tribble2, tribble3, tribble4;


        Texture2D introscreenTexture;

        private SpriteFont introfont;

        MouseState mouseState;

        enum Screen
        {
            Intro,
            TribbleYard,
        }
        Screen screen;

        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Animation()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            screen = Screen.Intro;

            base.Initialize();

            
            tribbleTextures = new List<Texture2D>();
            tribbleTextures.Add(tribbleGreyTexture);
            tribbleTextures.Add(tribbleCreamTexture);
            tribbleTextures.Add(tribbleOrangeTexture);
            tribbleTextures.Add(tribbleBrownTexture);

            tribble1 = new Tribble(tribbleGreyTexture, new Rectangle(10, 10, 100, 100), new Vector2(2, 0));
            tribble2 = new Tribble(tribbleBrownTexture, new Rectangle(100, 120, 100, 100), new Vector2(2, 2));
            tribble3 = new Tribble(tribbleCreamTexture, new Rectangle(10, 30, 100, 100));
            tribble4 = new Tribble(tribbleTextures, new Rectangle(20, 40, 100, 100));

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            tribbleGreyTexture = Content.Load<Texture2D>("tribbleGrey");
            tribbleCreamTexture = Content.Load<Texture2D>("tribbleCream");
            tribbleOrangeTexture = Content.Load<Texture2D>("tribbleOrange");
            tribbleBrownTexture = Content.Load<Texture2D>("tribbleBrown");
            introscreenTexture = Content.Load<Texture2D>("introscreen");
            introfont = Content.Load<SpriteFont>("File");
          
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.TribbleYard;

            }
            else if (screen == Screen.TribbleYard)
            {
                tribble1.Move(_graphics);
                tribble2.Move(_graphics);
                tribble3.Move(_graphics);
                tribble4.Move(_graphics);
            }
              

                // TODO: Add your update logic here

                base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(introscreenTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.DrawString(introfont, ("Left click to see tribbles."), new Vector2(500, 100), Color.White);
            }
            else if (screen == Screen.TribbleYard)
            {
                _spriteBatch.Draw(tribble1.Texture, tribble1.Bounds, Color.White);
                _spriteBatch.Draw(tribble2.Texture, tribble2.Bounds, Color.White);
                _spriteBatch.Draw(tribble3.Texture, tribble3.Bounds, Color.White);
                _spriteBatch.Draw(tribble4.Texture, tribble4.Bounds, Color.White);
            }
            _spriteBatch.End();
               

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}