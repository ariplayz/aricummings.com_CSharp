using System;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Styling;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.Threading;


namespace aricummings.com.Views;

public partial class MainView : UserControl
{
    
    private TranslateTransform _t1;
    private TranslateTransform _t2;
    private readonly Stopwatch _stopwatch = new Stopwatch();
    private readonly DispatcherTimer _timer;

    
    public MainView()
    {
        InitializeComponent();
        
        var f1 = this.FindControl<Border>("Float1Border");
        var f2 = this.FindControl<Border>("Float2Border");
        
        _t1 = f1?.RenderTransform as TranslateTransform ?? new TranslateTransform();
        _t2 = f2?.RenderTransform as TranslateTransform ?? new TranslateTransform();

        // Start the simple sinusoidal animation
        _stopwatch.Start();
        _timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(16) // ~60 FPS
        };
        _timer.Tick += OnTick;
        _timer.Start();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
    
    private void OnTick(object? sender, EventArgs e)
    {
        var t = _stopwatch.Elapsed.TotalSeconds;

        // Gentle floating motion
        var x1 = Math.Cos(t * 0.9) * 4.0;
        var y1 = Math.Sin(t * 1.2) * 8.0;

        var x2 = Math.Cos(t * 0.7 + 0.4) * 3.0;
        var y2 = Math.Sin(t * 1.1 + 1.5) * 6.0;

        if (_t1 != null)
        {
            _t1.X = x1;
            _t1.Y = y1;
        }

        if (_t2 != null)
        {
            _t2.X = x2;
            _t2.Y = y2;
        }
    }
    
    private void GithubButton1(object? sender, RoutedEventArgs e)
    {
        GithubLink();
    }

// Renamed from GithubButton2 to avoid confusion or remove if you prefer only one button
    private void GithubButton2(object? sender, RoutedEventArgs e)
    {
        GithubLink();
    }

    void GithubLink()
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "https://github.com/ariplayz", // Replace with your URL
            UseShellExecute = true // Opens the URL in the default browser
        });
    }
    
    
    
}