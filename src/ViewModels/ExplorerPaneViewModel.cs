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
using CrashPredictor.Views;
using ReactiveUI;

namespace CrashPredictor.ViewModels;

public class ExplorerPaneViewModel : AvantViewModel
{
    private bool _isViewOpen = true;
    private bool _isLoaded;
    private string? _titleText;

    public ExplorerPane? Owner;

    public string? TitleText
    {
        get { return _titleText; }
        set { this.RaiseAndSetIfChanged(ref _titleText, value, nameof(TitleText)); }
    }

    public bool IsViewOpen
    {
        get { return _isViewOpen; }

        set
        {
            if (_isViewOpen != value)
            {
                _isViewOpen = value;
                this.RaisePropertyChanged(nameof(IsViewOpen));
                this.RaisePropertyChanged(nameof(ToggleViewIcon));
            }
        }
    }

    public bool IsLoaded
    {
        get { return _isLoaded; }

        set
        {
            if (_isLoaded != value)
            {
                _isLoaded = value;
                this.RaisePropertyChanged(nameof(IsLoaded));
                this.RaisePropertyChanged(nameof(SolutionIcon));
                this.RaisePropertyChanged(nameof(CollapseIcon));
            }
        }
    }

    public IImage? SolutionIcon
    {
        get
        {
            return IsLoaded ? Global.Assets.Gear1Icon : Global.Assets.Gear1GrayIcon;
        }
    }

    public IImage? CollapseIcon
    {
        get
        {
            return IsLoaded ? Global.Assets.CollapseIcon : Global.Assets.CollapseGrayIcon;
        }
    }

    public IImage? ToggleViewIcon
    {
        get
        {
            return IsViewOpen ? Global.Assets.LeftIcon : Global.Assets.RightIcon;
        }
    }

    /// <summary>
    /// Override.
    /// </summary>
    protected override void OnThemeChanged()
    {
        base.OnThemeChanged();
        this.RaisePropertyChanged(nameof(SolutionIcon));
        this.RaisePropertyChanged(nameof(CollapseIcon));
        this.RaisePropertyChanged(nameof(ToggleViewIcon));
    }

}
