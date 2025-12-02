using System.Numerics;
   
   string input = File.ReadAllText("Day2/input.txt");
   string[] ranges = input.Split(',');
   
   BigInteger sum = 0;        // Part One.
   BigInteger totalSum = 0;   // Part Two.
   
   foreach (string range in ranges)
   {
       string[] parts = range.Split('-');
   
       BigInteger start = BigInteger.Parse(parts[0].Trim());
       BigInteger end   = BigInteger.Parse(parts[1].Trim());
   
       // --------------------------------------------
       // PART ONE.
       // --------------------------------------------
       {
           int minLen = 1;
           int maxLen = end.ToString().Length / 2 + 1;
   
           for (int len = minLen; len <= maxLen; len++)
           {
               BigInteger seqStart = (len == 1) ? 1 : BigInteger.Pow(10, len - 1);
               BigInteger seqEnd   = BigInteger.Pow(10, len) - 1;
   
               for (BigInteger seq = seqStart; seq <= seqEnd; seq++)
               {
                   string s = seq.ToString();
                   string invalidIdStr = s + s; 
                   BigInteger invalidId = BigInteger.Parse(invalidIdStr);
   
                   if (invalidId >= start && invalidId <= end)
                       sum += invalidId;
                   else if (invalidId > end)
                       break;
               }
           }
       }
   
       // --------------------------------------------
       // PART TWO.
       // --------------------------------------------
       {
           var seen = new HashSet<string>();
   
           int minL = parts[0].Trim().Length;
           int maxL = parts[1].Trim().Length;
           string endStr = parts[1].Trim();
   
           for (int L = minL; L <= maxL; L++)
           {
               for (int r = 2; r <= L; r++)
               {
                   if (L % r != 0) continue;
   
                   int lenS = L / r;
   
                   BigInteger sStart = (lenS == 1) ? 1 : BigInteger.Pow(10, lenS - 1);
                   BigInteger sEnd   = BigInteger.Pow(10, lenS) - 1;
   
                   for (BigInteger s = sStart; s <= sEnd; s++)
                   {
                       string sStr = s.ToString();
                       string invalidIdStr = string.Concat(Enumerable.Repeat(sStr, r));
   
                       if (invalidIdStr.Length > endStr.Length) break;
                       if (invalidIdStr.Length == endStr.Length &&
                           string.Compare(invalidIdStr, endStr, StringComparison.Ordinal) > 0)
                           break;
   
                       BigInteger invalidId = BigInteger.Parse(invalidIdStr);
   
                       if (invalidId > end) break;
                       if (invalidId >= start)
                       {
                           if (seen.Add(invalidIdStr))
                               totalSum += invalidId;
                       }
                   }
               }
           }
       }
   }
   
   Console.WriteLine(sum);         // Part One.
   Console.WriteLine(totalSum);    // Part Two.