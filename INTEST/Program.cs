using System;
     
         internal class Program
         {
             public static void Main()
             {
                 int divisible = 0;
                 var n_k = Console.ReadLine();
                 string[] words = n_k.Split(' ');
                 int n = int.Parse(words[0].ToString());
                 int k = int.Parse(words[1].ToString());
                 for (int a = 0; a < n; ++a)
                 {
                     if(int.Parse(Console.ReadLine()) % k == 0)
                         divisible++;
                 }
                 Console.Write(divisible);
             }
         }