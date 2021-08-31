using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms.Design;      

namespace Test
{
    public class Bottom : DrawableGameComponent
    {
        int height;
        int width;
        public int Score { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        SpriteBatch spriteBatch;
        Texture2D tex;
        GraphicsDevice graphics;

        public Bottom(Game game, GraphicsDevice graphics,SpriteBatch spriteBatch,int width, int height) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.width = width;
            this.height = height;

            tex = new Texture2D(graphics, 1, 1);
            tex.SetData(new Color[] { Color.Red });
            Score = 0;
            ResetPaddlePosition();
        }

        public void ResetPaddlePosition()
        {
            PosX = graphics.Viewport.Width / 2 - width / 2;
            PosY = graphics.Viewport.Height - 20;
        }
        public void CheckBottomBallCollsion(Ball ball)
        {

            if (ball.PosY + ball.size >=PosY && ball.PosX >=PosX &&  ball.PosX +ball.size <=PosX + width)
            {
                ball.DirY = -ball.DirY;
                Score = Score + 1;
                //ball.DirX = -ball.DirX;
            }
        }
        public Boolean check(Ball ball)
        {
            if (ball.PosY + ball.size >= PosY && ball.PosX >= PosX && ball.PosX + ball.size <= PosX + width)
            {
                return true;
            }
            return false;
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(tex, new Rectangle(PosX, PosY, width, height), Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
