using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy.Bird
{
    public partial class Form1 : Form
    {

        int pipeSpeed = 4;
        int gravity = 8;
        int score = 0;



        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            FlappyBird.Top += gravity;
            PipeBottom.Left -= pipeSpeed;
            PipeTop.Left -= pipeSpeed;
            ScoreText.Text = "Score: " + score;

            if (PipeBottom.Left < -150)
            {
                PipeBottom.Left = 800;
                score++;
            }
            if (PipeTop.Left < -180)
            {
                PipeTop.Left = 950;
                score++;
            }

            if (FlappyBird.Bounds.IntersectsWith(PipeBottom.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(PipeTop.Bounds) ||
                FlappyBird.Bounds.IntersectsWith(Ground.Bounds) || FlappyBird.Top < -25
                )
            {
                endGame();
            }


            if (score > 5)
            {
                pipeSpeed = 8;
            }
            

        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {

            if(e.KeyCode == Keys.Space)
            {
                gravity = -15;
            }

        }

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 15;
            }

        }

        private void endGame()
        {
            GameTimer.Stop();
            ScoreText.Text += "***GAME OVER***";
        }
    }
}
