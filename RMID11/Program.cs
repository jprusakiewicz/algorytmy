using System;

namespace RMID11
{
    internal class Program
    {
        public static void Main()
        {
            int i, l1 = 0, l2 = 0, r1 = 0, r2 = 0, n;
            int[] low = new int[100001];
            int[] high = new int[100001];
            while (Int32.TryParse(Console.ReadLine(), out n) != null)
            {
                if (n == 0)
                {
                    l1 = l2 = r1 = r2 = 0;
                    Console.WriteLine("\n");
                }
                else if (n == -1)
                {
                    Console.WriteLine("\n" + low[r1 - 1]);
                    if (r1 - l1 > r2 - l2)
                        r1--;

                    else
                    {
                        low[r1 - 1] = high[l2];
                        l2++;
                    }
                }
                else
                {
                    if (r1 - l1 > r2 - l2)
                    {
                        high[r2] = n;
                        r2++;
                    }

                    else
                    {
                        if (r1 == 0)
                        {
                            low[r1] = n;
                            r1++;
                        }
                        else
                        {
                            low[r1] = high[l2];
                            r1++;
                            l2++;
                            high[r2] = n;
                            r2++;
                        }
                    }
                }
            }
        }
    }
}