using MarsRover.Topologie;

namespace MarsRover.Test;

public class RoverStateTest
{
    public static IEnumerable<object[]> Cas_RoverState_Parse()
    {
        Orientation[] orientations = [Orientation.Est, Orientation.Nord, Orientation.Ouest, Orientation.Sud];
        int[] interestingValuesOfXOrY = [-2, -1, 0, 1, 2];

        foreach (var orientation in orientations)
        foreach (var x in interestingValuesOfXOrY)
        foreach (var y in interestingValuesOfXOrY)
        {
            yield return [x, y, orientation];
        }
    }

    [Theory]
    [MemberData(nameof(Cas_RoverState_Parse))]
    public void RoverState_Parse(int x, int y, Orientation orientation)
    {
        var original = new RoverState(x, y, orientation);
        var representation = original.ToString();
        var reconstituted = RoverState.Parse(representation);

        Assert.Equal(original, reconstituted);
    }
}