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

using Avalonia.Media;
using Avalonia.Threading;
using ReactiveUI;

namespace CrashPredictor.ViewModels;

/// <summary>
/// View model class common to all windows. It also serves as a base class.
/// </summary>
public class AvantViewModel : ReactiveObject
{
    private readonly DispatcherTimer _timer;
    private bool _isDark;
    private double _appFontSize;
    private double _monoFontSize;
    private FontFamily _monoFontFamily;

    public AvantViewModel()
    {
        _isDark = Global.Colors.IsDarkTheme;
        _appFontSize =  Global.AppFontSize;
        _monoFontSize =  Global.MonoFontSize;
        _monoFontFamily =  Global.MonoFontFamily;

        _timer = new(TimeSpan.FromSeconds(1), DispatcherPriority.Normal, RefreshTimerHandler);
        _timer.Start();
    }

    /// <summary>
    /// Gets global binding properties.
    /// </summary>
    public GlobalModel Global { get; } = GlobalModel.Global;

    /// <summary>
    /// Override to receive theme change.
    /// </summary>
    protected virtual void OnThemeChanged()
    {
    }

    /// <summary>
    /// Override to receive font size change.
    /// </summary>
    protected virtual void OnFontChanged()
    {
    }

    private void RefreshTimerHandler(object? sender, EventArgs e)
    {
        if (Global.Colors.IsDarkTheme != _isDark)
        {
            _isDark = Global.Colors.IsDarkTheme;
            OnThemeChanged();
        }

        if (Global.AppFontSize != _appFontSize || Global.MonoFontSize != _monoFontSize || Global.MonoFontFamily != _monoFontFamily)
        {
            _appFontSize = Global.AppFontSize;
            _monoFontSize = Global.MonoFontSize;
            _monoFontFamily = Global.MonoFontFamily;
            OnFontChanged();
        }
    }

}
