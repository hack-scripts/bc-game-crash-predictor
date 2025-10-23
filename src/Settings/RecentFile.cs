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

namespace CrashPredictor.Settings
{
    public class RecentFile : IComparable, IComparable<RecentFile>
    {
        public RecentFile()
        {
            Path = string.Empty;
        }

        public RecentFile(string path)
        {
            Path = path;
            Update();
        }

        public string Path { get; set; }

        public long Timestamp { get; set; }

        public void Update()
        {
            Timestamp = DateTime.UtcNow.Ticks;
        }

        public int CompareTo(RecentFile? other)
        {
            ArgumentNullException.ThrowIfNull(other);
            return other.Timestamp.CompareTo(Timestamp);
        }

        public int CompareTo(object? other)
        {
            return CompareTo(other as RecentFile);
        }

    }
}