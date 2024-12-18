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

namespace Flagi;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void StartGame(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NickNameInput.Text))
        {
            MessageBox.Show("Podaj swój nick!");
            return;
        }

        GameData.UserName = NickNameInput.Text;
        GameWindow gameWindow = new GameWindow();
        gameWindow.Show();
        this.Close();
    }
}