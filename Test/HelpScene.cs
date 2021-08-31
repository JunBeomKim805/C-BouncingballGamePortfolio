using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class HelpScene : GameScene
    {
        private Texture2D helpTex;
        private KeyboardState oldState;

        public HelpScene(Game game) : base(game)
        {
            helpTex = parent.Content.Load<Texture2D>("Images/HelpScene");
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape) && oldState.IsKeyUp(Keys.Escape))
            {
                parent.Notify(this, "escape");
            }
            else if (ks.IsKeyDown(Keys.A) && oldState.IsKeyUp(Keys.A))
            {
                parent.Notify(this, "New game");
            }
            oldState = ks;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            parent.Sprite.Begin();
            parent.Sprite.Draw(helpTex, Vector2.Zero, Color.CornflowerBlue);
            parent.Sprite.End();

            base.Draw(gameTime);
        }
    }
}
