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
using Microsoft.Win32;
using System;

namespace TempMonitoring
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TempCalc calc;
        int[] temps = null;
        string path;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnFill_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var startDate = DateTime.Parse(dateStart.Text);
                temps = Array.ConvertAll<string, int>(tempsData.Text.Split(), int.Parse);

                calc = new TempCalc(startDate, temps, 10);

                calc.prod = new Product(prodName.Text, int.Parse(maxTempVal.Text),
                    int.Parse(maxTempValTime.Text), int.Parse(minTempVal.Text),
                    int.Parse(minTempValTime.Text));

                calc.Calculate();
                dgInfo.ItemsSource = calc.diffs;
                if (calc.diffs.Count > 0)
                {
                    MessageBox.Show("Были нарушены условия хранения рыбы");
                }
                else
                {
                    MessageBox.Show("Условия хранения рыбы не были нарушены");
                }
            }
            catch {
                MessageBox.Show("Конкретно введите данные");
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new OpenFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    path = dialog.FileName;
                    calc.Load(path);
                }
                dateStart.Text = calc.date.ToString();
            }
            catch { }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var dialog = new SaveFileDialog();
                if (dialog.ShowDialog() == true)
                {
                    path = dialog.FileName;
                    calc.Save(path);
                }
            }
            catch { }
        }
    }
}
