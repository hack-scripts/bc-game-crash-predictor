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

using System.Diagnostics;
using System.Text.Json;

namespace CrashPredictor.Settings
{
    /// <summary>
    /// Base class for JSON settings with common load and save methods.
    /// </summary>
    public abstract class JsonSettings
    {
        static JsonSettings()
        {
            try
            {
                // Create config directory
                var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "CrashPredictor");
#if DEBUG
                // Don't spoil installed settings
                path = Path.Combine(path, "debug");
#endif
                Directory.CreateDirectory(path);
                ConfigDirectory = path;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        /// <summary>
        /// Get settings directory. Null if directory creation failed.
        /// </summary>
        public static readonly string? ConfigDirectory;

        /// <summary>
        /// Read the file and assigns properties to this instance.
        /// Requires implementation in subtype. Returns true on success (does not throw).
        /// </summary>
        public abstract bool Read();

        /// <summary>
        /// Writes the file. Returns true on success (does not throw).
        /// </summary>
        public bool Write()
        {
            if (ConfigDirectory != null)
            {
                try
                {
                    var type = GetType();
                    var path = Path.Combine(ConfigDirectory, type.Name + ".json");
                    using var fs = File.Create(path);

                    var opts = new JsonSerializerOptions
                        { WriteIndented = true, PropertyNameCaseInsensitive = true };

                    JsonSerializer.Serialize(fs, this, type, opts);
                    return true;
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e);
                }
            }

            return false;
        }

        /// <summary>
        /// Deletes app configuration directory. Does not throw. Possible use for uninstall?
        /// </summary>
        public static void Remove()
        {
            if (ConfigDirectory != null)
            {
                try
                {
                    Directory.Delete(ConfigDirectory);
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                }
            }
        }

        /// <summary>
        /// Internal implementation. Returns an instance of T or null on failure.
        /// </summary>
        protected T? Read<T>()
            where T : JsonSettings, new()
        {
            if (ConfigDirectory != null)
            {
                try
                {
                    var path = Path.Combine(ConfigDirectory, GetType().Name + ".json");

                    using var fs = File.OpenRead(path);

                    var opts = new JsonSerializerOptions
                        { WriteIndented = true, PropertyNameCaseInsensitive = true };

                    return JsonSerializer.Deserialize<T>(fs, opts);
                }
                catch(Exception e)
                {
                    Debug.WriteLine(e);
                }
            }

            return null;
        }

    }

}