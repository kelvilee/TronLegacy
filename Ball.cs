using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Pong
{
    public class Ball : Movable
    {
        public int ballSpeedX { set; get; }
        public int ballSpeedY { set; get; }
        public void resetBall()
        {

            Location = new Point(mainForm.Width / 2 - Width / 2, mainForm.Height / 2 - Height / 2);
        }
        public Ball(int ballSpeedX, int ballSpeedY)
        {
            this.ballSpeedX = ballSpeedX;
            this.ballSpeedY = ballSpeedY;
        }
        public Ball(Player player)
        {
            this.ballSpeedX = 0;
            this.ballSpeedY = 0;
            this.Location = player.Location;
            this.Size = new Size(20, 20);
            this.BackColor = Color.Red;
        }

    }
}