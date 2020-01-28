using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pong
{
    class Game
    {
        public Timer gameTime;
        // int gameTimeInterval=1;
        public Player player;
        //  public AI ai;
        public Ball ball;
        public ArrayList oldBalls;
        public Form form;
        public GameController controller;

        public KeyEventHandler KeyDown { get; private set; }

        public Game(Form form)
        {
            this.form = form;
            controller = new GameController(form);
            gameTime = new Timer();
            gameTime.Enabled = true;
            gameTime.Interval = 1;
            gameTime.Tick += new EventHandler(OnGameTimeTick);

            Movable.mainForm = form;
            player = new Player();
            player.Size = new Size(20, 20);
            player.Location = new Point(form.Width / 2 - player.Width / 2, player.Height / 2 - player.Height / 2);
            player.BackColor = Color.HotPink;

            oldBalls = new ArrayList();

            //ball = new Ball(3, 3);
            //ball.Size = new Size(20, 20);
            //ball.BackColor = Color.Red;
            //ball.Location = new Point(form.Width / 2 - ball.Width / 2, form.Height / 2 - ball.Height / 2);
        }

        void OnGameTimeTick(object sender, EventArgs e)
        {
            Ball newBall = ball;
            oldBalls.Add(new Ball(player));
            player.Location = new Point(player.Location.X + player.playerSpeedX, player.Location.Y + player.playerSpeedY);
            //controller.CollisionGameArea(ball);
            //controller.PaddleCollision(player, ball);
        }

    }
}