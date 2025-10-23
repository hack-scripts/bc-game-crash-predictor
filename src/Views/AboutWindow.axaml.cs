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

using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using CrashPredictor.Utility;
using CrashPredictor.ViewModels;

namespace CrashPredictor.Views;

/// <summary>
/// About CrashPredictor.
/// </summary>
public partial class AboutWindow : AvantWindow
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public AboutWindow()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void WebPressedHandler(object? sender, PointerPressedEventArgs e)
    {
        ShellOpen.Start(GlobalModel.WebUrl);
    }

    private void OkClickHandler(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}