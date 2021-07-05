using System;

namespace Chapter1
{
    // O(n^2) time, O(1) space
    // Others: Merge-Sort + scan, O(nlgn) time, O(n) space
    //         Hashtable/Bit vector, O(n) expected time, O(c) space
    // Notes:  Unicode issues, Can we assume character space is fixed ?

    public static class Exercise1
    {
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