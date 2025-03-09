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

namespace pr3_part2_Sergeev_Alexander_322
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void CalculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(AmountTextBox.Text) || string.IsNullOrWhiteSpace(TermTextBox.Text) || string.IsNullOrWhiteSpace(RateTextBox.Text))
            {
                MessageBox.Show("Пожалуйста заполните все поля.");
                return;
            }

            if (!SimpleInterestRadio.IsChecked.Value && !CompoundInterestRadio.IsChecked.Value)
            {
                MessageBox.Show("Пожалуйста выберите схему начисления.");
                return;
            }

            double amount, rate;
            int term;

            if (!double.TryParse(AmountTextBox.Text, out amount) || !int.TryParse(TermTextBox.Text, out term) || !double.TryParse(RateTextBox.Text, out rate))
            {
                MessageBox.Show("Пожалуйста введите корректные числовые значения.");
                return;
            }

            double result = 0;

            if (SimpleInterestRadio.IsChecked.Value)
            {
                result = amount * (1 + (rate / 100) * term);
            }
            else if (CompoundInterestRadio.IsChecked.Value)
            {
                result = amount * Math.Pow(1 + (rate / 100) / 12, term);
            }

            ResultLabel.Content = "Доход по вкладу: " + result.ToString("C");
        }
    }
}
