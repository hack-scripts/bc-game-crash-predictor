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

namespace CrashPredictor.Markup.Test;

public class SchemaGeneratorTest(ITestOutputHelper helper) : TestUtilBase(helper)
{
    [Fact]
    public void GetSchema()
    {
        var schema = SchemaGenerator.GetSchema(false, false);
        var schemaF = SchemaGenerator.GetSchema(true, false);
        var schemaA = SchemaGenerator.GetSchema(false, true);
        var schemaFA = SchemaGenerator.GetSchema(true, true);

        Assert.NotEqual(schema, schemaF);
        Assert.NotEqual(schema, schemaA);
        Assert.NotEqual(schema, schemaFA);
        Assert.NotEqual(schemaA, schemaF);
    }

    [Fact]
    public void SaveDocument()
    {
        SchemaGenerator.SaveDocument("Avalonia.xsd", false);
        SchemaGenerator.SaveDocument("Avalonia.Formatted.xsd", true);
    }

    [Fact]
    public void ScratchText()
    {
        var temp = new Control();
        WriteLine(temp.Width);
        WriteLine(temp.MinWidth);
        WriteLine(temp.MaxWidth);
    }

}