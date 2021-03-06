/// <summary>
/// Finds the number of permurations in a given text.
/// </summary>
/// <param name="text">Input text to find the permurations from.</param>
/// <param name="pattern">The pattern to search.</param>
/// <returns>Number of permutations in a given text.</returns>
public int PermutationOfPatternInString(string text, string pattern)
{
    int matchCount = 0;
    Dictionary<char, int> charCount = new Dictionary<char, int>();
    int patLen = pattern.Length;
    foreach (char c in pattern)
    {
        if (charCount.ContainsKey(c))
        {
            charCount[c]++;
        }
        else
        {
            charCount.Add(c, 1);
        }
    }

    var subStringCharCount = new Dictionary<char, int>();

    // loop through each character in the given text (string)....
    for (int i = 0; i <= text.Length - patLen; i++)
    {
        // check if current char and current + length of pattern-th char are in the pattern.
        if (charCount.ContainsKey(text[i]) && charCount.ContainsKey(text[i + patLen - 1]))
        {
            string subString = text.Substring(i, patLen);
            int j = 0;
            for (; j < patLen; j++)
            {
                // there is no point going on if this subString doesnt contain chars that are in pattern...
                if (charCount.ContainsKey(subString[j]))
                {
                    if (subStringCharCount.ContainsKey(subString[j]))
                    {
                        subStringCharCount[subString[j]]++;
                    }
                    else
                    {
                        subStringCharCount.Add(subString[j], 1);
                    }
                }
                else
                {
                    // if any of the chars dont appear in the subString that we are looking for
                    // break this loop and continue...
                    break;
                }
            }

            int x = 0;

            // this will be true only when we have current subString's permutation count
            // matched with pattern's.
            // we need this because the char count could be different 
            if (subStringCharCount.Count == charCount.Count)
            {
                for (; x < patLen; x++)
                {
                    if (subStringCharCount[subString[x]] != charCount[subString[x]])
                    {
                        // if any count dont match then we break from this loop and continue...
                        break;
                    }
                }
            }

            if (x == patLen)
            {
                // this means we have found a permutation of pattern in the text...
                // increment the counter.
                matchCount++;
            }

            subStringCharCount.Clear(); // clear the count map.
        }
    }

    return matchCount;
}


// Test cases..

[TestCase("encyclopedia", "dep", 1)]
[TestCase("cbabadcbbabbcbabaabccbabc", "abbc", 7)]
[TestCase("xyabxxbcbaxeabbxebbca", "abbc", 2)]
public void PermutationOfStringInText(string text, string pattern, int expectedAnswer)
{
    int answer = runner.PermutationOfPatternInString(text, pattern);
    Assert.AreEqual(expectedAnswer, answer);
}
