using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Zakgeld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double pocketMoney = double.Parse(pocketTextBox.Text);
            double raise = double.Parse(weeklyRaiseTextBox.Text);
            double desiredAmount = double.Parse(desiredSavingsTextBox.Text);
            StringBuilder sb = new StringBuilder();
            int weekCounter = 0;
            double total = 0;

            double raisedWeekly = pocketMoney;
            double startAmount = pocketMoney + raise;

            while(total < desiredAmount)
            {
                raisedWeekly += raise;
                total += raisedWeekly;
                weekCounter++;
            }

            sb.AppendLine($"Spaarbedrag na {weekCounter - 1} weken: {total - raisedWeekly:C}");
            sb.AppendLine($"Extra weekgeld op dat moment: {raisedWeekly - startAmount:C}");
            sb.AppendLine($"Totaal spaargeld: {total - startAmount:C}");
            resultTextBox.Text = sb.ToString();

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            pocketTextBox.Text = "";
            weeklyRaiseTextBox.Text = "";
            desiredSavingsTextBox.Text = "";
            resultTextBox.Text = "";
        }
    }
}