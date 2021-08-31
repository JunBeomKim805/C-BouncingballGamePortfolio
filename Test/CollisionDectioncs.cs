using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;

namespace Test
{
    public class CollisionDection : GameComponent
    {
        Game1 parent;
        Ball ball;
        Bottom bottom;
        Explosion explosion;
        public CollisionDection(Game game, Ball ball, Bottom bottom, Explosion e) : base(game)
        {
            parent = (Game1)game;
            this.ball = ball;
            this.bottom = bottom;
            this.explosion = e;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        public override void Update(GameTime gameTime)
        {

            if (ball.Enabled && bottom.check(ball))
            {
                explosion.StartAnimation(ball.Position);

            }
            base.Update(gameTime);
        }

    }
}
