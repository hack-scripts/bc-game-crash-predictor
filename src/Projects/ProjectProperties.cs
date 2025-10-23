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
/// Class which holds <see cref="DotnetProject"/> properties. This class is intended to be JSON friendly.
/// </summary>
public sealed class ProjectProperties
{
    private string? _appProjectName;
    private string? _assemblyOverride;
    private string? _avaloniaOverride;

    /// <summary>
    /// Default constructor.
    /// </summary>
    public ProjectProperties()
    {
        ProjectName = string.Empty;
    }

    public ProjectProperties(string name)
    {
        ProjectName = name;
    }

    /// <summary>
    /// Gets or sets the name of the project owning these properties.
    /// </summary>
    public string ProjectName { get; set; }

    /// <summary>
    /// Gets or sets the application host project name, excluding the extension. Applicable only where
    /// where <see cref="DotnetProject.IsApp"/> is false. Setting an empty string sets null.
    /// </summary>
    public string? AppProjectName
    {
        get { return _appProjectName; }
        set { _appProjectName = !string.IsNullOrWhiteSpace(value) ? value.Trim() : null; }
    }

    /// <summary>
    /// Gets or sets the Avalonia version, i.e. "11.0.5", to use for this project. IMPORTANT: This
    /// should normally be null, as it will be detected automagically by the <see
    /// cref="DotnetProject"/> class. However, there are some scenarios where an explicit version
    /// should be used and this allows override.
    /// </summary>
    public string? AvaloniaOverride
    {
        get { return _avaloniaOverride; }
        set { _avaloniaOverride = !string.IsNullOrWhiteSpace(value) ? value.Trim() : null; }
    }

    /// <summary>
    /// Gets or sets the build target assembly. This can be used to override the default assembly path.
    /// The default value is null. The value may be a fully qualified path or an unrooted path local to the owner
    /// project directory. Assigning an empty string sets the property to null.
    /// </summary>
    public string? AssemblyOverride
    {
        get { return _assemblyOverride; }
        set { _assemblyOverride = !string.IsNullOrWhiteSpace(value) ? PathItem.CleanPath(value) : null; }
    }

    /// <summary>
    /// Assigns from other.
    /// </summary>
    public void AssignFrom(ProjectProperties other)
    {
        ProjectName = other.ProjectName;
        _appProjectName = other._appProjectName;
        _avaloniaOverride = other._avaloniaOverride;
        _assemblyOverride = other._assemblyOverride;
    }

    /// <summary>
    /// Overrides.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(_appProjectName, _avaloniaOverride, _assemblyOverride);
    }

}