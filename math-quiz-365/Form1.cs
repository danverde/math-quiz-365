using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace math_quiz_365
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1;
        int addend2;

        int subend1;
        int subend2;

        int multiplier1;
        int multiplier2;

        int divend1;
        int divend2;

        int timeLeft;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        public void startQuiz()
        {
            /* get random ints to use for the math problems */
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            subend1 = randomizer.Next(0, 101);
            subend2 = randomizer.Next(1, subend1);

            multiplier1 = randomizer.Next(2, 11);
            multiplier2 = randomizer.Next(2, 11);

            divend2 = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            divend1 = divend2 * temporaryQuotient;
            divisionLeftLabel.Text = divend1.ToString();
            divisionRightLabel.Text = divend2.ToString();


            /* disply values  */
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            minusLeftLabel.Text = subend1.ToString();
            minusRightLabel.Text = subend2.ToString();

            timesLeftLabel.Text = multiplier1.ToString();
            timesRightLabel.Text = multiplier2.ToString();

            divisionLeftLabel.Text = divend1.ToString();
            divisionRightLabel.Text = divend2.ToString();

            /* set sum to 0 */
            sum.Value = 0;
            difference.Value = 0;
            product.Value = 0;
            quotient.Value = 0;
            
            /* start the timer */
            timeLeft = 300;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }
        
        private void StartButton_Click(object sender, EventArgs e)
        {
            startQuiz();
            startButton.Enabled = false;
        }

        private bool checkTheAnswers()
        {

            if ((addend1 + addend2 == sum.Value) && (subend1 - subend2 == difference.Value) && (multiplier1 * multiplier2 == product.Value) && (divend1 / divend2 == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (checkTheAnswers())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's Up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;
            
            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
