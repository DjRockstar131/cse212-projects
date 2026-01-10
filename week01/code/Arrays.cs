public static class Arrays
{
    /// <summary>
    /// This function will produce an array of size 'length' starting with 'number' followed by multiples of 'number'.  For 
    /// example, MultiplesOf(7, 5) will result in: {7, 14, 21, 28, 35}.  Assume that length is a positive
    /// integer greater than 0.
    /// </summary>
    /// <returns>array of doubles that are the multiples of the supplied number</returns>
    public static double[] MultiplesOf(double number, int length)
    {
        // Plan:
        // 1) Create a new double array with the given length.
        // 2) Loop from i = 0 up to i < length.
        // 3) For each position i, compute the multiple: number * (i + 1).
        //    - i = 0 should store number * 1 (the starting number)
        //    - i = 1 should store number * 2, etc.
        // 4) Return the filled array.

        double[] result = new double[length];

        for (int i = 0; i < length; i++)
        {
            result[i] = number * (i + 1);
        }

        return result;
    }

    /// <summary>
    /// Rotate the 'data' to the right by the 'amount'.  For example, if the data is 
    /// List<int>{1, 2, 3, 4, 5, 6, 7, 8, 9} and an amount is 3 then the list after the function runs should be 
    /// List<int>{7, 8, 9, 1, 2, 3, 4, 5, 6}.  The value of amount will be in the range of 1 to data.Count, inclusive.
    ///
    /// Because a list is dynamic, this function will modify the existing data list rather than returning a new list.
    /// </summary>
    public static void RotateListRight(List<int> data, int amount)
    {
        // Plan (slicing approach):
        // 1) Figure out where to split the list so the last 'amount' items move to the front.
        //    - splitIndex = data.Count - amount
        // 2) Copy the last 'amount' items into a new list (rightPart).
        // 3) Copy the first items (everything before splitIndex) into another list (leftPart).
        // 4) Clear the original list.
        // 5) Add rightPart first, then leftPart, back into the original list.

        int n = data.Count;
        int splitIndex = n - amount;

        List<int> rightPart = data.GetRange(splitIndex, amount);
        List<int> leftPart = data.GetRange(0, splitIndex);

        data.Clear();
        data.AddRange(rightPart);
        data.AddRange(leftPart);
    }
}
