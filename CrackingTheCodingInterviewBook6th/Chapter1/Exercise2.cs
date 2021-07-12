using System.Collections.Generic;

namespace Chapter1
{
    public static class Exercise2
    {
        // Hashtable count of characters: O(n) expected time, O(n) space
        // Others: Sort strings & compare O(nlgn) time, O(n) space
        //         Balanced bst with count and then decrement, O(nlgn) time, O(n) space
        // Notes: May check if character set limited and use array counts
        public static bool CheckPermutation(string input1, string input2)
        {
            if (input1 == null && input2 == null) return true;

            if (input1 == null || input2 == null)  return false;

            if (input1.Length != input2.Length) return false;

            var characterCounts = new Dictionary<char, int>(); 
            for(var i=0; i<input1.Length; i++)
            {
                var c = input1[i];
                if (characterCounts.ContainsKey(c))
                {
                    characterCounts[c]++;
                }
                else
                {
                    characterCounts.Add(c,1);
                }
            }
            
            for(var i=0; i<input2.Length; i++)
            {
                var c = input2[i];
                if (characterCounts.ContainsKey(c))
                {
                    characterCounts[c]--;
                }
            }
            
            foreach(var p in characterCounts)
            {
                if (p.Value != 0) return false;
            }

            return true;
        }
    }
}