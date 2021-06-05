using System;
using System.Collections;

namespace BinaryAddition
{
   class Program
   {
      static void Main(string[] args)
      {
         while (true)
         {
            AddFromUserInput();
         }
      }

      private static void AddFromUserInput()
      {
         Console.WriteLine("Enter first number");
         var a = Console.ReadLine();
         Console.WriteLine("Enter second number");
         var b = Console.ReadLine();


         if (int.TryParse(a, out var aInt) && int.TryParse(b, out var bInt))
         {
            var result = Add(aInt, bInt);
            Console.WriteLine("Result: " + result);
            Console.WriteLine();
         }
      }

      private static int Add(int firstNumber, int secondNumber)
      {
         var aBytes = new BitArray(new int[] { firstNumber });
         var bBytes = new BitArray(new int[] { secondNumber });

         bool c = false;
         var result = new BitArray(aBytes.Length);

         for (int i = 0; i < aBytes.Length; i++)
         {
            bool a = aBytes[i];
            bool b = bBytes[i];
            (bool right, bool left) = HalfAdder(a, b);

            //add the carry
            (bool carryRight, bool carryLeft) = HalfAdder(right, c);

            //set the result
            result[i] = carryRight;
            c = left || carryLeft;
         }


         int[] array = new int[1];
         result.CopyTo(array, 0);
         return array[0];
      }

      private static (bool right, bool left) HalfAdder(bool a, bool b)
      {
         bool right = a != b;
         bool left = a && b;
         return (right, left);
      }
   }
}
