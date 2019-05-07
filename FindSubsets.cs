public HashSet<string> FindSubsets(string input)
{
    var subsets = new HashSet<string>();
    LoadSubsets(input, string.Empty, subsets);
    return subsets;
}

/// <summary>
/// Loads the subset.
/// </summary>
/// <param name="input"></param>
/// <param name="chosen"></param>
/// <param name="subsets"></param>
private void LoadSubsets(string input, string chosen, HashSet<string> subsets)
{
    subsets.Add(chosen);
    if (string.IsNullOrEmpty(input))
    {
        return;
    }

    for (int i = 0; i < input.Length; i++)
    {
        // chose...
        char c = input[i];
        chosen += c;
        input = input.Remove(i, 1);

        // explore..
        LoadSubsets(input, chosen, subsets);

        // un choose..undo what we did in chose section...
        input = input.Insert(i, c.ToString());
        chosen = chosen.Remove(chosen.Length - 1);
    }
}

/*Unit test*/

[Test]
public void FindSubsets()
{
    string inputString = "abc";
    HashSet<string> subsets = runner.FindSubsets(inputString);
    Assert.IsTrue(subsets.Contains("abc"));
    Assert.IsTrue(subsets.Contains("bac"));
    Assert.IsTrue(subsets.Contains("b"));
    Assert.IsTrue(subsets.Contains("bc"));
    Assert.IsTrue(subsets.Contains("ac"));
    Assert.IsTrue(subsets.Contains("ca"));
    Assert.IsTrue(subsets.Contains("ba"));
}
