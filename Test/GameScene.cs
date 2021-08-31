using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class GameScene : DrawableGameComponent
    {
        protected Game1 parent;
        protected List<GameComponent> Components { get; set; }
        public GameScene(Game game) : base(game)
        {
            parent = (Game1)game;
            Components = new List<GameComponent>();
        }
        protected virtual void SetState(bool state)
        {
            this.Enabled = state;
            this.Visible = state;
            foreach (GameComponent item in Components)
            {
                item.Enabled = state;
                if (item is DrawableGameComponent)
                {
                    DrawableGameComponent comp = (DrawableGameComponent)item;
                    comp.Visible = state;
                }
            }
        }
        public virtual void Show()
        {
            SetState(true);
        }
        public virtual void hide()
        {
            SetState(false);
        }
        public override void Draw(GameTime gameTime)
        {
            foreach (GameComponent item in Components)
            {
                if (item is DrawableGameComponent)
                {
                    DrawableGameComponent comp = (DrawableGameComponent)item;
                    if (comp.Visible)
                    {
                        comp.Draw(gameTime);
                    }
                }
            }
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            foreach (GameComponent item in Components)
            {
                if (item.Enabled)
                {
                    item.Update(gameTime);
                }
            }
            base.Update(gameTime);
        }
    }
}
