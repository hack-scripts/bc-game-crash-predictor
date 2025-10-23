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

using ReactiveUI;

namespace CrashPredictor.ViewModels
{
    public class XamlTextControlViewModel : AvantViewModel
    {
        private const double DefButtonWidth = 80;

        private bool _isCodeChecked = true;
        private bool _isOutputChecked;
        private string? _codeText;
        private string? _outputText;

        public bool IsCodeChecked
        {
            get { return _isCodeChecked; }

            set
            {
                if (_isCodeChecked != value)
                {
                    _isCodeChecked = value;
                    IsOutputChecked = !value;
                    this.RaisePropertyChanged(nameof(IsCodeChecked));
                }
            }
        }

        public bool IsOutputChecked
        {
            get { return _isOutputChecked; }

            set
            {
                if (_isOutputChecked != value)
                {
                    _isOutputChecked = value;
                    IsCodeChecked = !value;
                    this.RaisePropertyChanged(nameof(IsOutputChecked));
                }
            }
        }

        public double MinButtonWidth
        {
            get { return DefButtonWidth *  Global.Scale; }
        }

        public string? CodeText
        {
            get { return _codeText; }
            set { this.RaiseAndSetIfChanged(ref _codeText, value, nameof(CodeText)); }
        }

        public string? OutputText
        {
            get { return _outputText; }
            set { this.RaiseAndSetIfChanged(ref _outputText, value, nameof(OutputText)); }
        }

        /// <summary>
        /// Override.
        /// </summary>
        protected override void OnThemeChanged()
        {
            base.OnThemeChanged();
        }

        /// <summary>
        /// Override.
        /// </summary>
        protected override void OnFontChanged()
        {
            base.OnFontChanged();
            this.RaisePropertyChanged(nameof(MinButtonWidth));
        }

    }
}
