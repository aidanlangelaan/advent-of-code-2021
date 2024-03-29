using System.ComponentModel;
using AdventOfCode.Core;

namespace AdventOfCode.Challenges;

[Description("Day 05")]
public class Day05 : Challenge<Day05>
{
    public Day05(string[] input) : base(input)
    {
    }

    public Day05() : base()
    {
    }

    public override Solution<TValueType> SolvePart1<TValueType>()
    {
        var positions = GetPositions(false);
        return new Solution<TValueType>((TValueType)Convert.ChangeType(positions.Count(x => x.Value > 1), typeof(TValueType)));
    }

    public override Solution<TValueType> SolvePart2<TValueType>()
    {
        var positions = GetPositions(true);
        return new Solution<TValueType>((TValueType)Convert.ChangeType(positions.Count(x => x.Value > 1), typeof(TValueType)));
    }

    private Dictionary<(int, int), int> GetPositions(bool allowDiagonal)
    {
        var positions = new Dictionary<(int, int), int>();
        foreach (var range in _input)
        {
            var startAndEnd = range.Split(" -> ");

            var start = startAndEnd[0].Split(',').Select(int.Parse).ToArray();
            var end = startAndEnd[1].Split(',').Select(int.Parse).ToArray();

            if (!allowDiagonal && (start[0] != end[0] && start[1] != end[1]))
            {
                continue;
            }

            positions = CalculatePositionsForRange(positions, start, end);
        }

        return positions;
    }

    private static Dictionary<(int, int), int> CalculatePositionsForRange(Dictionary<(int, int), int> positions, int[] start, int[] end)
    {
        var xPositions = start[0] <= end[0]
            ? Enumerable.Range(start[0], end[0] - start[0] + 1).ToArray()
            : Enumerable.Range(end[0], start[0] - end[0] + 1).Reverse().ToArray();

        var yPositions = start[1] <= end[1]
            ? Enumerable.Range(start[1], end[1] - start[1] + 1).ToArray()
            : Enumerable.Range(end[1], start[1] - end[1] + 1).Reverse().ToArray();

        if ((xPositions.Length > 1 && yPositions.Length == 1) || (xPositions.Length == 1 && yPositions.Length > 1))
        {
            foreach (var t in xPositions)
            {
                foreach (var t1 in yPositions)
                {
                    var x = t;
                    var y = t1;

                    if (positions.ContainsKey((x, y)))
                    {
                        positions[(x, y)] += 1;
                    }
                    else
                    {
                        positions.Add((x, y), 1);
                    }
                }
            }
        }
        else
        {
            for (var i = 0; i < xPositions.Length; i++)
            {
                var x = xPositions[i];
                var y = yPositions[i];

                if (positions.ContainsKey((x, y)))
                {
                    positions[(x, y)] += 1;
                }
                else
                {
                    positions.Add((x, y), 1);
                }
            }
        }

        return positions;
    }
}
