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

using Avalonia.Controls;
using CrashPredictor.Test.Internal;
using Xunit;
using Xunit.Abstractions;

namespace CrashPredictor.Utility.Test;

public class TypeExtensionTest(ITestOutputHelper helper) : TestUtilBase(helper)
{
    [Fact]
    public void GetFriendlyType_TupleInt()
    {
        var temp = typeof(Tuple<int, string>);
        var name = temp.GetFriendlyName();

        WriteLine(name);
        Assert.Equal("Tuple<int, string>", name);
    }

    [Fact]
    public void GetFriendlyType_GenericEvent()
    {
        var temp = typeof(TextBlock).GetEvent("PointerMoved");
        var name = temp?.EventHandlerType.GetFriendlyName();

        WriteLine(name);
        Assert.Equal("EventHandler<PointerEventArgs>", name);
    }
}