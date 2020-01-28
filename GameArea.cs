using System;
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
    public partial class GameArea : Form

    {
        Messager messager;
        Game game;
        const int GameAreaWidth = 1248;
        const int GameAreaHeight = 720;
        public GameArea()
        {
            messager = new Messager();
            //InitializeComponent();
            this.Height = GameAreaHeight;
            this.Width = GameAreaWidth;
            this.StartPosition = FormStartPosition.CenterScreen;
            game = new Game(this);
            KeyDown += new KeyEventHandler(OnKeyDown);

        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        public void OnKeyDown(object sender, KeyEventArgs e)
        {
            messager.sendMessage(game.player);
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (game.player.playerSpeedY == 0)
                    {
                        return;
                    }
                    game.player.playerSpeedX = -3;
                    game.player.playerSpeedY = 0;
                    break;
                case Keys.Right:
                    if (game.player.playerSpeedY == 0)
                    {
                        return;
                    }
                    game.player.playerSpeedX = 3;
                    game.player.playerSpeedY = 0;
                    break;
                case Keys.Up:
                    if (game.player.playerSpeedX == 0)
                    {
                        return;
                    }
                    game.player.playerSpeedX = 0;
                    game.player.playerSpeedY = -3;
                    break;
                case Keys.Down:
                    if (game.player.playerSpeedX == 0)
                    {
                        return;
                    }
                    game.player.playerSpeedX = 0;
                    game.player.playerSpeedY = 3;
                    break;
            }

        }


        private void GameArea_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}