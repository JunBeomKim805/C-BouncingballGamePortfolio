using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class MenuScene : GameScene
    {
        private List<string> menuItems;
        private int selectedIndex;
        private Vector2 position;

        private SpriteFont regularFont;
        private SpriteFont hightlightFont;
        private KeyboardState oldState;
        public MenuScene(Game game, List<string> menuItems) : base(game)
        {
            selectedIndex = 2;
            this.menuItems = menuItems;

            position = new Vector2(parent.Stage.X / 2, parent.Stage.Y / 2);
            regularFont = parent.Content.Load<SpriteFont>("Font/regularFont");
            hightlightFont = parent.Content.Load<SpriteFont>("Font/highlightFont");
        }

        public override void Draw(GameTime gameTime)
        {
            Vector2 tempPos = position;
            GraphicsDevice.Clear(Color.Black);
            parent.Sprite.Begin();
            for (int i = 0; i < menuItems.Count; i++)
            {
                if (i == selectedIndex)
                {
                    parent.Sprite.DrawString(hightlightFont, menuItems[i], tempPos, Color.Red);
                    tempPos.Y += hightlightFont.LineSpacing;
                }
                else
                {
                    parent.Sprite.DrawString(regularFont, menuItems[i], tempPos, Color.White);
                    tempPos.Y += regularFont.LineSpacing;
                }

            }
            parent.Sprite.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState ks = Keyboard.GetState();
            if (oldState.IsKeyUp(Keys.Down) && ks.IsKeyDown(Keys.Down))
            {
                selectedIndex = MathHelper.Clamp(selectedIndex + 1, 0, menuItems.Count - 1);
            }
            if (oldState.IsKeyUp(Keys.Up) && ks.IsKeyDown(Keys.Up))
            {
                selectedIndex = MathHelper.Clamp(selectedIndex - 1, 0, menuItems.Count - 1);
            }
            if (oldState.IsKeyUp(Keys.Enter) && ks.IsKeyDown(Keys.Enter))
            {
                parent.Notify(this, menuItems[selectedIndex]);
            }

            oldState = ks;
            base.Update(gameTime);
        }
    }
}
