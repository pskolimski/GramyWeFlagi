using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace Flagi;

public partial class GameWindow : Window
{
    private List<Button> OptionButtons { get; set; }
    DispatcherTimer timer = new DispatcherTimer();
    private TimeSpan secondsPlayed = new TimeSpan();
    private Country correctCountry;
    private int roundNumber = 0;

    public GameWindow()
    {
        InitializeComponent();

        NickLabel.Content = GameData.UserName;

        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += TimerOnTick;
        timer.Start();

        OptionButtons = new List<Button>()
        {
            Option1,
            Option2,
            Option3,
            Option4
        };
        StartRound();
    }

    private void StartRound()
    {
        if (roundNumber >= 10)
        {
            timer.Stop();
            GameData.TimePlayed = $"{secondsPlayed.Minutes:00}:{secondsPlayed.Seconds:00}";
            ResultWindow resultWindow = new ResultWindow();
            resultWindow.Show();
            this.Close();
        }
        else
        {
            roundNumber++;
        }
        RoundLabel.Content = $"Runda {roundNumber}/10";
        List<Country> roundSet = new List<Country>();

        while (roundSet.Count < 4)
        {
            Country randomCountry = GameData.Countries[new Random().Next(GameData.Countries.Count)];
            if (!roundSet.Contains(randomCountry))
            {
                roundSet.Add(randomCountry);
            }
        }

        for (int i = 0; i < 4; i++)
        {
            OptionButtons[i].Content = roundSet[i].CountryName;
        }

        correctCountry = roundSet[new Random().Next(4)];
        FlagImage.Source = new BitmapImage(new Uri($"flagi/{correctCountry.CountryFlagImage}", UriKind.Relative));
    }

    private void TimerOnTick(object? sender, EventArgs e)
    {
        secondsPlayed = secondsPlayed.Add(TimeSpan.FromSeconds(1));
        TimeLabel.Content = $"Czas: {secondsPlayed.Minutes:00}:{secondsPlayed.Seconds:00}";
    }

    private void OptionButtonClick(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;

        if (button.Content.ToString() == correctCountry.CountryName)
        {
            AnswerLabel.Content = "Brawo! Poprawna odpowiedź!";
            AnswerLabel.Background = Brushes.LimeGreen;
            GameData.Score += 1;
            StartRound();
        }
        else
        {
            AnswerLabel.Content = $"Zła odpowiedź! Poprawna odpowiedź to: {correctCountry.CountryName}";
            AnswerLabel.Background = Brushes.OrangeRed;
            StartRound();
        }
    }
}