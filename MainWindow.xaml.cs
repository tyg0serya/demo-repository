using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _555
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            ResetErrorHighlighting();

            string lastname = LastNameTextBox.Text;
            string firstname = FirstNameTextBox.Text;
            string middlname = middlnameTextBox.Text;
            string ageText = AgeTextBox.Text;
            string numPassText = numPassTextBox.Text;
            string sPassText = sPassTextBox.Text;
            string email = EmailTextBox.Text;
            string phNumberText = phNumberTextBox.Text;

            string errorMessages = "";

            if (string.IsNullOrEmpty(lastname) || !lastname.All(char.IsLetter))
            {
                errorMessages += "Пожалуйста, введите корректную фамилию (только буквы).\n";
                LastNameTextBox.BorderBrush = Brushes.Red;
            }
            if (string.IsNullOrEmpty(firstname) || !firstname.All(char.IsLetter))
            {
                errorMessages += "Пожалуйста, введите корректное имя (только буквы).\n";
                FirstNameTextBox.BorderBrush = Brushes.Red;
            }

            if (string.IsNullOrEmpty(middlname) || !middlname.All(char.IsLetter))
            {
                errorMessages += "Пожалуйста, введите корректное отчество (только буквы).\n";
                middlnameTextBox.BorderBrush = Brushes.Red;
            }
            if (!string.IsNullOrEmpty(ageText) && (!int.TryParse(ageText, out int age) || age < 0 || age > 120))
            {
                errorMessages += "Пожалуйста, введите корректный возраст.\n";
                AgeTextBox.BorderBrush = Brushes.Red;
            }
            if (string.IsNullOrEmpty(numPassText) || !int.TryParse(numPassText, out int numPass) || numPass < 0 || numPass > 9999)
            {
                errorMessages += "Пожалуйста, введите корректный номер паспорта.\n";
                numPassTextBox.BorderBrush = Brushes.Red;
            }
            if (string.IsNullOrEmpty(sPassText) || !int.TryParse(sPassText, out int sPass) || sPass < 0 || sPass > 999999)
            {
                errorMessages += "Пожалуйста, введите корректную серию паспорта.\n";
                sPassTextBox.BorderBrush = Brushes.Red;
            }
            if (string.IsNullOrEmpty(phNumberText) || !long.TryParse(phNumberText, out long phnumber) || phNumberText.Length < 11 || !phNumberText.All(char.IsDigit))
            {
                errorMessages += "Пожалуйста, введите корректный номер телефона (не менее 11 цифр).\n";
                phNumberTextBox.BorderBrush = Brushes.Red;
            }

            if (string.IsNullOrEmpty(email) || !IsValidEmail(email))
            {
                errorMessages += "Пожалуйста, введите корректный email.\n";
                EmailTextBox.BorderBrush = Brushes.Red;
            }

            if (!string.IsNullOrEmpty(errorMessages))
            {
                MessageBox.Show(errorMessages);
                return;
            }

            MessageBox.Show("Регистрация прошла успешно!");
        }

        private bool IsValidEmail(string email)
        {
            var emailPattern = @"[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, emailPattern);
        }

        private void HighlightErrorFields(params string[] fieldValues)
        {
            foreach (var fieldValue in fieldValues)
            {
                if (string.IsNullOrEmpty(fieldValue))
                {
                    if (fieldValue == LastNameTextBox.Text) LastNameTextBox.BorderBrush = Brushes.Red;
                    if (fieldValue == FirstNameTextBox.Text) FirstNameTextBox.BorderBrush = Brushes.Red;
                    if (fieldValue == middlnameTextBox.Text) middlnameTextBox.BorderBrush = Brushes.Red;
                    if (fieldValue == AgeTextBox.Text) AgeTextBox.BorderBrush = Brushes.Red;
                    if (fieldValue == numPassTextBox.Text) numPassTextBox.BorderBrush = Brushes.Red;
                    if (fieldValue == sPassTextBox.Text) sPassTextBox.BorderBrush = Brushes.Red;
                    if (fieldValue == phNumberTextBox.Text) phNumberTextBox.BorderBrush = Brushes.Red;
                    if (fieldValue == EmailTextBox.Text) EmailTextBox.BorderBrush = Brushes.Red;
                }
            }
        }

        private void ResetErrorHighlighting()
        {
            LastNameTextBox.BorderBrush = Brushes.Gray;
            FirstNameTextBox.BorderBrush = Brushes.Gray;
            middlnameTextBox.BorderBrush = Brushes.Gray;
            AgeTextBox.BorderBrush = Brushes.Gray;
            numPassTextBox.BorderBrush = Brushes.Gray;
            sPassTextBox.BorderBrush = Brushes.Gray;
            EmailTextBox.BorderBrush = Brushes.Gray;
            phNumberTextBox.BorderBrush = Brushes.Gray;
        }
    }
}