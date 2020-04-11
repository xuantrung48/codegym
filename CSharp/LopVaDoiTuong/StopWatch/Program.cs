using System;
namespace demo
{
	public class Exercise1
	{
		public static void Main()
		{
			StopWatch demo = new StopWatch();
			Console.WriteLine(demo.StartTime);
			int[] Numbers = CreateNumbersArray();
			sortNumber(ref Numbers);
			demo.Stop();
			Console.WriteLine(demo.EndTime);
			Console.WriteLine("Time: " + demo.GetElapsedTime());
		}
		public static void ShowArray(int[] arr)
		{
			Console.Write("Array: ");
			for (int i = 0; i < arr.Length; i++)
			{
				Console.Write(arr[i] + " ");
			}
		}
		public static int[] CreateNumbersArray()
		{
			int[] numbers = new int[100000];
			Random rnd = new Random();
			for (int i = 0; i < 100000; i++)
			{
				numbers[i] = rnd.Next(1, 100000);
			}
			return numbers;
		}

		public static void sortNumber(ref int[] numbersArray)
		{
			int min;
			for (int i = 0; i < numbersArray.Length - 1; i++)
			{
				min = i;
				for (int j = i + 1; j < numbersArray.Length; j++)
				{
					if (numbersArray[j] < numbersArray[min])
					{
						min = j;
					}
				}
				int temp = numbersArray[i];
				numbersArray[i] = numbersArray[min];
				numbersArray[min] = numbersArray[temp];
			}
		}
	}

	public class StopWatch
	{
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public StopWatch()
		{
			this.StartTime = DateTime.Now;
		}
		public void Start()
		{
			this.StartTime = DateTime.Now;
		}
		public void Stop()
		{
			this.EndTime = DateTime.Now;
		}
		public int GetElapsedTime()
		{
			return Convert.ToInt32((this.EndTime - this.StartTime).TotalMilliseconds);
		}
	}
}
