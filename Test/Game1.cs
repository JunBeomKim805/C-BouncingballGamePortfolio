using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Test
{
    public class Game1 : Game
    {
        public SpriteBatch Sprite { get => _spriteBatch; }
        public Vector2 Stage { get; set; }
        public GraphicsDeviceManager Graphics { get => _graphics; }
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private List<string> menuItems = new List<string> { "New game", "Help", "About", "Quit" };
        private MenuScene menuScene;
        private ActionScene actionScene;
        private GameScene currentScene;
        private HelpScene helpScene;
        private AboutScene AboutScene;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            float width = _graphics.PreferredBackBufferWidth;
            float height = _graphics.PreferredBackBufferHeight;
            this.Stage = new Vector2(width, height);
            Vector2 stage = new Vector2(width, height);


            menuScene = new MenuScene(this, menuItems);
            this.Components.Add(menuScene);
            actionScene = new ActionScene(this);
            actionScene.hide();
            this.Components.Add(actionScene);
            currentScene = menuScene;
            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);
            helpScene.hide();
            AboutScene = new AboutScene(this);
            this.Components.Add(AboutScene);
            AboutScene.hide();
            base.LoadContent();
            // TODO: use this.Content to load your game content here
        }


        protected override void Update(GameTime gameTime)
        {
            //if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //    Exit();
            
            //else if(Keyboard.GetState().IsKeyDown(Keys.Space)&& !ball.run)
            //{
            //    ball.run = true;
            //}

            //bottom.PosX = Mouse.GetState().X;
            //bottom.CheckBottomBallCollsion(ball);

            //foreach (var item in bricks)
            //{
            //    if (item.CheckBallCollisiion(ball))
            //    {
            //        item.active = false; 
            //    }
            //}
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
        public void Notify(GameScene sender, string action)
        {
            currentScene.hide();
            if (sender is MenuScene)
            {
                switch (action)
                {
                    case "New game":
                        currentScene = actionScene;
                        break;
                    case "Help":
                        currentScene = helpScene;
                        break;
                    case "About":
                        currentScene = AboutScene;
                        break;
                    case "Quit":
                        Exit();
                        break;

                }
            }
            else if (sender is ActionScene)
            {
                if (action == "escape" || action == "gameover")
                {
                    currentScene = menuScene;
                }
            }
            else if(sender is HelpScene)
            {
                if(action == "New game")
                {
                    currentScene = actionScene; 
                }
                if (action == "escape")
                {
                    currentScene = menuScene;
                }
            }
            else if (sender is AboutScene)
            {
                currentScene = menuScene;
            }
            currentScene.Show();
        }
    }
}
