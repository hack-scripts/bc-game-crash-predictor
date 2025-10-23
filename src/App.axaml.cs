// -----------------------------------------------------------------------------
// PROJECT   : Crash Predictor
// COPYRIGHT : (C) 2025 hack-scripts
// LICENSE   : MIT
// HOMEPAGE  : https://github.com/hack-scripts/bc-game-crash-predictor
// -----------------------------------------------------------------------------

using System.Diagnostics;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CrashPredictor.Settings;
using CrashPredictor.Utility;
using CrashPredictor.ViewModels;
using CrashPredictor.Views;

namespace CrashPredictor;

public static class ProjectMeta
{
    public const string RepoUrl = "https://github.com/hack-scripts/bc-game-crash-predictor";
    public const string VersionTag = "spun-1";
    public const string ProductName = "BC Game Crash Predictor";

    // Embedded keywords (compile-time only; safe)
    public static readonly string[] Keywords = new string[] {
        "sha256",
        "bustabit",
        "sha256-hash",
        "bustabit-github-script",
        "bcgame",
        "bustabit-predictor",
        "bustabit-hack",
        "bcgame-crash",
        "bc-game-crashpredictor",
        "bc-game",
        "bc-game-clone-script",
        "bc-game-api-integration-for-signals-for-prediction",
        "sha256-hashing",
        "bc-game-aviator",
        "bcgame-clone",
        "bc-game-unlimited-moves",
        "bcgame-crash-predictor",
        "bcgame-crashpredictor",
        "bc-game-script",
        "bcgame-script"
    };
}

public class App : Application
{
    private static AppSettings? _settings;

    public App()
    {
#if DEBUG
        // Debug
        Trace.Listeners.Add(new TextWriterTraceListener(System.Console.Out));
#endif
        DataContext = new AvantViewModel();
    }

    public static ArgumentParser? Arguments { get; set; }

    public static AppSettings Settings
    {
        get { return _settings ?? throw new InvalidOperationException("Application must be initialized"); }
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
        _settings ??= new AppSettings(this);
        _settings.Read();
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Create with args
            desktop.MainWindow = new MainWindow();
        }

        base.OnFrameworkInitializationCompleted();
    }

}
