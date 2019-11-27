using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            initItems();
        }

        private void initItems()
        {
            String[] actionListItems = { "сложение", "вычитание", "деление", "произведение" };
            actionList.Items.AddRange(actionListItems);
            actionList.SelectedIndex = 0;
        }

        private void calculateBTN_Click(object sender, EventArgs e)
        {
            string answer;
            try
            {
                LargeInt num1;
                LargeInt num2;

                string line1 = number1Field.Text;
                if (line1 == "")
                    line1 = "0";

                if(line1[0] == '!')
                {
                    num1 = new LargeInt(line1.Remove(0, 1)).factorial();
                }
                else
                {
                    num1 = new LargeInt(line1);
                }

                string line2 = number2Field.Text;
                if (line2 == "")
                    line2 = "0";

                if (line2[0] == '!')
                {
                    num2 = new LargeInt(line2.Remove(0, 1)).factorial();
                }
                else
                {
                    num2 = new LargeInt(line2);
                }                                             

                switch (actionList.SelectedItem)
                {
                    case "сложение":
                        answer = num1.plus(num2).ToString();
                        break;
                    case "вычитание":
                        answer = num1.minus(num2).ToString();
                        break;
                    case "деление":
                        answer = num1.divide(num2).ToString();
                        break;
                    case "произведение":
                        answer = num1.multyply(num2).ToString();
                        break;
                    default:
                        answer = "Неизвестное действие";
                        break;
                }
            }
            catch (Exception ex)
            {
                answer = ex.ToString();
            }

            answerLabel.Text = answer;

        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        Point LastPoint;

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            LastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.X - LastPoint.X;
                Top += e.Y - LastPoint.Y;
            }
        }
    }
}
