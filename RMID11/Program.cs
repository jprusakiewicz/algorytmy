using System;

namespace RMID11
{
    internal class Program
    {
        public static void Main()
        {
            int i, l1 = 0, l2 = 0, r1 = 0, r2 = 0, n;
            int[] min = new int[100001];
            int[] max = new int[100001];
            while (Int32.TryParse(Console.ReadLine(), out n) != null)
            {
                if (n == 0)
                {
                    l1 = l2 = r1 = r2 = 0;
                    Console.WriteLine("\n");
                }
                else if (n == -1)
                {
                    Console.WriteLine("\n" + min[r1 - 1]);
                    if (r1 - l1 > r2 - l2)
                        r1--;

                    else
                    {
                        min[r1 - 1] = max[l2];
                        l2++;
                    }
                }
                else
                {
                    if (r1 - l1 > r2 - l2)
                    {
                        max[r2] = n;
                        r2++;
                    }

                    else
                    {
                        if (r1 == 0)
                        {
                            min[r1] = n;
                            r1++;
                        }
                        else
                        {
                            min[r1] = max[l2];
                            r1++;
                            l2++;
                            max[r2] = n;
                            r2++;
                        }
                    }
                }
            }
        }
    }
}