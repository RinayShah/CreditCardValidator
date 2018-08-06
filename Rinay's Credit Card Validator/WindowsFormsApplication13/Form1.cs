    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication13
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private string cardType(string cardnumber)
            // Checks the type of Credit Card
        {
            string typeofcard = "Unknown";
            label1.ForeColor = Color.Red;
            if (cardnumber.Length == 16 && cardnumber.Substring(0, 1) == "4")
            {
                typeofcard = "Visa";
                label1.ForeColor = Color.Green;
            }

            if (cardnumber.Length == 16 && (cardnumber.Substring(0, 2) == "51" || cardnumber.Length == 16 & cardnumber.Substring(0, 2) == "52" || cardnumber.Length == 16 & cardnumber.Substring(0, 2) == "53" || cardnumber.Length == 16 & cardnumber.Substring(0, 2) == "54" || cardnumber.Length == 16 & cardnumber.Substring(0, 2) == "55"))
            {
                typeofcard = "Master Card";
                label1.ForeColor = Color.Green;
            }
            if (cardnumber.Length == 15 && (cardnumber.Substring(0, 2) == "34" || cardnumber.Length == 15 & cardnumber.Substring(0, 2) == "37"))
            {
                typeofcard = "American Express";
                label1.ForeColor = Color.Green;
            }
            if (cardnumber.Length == 16 && cardnumber.Substring(0, 4) == "6011")
            {
                typeofcard = "Discover";
                label1.ForeColor = Color.Green;
            }
            if (cardnumber.Length == 14 && cardnumber.Substring(0, 2) == "36")
            {
                typeofcard = "Diners Club";
                label1.ForeColor = Color.Green;
            }
            return typeofcard;

        }
        private bool checkSumValid(string cardnumber)
        {
            if (cardnumber == "")
                return false;
            int sumDouble = 0;
            int sumAdd = 0;
            int CheckSum = 0;
            //Starting from the back of the credit card every other number is multiplied by 2
            for (int i = cardnumber.Length - 2; i >= 0; i -= 2)
            {
                int otherSum = 0;
                int x = Convert.ToInt32(cardnumber.Substring(i, 1));
                x = 2 * x;
                // OtherSum Stores the first value of the number and SumDouble stores the last value number
                do
                {
                    otherSum += x % 10;
                    x = x / 10;
                } while (x != 0);
                sumDouble += otherSum;
            }
            // Adds the remaning values to the CheckSum
            for (int y = cardnumber.Length - 1; y >= 0; y -= 2)
            {
                int x = Convert.ToInt32(cardnumber.Substring(y, 1));
                sumAdd += x;
            }
            CheckSum = sumDouble + sumAdd;
            if (CheckSum % 10 == 0 && cardnumber.Length <= 16)
                return true;
            else return false;

        }

        private void button1_Click(object sender, EventArgs e)
            //Picture Visiblity 
        { 
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            pictureBox3.Visible = false;
            pictureBox4.Visible = false;
            pictureBox5.Visible = false;
            label1.Text = cardType(textBox1.Text);
            if (cardType(textBox1.Text) == "Visa")
            {
                pictureBox1.Visible = true;
            }
            if (cardType(textBox1.Text) == "Master Card")
            {
                pictureBox2.Visible = true;
            }
            if (cardType(textBox1.Text) == "Discover")
            {
                pictureBox3.Visible = true;
            }
            if (cardType(textBox1.Text) == "American Express")
            {
                pictureBox4.Visible = true;
            }
            if (cardType(textBox1.Text) == "Diners Club")
            {
                pictureBox5.Visible = true;
            }
            if (checkSumValid(textBox1.Text))
            {
                label2.Text = "Valid Number";
                label2.ForeColor = Color.Green;
            }
            else
            {
                label2.Text = "Invalid Number";
                label2.ForeColor = Color.Red;     
            }
        }
        private string CreditCardGenerator(int prefix)
        {
            int length = 0;
            int abc = 0;
            Random ram = new Random();
            string generaterandomnumber = prefix.ToString();
            // Sets the credit length after a radio button is clicked 
            if (radioButton1.Checked)
            {
                length = 16;
            }
            if (radioButton2.Checked)
            {
                length = 16;
            }
            if (radioButton3.Checked)
            {
                length = 16;
            }
            if (radioButton4.Checked)
            {
                length = 14;
            }
            if (radioButton5.Checked)
            {
                length = 15;
            }
            do
                //Sets random numbers between 1 to 9 upto the 2nd last number in the card length
            {
                int digits = ram.Next(0, 10);
                generaterandomnumber += digits.ToString();
            } while (generaterandomnumber.Length < length - 1);
            //Last digit for the credit card number is 0
            generaterandomnumber += abc.ToString();
            //CheckSum Code
            int sumdouble = 0;
            int sumadd = 0;
            int checksum = 0;
            for (int i = generaterandomnumber.Length - 2; i >= 0; i -= 2)
            {
                int othersum = 0;
                int x = Convert.ToInt32(generaterandomnumber.Substring(i, 1));
                x = 2 * x;
                do
                {
                    othersum += x % 10;
                    x = x / 10;
                } while (x != 0);
                sumdouble += othersum;
            }
            for (int y = generaterandomnumber.Length - 1; y >= 0; y -= 2)
            {
                int x = Convert.ToInt32(generaterandomnumber.Substring(y, 1));
                sumadd += x;
            }
            checksum = sumdouble + sumadd;

            if (checksum % 10 != 0)
            {
                //Last number which was 0 is removed and replaced by the new value of abc
                abc = 10 - (checksum % 10);
                generaterandomnumber = generaterandomnumber.Remove(length - 1);
                generaterandomnumber += abc.ToString();
            }
            return generaterandomnumber.ToString();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            int pick = r.Next(5);
            int pick2 = r.Next(2);
            // Picks randomly between 34 and 37 
            if (pick2 == 0)
            {
                pick2 = 34;
            }
            else
            {
                pick2 = 37;
            }
            // The prefix of each credit card number is added
            if (radioButton1.Checked)
                textBox2.Text = CreditCardGenerator(4);
            if (radioButton2.Checked)
                textBox2.Text = CreditCardGenerator(6011);
            if (radioButton3.Checked)
                textBox2.Text = CreditCardGenerator(pick + 51);
            if (radioButton4.Checked)
                textBox2.Text = CreditCardGenerator(36);
            if (radioButton5.Checked)
                textBox2.Text = CreditCardGenerator(pick2);

        }

        private void textBox1_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
            else
            {
                e.Handled = false;
            }
        }
    }
}






