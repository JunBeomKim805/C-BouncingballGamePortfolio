using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Text;

namespace Test
{
    public class ActionScene : GameScene
    {
        Vector2 ScorePosition;
        Explosion explosion;
        Game1 parent;
        KeyboardState oldState;
        Ball ball;
        Bottom bottom;
        Brick brick;
        int ballSize = 6;
        int bottomWidth = 40;
        int bottomHeight = 10;
        int brickHeight = 20;
        int brickWidth = 50;
        int brickRows = 6;
        int gamewidth = 800;
        int gameHeight = 600;
        List<Brick> bricks;
        private SpriteFont regularFont;
        public ActionScene(Game game) : base(game)
        {
            parent = (Game1)game;
            parent.Graphics.PreferredBackBufferWidth = gamewidth;
            parent.Graphics.PreferredBackBufferHeight = gameHeight;
            ball = new Ball(parent, GraphicsDevice, parent.Sprite, ballSize, "Sound/hitSound", "Sound/gameOverSound");
            Components.Add(ball);
            bottom = new Bottom(parent, GraphicsDevice, parent.Sprite, bottomWidth, bottomHeight);
            Components.Add(bottom);
            bricks = new List<Brick>();
            CreateBricks();
            Explosion explosion = new Explosion(parent, "Images/explosion", 5, 5);
            regularFont = parent.Content.Load<SpriteFont>("Font/regularFont");
            CollisionDection cd = new CollisionDection(parent, ball, bottom, explosion);


            this.Components.Add(cd);
            this.Components.Add(explosion);

            ScorePosition.X = 100;
            ScorePosition.Y = 400;
        }
        public override void Draw(GameTime gameTime)
        {
            parent.Sprite.Begin();
            parent.Sprite.DrawString(regularFont, "Score :" + bottom.Score.ToString(),ScorePosition,Color.Red);
            parent.Sprite.End();
            base.Draw(gameTime);
        }
        public void CreateBricks()
        {
            for (int i = 0; i < gamewidth / brickWidth; i++)
            {
                for (int j = 0; j < brickRows + 1; j++)
                {
                    bricks.Add(new Brick(parent, GraphicsDevice, parent.Sprite, brickWidth, brickHeight, i * brickWidth + i, j * brickHeight + j));
                }
            }
            foreach (var item in bricks)
            {
                Components.Add(item);
            }
        }
        protected override void UnloadContent()
        {
            base.UnloadContent();
        }
        public override void Update(GameTime gameTime)
        {

            KeyboardState ks = Keyboard.GetState();
            if (ks.IsKeyDown(Keys.Escape) && oldState.IsKeyUp(Keys.Escape))
            {
                parent.Notify(this, "escape");
            }
            if (ball.Enabled == false)
            {
                parent.Notify(this, "gameover");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && !ball.run)
            {
                ball.run = true;
            }

            bottom.PosX = Mouse.GetState().X;
            bottom.CheckBottomBallCollsion(ball);

            foreach (var item in bricks)
            {
                if (item.CheckBallCollisiion(ball))
                {
                    item.active = false;
                }
            }
            // TODO: Add your update logic here

            base.Update(gameTime);
        }
    }
}
