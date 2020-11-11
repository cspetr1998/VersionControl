using _8gyakorlat.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _8gyakorlat
{
    public partial class Form1 : Form
    {
        private List<Ball> _balls = new List<Ball>();

        private BallFactory _factory;
        public BallFactory Factory
        {
            get { return _factory; }
            set { _factory = value; }
        }

        public Form1()
        {
            InitializeComponent();
            Factory = new BallFactory();
        }

        private void createTimer_Tick(object sender, EventArgs e)
        {
            var ball = Factory.CreateNew();
            _balls.Add(ball);
            ball.Left = -ball.Width;
            mainPanel.Controls.Add(ball);
        }
        //A conveyorTimer eseménykezelőjében egy foreach segítségével menj végig a _balls listán 
        //és hívd meg mindegyik elemének a MoveBall metódusát. 
        //Ezen felül egy a cikluson kívüli segédváltozóval tárold le a leginkább jobbra levő Ball példány pozícióját.
        //A ciklus után, ha a legnagyobb pozíció eléri az 1000-et akkor tárold le egy változóba a _balls 
        //lista első elemét és töröld ki a listából és a Form vezérlőiből is.
        
        private void conveyorTimer_Tick(object sender, EventArgs e)
        {
            var maxPosition = 0;
            foreach (var ball in _balls)
            {
                ball.MoveBall();
                if (ball.Left > maxPosition)
                    maxPosition = ball.Left;
            }
            if (maxPosition > 1000)
            {
                var oldestBall = _balls[0];
                mainPanel.Controls.Remove(oldestBall);
                _balls.Remove(oldestBall);
            }
        }
    }
}
