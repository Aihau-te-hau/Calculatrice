using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculatrice
{
    public partial class Calc : Form
    {
        //Déclarations et initialisations des var
        double result = 0;
        string operation = string.Empty;
        string fstNum, secNum;
        bool enterValue = false;
        bool mouseDown = false;
        bool mouseUp = false;
        
        public Calc()
        {
            InitializeComponent();
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            txbDisplay1.Text = "0";
            txbDisplay2.Text = string.Empty;
            result = 0;
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            //Non traité
        }

        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnNum_Click(object sender, EventArgs e)
        {
            if (txbDisplay1.Text == "0" || enterValue)
            {
                txbDisplay1.Text = string.Empty;
            }

            //pq garderais-je cette partie redondante ?
            enterValue = false;

            //Evènement
            Button btn = (Button)sender;

            if (btn.Text == ".")
            {
                if (!txbDisplay1.Text.Contains("."))
                {
                    txbDisplay1.Text = txbDisplay1.Text + btn.Text;
                }
            }
            else
            {
                txbDisplay1.Text = txbDisplay1.Text + btn.Text;
            }
        }

        private void BtnOperations_Click(object sender, EventArgs e)
        {
            if (result != 0)
            {
                btnEqual.PerformClick();
            }
            else
            {
                result = Double.Parse(txbDisplay1.Text);
            }

            //Evènement
            Button btn = (Button)sender;

            operation = btn.Text;
            enterValue = true;

            if(txbDisplay1.Text != "0")
            {
                txbDisplay2.Text = fstNum = $"{result}{operation}";
                txbDisplay1.Text = string.Empty;
            }

        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void pnlTitle_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void pnlTitle_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void BtnResult_Click(object sender, EventArgs e)
        {
            secNum = txbDisplay2.Text;
            txbDisplay2.Text = $"{txbDisplay2.Text} {txbDisplay1.Text}=";

            if (txbDisplay1.Text != string.Empty)
            {
                if (txbDisplay1.Text == "0")
                {
                    txbDisplay2.Text = string.Empty;
                }
                switch (operation)
                {
                    case "+":
                        txbDisplay1.Text = (result + Double.Parse(txbDisplay1.Text)).ToString();
                        break;
                    case "-":
                        txbDisplay1.Text = (result - Double.Parse(txbDisplay1.Text)).ToString();
                        break;
                    case "*":
                        txbDisplay1.Text = (result * Double.Parse(txbDisplay1.Text)).ToString();
                        break;
                    case "/":
                        txbDisplay1.Text = (result / Double.Parse(txbDisplay1.Text)).ToString();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
