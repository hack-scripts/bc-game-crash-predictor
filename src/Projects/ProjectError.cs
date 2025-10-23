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

namespace CrashPredictor.Projects;

/// <summary>
/// A simple immutable class holding an error string and further details.
/// </summary>
public class ProjectError
{
    /// <summary>
    /// Constructor.
    /// </summary>
    public ProjectError(DotnetProject project, string message, string? details = null)
    {
        ProjectName = project.ProjectName;
        Message = message;
        Details = details;
    }

    public ProjectError(string message, string? details = null)
    {
        ProjectName = "";
        Message = message;
        Details = details;
    }

    /// <summary>
    /// Gets the project name.
    /// </summary>
    public string ProjectName { get; }

    /// <summary>
    /// Gets the message.
    /// </summary>
    public string Message { get; }

    /// <summary>
    /// Gets the details string.
    /// </summary>
    public string? Details { get; }

    /// <summary>
    /// Returns <see cref="Message"/>.
    /// </summary>
    public override string ToString()
    {
        return ProjectName + " - " + Message;
    }
}
