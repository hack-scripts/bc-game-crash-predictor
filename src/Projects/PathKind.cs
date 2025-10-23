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
/// Project path kind. File kinds are based on extension.
/// </summary>
public enum PathKind
{
    /// <summary>
    /// The path is a directory.
    /// </summary>
    Directory = 0,

    /// <summary>
    /// Use only for construction of file kinds. It causes the file to be identified as one of the kind below.
    /// </summary>
    AnyFile,

    /// <summary>
    /// Dotnet solution or project file.
    /// </summary>
    Solution,

    /// <summary>
    /// The ".cs" extension and related.
    /// </summary>
    CSharp,

    /// <summary>
    /// XML or related file, excluding XAML and AXAML.
    /// </summary>
    Xml,
    /// <param name="name"></param>
    /// <returns></returns>

    /// <summary>
    /// XAML or AXAML file.
    /// </summary>
    Xaml,

    /// <summary>
    /// Any support image file, jpg or png etc.
    /// </summary>
    Image,

    /// <summary>
    /// Any other recognized extension that is a text document.
    /// </summary>
    Document,

    /// <summary>
    /// A DLL or EXE.
    /// </summary>
    Assembly,

    /// <summary>
    /// Unknown or other file kind.
    /// </summary>
    OtherFile,
}

/// <summary>
/// Extension methods.
/// </summary>
public static class PathKindExtension
{
    /// <summary>
    /// Returns true if the kind is a readable text file.
    /// </summary>
    public static bool IsText(this PathKind kind)
    {
        return kind == PathKind.Solution || kind == PathKind.CSharp ||
            kind == PathKind.Xml || kind == PathKind.Xaml ||
            kind == PathKind.Document;
    }
}