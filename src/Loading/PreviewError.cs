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

namespace CrashPredictor.Loading;

/// <summary>
/// A simple immutable class holding an error string and position details.
/// </summary>
public class PreviewError
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public PreviewError(string message, int line = 0, int pos = 0)
    {
        Message = message;
        LineNum = line;
        LinePos = pos;
    }

    /// <summary>
    /// Gets the message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the line number. A value of 0 or less is NA.
    /// </summary>
    public int LineNum { get; }

    /// <summary>
    /// Gets the line position. A value of 0 or less is NA.
    /// </summary>
    public int LinePos { get; }

    /// <summary>
    /// Returns <see cref="Message"/>.
    /// </summary>
    public override string ToString()
    {
        return Message;
    }
}