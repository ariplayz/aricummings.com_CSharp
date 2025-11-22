using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using Avalonia.Markup.Xaml;

namespace aricummings.com.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
    
    private void GithubButton_OnClick(object? sender, RoutedEventArgs e)
    {
        System.Diagnostics.Process.Start("https://github.com/ariplayz");
    }
}