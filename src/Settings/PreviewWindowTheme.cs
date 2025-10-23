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

namespace CrashPredictor.Settings
{
    /// <summary>
    /// Preview window title color. Do not change order as values stored in JSON.
    /// </summary>
    public enum PreviewWindowTheme
    {
        DarkGray = 0,
        AvantPurple,
        StockBlue,
        PlainWhite,

        /// <summary>
        /// Hides emulated window top bar.
        /// </summary>
        None = 255,
    }

    /// <summary>
    /// Extension class.
    /// </summary>
    public static class PreviewWindowThemeExtension
    {
        private readonly static ISolidColorBrush Purple = new SolidColorBrush(Color.Parse("#593358"));
        private readonly static ISolidColorBrush Blue = new SolidColorBrush(Color.Parse("#0B548D"));
        private readonly static ISolidColorBrush Gray = new SolidColorBrush(Color.Parse("#252526"));

        /// <summary>
        /// Returns true if theme is white on a dark color.
        /// </summary>
        public static bool IsDark(this PreviewWindowTheme theme)
        {
            switch (theme)
            {
                case PreviewWindowTheme.PlainWhite: return false;
                default: return true;
            }
        }

        public static ISolidColorBrush GetBorder(this PreviewWindowTheme theme)
        {
            switch (theme)
            {
                case PreviewWindowTheme.PlainWhite: return Brushes.Black;
                default: return GetBackground(theme);
            }
        }

        public static ISolidColorBrush GetForeground(this PreviewWindowTheme theme)
        {
            return theme.IsDark() ? Brushes.White : Brushes.Black;
        }

        public static ISolidColorBrush GetBackground(this PreviewWindowTheme theme)
        {
            switch (theme)
            {
                case PreviewWindowTheme.AvantPurple: return Purple;
                case PreviewWindowTheme.StockBlue: return Blue;
                case PreviewWindowTheme.PlainWhite: return Brushes.White;
                default: return Gray;
            }
        }

    }
}