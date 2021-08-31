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
    public class Brick : DrawableGameComponent 
    {
        SpriteBatch spriteBatch;
        GraphicsDevice graphics;
        Texture2D tex;
        int width;
        int height;
        int posX;
        int posY;
        public bool active { get; set; } = true;
        public bool CheckBallCollisiion(Ball ball)
        {
            if(active&&ball.PosX >= posX && ball.PosX <= posX +width && ball.PosY <= posY + height && ball.PosY>=posY)
            {

                ball.DirY = -ball.DirY;
                return true;

            }
            return false;
        }
        public Brick(Game game, GraphicsDevice graphics, SpriteBatch spriteBatch, int width,int height, int posX, int posY) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.height = height;
            this.width = width;
            this.posX = posX;
            this.posY = posY;

            tex = new Texture2D(graphics, 1, 1);
            tex.SetData(new Color[] { Color.Red });
        }
        public override void Draw(GameTime gameTime)
        {
            if (active)
            {
                spriteBatch.Begin();
                spriteBatch.Draw(tex, new Rectangle(posX, posY, width, height), Color.Red);
                spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
    
    
}
