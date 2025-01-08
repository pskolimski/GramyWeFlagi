using System.Windows;

namespace Flagi;

public partial class ResultWindow : Window
{
    public ResultWindow()
    {
        InitializeComponent();
    
        NickLabel.Content = GameData.UserName;
        ScoreLabel.Content = $"{GameData.Score}/10";
        TimeLabel.Content = $"Czas: {GameData.TimePlayed}";
    }

    private void PlayAgain(object sender, RoutedEventArgs e)
    {
        MainWindow mainWindow = new MainWindow();
        mainWindow.Show();
        this.Close();
    }
}