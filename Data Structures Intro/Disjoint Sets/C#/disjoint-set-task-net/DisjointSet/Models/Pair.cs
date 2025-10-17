namespace DisjointSet.Models;

/// <summary>
/// Represents a pair of two integers (used as an edge between two vertices).
/// </summary>
public readonly struct Pair
{
    /// <summary>
    /// Gets the first value.
    /// </summary>
    public int First { get; }

    /// <summary>
    /// Gets the second value.
    /// </summary>
    public int Second { get; }

    /// <summary>
    /// Alias for First (for tests that use I).
    /// </summary>
    public int I => First;

    /// <summary>
    /// Alias for Second (for tests that use J).
    /// </summary>
    public int J => Second;

    /// <summary>
    /// Initializes a new instance of the <see cref="Pair"/> struct.
    /// </summary>
    public Pair(int first, int second)
    {
        First = first;
        Second = second;
    }

    /// <inheritdoc/>
    public override string ToString() => $"({First}, {Second})";
}