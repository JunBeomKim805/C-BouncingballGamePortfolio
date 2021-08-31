using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms.Design;
namespace Test
{
    
    public class Ball : DrawableGameComponent
    {
        Game1 parent;

        public bool run { get; set; } = false;
        public int size;
        public int DirX { get; set; }
        public int DirY { get; set; }

        public int PosX { get; set; }
        public int PosY { get; set; }
        int speed = 1;
        SpriteBatch spriteBatch;
        Texture2D tex;
        GraphicsDevice graphics;
        Random random; 
        private Song hitSound;
        private Song missSound;
        public Vector2 Position { get; set; }
        public Ball(Game game, GraphicsDevice graphics, SpriteBatch spriteBatch, int size, string hitSoundName, string MissSoundName) : base(game)
        {
            parent = (Game1)game;
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.size = size;
            tex = new Texture2D(graphics, 1, 1);
            tex.SetData(new Color[] { Color.Red });
            this.hitSound = parent.Content.Load<Song>(hitSoundName);
            this.missSound = parent.Content.Load<Song>(MissSoundName);
            random = new Random();
            
            ResetBallPosition();
            ResetBallDirection();
        }

        public void ResetBallDirection()
        {
            do
            {
                DirX = random.Next(-5, 5);
            } while (DirX ==0);
            do
            {
                DirY = random.Next(-5, 5);
            } while (DirY == 0);
        }
        public void ResetBallPosition()
        {
            PosX = graphics.Viewport.Width / 2 - size / 2;
            PosY = graphics.Viewport.Height - graphics.Viewport.Height / 3;
        }
        public void CheckWallCollsiion()
        {
            if(PosX<=graphics.Viewport.X || PosX +size > graphics.Viewport.Width)
            {
                MediaPlayer.Play(hitSound);
                DirX *=-1;

            }
            if (PosY <= 0)
            {
                MediaPlayer.Play(hitSound);
                DirY *=-1;

            }
            if (PosY >= graphics.Viewport.Height-10 )
            {
                MediaPlayer.Play(missSound);
                run = false;
                ResetBallDirection();
                ResetBallPosition();

            }
        }
        public bool Check()
        {
            if (PosX <= graphics.Viewport.X || PosX + size > graphics.Viewport.Width)
            {
                return true;
            }
            if (PosY <= 0)
            {
                return true;
            }
            return false;
        }
        public override void Update(GameTime gameTime)
        {
            if (run)
            {
                Position = new Vector2(PosX-20, PosY-20);
                CheckWallCollsiion();
                PosX += DirX*speed;
                PosY += DirY * speed;

            }

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            
            spriteBatch.Draw(tex,new Rectangle(PosX,PosY,size,size),Color.Red);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
