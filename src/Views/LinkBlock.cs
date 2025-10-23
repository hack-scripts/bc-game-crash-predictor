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
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

namespace CrashPredictor.Views;

/// <summary>
/// Custom TextBlock with hover link.
/// </summary>
public class LinkBlock : TextBlock
{
    private IBrush? _holdForeground;
    private TextDecorationCollection? _holdDecor;

    /// <summary>
    /// Constructor.
    /// </summary>
    public LinkBlock()
    {
        _holdForeground = Brushes.Blue;
        _holdDecor = TextDecorations;

        FontWeight = FontWeight.SemiBold;
        Foreground = _holdForeground;
        Cursor = new Cursor(StandardCursorType.Hand);

        PointerEntered += PointerEnteredHandler;
        PointerExited += PointerExitedHandler;
    }

    /// <summary>
    /// Custom property.
    /// </summary>
    public static readonly StyledProperty<IBrush?> HoverForegroundProperty =
        AvaloniaProperty.Register<LinkBlock, IBrush?>(nameof(HoverForeground), Brushes.Purple);

    /// <summary>
    /// Gets or sets the hover foreground brush.
    /// </summary>
    public IBrush? HoverForeground
    {
        get { return GetValue(HoverForegroundProperty); }
        set { SetValue(HoverForegroundProperty, value); }
    }

    private void PointerEnteredHandler(object? _, PointerEventArgs e)
    {
        _holdForeground = Foreground;
        _holdDecor = TextDecorations;

        Foreground = HoverForeground;
        TextDecorations = Avalonia.Media.TextDecorations.Underline;
    }

    private void PointerExitedHandler(object? _, PointerEventArgs e)
    {
        Foreground = _holdForeground;
        TextDecorations = _holdDecor;
    }

}