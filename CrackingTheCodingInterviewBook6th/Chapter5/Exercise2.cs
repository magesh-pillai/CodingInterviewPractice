using System;
using System.Text;

namespace Chapter5
{
    public static class Exercise2
    {
        //
        // Print the binary representation of a real number between 0 and 1
        // with at most 32 characters (excl. "0." in front). Print "ERROR" if
        // this is not possible.
        //
        // Remarks: I totally mis-understood this question and messed it up.
        //          Incorrect thought process by presuming that this require 
        //          actually interpreting the double binary format!.
        //          The clue is 0.0 < r < 1.0.
        //          Alternatives: try to multiple r by 2^32.
        //
        public static string DoubleTo32LengthBinaryString(double r)
        {
            if (r < Double.Epsilon || r  > (1.0 - Double.Epsilon)) throw new ArgumentOutOfRangeException(nameof(r));

            var result = new StringBuilder(32);
            while (r > Double.Epsilon)
            {
                if (result.Length > 32) return "ERROR";

                r = r * 2;
                if (r > 1.0)
                {
                    result.Append("1");
                    r = r - 1.0;
                }
                else
                {
                    result.Append("0");
                }
            }

            return "0." + result.ToString();
        }
    }
}