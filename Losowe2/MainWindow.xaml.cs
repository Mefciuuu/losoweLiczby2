using System.Text;
using System.Windows;
using System.Linq;

namespace Losowe2
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

        private void DrawButton_Click(object sender, RoutedEventArgs e)
        {
            const int draws = 100;
            const int min = 1;
            const int max = 10;

            var counts = new int[max + 1]; // indeksy 0..100, używamy 1..100

            var rng = System.Random.Shared;
            for (int i = 0; i < draws; i++)
            {
                int value = rng.Next(min, max + 1); // [min, max]
                counts[value]++;
            }

            var sb = new StringBuilder();
            sb.AppendLine($"Wylosowano {draws} liczb z zakresu {min}..{max}");
            sb.AppendLine(new string('-', 30));
            for (int i = min; i <= max; i++)
            {
                sb.AppendLine($"{i,3}: {counts[i],3}");
            }

            // dodatkowa kontrola: suma powinna równać się liczbie losowań
            sb.AppendLine(new string('-', 30));
            sb.AppendLine($"Suma: {counts.Skip(1).Sum()}");

            OutputTextBox.Text = sb.ToString();
            OutputTextBox.ScrollToHome();
        }
    }
}