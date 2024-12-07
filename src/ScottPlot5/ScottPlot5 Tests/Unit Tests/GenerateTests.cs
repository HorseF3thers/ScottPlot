using NUnit.Framework;

namespace ScottPlotTests.RenderTests.Figure;

public class GenerateTests
{
    [Test]
    public void Test_Generate_Consecutive()
    {
        double[] values = ScottPlot.Generate.Consecutive(10);
        values.Should().NotBeNullOrEmpty();
        values.Should().HaveCount(10);
    }

    [Test]
    public void Test_RandomNormal()
    {
        double[] values = Generate.RandomNormal(10);
        Console.WriteLine(string.Join(Environment.NewLine, values.Select(x => x.ToString())));
    }

    [Test]
    public void Test_Range()
    {
        double[] values = Generate.Range(7, 9, 0.5);
        double[] expected = [7, 7.5, 8, 8.5, 9];
        values.Should().BeEquivalentTo(expected);
    }

    [Test]
    public void Test_RangeRound()
    {
        double[] values = Generate.Range(0, 1, 0.05);
        values.Length.Should().Be(21);
        values[0].Should().Be(0);
        values[1].Should().Be(.05);
        values[2].Should().Be(.10);
        values[^2].Should().Be(.95);
        values[^1].Should().Be(1);
    }

    [Test]
    public void Test_Consecutive2D()
    {
        int rows = 3;
        int columns = 3;
        double spacing = 1;
        double offset = 0;

        double[,] result = Generate.Consecutive2D(rows, columns, spacing, offset);

        double[,] expected = new double[,]
        {
            { 0, 1, 2 },
            { 3, 4, 5 },
            { 6, 7, 8 }
        };

        result.Should().BeEquivalentTo(expected);
    }


    [Test]
    public void Test_Ramp2D()
    {
        int width = 3;
        int height = 3;

        double[,] result = Generate.Ramp2D(width, height);

        double[,] expected = new double[,]
        {
            { 0, 1.0 / 6, 2.0 / 6 },
            { 1.0 / 6, 2.0 / 6, 3.0 / 6 },
            { 2.0 / 6, 3.0 / 6, 4.0 / 6 }
        };

        result.Should().BeEquivalentTo(expected);
    }
}
