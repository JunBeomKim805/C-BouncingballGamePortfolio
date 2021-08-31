using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;
namespace Test
{
    public class Explosion : DrawableGameComponent
    {
        Game1 parent;
        Texture2D tex;
        int width;
        int height;
        int currentX;
        int currentY;
        Vector2 position;
        int count = 0;
        int MaxCount = 3;
        public Explosion(Game game, string image,int rows, int cols) : base(game)
        {
            parent = (Game1)game;
            this.tex = parent.Content.Load<Texture2D>(image);
            this.width = this.tex.Width / rows;
            this.height = this.tex.Height / cols;
            currentX = 0;
            currentY = 0;
            position = Vector2.Zero;
        }
        public void StartAnimation(Vector2 pos)
        {
            this.position = pos;
            this.currentX = 0;
            this.currentY = 0;
            this.Enabled = true;
            this.Visible = true;
        }
        public override void Draw(GameTime gameTime)
        {
            Rectangle sourceRectangle = new Rectangle(currentX, currentY, width, height);
            parent.Sprite.Begin();
            parent.Sprite.Draw(tex,position,sourceRectangle,Color.White);
            parent.Sprite.End();
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            if (++count < MaxCount) return;
            count = 0;
            currentX += width;
            if(currentX >= tex.Width)
            {
                currentY += height;
                if (currentY >= tex.Height)
                {
                    Visible = false;
                    Enabled = false;
                }
            }
            base.Update(gameTime);
        }
    }
}
