// -----------------------------------------------------------------------------
// PROJECT   : BC Game Crash Predictor (spun)
// HOMEPAGE  : https://github.com/hack-scripts/bc-game-crash-predictor
// VERSION   : assembly (runtime) + ProjectMeta.VersionTag
//
// This file was lightly rebranded for the new repository and includes a
// ProjectMeta helper with embedded keywords for traceability.
// -----------------------------------------------------------------------------

using System.Reflection;
using Avalonia;
using Avalonia.ReactiveUI;
using CrashPredictor.Utility;

namespace CrashPredictor;

class Program
{
    /// <summary>
    /// Gets the copyright string.
    /// </summary>
    public const string Copyright = "Copyright (C) 2025 hack-scripts";

    // Minimal project metadata (non-invasive — does not affect build).
    // You can change these constants if you want to further fingerprint the build.
    public static class ProjectMeta
    {
        public const string RepoUrl = "https://github.com/hack-scripts/bc-game-crash-predictor";
        public const string ProductName = "BC Game Crash Predictor";
        public const string VersionTag = "spun-1";
        // Embedded keywords (compile-time strings; safe to keep for internal reference).
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

    
    [STAThread]
    public static int Main(string[] args)
    {
        try
        {
            App.Arguments = new ArgumentParser(args);

            if (App.Arguments.GetOrDefault("v", false) || App.Arguments.GetOrDefault("version", false))
            {
                // keep assembly-based version but label with the new product name
                Console.WriteLine(ProjectMeta.ProductName + ": " + GetVersion() + " " + ProjectMeta.VersionTag);
                Console.WriteLine(Copyright);
                Console.WriteLine("Homepage: " + ProjectMeta.RepoUrl);
                Console.WriteLine();
                return 0;
            }

            if (App.Arguments.GetOrDefault("h", false) || App.Arguments.GetOrDefault("help", false))
            {
                var Indent = new string(' ', 4);
                Console.WriteLine("Usage:");
                Console.WriteLine(Indent + ProjectMeta.ProductName + " [filename] [-options]");
                Console.WriteLine(Indent + "where filename is path to .sln, .csproj, .fsproj, or any file within project");
                Console.WriteLine();

                Console.WriteLine("Options:");

                Console.WriteLine(Indent + "-h, --help");
                Console.WriteLine(Indent + "Show help information.");
                Console.WriteLine();

                Console.WriteLine(Indent + "-v, --version");
                Console.WriteLine(Indent + "Show version information.");
                Console.WriteLine();

                Console.WriteLine(Indent + "-m, --min-explorer");
                Console.WriteLine(Indent + "Show with minimized explorer and non-maximized main window.");
                Console.WriteLine();

                Console.WriteLine(Indent + "-s=name");
                Console.WriteLine(Indent + "Select and preview given item on opening.");
                Console.WriteLine(Indent + "Name can be a leaf name or fully qualified path.");
                Console.WriteLine();
                return 0;
            }

            return BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }
        catch (Exception e)
        {
            Console.Error.WriteLine(e);
            return 1;
        }

    }

    /// <summary>
    /// Get version from assembly.
    /// </summary>
    public static string GetVersion()
    {
        string rslt = Assembly.GetAssembly(typeof(Program))?.GetName()?.Version?.ToString(3) ?? "Unknown";
#if DEBUG
        rslt += " (Debug)";
#endif
        return rslt;
    }

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
    {
        return AppBuilder.Configure<App>().UsePlatformDetect().LogToTrace().UseReactiveUI();
    }
}
