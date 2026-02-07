using System.Collections;

public static class Recursion
{
    /// <summary>
    /// #############
    /// # Problem 1 #
    /// #############
    /// Using recursion, find the sum of 1^2 + 2^2 + 3^2 + ... + n^2
    /// and return it.  Remember to both express the solution 
    /// in terms of recursive call on a smaller problem and 
    /// to identify a base case (terminating case).  If the value of
    /// n <= 0, just return 0.   A loop should not be used.
    /// </summary>
    public static int SumSquaresRecursive(int n)
    {
        // Base case
        if (n <= 0)
            return 0;

        // Recursive case: sumSquares(n) = n^2 + sumSquares(n-1)
        return (n * n) + SumSquaresRecursive(n - 1);
    }

    /// <summary>
    /// #############
    /// # Problem 2 #
    /// #############
    /// Using recursion, insert permutations of length
    /// 'size' from a list of 'letters' into the results list.  This function
    /// should assume that each letter is unique (i.e. the 
    /// function does not need to find unique permutations).
    ///
    /// In mathematics, we can calculate the number of permutations
    /// using the formula: len(letters)! / (len(letters) - size)!
    ///
    /// For example, if letters was [A,B,C] and size was 2 then
    /// the following would the contents of the results array after the function ran: AB, AC, BA, BC, CA, CB (might be in 
    /// a different order).
    ///
    /// You can assume that the size specified is always valid (between 1 
    /// and the length of the letters list).
    /// </summary>
    public static void PermutationsChoose(List<string> results, string letters, int size, string word = "")
    {
        // Base case: if we've built a word of the needed size, record it.
        if (word.Length == size)
        {
            results.Add(word);
            return;
        }

        // Recursive case: pick each remaining letter once, and recurse on the smaller set.
        for (int i = 0; i < letters.Length; i++)
        {
            char chosen = letters[i];
            string remaining = letters.Remove(i, 1);
            PermutationsChoose(results, remaining, size, word + chosen);
        }
    }

    /// <summary>
    /// #############
    /// # Problem 3 #
    /// #############
    /// ... (see prompt)
    /// </summary>
    public static decimal CountWaysToClimb(int s, Dictionary<int, decimal>? remember = null)
    {
        // Base Cases
        if (s == 0)
            return 0;
        if (s == 1)
            return 1;
        if (s == 2)
            return 2;
        if (s == 3)
            return 4;

        // Initialize memo dictionary on first call
        remember ??= new Dictionary<int, decimal>();

        // If we've already computed this, return it
        if (remember.TryGetValue(s, out decimal cached))
            return cached;

        // Solve using recursion (WITH memoization passed through)
        decimal ways =
            CountWaysToClimb(s - 1, remember) +
            CountWaysToClimb(s - 2, remember) +
            CountWaysToClimb(s - 3, remember);

        // Store result for future calls
        remember[s] = ways;

        return ways;
    }

    /// <summary>
    /// #############
    /// # Problem 4 #
    /// #############
    /// ... (see prompt)
    /// </summary>
    public static void WildcardBinary(string pattern, List<string> results)
    {
        int starIndex = pattern.IndexOf('*');

        // Base case: no wildcards left => this is a complete binary string
        if (starIndex == -1)
        {
            results.Add(pattern);
            return;
        }

        // Recursive case: replace the first '*' with '0' and '1'
        string prefix = pattern[..starIndex];
        string suffix = pattern[(starIndex + 1)..];

        WildcardBinary(prefix + "0" + suffix, results);
        WildcardBinary(prefix + "1" + suffix, results);
    }

    /// <summary>
    /// Use recursion to insert all paths that start at (0,0) and end at the
    /// 'end' square into the results list.
    /// </summary>
    public static void SolveMaze(List<string> results, Maze maze, int x = 0, int y = 0, List<ValueTuple<int, int>>? currPath = null)
{
    // Initialize path list on first call
    if (currPath == null)
        currPath = new List<ValueTuple<int, int>>();

    // Stop if this move is not valid (bounds, wall, or already visited)
    if (!maze.IsValidMove(currPath, x, y))
        return;

    // Choose: add this location to our current path
    currPath.Add((x, y));

    // If we reached the end, record the solution path
    if (maze.IsEnd(x, y))
    {
        results.Add(currPath.AsString());
        currPath.RemoveAt(currPath.Count - 1); // backtrack
        return;
    }

    // Explore: try each direction
    SolveMaze(results, maze, x + 1, y, currPath); // right
    SolveMaze(results, maze, x - 1, y, currPath); // left
    SolveMaze(results, maze, x, y + 1, currPath); // down
    SolveMaze(results, maze, x, y - 1, currPath); // up

    // Un-choose: remove this location before returning to caller
    currPath.RemoveAt(currPath.Count - 1);
}
}