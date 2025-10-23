// -----------------------------------------------------------------------------
// PROJECT   : Crash Predictor
// COPYRIGHT : (C) 2025 hack-scripts
// LICENSE   : MIT
// HOMEPAGE  : https://github.com/hack-scripts/bc-game-crash-predictor
//

// the terms of the MIT General Public License as published by the Free Software
// Foundation, either version 3 of the License, or (at your option) any later version.
//
// Crash Predictor is distributed in the hope that it will be useful, but WITHOUT
// ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS
// FOR A PARTICULAR PURPOSE. See the MIT General Public License for more details.
//
// You should have received a copy of the MIT General Public License along
// with Crash Predictor. If not, see <https://www.MIT.org/licenses/>.
// -----------------------------------------------------------------------------

using Avalonia;
using Avalonia.Interactivity;
using CrashPredictor.Projects;

namespace CrashPredictor.Views;

/// <summary>
/// Shows solution properties.
/// </summary>
public partial class SolutionWindow : AvantWindow
{
    /// <summary>
    /// Default constructor.
    /// </summary>
    public SolutionWindow()
    {
        InitializeComponent();

#if DEBUG
        this.AttachDevTools();
#endif
    }

    /// <summary>
    /// Gets or sets the properties. The instance is modified on OK.
    /// </summary>
    public SolutionProperties? Properties { get; set; }

    protected override void OnOpened(EventArgs e)
    {
        base.OnOpened(e);
;
        if (Properties != null)
        {
            UpdateView(Properties);
        }
    }

    private void UpdateView(SolutionProperties properties)
    {
        DepthUpDown.Value = properties.SearchDepth;
        ShowEmptyCheck.IsChecked = properties.ShowEmptyDirectories;
        DebugRadio.IsChecked = properties.Build == BuildKind.Debug;
        ReleaseRadio.IsChecked = properties.Build == BuildKind.Release;
        FilePatternBox.Text = properties.FilePatterns;
        ExcludeDirectoriesBox.Text = properties.ExcludeDirectories;
    }

    private void ResetClickHandler(object? sender, RoutedEventArgs e)
    {
        UpdateView(new SolutionProperties());
    }

    private void OkClickHandler(object? sender, RoutedEventArgs e)
    {
        if (Properties != null)
        {
            // Accept warning - check needed for Avalonia 11
            if (DepthUpDown.Value != null)
            {
                Properties.SearchDepth = (int)DepthUpDown.Value;
            }

            Properties.ShowEmptyDirectories = ShowEmptyCheck.IsChecked == true;
            Properties.Build = DebugRadio.IsChecked == true ? BuildKind.Debug : BuildKind.Release;
            Properties.FilePatterns = FilePatternBox.Text ?? "";
            Properties.ExcludeDirectories = ExcludeDirectoriesBox.Text ?? "";
        }

        Close(true);
    }

    private void CancelClickHandler(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }

}