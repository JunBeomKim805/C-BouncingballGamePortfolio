using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class AboutScene : GameScene
    {
        private Texture2D aboutTex;
        private KeyboardState oldState;

        public AboutScene(Game game) : base(game)
        {
            aboutTex = parent.Content.Load<Texture2D>("Images/about");
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape) && oldState.IsKeyUp(Keys.Escape))
            {
                parent.Notify(this, "escape");
            }
            oldState = ks;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            parent.Sprite.Begin();
            parent.Sprite.Draw(aboutTex, Vector2.Zero, Color.CornflowerBlue);
            parent.Sprite.End();

            base.Draw(gameTime);
        }
    }
}
