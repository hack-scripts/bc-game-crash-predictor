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

namespace CrashPredictor.Utility;

/// <summary>
/// Provides extension methods.
/// </summary>
public static class ControlExtension
{
    /// <summary>
    /// Gets the owner Window of the control.
    /// </summary>
    /// <exception cref="ArgumentException">Control has no owner window</exception>
    public static Window GetOwnerWindow(this StyledElement control)
    {
        if (control is Window window)
        {
            return window;
        }

        if (control.Parent != null)
        {
            return GetOwnerWindow(control.Parent);
        }

        throw new ArgumentException("Element has no owner window");
    }
}