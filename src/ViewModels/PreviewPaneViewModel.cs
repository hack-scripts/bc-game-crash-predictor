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

namespace CrashPredictor.ViewModels
{
    public class PreviewPaneViewModel : PreviewOptionsViewModel
    {
        private string? _caretText;
        private bool _isPreviewSuspended;
        private bool _isCheckered;

        public PreviewPane? Owner { get; set; }

        public string? StatusText
        {
            get
            {
                if (IsPreviewSuspended)
                {
                    return "Preview Suspended";
                }

                return IsDisableEventsChecked ? "Events Disabled" : null;
            }
        }

        public string? CaretText
        {
            get { return _caretText; }
            set { this.RaiseAndSetIfChanged(ref _caretText, value, nameof(CaretText)); }
        }

        public bool IsPreviewSuspended
        {
            get { return _isPreviewSuspended; }

            set
            {
                if (_isPreviewSuspended != value)
                {
                    _isPreviewSuspended = value;
                    this.RaisePropertyChanged(nameof(IsPreviewSuspended));
                    OnFlagChanged(false);
                }
            }
        }

        public bool IsCheckered
        {
            get { return _isCheckered; }

            set
            {
                if (_isCheckered != value)
                {
                    _isCheckered = value;
                    this.RaisePropertyChanged(nameof(IsCheckered));
                    this.RaisePropertyChanged(nameof(Background));
                }
            }
        }

        public IBrush Background
        {
            get { return _isCheckered ? GlobalModel.Global.Colors.PreviewTile : GlobalModel.Global.Colors.PreviewBackground; }
        }

        public void CopyCommand()
        {
            Owner?.CopyToClipboard();
        }

        public void RestartCommand()
        {
            Owner?.OnRestart();
        }

        public void ToggleCommand()
        {
            if (Owner != null)
            {
                Owner.IsXamlViewOpen = !Owner.IsXamlViewOpen;
            }
        }

        protected override void OnThemeChanged()
        {
            this.RaisePropertyChanged(nameof(Background));
        }

        protected override void OnFlagChanged(bool invoke)
        {
            this.RaisePropertyChanged(nameof(StatusText));
            base.OnFlagChanged(invoke);
        }

    }
}
