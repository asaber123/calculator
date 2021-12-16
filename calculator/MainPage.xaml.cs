using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace calculator
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private decimal firstNumber;
        private string operatorName;
        private bool isOperatorClicked;

        private void BtnOne_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (LblResult.Text == "0" || isOperatorClicked)
            {
                LblResult.Text = button.Text;
                isOperatorClicked = false;
            }
            else
            {
                LblResult.Text += button.Text;
            }
        }

        void BtnClear_Clicked(System.Object sender, System.EventArgs e)
        {
            LblResult.Text = "0";
        }

        void BtnX_Clicked(System.Object sender, System.EventArgs e)
        {
            string number = LblResult.Text;
            if (number != "0")
            {
                number = number.Remove(number.Length - 1, 1);
                if (string.IsNullOrEmpty(number))
                {
                    LblResult.Text = "0";
                }
                else
                {
                    LblResult.Text = number;
                }
            }
        }


       private async void  BtnPercentage_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
               string number= LblResult.Text;
                if (number != "0")
                {
                    decimal percentValue = Convert.ToDecimal(number);
                    string result = (percentValue/100).ToString("0.##");
                    LblResult.Text = result;
                }
            }
            catch (Exception ex)
            {
               await DisplayAlert("error", ex.Message, "ok");
            }
        }

        void BtnEqual_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                decimal secondNumber = Convert.ToDecimal(LblResult.Text);
                string finalResult = Calculate(firstNumber, secondNumber, operatorName).ToString("0.##");
                LblResult.Text = finalResult;
            }
            catch (Exception ex)
            {
                DisplayAlert("error", ex.Message, "ok");
            }
        }
        public decimal Calculate(decimal firstNumber, decimal secondNumber, string operatorName)
        {
            decimal result = 0;
            if (operatorName == "+")
            {
                result = firstNumber + secondNumber;
            }
            else if (operatorName == "-")
            {
                result = firstNumber - secondNumber;
            }
            else if (operatorName == "*")
            {
                result = firstNumber * secondNumber;
            }
            else if (operatorName == "/")
            {
                result= firstNumber / secondNumber;
            }
            return result;
        }

        void BtnCommonOperation_Clicked(System.Object sender, System.EventArgs e)
        {
            var button = sender as Button;
            isOperatorClicked = true;
            operatorName = button.Text;
            firstNumber = Convert.ToDecimal(LblResult.Text);
        }
    }
}
