using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Pong
{
    public class Player : Movable
    {

        public int playerSpeedX { set; get; }
        public int playerSpeedY { set; get; }

        public Player()
        {
            this.playerSpeedX = 0;
            this.playerSpeedY = 3;
        }

    }

}