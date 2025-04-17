using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfPractic2
{
    public partial class MainWindow : Window
    {
        private const string RusAlphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
        private const string EngAlphabet = "abcdefghijklmnopqrstuvwxyz";
        private const string SpecialChars = "-;+_=\"[-@#$%^&?**)(!]";
        private const string Digits = "0123456789";
        private static Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            languageComboBox.SelectedIndex = 0;
        }
        private void GenerateLoginButton_Click(object sender, RoutedEventArgs e)
        {
            if (!ValidateInput(out string selectedLanguage, out string name, out DateTime birthDate))
            {
                loginResultTextBox.Text = "";
                return;
            }

            string alphabet = (selectedLanguage == "Русский") ? RusAlphabet : EngAlphabet;

            StringBuilder loginBuilder = new StringBuilder();
            string lowerCaseName = name.ToLower(); 

            foreach (char c in lowerCaseName)
            {
                int index = alphabet.IndexOf(c);
                if (index != -1) 
                {
                    loginBuilder.Append(index + 1); 
                }
            }

            string dateString = birthDate.ToString("ddMMyyyy"); 
            int dateSum = 0;
            foreach (char c in dateString)
            {
                if (char.IsDigit(c))
                {
                    dateSum += int.Parse(c.ToString()); 
                }
            }

            loginBuilder.Append(dateSum);

            loginResultTextBox.Text = loginBuilder.ToString();
        }

        private void GeneratePasswordButton_Click(object sender, RoutedEventArgs e)
        {

            if (!ValidateInput(out _, out _, out _))
            {
                passwordResultTextBox.Text = "";
                return; 
            }

            passwordResultTextBox.Text = GeneratePassword();
        }

        private bool ValidateInput(out string language, out string name, out DateTime birthDate)
        {
            language = (languageComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            name = nameTextBox.Text;
            birthDate = birthDatePicker.SelectedDate ?? DateTime.MinValue; 

            if (string.IsNullOrEmpty(language))
            {
                MessageBox.Show("Пожалуйста, выберите язык ввода.", "Ошибка ввода");
                return false;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Пожалуйста, введите имя.", "Ошибка ввода");
                return false;
            }

   
            string alphabet = (language == "Русский") ? RusAlphabet + RusAlphabet.ToUpper() : EngAlphabet + EngAlphabet.ToUpper();

            string allowedChars = alphabet + " -";
            foreach (char c in name)
            {
                if (!allowedChars.Contains(c))
                {
                    MessageBox.Show($"Имя содержит недопустимые символы для выбранного языка ('{language}').", "Ошибка ввода");
                    return false;
                }
            }

            if (birthDate == DateTime.MinValue)
            {
                MessageBox.Show("Пожалуйста, выберите или введите дату рождения.", "Ошибка ввода");
                return false;
            }

            if (birthDate > DateTime.Today)
            {
                MessageBox.Show("Дата рождения не может быть в будущем.", "Ошибка ввода");
                birthDatePicker.SelectedDate = null; 
                return false;
            }


            return true;
        }

        private string GeneratePassword()
        {
            const int passwordLength = 10;
            const int maxDigits = 5;

            List<char> passwordChars = new List<char>(passwordLength);
            int digitCount = 0;
            bool hasUppercase = false;
            bool hasSpecial = false;

            passwordChars.Add(EngAlphabet.ToUpper()[random.Next(EngAlphabet.Length)]);
            hasUppercase = true;

            passwordChars.Add(SpecialChars[random.Next(SpecialChars.Length)]);
            hasSpecial = true;

            string allowedChars = EngAlphabet + Digits; 

            while (passwordChars.Count < passwordLength)
            {
                char nextChar;
                bool isDigit = false;

                nextChar = allowedChars[random.Next(allowedChars.Length)];
                isDigit = char.IsDigit(nextChar);

                if (isDigit && digitCount >= maxDigits)
                {
                    continue; 
                }

                if (isDigit && passwordChars.Count > 0 && char.IsDigit(passwordChars.Last()))
                {
                    continue;
                }

                passwordChars.Add(nextChar);
                if (isDigit)
                {
                    digitCount++;
                }
            }

            for (int i = passwordChars.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                char temp = passwordChars[i];
                passwordChars[i] = passwordChars[j];
                passwordChars[j] = temp;
            }

            for (int i = 0; i < passwordChars.Count - 1; i++)
            {
                if (char.IsDigit(passwordChars[i]) && char.IsDigit(passwordChars[i + 1]))
                {
                    Console.WriteLine("Перегенерация из-за двух цифр подряд после перемешивания..."); 
                    return GeneratePassword();
                }
            }

            return new string(passwordChars.ToArray());
        }
    }
}
