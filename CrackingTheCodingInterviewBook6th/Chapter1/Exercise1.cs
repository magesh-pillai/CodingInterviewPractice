using System;

namespace Chapter1
{
    public static class Exercise1
    {
        // O(n^2) time complexity, O(1) space complexity
        public static bool IsUnique(string text)
        {
            if (text == null) throw new ArgumentNullException(nameof(text));

            for(var i=0; i<text.Length-1; i++)
            {
                var current = text[i];
                for(var j=i+1; j<text.Length; j++)
                {
                    if (current == text[j]) return false;
                }
            }

            return true;
        }
    }
}