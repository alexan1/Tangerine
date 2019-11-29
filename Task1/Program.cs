using System;

namespace ConsoleApp2
{
    class Program
    {
		public class myInt
		{
			public int val;

			public myInt(int val)
			{
				this.val = val;
			}

			public override String ToString()
			{
				return val.ToString();
			}
		}

		public static void Main()
		{
			int[] a = { 5 };

			myInt[] b = new myInt[1];
			b[0] = new myInt(5);

			ChangeArray(a);

			ChangeValue(b[0]);

			Console.WriteLine(a[0]); //Line A
			Console.WriteLine(b[0]); //Line B
			Console.WriteLine(b[0].val); //Line C
			Console.ReadLine();

		}


		public static void ChangeArray(int[] arr)
		{
			arr[0]++;
		}

		public static void ChangeValue(myInt mint)
		{
			mint.val++;
		}
	}
}
